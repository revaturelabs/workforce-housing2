(function (ga) {
  'use strict';

  ga.register.factory('registerService', ['$http', function ($http) {
      var url = '/workforce-associate-rest/api/associate/';
      return {
          post: function (data, pass, fail) {
              $http({
                  method: 'post',
                  url: url,
                  data: data,
                  headers: {
                  'Content-Type': 'application/json'
              }
              }).then(pass, fail);
          }
      }
  }]);

  ga.register.factory('batchService', ['$http', function ($http) {
      var url = '/workforce-associate-rest/api/batch/';
      return {
          get: function (pass, fail) {
              $http({
                  method: 'get',
                  url: url
              }).then(pass, fail);
          }
      }
  }]);
  ga.register.factory('genderService', ['$http', function ($http) {
      var url = '/workforce-associate-rest/api/gender/';
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