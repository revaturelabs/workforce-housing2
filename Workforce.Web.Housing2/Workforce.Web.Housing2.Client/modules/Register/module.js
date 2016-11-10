(function (ga) {
  ga.register = angular.module('ahRegister', []);

  ga.register.controller('registerController', ['$scope', 'registerService', 'batchService', function ($scope, registerService, batchService) {
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
      $scope.back = function () {
            location = '#/associatelist';
      }

      /*
            first name
            last name
            batch id
            email
            Gender
        
        */
      $scope.model = {
          FirstName: null,
          LastName: null,
          BatchID: null,
          Gender: null,
          Email: null
      };

      $scope.newAssoc = function () {
          listPostService.addNew($scope.model, function (result) {
              $window.location.reload();
          });
      };

      $scope.get = function () {
          batchService.get(function (response) {
              $scope.batches = response.data;
            }
        )}
      
  }]);
})(window.ahApp);