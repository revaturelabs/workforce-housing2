(function (ga) {
    'use strict';

    ga.angular.factory('traineeDataGrab', [function () {

        //gets and sets information on a specific associate. 
        function set(data) {
            sessionStorage.setItem('aTrainee', JSON.stringify(data)); //stringified.  needs to be parse       
        }

        function get() {
            var x = JSON.parse(sessionStorage.getItem('aTrainee')); //using sessionstorage
            return x;
        }

        return {

            set: set,
            get: get
        };
    }]);
})(window.ahApp);