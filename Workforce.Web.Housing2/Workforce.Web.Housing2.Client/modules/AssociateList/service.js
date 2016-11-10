(function (ga) {
    'use strict';

    ga.assocList.factory('listGetService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/associate/';
        return {
            get: function (data, pass, fail) {
                $http({
                    method: 'get',
                    url: url,
                    params: data
                }).then(pass, fail);
            }
        }
    }]);

    

})(window.ahApp);