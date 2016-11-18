/// <reference path="C:\Revature\1607-jul25-net\1607-workforce-web\Workforce.Web.Grace\Workforce.Web.Grace.Client\Scripts/app.js" />

(function (ga) {
    'use strict';

    ga.controlPanel = angular.module('ahPanel', ['ui.bootstrap', 'ngMessages']);

    

    ga.controlPanel.controller('panelController', ['$scope', '$rootScope', '$location', '$window', 'complexGetService', 'complexToAptService',
    function ($scope, $rootScope, $location, $window, complexGetService, complexToAptService) {

        var sessionItem = sessionStorage.getItem('Login');
        if (sessionItem !== "true") {
            window.location.href = '#/login';
        }
        
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

        //$scope.$on('complexObtained', function () {
        //    $scope.aptGet();
        //});

        $scope.$on('complexPicked', function () {
            var x = complexToAptService.get();
            $('#complexName').html(x.Name);
            filterAptService.get(x, function (response) {
                var x = $scope.numPerPage;
                $scope.apts = response.data;
                $scope.filteredApartments = $scope.apts.slice(0, x);
                $rootScope.$broadcast('apartmentObtained', {});
            })
        });

        $scope.$on('assocMovedIn', function () {
            var x = complexToAptService.get();
            filterAptService.get(x, function (response) {
                var x = $scope.numPerPage;
                $scope.apts = response.data;
                $scope.filteredApartments = $scope.apts.slice(0, x);
            })
        });

        $scope.$on('assocRemoved', function () {
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

    ga.controlPanel.controller('panelAssocController', ['$scope', '$rootScope', '$route', 'associateGetService', 'aptToRoomService', 'associatePostService', function ($scope, $rootScope, $route, associateGetService, aptToRoomService, associatePostService) {


        $scope.$on('aptPicked', function () {
            $('#chooseAptFirst').html('');
            var x = $scope.filteredAssociates;
            if (x.length === 0) {
                $scope.assocGet();
            }
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

        

        $scope.moveIn = function (data)
        {
            var x = aptToRoomService.get();
            $scope.moveModel = {
                RoomID: x.RoomID,
                AssociateID: data.AssociateID
            }
            associatePostService.addAssoc($scope.moveModel, function (result) {
                aptToRoomService.set(x);
                $scope.getModel = {
                    RoomID: -1,
                    AssociateID: -1
                }
                associateGetService.get($scope.getModel, function (response) {
                    var g = $scope.numPerPage;
                    $scope.associates = response.data;
                    console.log($scope.assocCurrentPage);
                    $scope.filteredAssociates = $scope.associates.slice(0, g);
                    $rootScope.$broadcast('assocMovedIn', {});
                }, function (response) {
                })
            }, function (result) {

                console.log(result);
                setTimeout(function () { $('#failAddAssoc').fadeIn(200); });
                setTimeout(function () { $('#failAddAssoc').fadeOut(3000); }, 2000);
            });
        }

        $scope.$on('assocRemoved', function () {
            $scope.getModel = {
                RoomID: -1,
                AssociateID: -1
            }
            associateGetService.get($scope.getModel, function (response) {
                var g = $scope.numPerPage;
                $scope.associates = response.data;
                $scope.filteredAssociates = $scope.associates.slice(0, g);
            }, function (response) {
            })
        });

    }]);

    ga.controlPanel.controller('panelRoomController', ['$scope', '$rootScope', '$route', 'aptToRoomService', 'associateByAptService', 'associateDeleteService', function ($scope, $rootScope, $route, aptToRoomService, associateByAptService, associateDeleteService) {
        
        $scope.$on('complexPicked', function () {
            $('#roomNumber').html('Choose an Apartment');
            $('#assocRoom').empty();
            $scope.livingAssoc = [];

        });

        $scope.$on('aptPicked', function () {
            var x = aptToRoomService.get();
            $('#roomNumber').html('Apt #: ' + x.RoomNumber);
            associateByAptService.get(x, function (response) {
                var y = response.data.length;
                if (y === 0) {
                    $('#assocRoom').text("There's no one here, would you like to add someone?");
                }
                else {
                    $('#assocRoom').text('');
                }
                $scope.livingAssoc = response.data;
            })
            
        });

        $scope.moveOut = function (data) {
            var y = aptToRoomService.get();

            $scope.deleteModel = {
                AssociateID: data.AssociateID,
                RoomID: y.RoomID
            };
            associateDeleteService.removeAssoc($scope.deleteModel, function (result) {
                aptToRoomService.set(y);
                associateByAptService.get(y, function (response) {
                    $scope.livingAssoc = response.data;
                    $rootScope.$broadcast('assocRemoved', {});
                })
            });
        }

        $scope.$on('assocMovedIn', function () {
            var x = aptToRoomService.get();
            associateByAptService.get(x, function (response) {
                var y = response.data.length;
                if (y === 0) {
                    $('#assocRoom').text("There's no one here, would you like to add someone?");
                }
                else {
                    $('#assocRoom').text('');
                }
                $scope.livingAssoc = response.data;
            })
        });
    }]);


})(window.ahApp);
