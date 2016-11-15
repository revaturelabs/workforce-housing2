(function (ga) {
  'use strict';

  ga.angular = angular.module('ahApp', ['ngRoute', 'ngMessages', 'ahComplex', 'ahApartment', 'ahAssociate', 'ahLogin', 'ahRegister', 'ahCap', 'ahPanel']);
  ga.angular.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
      controller: 'loginController',
      templateUrl: 'modules/Login/view.html'
    })
        .when('/apartments', {
            controller: 'apartmentController',
            templateUrl: 'modules/Apartments/view.html'
        })
        .when('/complexes', {
            controller: 'complexController',
            templateUrl: 'modules/Complexes/view.html'
        })
        .when('/rooming', {
            controller: 'associateController',
            templateUrl: 'modules/Associates/view.html'
        })
      .when('/login', {
        controller: 'loginController',
        templateUrl: 'modules/Login/view.html'
      })
      .when('/register', {
        controller: 'registerController',
        templateUrl: 'modules/Register/view.html'
      })
      .when('/thanksForRegister', {
        controller: 'registerController',
        templateUrl: 'modules/Register/thanks.html'
      })
      .when('/fail', {
        controller: 'registerController',
        templateUrl: 'modules/Login/fail.html'
      })
      .when('/capacity', {
             controller: 'capController',
             templateUrl: 'modules/Capacity/view.html'
      })
        .when('/controlpanel', {
            controller: 'panelController',
            templateUrl: 'modules/ControlPanel/view.html'
      })
    .otherwise({ redirectTo: '/' })
  }]);

})(window.ahApp || (window.ahApp = {}));