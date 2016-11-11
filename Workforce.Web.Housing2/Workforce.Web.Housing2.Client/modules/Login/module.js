(function (ga) {
  'use strict';
  ga.login = angular.module('ahLogin', []);

  var sessionItem = sessionStorage.getItem('Login');
  if (sessionItem !== "true") {
    location = '#/login';
  }

  ga.login.controller('loginController', ['$scope', 'loginService', function ($scope, loginService) {



    $scope.authenticate = function (u, p) {
      //loginService.get(u, p);
      if ((u === "admin") && (p === "password")) {
        sessionStorage.setItem("Login", "true");
        var lb = document.getElementById('lo');
        lb.style.visibility = 'visible';
        location = '#/complexes';
      }
      else
      {
        var fname = document.getElementById('fn');
        var lname = document.getElementById('pw');
        fname.value = '';
        lname.value = '';
        var el = document.getElementById('error');
        el.innerHTML = '<p style="color:red;font-size:150%">please enter valid username and password</p>';
      }
    };
  }]);
})(window.ahApp);