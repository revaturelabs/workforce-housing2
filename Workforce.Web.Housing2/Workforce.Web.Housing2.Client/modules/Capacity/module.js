(function (ga) {
    'use strict';

    ga.aptCapacity = angular.module('ahCap', []);

    ga.aptCapacity.controller('capController', ['$scope', function ($scope) {
        var sessionItem = sessionStorage.getItem('Login');
        if (sessionItem !== "true") {
            window.location.href = '#/login';
        }
        else
        {
            init();
        }

        var data_url = 'http://ec2-54-175-5-94.compute-1.amazonaws.com/workforce-housing-rest/api/d3aptcapacity';
        
        // callback function wrapped for loader in 'init' function
        function init() {

          setTimeout(function () {
            d3.json(data_url, function (data) {
              chart(data);
            });
          }, 1500);
        };

        function chart(data) {

            var ar = [];
            for (var i = 0; i < data.length; i++)
            {
                ar.push(data[i].maxCapacity);
                ar.push(data[i].currentCapacity);
            }

          var width = 960;
          var height = 500;

          var y = d3.scale.linear().range([height, 0]).domain([0, d3.max(data, function (d) { return d.maxCapacity; })]);

          var chart = d3.select("#chart").attr("width", width).attr("height", height);

          var barWidth = width / (ar.length);

          var bar = chart.selectAll("g").data(ar).enter().append("g")
         .attr("transform", function (d, i) { return "translate(" + i * barWidth + ",0)"; });

          bar.append("rect")
                .attr("y", function (d) { return y(d); })
                .attr("height", function (d) { return height - y(d); })
                .attr("width", barWidth - 1)
                .style('fill', "#dd2020");

        }

    }]);
})(window.ahApp);
