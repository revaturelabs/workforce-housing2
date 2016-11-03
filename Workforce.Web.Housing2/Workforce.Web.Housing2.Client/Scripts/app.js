(function (ga) {
  'use strict';

  ga.angular = angular.module('ahApp', ['ngRoute', 'ahComplex']);
  ga.angular.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
      controller: 'complexController',
      templateUrl: 'modules/Complexes/view.html'
    })
    .otherwise({
      controller: 'complexController',
      templateUrl: 'modules/Complexes/view.html'
    })
  }]);

})(window.ahApp || (window.ahApp = {}));