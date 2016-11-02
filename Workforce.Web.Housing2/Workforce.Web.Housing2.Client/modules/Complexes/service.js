(function (ga) {
  'use strict';

  ga.complex.factory('complexGetService', ['$http', function ($http) {
    var url = '/workforce-housing2-rest/api/housingcomplex';
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