/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
  'use strict';

  ga.complex = angular.module('ahComplex', []);

  ga.complex.controller('complexController', ['$scope', '$location', 'complexGetService', 'complexToAptService',
  function ($scope, $location, complexGetService, complexToAptService) {
    $scope.currentPage = 1;
    $scope.numPerPage = 10;

    $scope.get = function () {
      complexGetService.get(function (response) {
        var x = $scope.numPerPage;
        $scope.complexes = response.data;
        $scope.filteredComplexes = $scope.complexes.slice(0, x);
      })
    }

    $scope.go = function (complex, path) {
      complexToAptService.set(complex);
      $location.path(path);
    }

    $scope.newComplex = function () {
      complexPostService.addComplex($scope.model, function (result) {
        $window.location.reload();
      });
    };

    $scope.grab = function (data) {
      complexToAptService.set(data);
    }

    $scope.removeComplex = function () {
      var x = complexToAptService.get();
      complexDeleteService.removeTheComplex(x, function (result) {
        $window.location.reload();
      });
    };



  }]);
})(window.ahApp);