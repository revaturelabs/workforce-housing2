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

        var data_url = '/workforce-housing-rest/api/d3aptcapacity';
        
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
            function ob() { this.val = null; this.name = null; };
            var ob1 = new ob();
            var ob2 = new ob();
            for (var i = 0; i < data.length; i++)
            {
                ob1.val = data[i].maxCapacity;
                ob1.name = data[i].name;
                ar.push(ob1);
                ob2.val = data[i].currentCapacity;
                ob2.name = data[i].name;
                ar.push(ob2);
            }


          var width = 960;
          var height = 500;

          var y = d3.scale.linear().range([height, 0]).domain([0, d3.max(ar, function (d) { return d.val; })]);

          var chart = d3.select("#chart").attr("width", width).attr("height", height);

          var barWidth = width / (ar.length);

          var bar = chart.selectAll("g").data(ar).enter().append("g")
         .attr("transform", function (d, i) { return "translate(" + i * barWidth + ",0)"; });

          bar.append("rect")
          .attr("y", function (d) { return y(d.val); })
          .attr("height", function (d) { return height - y(d.val); })
          .attr("width", barWidth - 1)
          .style('fill', function (d, i) { return i%2? '#808080':'#ba122b'; });

          bar.append("text")
          .attr("text-anchor", "middle")
          .attr('x', barWidth/2)
          .attr("y", function (d) { return y(d.val) + 20; })
          .attr("dy", ".75em")
          .style('font-size', '20px')
          .style('fill', '#FFFFFF')
          .text(function (d) { return d.name });

          bar.append("text")
          .attr("text-anchor", "middle")
          .attr('x', barWidth / 2)
          .attr("y", function (d) { return y(d.val) + 45; })
          .attr("dy", ".75em")
          .style('font-size', '20px')
          .style('fill', '#FFFFFF')
          .text(function (d, i) { return i % 2 ? 'Current Capacity: ' + d.val : 'Max Capacity: ' + d.val; });
        }

    }]);
})(window.ahApp);
