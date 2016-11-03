(function (ga) {
    'use strict';

    ga.associate = angular.module('gtAssociate', []);

    ga.associate.controller('associateController', ['$scope', function ($scope) {
                      
        $scope.test = 'Hi There';

    }]);

})(window.gtApp);