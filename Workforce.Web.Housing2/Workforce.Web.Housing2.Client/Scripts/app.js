(function (ga) {
  'use strict';

  ga.angular = angular.module('ahApp', ['ngRoute', 'ahComplex', 'ahAssociate']);
  ga.angular.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
      controller: 'complexController',
      templateUrl: 'modules/Complexes/view.html'
    })
        .when('/rooming', {
            controller: 'associateController',
            templateUrl: 'modules/Associates/view.html'
        })
    .otherwise({ redirectTo: '/' })
  }]);

})(window.ahApp || (window.ahApp = {}));