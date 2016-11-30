(function (ga) {
  'use strict';

  ga.complex = angular.module('ahComplex', ['ui.bootstrap', 'ngMessages']);

  ga.complex.controller('complexController', ['$scope', '$location', '$window', '$timeout', '$route', 'complexGetService', 'complexPostService', 'complexDeleteService', 'complexToAptService',
  function ($scope, $location, $window, $timeout, $route, complexGetService, complexPostService, complexDeleteService, complexToAptService) {

    //removes the controlPanel css class
    $('#mainPage').removeClass('controlPanel');

    //login session storage
    var sessionItem = sessionStorage.getItem('Login');
    if (sessionItem !== "true") {
      window.location.href = '#/login';
    }

    //pagination settings 
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
    
    //Gets all complexes and filters them by a set number
    $scope.get = function () {
      complexGetService.get(function (response) {
        var x = $scope.numPerPage;
        $scope.complexes = response.data;
        $scope.filteredComplexes = $scope.complexes.slice(0, x);
      })
    }

    //clicking on any complex brings you to the apartment module
    $scope.go = function (complex, path) {
      complexToAptService.set(complex);
      $location.path(path);
    }

    //from the bootstrap modal, it takes in information to place into the service
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
      });
    };

    $scope.grab = function (data) {
      complexToAptService.set(data);
    }

    //removes a complex. if there are apartments with people in them that exist in an apartment, it raises an error
    $scope.removeComplex = function () {
      var x = complexToAptService.get();
      complexDeleteService.removeTheComplex(x, function (result) {
        $timeout(function () {
          // 1 second delay, might not need this long, but it works.
          $route.reload();
        }, 1000);
      }, function (result) {


        setTimeout(function () { $('#failRemoveComplex').fadeIn(2000); });
        setTimeout(function () { $('#failRemoveComplex').fadeOut(5000); }, 10000);
      });
    };
  }]);
})(window.ahApp);
