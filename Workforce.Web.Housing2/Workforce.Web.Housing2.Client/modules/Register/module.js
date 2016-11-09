(function (ga) {
  ga.register = angular.module('ahRegister', []);

  ga.register.controller('registerController', ['$scope', 'registerService', function ($scope, registerService) {
    $scope.register = function () {
      registerService.get();
    };
  }]);
})(window.ahApp);