(function (ga) {
  'use strict';
  ga.login = angular.module('ahLogin', []);

  var sessionItem = sessionStorage.getItem('Login');
  if (sessionItem !== "true") {
    location = '#/login';
  }

  ga.login.controller('loginController', ['$scope', 'loginService', function ($scope, loginService) {

      $('#mainPage').removeClass('controlPanel');

    $scope.authenticate = function () {
      var fname = document.getElementById('fn');
      var lname = document.getElementById('pw');
      var u = fname.value;
      var p = lname.value;
      if ((u === "admin") && (p === "password")) {
        sessionStorage.setItem("Login", "true");
        var lb = document.getElementById('lo');
        lb.style.visibility = 'visible';
        location = '#/controlpanel';
      }
      else {
        fname.value = '';
        lname.value = '';
        var el = document.getElementById('error');
        el.innerHTML = '<p style="color:red;font-size:150%">Invalid username / password</p>';
      }

    };
  }]);
})(window.ahApp);