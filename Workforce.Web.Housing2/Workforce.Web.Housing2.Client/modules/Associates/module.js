(function (ga) {
    'use strict';
    /*
    Legacy code, this module used to be used to do the housing for associates, but after the control panel was created, the associates module(not to be mistaken for associateList) 
    is kinda unnecessary.  I'm leaving this here, in case someone would like to utilize this code for future use.  
    If you find it doesn't have any use, just delete it.  
    */
    ga.associate = angular.module('ahAssociate', ['ui.bootstrap']);

    ga.associate.controller('associateController', ['$scope', '$window', '$route', 'aptToRoomService', 'traineeGetService', 'traineeDataGrab', 'associatePostService', 'associateByAptService', 'associateDeleteService',
                                                function ($scope, $window, $route, aptToRoomService, traineeGetService, traineeDataGrab, associatePostService, associateByAptService, associateDeleteService) {
                                                  var sessionItem = sessionStorage.getItem('Login');
                                                  if (sessionItem !== "true") {
                                                    window.location.href = '#/login';
                                                  }
                                                  $('#mainPage').removeClass('controlPanel');
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

        $scope.info = aptToRoomService.get().RoomNumber; //information get succeeded

        $scope.current = aptToRoomService.get().CurrentCapacity;
        $scope.max = aptToRoomService.get().MaxCapacity;

        $scope.pageChanged = function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            $scope.filteredTrainees = $scope.trainees.slice(begin, end);
        };

        $scope.get = function () {
            $scope.getModel = {
                RoomID: -1,
                AssociateID: -1
            }
            traineeGetService.get($scope.getModel, function (response) {
                var x = $scope.numPerPage;
                $scope.trainees = response.data;
                $scope.filteredTrainees = $scope.trainees.slice(0, x);
            })
        }

        $scope.addAssoc = function () { location = '#/register'; };

        $scope.living = function () {
            //var u = traineeDataGrab.get();
            var v = aptToRoomService.get();
            $scope.assocModel = {
                RoomID: v.RoomID
                //AssociateID: u.AssociateID
            }

            associateByAptService.get($scope.assocModel, function (response) {
                $scope.livingAssoc = response.data;
            })
        }

        $scope.removeApartment = function () {
            var x = aptToRoomService.get();
            $scope.rModel = {
                RoomID: x.RoomID,
                RoomNumber: x.RoomNumber,
                CurrentCapacity: x.CurrentCapacity,
                MaxCapacity: x.MaxCapacity,
                Gender: x.Gender,
                Hotel: x.Hotel,
            };
            roomDeleteService.removeApt($scope.rModel, function (result) {
                $window.location.href = '#/apartments';
                $route.reload();
            });
        };

        $scope.grab = function (data) {
            $scope.traineeFirstName = data.FirstName;
            $scope.traineeLastName = data.LastName;
            $scope.traineeGender = data.Gender;
            $scope.traineeEmail = data.Email;

            traineeDataGrab.set(data);
        };

        $scope.moveIn = function () {
            var x = traineeDataGrab.get();
            var y = aptToRoomService.get();

            $scope.insertModel = {
                AssociateID: x.AssociateID,
                RoomID: y.RoomID
            };
            associatePostService.addAssoc($scope.insertModel, function (result) {
                aptToRoomService.set(y);
                $route.reload();
            });
        }

        $scope.release = function () {
            traineeDataGrab.set(data);
        }
        $scope.moveOut = function (data) {
            //var x = traineeDataGrab.get();
            var y = aptToRoomService.get();

            $scope.deleteModel = {
                AssociateID: data.AssociateID,
                RoomID: y.RoomID
            };
            associateDeleteService.removeAssoc($scope.deleteModel, function (result) {
                aptToRoomService.set(y);
                $route.reload();
            });
        }

    }]);

})(window.ahApp);
