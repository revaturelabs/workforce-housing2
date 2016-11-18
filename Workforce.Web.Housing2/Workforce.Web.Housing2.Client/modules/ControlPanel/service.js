(function (ga) {
    'use strict';

    ga.controlPanel.factory('complexGetService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/housingcomplex';
        return {
            get: function (pass, fail) {
                $http({
                    method: 'get',
                    url: url
                }).then(pass, fail);
            }
        }
    }]);

    ga.controlPanel.factory('associateGetService', ['$http', function ($http) {
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

    ga.controlPanel.factory('aptGetService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/apartment/';
        return {
            get: function (pass, fail) {
                $http({
                    method: 'get',
                    url: url
                }).then(pass, fail);
            }
        }
    }]);

    ga.controlPanel.factory('filterAptService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/filteraptsbycomplex/';
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

    ga.controlPanel.factory('associateByAptService', ['$http', function ($http) {
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

    ga.controlPanel.factory('associatePostService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/associate/';
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

    ga.controlPanel.factory('associateDeleteService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/associate/';
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
