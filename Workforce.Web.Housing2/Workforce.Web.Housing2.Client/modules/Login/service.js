(function (ga) {
  'use strict';
  ga.login.factory('loginService', ['$http', function ($http) {
    var url = '/workforce-associate-rest/api/accounts/getToken';
    return {
      get: function (u, p) {
        $http({
          withCredentials: true,
          username: u,
          password: p,
          method: 'get',
          url: url
        }).success(function () {
          location = '#/complexes';
        }).error(function () { location = '#/fail'; })
        }
      }
  }]);
})(window.ahApp);