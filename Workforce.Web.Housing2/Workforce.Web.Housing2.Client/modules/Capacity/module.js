(function (ga) {
    'use strict';

    ga.aptCapacity = angular.module('ahCap', []);

    ga.aptCapacity.controller('capController', ['$scope', function ($scope) {

        // config references
        var chartConfig = {
            target: 'chart',
            data_url: 'http://ec2-54-175-5-94.compute-1.amazonaws.com/workforce-housing-rest/api/d3aptcapacity',
            width: 900,
            height: 450,
            val: 90
        };

        // loader settings
        var opts = {
            lines: 9, // The number of lines to draw
            length: 9, // The length of each line
            width: 5, // The line thickness
            radius: 14, // The radius of the inner circle
            color: '#f26925', // #rgb or #rrggbb or array of colors
            speed: 1.9, // Rounds per second
            trail: 40, // Afterglow percentage
            className: 'spinner', // The CSS class to assign to the spinner
        };


        var target = document.getElementById(chartConfig.target);



        // callback function wrapped for loader in 'init' function
        function init() {

            // trigger loader
            var spinner = new Spinner(opts).spin(target);

            // slow the json load intentionally, so we can see it every load
            setTimeout(function () {

                // load json data and trigger callback
                d3.json(chartConfig.data_url, function (data) {

                    // stop spin.js loader
                    spinner.stop();

                    // instantiate chart within callback
                    chart(data);

                });

            }, 1500);
        }

        init();




        function chart(data) {


            var margin = { top: 35, right: 20, bottom: 35, left: 40 },
                width = 960 - margin.left - margin.right,
                height = 500 - margin.top - margin.bottom;

            var x0 = d3.scale.ordinal()
                .rangeRoundBands([0, width], .1);

            var x1 = d3.scale.ordinal();

            var y = d3.scale.linear()
                .range([height, 0]);

            //two colors of the graphs		
            var color = d3.scale.ordinal()
                .range(["#21b200", "#dd2020"]);

            var xAxis = d3.svg.axis()
                .scale(x0)
                .orient("bottom");

            var yAxis = d3.svg.axis()
                .scale(y)
                .orient("left");
            //.tickFormat(d3.format(".2s"));

            var tip = d3.tip()
              .attr('class', 'd3-tip')
              .offset([-10, 0])
              .html(function (d) {
                  return "<strong>Value:</strong> <span style='color:red'>" + d.value + "</span>";
              })


            var svg = d3.select("body").append("svg")
                .attr("width", width + margin.left + margin.right)
                .attr("height", height + margin.top + margin.bottom)
              .append("g")
                .attr("transform", "translate(" + margin.left + "," + margin.top + ")");


            svg.call(tip);


            var colNames = d3.keys(data[0]).filter(function (key) { return key !== "name"; });

            data.forEach(function (d) {
                d.capacities = colNames.map(function (name) { return { name: name, value: +d[name] }; });
            });

            x0.domain(data.map(function (d) { return d.name; }));
            x1.domain(colNames).rangeRoundBands([0, x0.rangeBand()]);
            y.domain([0, d3.max(data, function (d) { return d3.max(d.capacities, function (d) { return d.value; }); })]);

            svg.append("g")
                .attr("class", "x axis")
                .attr("transform", "translate(0," + height + ")")
                .call(xAxis).append("text")
                      .attr("x", (width / 2))
                      .attr("y", 30)
                      .style("text-anchor", "start")
                      .text("Apartment Complex Name");

            svg.append("g")
                .attr("class", "y axis")
                .call(yAxis)
              .append("text")
                .attr("transform", "rotate(-90)")
                .attr("y", 2)
                .attr("dy", ".71em")
                .style("text-anchor", "end")
                .text("Capacity");

            var state = svg.selectAll(".state")
                .data(data)
              .enter().append("g")
                .attr("class", "state")
                .attr("transform", function (d) { return "translate(" + x0(d.name) + ",0)"; });

            state.selectAll("rect")
                .data(function (d) { return d.capacities; })
              .enter().append("rect")
                .attr("width", x1.rangeBand())
                .attr("x", function (d) { return x1(d.name); })
                .attr("y", function (d) { return y(d.value); })
                .attr("height", function (d) { return height - y(d.value); })
                .style("fill", function (d) { return color(d.name); })
                            .on('mouseover', tip.show)
                .on('mouseout', tip.hide);

            var legend = svg.selectAll(".legend")
                .data(colNames.slice().reverse())
              .enter().append("g")
                .attr("class", "legend")
                .attr("transform", function (d, i) { return "translate(0," + i * 20 + ")"; });

            legend.append("rect")
                .attr("x", width - 18)
                .attr("width", 18)
                .attr("height", 18)
                .style("fill", color);

            legend.append("text")
                .attr("x", width - 24)
                .attr("y", 9)
                .attr("dy", ".35em")
                .style("text-anchor", "end")
                .text(function (d) { return d; });

        }

    }]);
})(window.ahApp);
