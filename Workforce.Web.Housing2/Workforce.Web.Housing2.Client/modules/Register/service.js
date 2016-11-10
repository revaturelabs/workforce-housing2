(function (ga) {
  'use strict';

  ga.register.factory('registerService', ['$http', function ($http) {
    var url = 'http://ec2-54-175-5-94.compute-1.amazonaws.com/workforce-associate-rest/api/accounts/create';
    return {
      post: function (data, pass, fail) {
        $http({
          method: 'post',
          url: url,
          params: data
        }).then(pass, fail);
      }
    }
  }]);
})(window.ahApp);