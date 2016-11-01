
(function (ga) {
    'use strict';

    ga.angular = angular.module('gtApt', ['ngRoute', 'gtComplex']);
    ga.angular.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            controller: 'complexController',
            templateUrl: 'modules/complexes/view.html'
        })
            
        .otherwise({ redirectTo: '/' })
    }]);

})(window.gtApp || (window.gtApp = {}));