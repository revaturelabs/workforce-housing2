(function (ga) {
    'use strict';

    ga.controlPanel = angular.module('ahPanel', ['ui.bootstrap', 'ngMessages']);

    /*The control panel was my rendition of mixing together the previous modules into a single page application.
      Probably might have some areas that need redoing, but out of the pages, I think it's gotten the best work.
      
      I wish the next person the best of luck as they decipher my craziness. Forgive me for the mess.  --Marc
    */

    ga.controlPanel.controller('panelController', ['$scope', '$rootScope', '$location', '$window', 'complexGetService', 'complexToAptService',
    function ($scope, $rootScope, $location, $window, complexGetService, complexToAptService) {

        //This session storage checks to see if we retained our login.  
        var sessionItem = sessionStorage.getItem('Login');
        if (sessionItem !== "true") {
            window.location.href = '#/login'; //if there is no session, then it goes back to the login page.  
        }
        
        /*Next area contains information on pagination.  Could be redone to load a new part of the api rather than loading everything at once. 
          NOTE: Refer to AngularUI for notes on this pagination configuration.  
        */
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
        

        //Call to the api is done here, to obtain the complexes.  
        $scope.get = function () {
            complexGetService.get(function (response) {
                var x = $scope.numPerPage;
                $scope.complexes = response.data;
                $scope.filteredComplexes = $scope.complexes.slice(0, x);
            })
        }

        $scope.chosen = function (complex) {
            complexToAptService.set(complex); //saves our complex for future use.  
            $rootScope.$broadcast('complexPicked', {}); //Clicking on a complex causes the module to broadcast to the others, letting them know a complex has been chosen
        }

    }]);

    ga.controlPanel.controller('panelAptController', ['$scope', '$rootScope', 'aptGetService', 'filterAptService', 'complexToAptService', 'aptToRoomService', function ($scope, $rootScope, aptGetService, filterAptService, complexToAptService, aptToRoomService) {
        
        /*Same idea with complex pagination.  Paginates the pages. */
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

        /*Once a complex is picked, this function fires, so we grab all apartments from that base complex
          NOTE: it follows the same idea as complexes */
        $scope.$on('complexPicked', function () {
            var x = complexToAptService.get();
            $('#complexName').html(x.Name);
            filterAptService.get(x, function (response) {
                var x = $scope.numPerPage;
                $scope.apts = response.data;
                $scope.filteredApartments = $scope.apts.slice(0, x);
            })
        });

        /*When an associate moves into an apartment, the get api is called once again to refresh the apartments.
          NOTE: Needs editting to retain the page you were on previously, because it reverts to the first page.  */
        $scope.$on('assocMovedIn', function () {
            var x = complexToAptService.get();
            filterAptService.get(x, function (response) {
                var x = $scope.numPerPage;
                $scope.apts = response.data;
                $scope.filteredApartments = $scope.apts.slice(0, x);
            })
        });

        //Same idea as above with assocMovedIn
        $scope.$on('assocRemoved', function () {
            var x = complexToAptService.get();
            filterAptService.get(x, function (response) {
                var x = $scope.numPerPage;
                $scope.apts = response.data;
                $scope.filteredApartments = $scope.apts.slice(0, x);
            })
        });

        //Once an apartment is chosen, it broadcasts this to the next module.  
        $scope.aptChoose = function (apt) {
            aptToRoomService.set(apt);
            $rootScope.$broadcast('aptPicked', {});
        }
    }]);

    ga.controlPanel.controller('panelAssocController', ['$scope', '$rootScope', '$route', 'associateGetService', 'aptToRoomService', 'associatePostService', function ($scope, $rootScope, $route, associateGetService, aptToRoomService, associatePostService) {


        //When an apt is picked, the associate list pops up.  
        $scope.$on('aptPicked', function () {
            $('#chooseAptFirst').html('');
            var x = $scope.filteredAssociates;
            if (x.length === 0) {
                $scope.assocGet();
            }
        });

        //Pagination yet again.
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

        /*
            Gets all associates based on parameters set in the model.
        */
        $scope.assocGet = function () {
            /*For the love of God and all things almighty, do not delete the -1s, since 
              it pulls all associates not living in ANY apartment.  Apparently 0 doesn't work as a correct value, which is super dumb.
              Anyways, if you want a correct list, please keep this the way it is.  
            */
            $scope.getModel = {
                RoomID: -1,
                AssociateID: -1
            }
            associateGetService.get($scope.getModel, function (response) {
                var x = $scope.numPerPage;
                $scope.associates = response.data;
                $scope.filteredAssociates = $scope.associates.slice(0, x);
            }, function (response) { //We didn't need this part, but if a response is needed should it fail, you can log into console here.  
            })
        }

        /*
            Primary role of the associate list, it takes the roomID from the apttoroom service and the associate's id passed in and posts that to the room
            This in turn sticks the associate in the room, and refreshes several modules based on information received.  
        */
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
                    $scope.filteredAssociates = $scope.associates.slice(0, g);
                    $rootScope.$broadcast('assocMovedIn', {});
                }, function (response) {
                })
            }, function (result) {
                //Should the order fail, an error message appears.  You might want to figure out a tweak to differentiate between gender, and capacity
                //Since it only tells you there's an error.
                setTimeout(function () { $('#failAddAssoc').fadeIn(200); });
                setTimeout(function () { $('#failAddAssoc').fadeOut(3000); }, 2000);
            });
        }

        //When an associate is removed from a room, the associate list will refresh
        //NOTE: There needs to be a way to retain the page you're on if you're not on the first page of associates.  Gonna go rip my hair out.  
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
        
        /*Presents a list of the associates within a specific apartment.  */
        $scope.$on('complexPicked', function () {
            $('#roomNumber').html('Choose an Apartment');
            $('#assocRoom').empty();
            $scope.livingAssoc = [];

        });

        /*Whenever an apartment is picked, we change the name of the text to equal that room nmber*/
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

        /*When delete is called, it takes the associate's id and the room id and then refreshes the page. */
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
