(function (ga) {
    'use strict';

    ga.complex.factory('complexGetService', ['$http', function ($http) {
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

    ga.complex.factory('complexPostService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/housingcomplex';
        return {
            addComplex: function (info, pass, fail) {
                $http({
                    method: 'post',
                    url: url,
                    data: info
                }).then(pass, fail);
            }
        }
    }]);

    ga.complex.factory('complexEditService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/housingcomplex';
        return {
            editComplex: function (info, pass, fail) {
                $http({
                    method: 'put',
                    url: url,
                    data: info
                }).then(pass, fail);
            }
        }
    }]);
    ga.complex.factory('complexDeleteService', ['$http', function ($http) {
        var url = '/workforce-housing-rest/api/housingcomplex';
        return {
            removeTheComplex: function (data, pass, fail) {
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