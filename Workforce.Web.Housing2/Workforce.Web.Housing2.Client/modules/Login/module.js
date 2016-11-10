(function (ga) {
  'use strict';
  ga.login = angular.module('ahLogin', []);

  var sessionItem = sessionStorage.getItem('Login');
  if (sessionItem != "true") {
    location = '#/login';
  }

  ga.login.controller('loginController', ['$scope', 'loginService', function ($scope, loginService) {



    $scope.authenticate = function (u, p) {
      //loginService.get(u, p);
      if ((u === "admin") && (p === "password")) {
        sessionStorage.setItem("Login", "true");
      }
      location = '#/complexes';
    };
  }]);
})(window.ahApp);