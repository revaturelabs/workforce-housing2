/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
  'use strict';

  ga.complex = angular.module('ahComplex', []);

  ga.complex.controller('complexController', ['$scope', 'complexGetService',
  function ($scope, complexGetService) {
    $scope.currentPage = 1;
    $scope.numPerPage = 10;

    $scope.get = function () {
      complexGetService.get(function (response) {
        var x = $scope.numPerPage;
        $scope.complexes = response.data;
        $scope.filteredComplexes = $scope.complexes.slice(0, x);
      })
    }

  }]);
})(window.ahApp);