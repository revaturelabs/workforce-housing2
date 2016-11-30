(function (ga) {
  'use strict';

  ga.angular.factory('aptToRoomService', [function () {

    //grabs an apt and saves it so we can access rooms.  
    function set(data) {
      sessionStorage.setItem('aRoom', JSON.stringify(data)); //stringified.  needs to be parsed    
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