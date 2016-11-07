/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
  'use strict';

  ga.apartment = angular.module('ahApartment', []);

  ga.apartment.controller('apartmentController', ['$scope', '$location', '$window', 'complexGetService', 'aptToRoomService',
    'aptGetService', 'aptPostService', 'roomDeleteService', function ($scope, $location, $window, complexGetService, aptToRoomService, aptGetService,
      aptPostService, roomDeleteService) {

    $scope.get = function () {
      aptGetService.get($scope.getModel, function (response) {
        var x = $scope.numPerPage;
        $scope.apts = response.data;
        $scope.filteredApartments = $scope.apts.slice(0, x);
      })
    }

    $scope.go = function (room, path) {
      aptToRoomService.set(room);
      $location.path(path);
    }

    $scope.newApartment = function () {
      aptPostService.addApt($scope.model, function (result) {
        $window.location.reload();
      });
    };

    $scope.removeApartment = function () {
      var x = aptToRoomService.get();
      roomDeleteService.removeApt(x, function (result) {
        $window.location.reload();
      });
    };


  }]);
})(window.ahApp);