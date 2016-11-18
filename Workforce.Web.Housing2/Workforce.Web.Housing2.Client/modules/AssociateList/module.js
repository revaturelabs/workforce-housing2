
(function (ga) {
    'use strict';

    ga.assocList = angular.module('ahAssocList', ['ui.bootstrap']);

    ga.assocList.controller('assocListController', ['$scope', '$route', 'listGetService', 'listDeleteService', function ($scope, $route, listGetService, listDeleteService) {
        $('#mainPage').removeClass('controlPanel');
        var sessionItem = sessionStorage.getItem('Login');
        if (sessionItem !== "true") {
            window.location.href = '#/login';
        }

        $scope.filteredAssociates = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 6;

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        }

        $scope.pageChanged = function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            $scope.filteredAssociates = $scope.listAssoc.slice(begin, end);
        };

        $scope.list = function () {
            $scope.getModel = {
                RoomID: -1,
                AssociateID: -1
            }
            listGetService.get($scope.getModel, function (response) {
                var x = $scope.numPerPage;
                $scope.listAssoc = response.data;
                $scope.filteredAssociates = $scope.listAssoc.slice(0, x);
            })
        }

        $scope.addAssoc = function () { location = '#/register'; };
        
        $scope.removal = function (data) {
            

            listDeleteService.removeAssociate(data , function (result) {
                $route.reload();
            }, function (result) {
            });
        }

      }]);
})(window.ahApp);



