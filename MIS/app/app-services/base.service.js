/**
 * Created by NghiaNM on 3/14/2016.
 */

(function () {
    'use strict';

    angular
        .module('app')
        .factory('BaseService', BaseService);

    BaseService.$inject = ['$http'];
    function BaseService($http) {
        var service = {};

        service.Report = Report;
        return service;

        function Report(type, page, size) {
            return $http.get('/cms/hospital/dashboard?type=' + type + '&page_index=' + page + '&page_size=' + size).then(handleSuccess, handleError);
        }

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            if (error.status == 401) {
                return {status: 401, message: 'Error'};
            } else {
                return {status: 0, message: 'Error'}
            }
        }
    }

})();