(function (ga) {
  'use strict';
  ga.login = angular.module('ahLogin', []);

  ga.login.controller('loginController', ['$scope', 'loginService', function ($scope, loginService) {
    $scope.authenticate = function (u, p) {
      loginService.get(u, p);
    };
  }]);
})(window.ahApp);