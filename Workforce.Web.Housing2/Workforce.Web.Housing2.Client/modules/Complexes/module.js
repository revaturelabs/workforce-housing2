/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
  'use strict';

  ga.complex = angular.module('ahComplex', ['ui.bootstrap', 'ngMessages']);

  ga.complex.controller('complexController', ['$scope', '$location', '$window', 'complexGetService', 'complexPostService', 'complexDeleteService', 'complexToAptService',
  function ($scope, $location, $window, complexGetService, complexPostService, complexDeleteService, complexToAptService) {

      $('#mainPage').removeClass('controlPanel');
    var sessionItem = sessionStorage.getItem('Login');
    if (sessionItem !== "true") {
      window.location.href = '#/login';
    }
    $scope.filteredComplexes = [];
    $scope.currentPage = 1;
    $scope.numPerPage = 10;
    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    }
    $scope.pageChanged = function () {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
        , end = begin + $scope.numPerPage;

        $scope.filteredComplexes = $scope.complexes.slice(begin, end);
    };

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

    $scope.model = {
        Name: null,
        Address: null,
        IsHotel: null,
        PhoneNumber: null
    };

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
