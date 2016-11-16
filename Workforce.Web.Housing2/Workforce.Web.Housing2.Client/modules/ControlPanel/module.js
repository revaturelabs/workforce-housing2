/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

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
                //$scope.broadCast = function () {
                //    $rootScope.$broadcast('complexObtained', {});
                //}
            })
        }

        $scope.go = function (complex) {
            complexToAptService.set(complex);

        }


        $scope.model = {
            Name: null,
            Address: null,
            IsHotel: null,
            PhoneNumber: null
        };

        $scope.newComplex = function () {
            complexPostService.addComplex($scope.model, function (result) {
                $window.location.reload();
            });
        };

        $scope.grab = function (data) {
            complexToAptService.set(data);
        }

        $scope.removeComplex = function () {
            var x = complexToAptService.get();
            complexDeleteService.removeTheComplex(x, function (result) {
                $window.location.reload();
            });
        };

        

        
    }]);

    ga.controlPanel.controller('panelAptController', ['$scope', '$rootScope', 'aptGetService', 'complexToAptService', function ($scope, $rootScope, aptGetService, complexToAptService) {

        $scope.$on('complexObtained', function () {
            console.log('well then');
            $scope.aptGet();
        });
    
        $scope.aptGet = function () {
            //var y = complexToAptService.get();
            //$scope.getModel = {
            //    HotelID: -1
            //}
                aptGetService.get(function (response) {
                    //var x = $scope.numPerPage;
                    $scope.apts = response.data;
                    //$scope.filteredApartments = $scope.apts.slice(0, x);
                    $rootScope.$broadcast('apartmentObtained', {});
                })
            
        }
    }]);

    ga.controlPanel.controller('panelRoomController', ['$scope', function ($scope) {

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
                console.log($scope.associates.length);
                $scope.filteredAssociates = $scope.associates.slice(0, x);
            }, function (response) {
                console.log(response);
            })
        }

    }]);

    


})(window.ahApp);
