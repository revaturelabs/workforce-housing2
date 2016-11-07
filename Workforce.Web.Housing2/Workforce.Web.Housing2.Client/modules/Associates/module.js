(function (ga) {
    'use strict';

    ga.associate = angular.module('ahAssociate', []);

    ga.associate.controller('associateController', ['$scope', function ($scope) {
                      
        $scope.filteredTrainees = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 5;
        $scope.traineeFirstName = 'Click an Associate';

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        }

        $scope.back = function () {
            $window.location.href = '#/apartments';
        }

        $scope.pageChanged = function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            $scope.filteredTrainees = $scope.trainees.slice(begin, end);
        };
    }]);

})(window.ahApp);
