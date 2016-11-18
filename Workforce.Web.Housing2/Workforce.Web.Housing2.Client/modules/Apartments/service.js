(function (ga) {
    'use strict';

    ga.apartment.factory('filterAptService', ['$http', function ($http) {
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

    ga.apartment.factory('aptPostService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/apartment/';
        return {
            addApt: function (data, pass, fail) {
                $http({
                    method: 'post',
                    url: url,
                    data: data
                }).then(pass, fail);
            }
        }
    }]);


    ga.apartment.factory('complexGetService', ['$http', function ($http) {
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

    ga.apartment.factory('roomDeleteService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/apartment/';
        return {
            removeApt: function (data, pass, fail) {
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