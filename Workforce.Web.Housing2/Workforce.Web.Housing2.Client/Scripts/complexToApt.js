(function (ga) {
    'use strict';

    ga.angular.factory('complexToAptService', [function () {

        //saves information on a specific complex.  
        function set(data) {
            sessionStorage.setItem('aComplex', JSON.stringify(data)); //stringified.  needs to be parse       
        }

        function get() {
            var x = JSON.parse(sessionStorage.getItem('aComplex')); //using sessionstorage
            return x;
        }

        return {

            set: set,
            get: get
        };
    }]);
})(window.ahApp);