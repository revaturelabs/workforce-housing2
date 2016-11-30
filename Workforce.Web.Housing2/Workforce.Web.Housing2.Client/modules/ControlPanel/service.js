(function (ga) {
    'use strict';

    /*
        Each service used in this module. There are a few gets as well as some posts done in this field.
        API Calls:
            Get Service for complex
            Get Service for associates
            Get Service for apartments
            Post Service for Associates
            Delete Service for Associates

            The factories themselves are services that can be called upon.
            For a few, there are parameters that are brought in to designate what information to get from the database.

            Make sure to call these services in the module you're working on in order for angular to understand what you're using.  
    */
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
