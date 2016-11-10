(function (ga) {
  ga.register = angular.module('ahRegister', []);

  ga.register.controller('registerController', ['$scope', 'registerService', function ($scope, registerService) {
    $scope.register = function (fname, lname, uEmail, male, female, notSpec) {
      var u = { Email: uEmail, FirstName: fName, LastName: lname };
      if (male === true)
      {
        u.Gender = male;
      }
      else
      {
        u.Gender = female;
      }
      registerService.post(u, function () { location = '#/thanksForRegister'; }, function () { location = '#/fail'; });
    };
  }]);
})(window.ahApp);