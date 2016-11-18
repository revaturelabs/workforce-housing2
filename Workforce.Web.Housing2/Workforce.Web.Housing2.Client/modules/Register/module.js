(function (ga) {
  ga.register = angular.module('ahRegister', []);

  ga.register.controller('registerController', ['$scope', 'registerService', 'batchService', 'genderService', function ($scope, registerService, batchService, genderService) {

      $('#mainPage').removeClass('controlPanel');
      function check() {
      var sessionItem = sessionStorage.getItem('Login');
      if (sessionItem !== "true") {
        location = '#/login';
      }
    }

    $scope.register = function (fname, lname, uEmail, gender, batch) {
        //var u = { Email: uEmail, FirstName: fname, LastName: lname, BatchID: batch, Gender: gender };
        $scope.model = {
            Email: uEmail,
            FirstName: fname,
            LastName: lname,
            Gender: gender,
            Batch: batch
        };
      
      
      registerService.post($scope.model, function (response) {
          location = '#/associatelist';
      }, function (response) {
          location = '#/fail';
      });
    };

    $scope.goLogin = function () { location = '#/associatelist'; };
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
      //$scope.model = {
      //    FirstName: null,
      //    LastName: null,
      //    BatchID: null,
      //    Gender: null,
      //    Email: null
      //};

      //$scope.newAssoc = function () {
      //    listPostService.addNew($scope.model, function (result) {
      //        $window.location.reload();
      //    });
      //};

      
      batchService.get(function (response) {
              $scope.batches = response.data;
            })
        genderService.get(function (response) {
              $scope.genders = response.data;
            })
      
  }]);
})(window.ahApp);