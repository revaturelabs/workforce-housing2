
(function (ga) {
    'use strict';

    ga.associate.factory('traineeGetService', ['$http', function ($http) {
        var url = '/workforce-grace-rest/api/associate/';
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

    ga.associate.factory('associateByAptService', ['$http', function ($http) {
        var url = '/workforce-grace-rest/api/associate/';
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

    ga.associate.factory('associatePostService', ['$http', function ($http) {
        var url = '/workforce-grace-rest/api/associate/';
        return {
            addAssoc: function (info, pass, fail) {
                $http({
                    method: 'post',
                    url: url,
                    data: info
                }).then(pass, fail);
            }
        }
    }]);

    ga.associate.factory('associateDeleteService', ['$http', function ($http) {
        var url = '/workforce-grace-rest/api/associate/';
        return {
            removeAssoc: function (info, pass, fail) {
                $http({
                    method: 'delete',
                    url: url,
                    data: info,
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(pass, fail);
            }
        }
    }]);

})(window.ahApp);