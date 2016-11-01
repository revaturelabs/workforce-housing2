(function (ga) {
    'use strict';

    ga.complex = angular.module('gtComplex', []);

    ga.complex.controller('complexController', ['$scope', function ($scope) {
   
        $scope.test = 'hi there';
    }])

})(window.gtApp);