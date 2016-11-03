/// <reference path="module.js" />

(function (ga) {
  'use strict';

  ga.apartment.factory('complexGetService', ['$http', function ($http) {
    var url = '/workforce-grace-rest/api/housingcomplex';
    return {
      get: function (pass, fail) {
        $http({
          method: 'get',
          url: url
        }).then(pass, fail);
      }
    }
  }]);

})(window.ahApp);