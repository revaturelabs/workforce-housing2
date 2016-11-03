(function (ga) {
  'use strict';

  ga.angular = angular.module('ahApp', ['ngRoute', 'ahComplex', 'ahApartment']);
  ga.angular.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
      controller: 'complexController',
      templateUrl: 'modules/complexes/view.html'
    })
      .when('/apartment', {
        controller: 'apartmentController',
        templateUrl: 'modules/apartment/view.html'
      })
    .otherwise({
      controller: 'complexController',
      templateUrl: 'modules/complexes/view.html'
    })
  }]);

})(window.ahApp || (window.ahApp = {}));