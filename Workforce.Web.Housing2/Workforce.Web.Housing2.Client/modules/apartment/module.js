/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
  'use strict';

  ga.apartment = angular.module('ahApartment', []);

  ga.apartment.controller('apartmentController', ['$scope', 'complexGetService', function ($scope, complexGetService) {

    complexGetService.get(function (response) {
      $scope.complexes = response.data;
    });

  }]);
})(window.ahApp);