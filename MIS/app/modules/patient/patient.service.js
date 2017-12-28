/**
 * Created by quangbv on 08/03/2016.
 */
(function () {
    'use strict';

    angular
        .module('app')
        .factory('PatientService', PatientService);
    PatientService.$inject = ['$http', '$rootScope', "$q", '$location'];
    function PatientService($http, $rootScope, $q, $location) {
        var service = {};
        service.ListPatientSurvey = ListPatientSurvey;
        service.DetailPatientSurvey = DetailPatientSurvey;
        return service;

        function ListPatientSurvey(url, params, callback) {
            var config = {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            };
            $http.post(url, params, config)
                .success(function (response) {
                    callback(response);
                })
                .error(function (response) {
                    callback(response);
                });
        }

        function DetailPatientSurvey(url, params, callback) {
            $http.get(url + params)
                .success(function (response) {
                    callback(response);
                })
                .error(function (response) {
                    callback(response);
                })
        }

    }
})();