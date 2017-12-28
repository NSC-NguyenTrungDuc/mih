/**
 * Created by quangbv on 08/03/2016.
 */
(function () {
    'use strict';

    angular
        .module('app')
        .factory('PatientSurveysService', PatientSurveysService);
    PatientSurveysService.$inject = ['$http', '$rootScope', "$q", '$location'];
    function PatientSurveysService($http, $rootScope, $q, $location) {
        var service = {};
        service.GetSurveyByDept = GetSurveyByDept;
        service.doSurvey = doSurvey;
        service.doneSurvey = doneSurvey;
        service.exportPhrByToken = exportPhrByToken;
        service.getDetailPatientSurveyByToken = getDetailPatientSurveyByToken;
        service.getHospinfo = getHospinfo;
        service.getHospinfoByToken = getHospinfoByToken;
        return service;

        function GetSurveyByDept(dept_code, callback) {
            $.ajax({
                url: '/survey/search?department_code=' + dept_code + '&page_size=' + 10000 + '&page_index=' + 1,
                type: 'GET',
                async: false,
                headers: {
                    token: $http.defaults.headers.common['token']
                },
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    if (response.status == 401) {
                        return response = {status: 401, message: 'Token invalid'};
                    } else {
                        return response = {status: 0, message: 'response.error'}
                    }
                    callback(response);
                }
            });
            //return $http.get('/survey/search?department_code=' + dept_code + '&page_size=' + 10000 + '&page_index=' + 1).then(handleSuccess, handleError('Err'));
        }

        // For getting patient's survey information to do
        function doSurvey(id) {

            var config = {
                headers: {
                    // 'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            };

            return $http.get('/survey/do_patient_survey_by_token/' + id, config).then(handleSuccess, handleError('Error getting all users'));
        }

        // For finishing patient's survey information
        function doneSurvey(params, callback) {
            var config = {
                headers: {
                    // 'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            };

            $http.post('/survey/patient_survey_token', params, config)
                .success(function (response) {
                    if (response.status == 1) {
                        response = {success: true, data: response.data};
                    } else {
                        response = {success: false, message: response.message};
                    }
                    callback(response);
                }).error(function (response) {
                response = {success: false, message: response.message};
                callback(response);
            });
        }

        function exportPhrByToken(id, token) {
            return $http.get('/cms/hospital/export_phr_token/' + id + '/' + token).then(handleSuccess, handleError('Error getting all users'));
        }

        function getDetailPatientSurveyByToken(id, token) {
            return $http.get('/survey/view_patient_survey_token/' + id + '/' + token).then(handleSuccess, handleError('Error getting all users'));
        }

        function getHospinfo(hospCode) {
            return $http.get('/cms/hospital/search?hosp_code=' + hospCode).then(handleSuccess, handleError('Error getting all users'));
        }

        function getHospinfoByToken(token) {
            var promise = $http.get('/cms/hospital/search_token?token=' + token).then(handleSuccess, handleError('Error getting all users'));
            return promise;
        }

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            if (error.status == 401) {
                return {status: 401, message: 'Token invalid'};
            } else {
                return {status: 0, message: 'response.error'}
            }
        }
    }
})();