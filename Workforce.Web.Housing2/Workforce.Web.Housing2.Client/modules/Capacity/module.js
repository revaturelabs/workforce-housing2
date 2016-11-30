(function (ga) {
  'use strict';

  ga.aptCapacity = angular.module('ahCap', []);

  ga.aptCapacity.controller('capController', ['$scope', function ($scope) {
      $('#mainPage').removeClass('controlPanel');
    var sessionItem = sessionStorage.getItem('Login');
    if (sessionItem !== "true") {
      window.location.href = '#/login';
    }
    else {
      init();
    }
      /*
        Most of this information was found on a basic d3js graph.  
        Information about these graphs can be found on https://d3js.org/
        The idea behind this is to represent the data over time on the apartments max capacity and how many people are rooming through the months
        Ratios between male and female as well, and see if there are increases in the amount of people Revature can take in.  
      */
    // config references
    var chartConfig = {
      target: 'chart',
      data_url: '/workforce-housing-rest/api/d3aptcapacity',
      width: 900,
      height: 450,
      val: 90
    };

    var spin = document.getElementById('spin');



    // callback function wrapped for loader in 'init' function
    function init() {

      // slow the json load intentionally, so we can see it every load
      setTimeout(function () {

        // load json data and trigger callback
        d3.json(chartConfig.data_url, function (data) {
          spin.style.visibility = 'hidden';

          // instantiate chart within callback

          chart(data);

        });

      }, 1500);
    }






    function chart(data) {


      var margin = { top: 75, right: 20, bottom: 60, left: 70 },
          width = 960 - margin.left - margin.right,
          height = 500 - margin.top - margin.bottom;

      var x0 = d3.scale.ordinal()
          .rangeRoundBands([0, width], .1);

      var x1 = d3.scale.ordinal();

      var y = d3.scale.linear()
          .range([height, 0]);

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


      var svg = d3.select("#chart").append("svg")
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
                .attr("y", 50)
                .style("text-anchor", "middle")
                .style('font-size', '25px')
                .text("Apartment Complex Name");



      svg.append("g")
          .attr("class", "y axis")
          .call(yAxis)
        .append("text")
          .attr("transform", "rotate(-90)")
          .attr("x", -(height / 2))
          .attr("dy", ".71em")
          .style("text-anchor", "center")
          .style('font-size', '25px')
          .text("Capacity")
          .attr("y", -65);

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
          .style('fill', function (d, i) { return i % 2 ? '#808080' : '#ba122b'; })
          .style("font-size", "50px")
          .on('mouseover', tip.show)
          .on('mouseout', tip.hide);

      var legend = svg.selectAll(".legend")
          .data(colNames.slice().reverse())
        .enter().append("g")
          .attr("class", "legend")
          .attr("transform", function (d, i) { return "translate(0," + ((i * 20) - 60) + ")"; });

      legend.append("rect")
          .attr("x", width - 18)
          .attr("width", 18)
          .attr("height", 18)
          .style('fill', function (d, i) { return i % 2 ? '#808080' : '#ba122b'; });

      legend.append("text")
          .attr("x", width - 24)
          .attr("y", 9)
          .attr("dy", ".35em")
          .style("text-anchor", "end")
          .style('font-size', '20px')
          .text(function (d, i) { return i % 2 ? 'Current Capacity' : 'Max Capacity'; });

      svg.selectAll('.tick').style('font-size', function () {
        var pix = x1.rangeBand();
        if (pix > 100) {
          return '22px';
        }
        else if (pix > 75) {
          return '18px';
        }
        else {
          return '14px';
        }
      });

    }

  }]);
})(window.ahApp);
