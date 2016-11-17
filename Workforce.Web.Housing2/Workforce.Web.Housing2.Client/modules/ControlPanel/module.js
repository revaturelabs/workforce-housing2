﻿/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
    'use strict';

    ga.controlPanel = angular.module('ahPanel', ['ui.bootstrap', 'ngMessages']);

    var sessionItem = sessionStorage.getItem('Login');
    if (sessionItem !== "true") {
        window.location.href = '#/login';
    }

    ga.controlPanel.controller('panelController', ['$scope', '$rootScope', '$location', '$window', 'complexGetService', 'complexToAptService',
    function ($scope, $rootScope, $location, $window, complexGetService, complexToAptService) {

        
        $scope.filteredComplexes = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 10;

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        }
        $scope.pageChanged = function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            $scope.filteredComplexes = $scope.complexes.slice(begin, end);
        };
        

        $scope.get = function () {
            complexGetService.get(function (response) {
                var x = $scope.numPerPage;
                $scope.complexes = response.data;
                $scope.filteredComplexes = $scope.complexes.slice(0, x);
                $rootScope.$broadcast('complexObtained', {});
                
            })
        }

        $scope.chosen = function (complex) {
            complexToAptService.set(complex);
            $rootScope.$broadcast('complexPicked', {});
        }

    }]);

    ga.controlPanel.controller('panelAptController', ['$scope', '$rootScope', 'aptGetService', 'filterAptService', 'complexToAptService', 'aptToRoomService', function ($scope, $rootScope, aptGetService, filterAptService, complexToAptService, aptToRoomService) {

        $scope.filteredApartments = [];
        $scope.aptCurrentPage = 1;
        $scope.numPerPage = 3;

        $scope.setPage = function (pageNo) {
            $scope.aptCurrentPage = pageNo;
        }
        $scope.aptPageChanged = function () {
            var begin = (($scope.aptCurrentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            $scope.filteredApartments = $scope.apts.slice(begin, end);
        };

        $scope.$on('complexObtained', function () {
            $scope.aptGet();
        });

        $scope.$on('complexPicked', function () {
            var x = complexToAptService.get();

            filterAptService.get(x, function (response) {
                var x = $scope.numPerPage;
                $scope.apts = response.data;
                $scope.filteredApartments = $scope.apts.slice(0, x);
            })
        });
    
        $scope.aptGet = function () {
            aptGetService.get(function (response) {
                var x = $scope.numPerPage;
                $scope.apts = response.data;
                $scope.filteredApartments = $scope.apts.slice(0, x);
                $rootScope.$broadcast('apartmentObtained', {});
            })
        }

        $scope.aptChoose = function (apt) {
            aptToRoomService.set(apt);
            $rootScope.$broadcast('aptPicked', {});
        }
    }]);

    ga.controlPanel.controller('panelAssocController', ['$scope', 'associateGetService', function ($scope, associateGetService) {

        $scope.$on('apartmentObtained', function () {
            $scope.assocGet();
        });

        $scope.filteredAssociates = [];
        $scope.assocCurrentPage = 1;
        $scope.numPerPage = 5;

        $scope.setPage = function (pageNo) {
            $scope.assocCurrentPage = pageNo;
        }

        $scope.assocPageChanged = function () {
            var begin = (($scope.assocCurrentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            $scope.filteredAssociates = $scope.associates.slice(begin, end);
        };

        $scope.assocGet = function () {
            $scope.getModel = {
                RoomID: -1,
                AssociateID: -1
            }
            associateGetService.get($scope.getModel, function (response) {
                var x = $scope.numPerPage;
                $scope.associates = response.data;
                $scope.filteredAssociates = $scope.associates.slice(0, x);
            }, function (response) {
            })
        }

    }]);

    ga.controlPanel.controller('panelRoomController', ['$scope', 'aptToRoomService', 'associateByAptService', function ($scope, aptToRoomService, associateByAptService) {
        
        $scope.aptRoom = '';

        $scope.$on('complexPicked', function () {
            $scope.aptRoom = 'Choose A Room';
        })
        

        $scope.$on('aptPicked', function () {
            var x = aptToRoomService.get();
            associateByAptService.get(x, function (response) {
                $scope.livingAssoc = response.data;
            })
            
        });

        $scope.living = function () {
            var v = aptToRoomService.get();

            associateByAptService.get(v, function (response) {
                $scope.livingAssoc = response.data;
            })
        }

    }]);


})(window.ahApp);
