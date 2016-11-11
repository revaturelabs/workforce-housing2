(function (ga) {
    'use strict';

    ga.assocList.factory('listGetService', ['$http', function ($http) {
        var url = '/workforce-associate-rest/api/associate/';
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

    ga.assocList.factory('listDeleteService', ['$http', function ($http) {
        var url = '/workforce-associate-rest/api/associate/';
        return {
            removeAssociate: function (data, pass, fail) {
                $http({
                    method: 'delete',
                    url: url,
                    data: data,
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(pass, fail);
            }
        }
    }]);

})(window.ahApp);