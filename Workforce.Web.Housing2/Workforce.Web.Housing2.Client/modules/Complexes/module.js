/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
  'use strict';

  ga.complex = angular.module('ahComplex', ['ui.bootstrap', 'ngMessages']);

  ga.complex.controller('complexController', ['$scope', '$location', '$window', '$timeout', '$route', 'complexGetService', 'complexPostService', 'complexDeleteService', 'complexToAptService',
  function ($scope, $location, $window, $timeout, $route, complexGetService, complexPostService, complexDeleteService, complexToAptService) {

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
            $timeout(function () {
                // 1 second delay, might not need this long, but it works.
                $route.reload();
            }, 1000);
          //$route.reload();
      });
    };

    $scope.grab = function (data) {
      complexToAptService.set(data);
    }

    $scope.refresh = function () {
        $route.reload();
    }

    $scope.removeComplex = function () {
      var x = complexToAptService.get();
      complexDeleteService.removeTheComplex(x, function (result) {
          $timeout(function () {
            // 1 second delay, might not need this long, but it works.
              $route.reload();              
          }, 1000);
        //$route.reload();
      }, function (result) {
        alert("Failed to remove complex.  This is most likely due to it containing an associate / associates.");
      });
    };



  }]);
})(window.ahApp);
