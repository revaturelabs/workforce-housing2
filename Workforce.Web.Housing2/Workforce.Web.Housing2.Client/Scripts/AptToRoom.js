(function (ga) {
  'use strict';

  ga.angular.factory('aptToRoomService', [function () {


    function set(data) {
      sessionStorage.setItem('aRoom', JSON.stringify(data)); //stringified.  needs to be parse       
    }

    function get() {
      var x = JSON.parse(sessionStorage.getItem('aRoom')); //using sessionstorage instead. gets wiped out after session is done
      return x;
    }

    return {

      set: set,
      get: get
    };
  }]);
})(window.ahApp);