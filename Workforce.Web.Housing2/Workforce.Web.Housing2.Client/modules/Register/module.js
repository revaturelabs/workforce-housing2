(function (ga) {
  ga.register = angular.module('ahRegister', []);

  ga.register.controller('registerController', ['$scope', 'registerService', function ($scope, registerService) {
    function check() {
      var sessionItem = sessionStorage.getItem('Login');
      if (sessionItem !== "true") {
        location = '#/login';
      }
    }

    $scope.register = function (fname, lname, uEmail, male, female, notSpec) {
      var u = { Email: uEmail, FirstName: fname, LastName: lname };
      if (male === true) {
        u.Gender = male;
      }
      else {
        u.Gender = female;
      }
      registerService.post(u, function () { location = '#/thanksForRegister'; }, function () { location = '#/fail'; });
    };

    $scope.goLogin = function () { location = '#/login'; };
  }]);
})(window.ahApp);