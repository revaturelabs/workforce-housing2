(function (ga) {
    'use strict';

    ga.associate = angular.module('ahAssociate', []);

    ga.associate.controller('associateController', ['$scope', function ($scope) {
                      
        $scope.test = 'Hi There';

    }]);

})(window.ahApp);