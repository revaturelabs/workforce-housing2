(function (ga) {
  'use strict';

  ga.apartment = angular.module('ahApartment', ['ui.bootstrap']);

    /*
        Refer to the complex module.  The apartment module is very similar to that of the complex module.  These modules are separated to allow for 
        a more "module" application.  That way, if you need to delete something, you just have to delete a module rather than parts of code here and there.
        This is more of a standard.  

        Good luck, I hope my code doens't kill you --Marc
    */

  ga.apartment.controller('apartmentController', ['$scope', '$location', '$window', '$timeout', '$route', 'complexGetService', 'complexToAptService', 'aptToRoomService',
    'filterAptService', 'aptPostService', 'roomDeleteService', function ($scope, $location, $window, $timeout, $route, complexGetService, complexToAptService, aptToRoomService, filterAptService,
      aptPostService, roomDeleteService) {

      $('#mainPage').removeClass('controlPanel');
      var sessionItem = sessionStorage.getItem('Login');
      if (sessionItem !== "true") {
        window.location.href = '#/login';
      }
    $scope.filteredApartments = [];
    $scope.currentPage = 1;
    $scope.numPerPage = 10;

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    }

    complexGetService.get(function (response) {
        $scope.complexes = response.data;

    });

    $scope.get = function () {
        var y = complexToAptService.get();
        filterAptService.get(y, function (response) {
        var x = $scope.numPerPage;
        $scope.apts = response.data;
        $scope.filteredApartments = $scope.apts.slice(0, x);
      })
    }

    $scope.pageChanged = function () {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
        , end = begin + $scope.numPerPage;

        $scope.filteredApartments = $scope.apts.slice(begin, end);
    };

    $scope.info = complexToAptService.get().Name;

    $scope.go = function (room) {
      aptToRoomService.set(room);
    }

    $scope.back = function () {
        $window.location.href = '#/complexes';
    }

    $scope.model = {
        HotelID: complexToAptService.get().HotelID,
        RoomNumber: null,
        MaxCapacity: null,
        GenderID: null
    };

    $scope.newApartment = function () {
        aptPostService.addApt($scope.model, function (result) {
            $timeout(function () {
                // 1 second delay, might not need this long, but it works.
                $route.reload();
            }, 500);
          //$route.reload();
      });
    };

    $scope.grab = function (data) {
        aptToRoomService.set(data);
        $scope.removedApt = aptToRoomService.get().RoomNumber

    }

    $scope.removeApartment = function () {
      var x = aptToRoomService.get();
      roomDeleteService.removeApt(x, function (result) {
          $timeout(function () {
              // 1 second delay, might not need this long, but it works.
              $route.reload();
          }, 1000);
         // $route.reload();
      });
    };


  }]);
})(window.ahApp);
