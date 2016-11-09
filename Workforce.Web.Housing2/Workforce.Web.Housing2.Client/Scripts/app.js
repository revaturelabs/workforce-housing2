(function (ga) {
  'use strict';

  ga.angular = angular.module('ahApp', ['ngRoute', 'ngMessages', 'ahComplex', 'ahApartment', 'ahAssociate', 'ahCap']);
  ga.angular.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
      controller: 'complexController',
      templateUrl: 'modules/Complexes/view.html'
    })
        .when('/apartments', {
            controller: 'apartmentController',
            templateUrl: 'modules/Apartments/view.html'
        })
        .when('/rooming', {
            controller: 'associateController',
            templateUrl: 'modules/Associates/view.html'
        })
        .when('/capacity', {
            controller: 'capController',
            templateUrl: 'modules/Capacity/view.html'
        })
    .otherwise({ redirectTo: '/' })
  }]);

})(window.ahApp || (window.ahApp = {}));