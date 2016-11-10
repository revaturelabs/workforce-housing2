/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
  'use strict';

  ga.apartment = angular.module('ahApartment', ['ui.bootstrap']);



  ga.apartment.controller('apartmentController', ['$scope', '$location', '$window', 'complexGetService', 'complexToAptService', 'aptToRoomService',
    'aptGetService', 'aptPostService', 'roomDeleteService', function ($scope, $location, $window, complexGetService, complexToAptService, aptToRoomService, aptGetService,
      aptPostService, roomDeleteService) {

      var sessionItem = sessionStorage.getItem('Login');
      if (sessionItem != "true") {
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

    var y = complexToAptService.get();
    $scope.getModel = {
        HotelID: y.HotelID
    }

    $scope.get = function () {
      aptGetService.get($scope.getModel, function (response) {
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

    $scope.go = function (room, path) {
      aptToRoomService.set(room);
      $location.path(path);
    }

    $scope.back = function () {
        $window.location.href = '#/';
    }

    $scope.model = {
        HotelID: complexToAptService.get().HotelID,
        RoomNumber: null,
        MaxCapacity: null,
        Gender: null
    };

    $scope.newApartment = function () {
      aptPostService.addApt($scope.model, function (result) {
        $window.location.reload();
      });
    };

    $scope.grab = function (data) {
        aptToRoomService.set(data);
        $scope.removedApt = aptToRoomService.get().RoomNumber
    }

    $scope.removeApartment = function () {
      var x = aptToRoomService.get();
      roomDeleteService.removeApt(x, function (result) {
        $window.location.reload();
      });
    };


  }]);
})(window.ahApp);
