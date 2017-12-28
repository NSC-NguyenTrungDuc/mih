/**
 * Created by quangbv on 08/03/2016.
 */
(function () {
    'use strict';

    angular
        .module('app')
        .factory('SurveysService', SurveysService);
    SurveysService.$inject = ['$http', '$rootScope', "$q", '$location'];
    function SurveysService($http, $rootScope, $q, $location) {
        var service = {};
        service.GetSurveyByDept = GetSurveyByDept;
        service.GetDetailSurvey = GetDetailSurvey;
        service.LastestSurvey = LastestSurvey;
        service.CreateSurvey = CreateSurvey;
        service.EditSurvey = EditSurvey;
        service.DeleteSurvey = DeleteSurvey;
        service.listAll = listAll;
        service.SearchSurvey = SearchSurvey;
        service.ChangeStatus = ChangeStatus;
        service.doSurvey = doSurvey;
        service.exportPhr = exportPhr;
        service.getDetailPatientSurvey = getDetailPatientSurvey;
        service.doneSurvey = doneSurvey;
        service.getSurveyRule = getSurveyRule;
        service.saveSurveySetting = saveSurveySetting;
        return service;

        function LastestSurvey(data, callback) {
            var params = {};
            if (data.dept_code == -1) {
                params = {
                    search: data.search_text,
                    survey_status: 0
                };
            } else {
                params = {
                    search: data.search_text,
                    department_code: data.dept_code,
                    survey_status: 0
                };
            }
            $.ajax({
                url: '/cms/hospital/dashboard/search?page_size=' + data.page_size + '&page_index=' + data.page_index + '&column=' + data.column + '&dir=' + data.dir,
                type: 'POST',
                data: JSON.stringify(params),
                async: false,
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json',
                    token: $http.defaults.headers.common['token']
                },
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    if (response.status == 401) { // Invalid token
                        response = {status: 401, message: 'Invalid token'};
                        callback(response);
                    } else {
                        response = {status: 0, message: 'incorrect'};
                        callback(response);
                    }
                }
            });
        }

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

        function DeleteSurvey(id, callback) {
            $.ajax({
                url: '/survey/' + id,
                type: 'DELETE',
                async: false,
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json',
                    token: $http.defaults.headers.common['token']
                },
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    callback(response);
                }
            })
            //return $http.delete('/survey/' + id).then(handleSuccess, handleError('Err'));
        }

        function CreateSurvey(data, callback) {
            $.ajax({
                url: '/survey',
                data: angular.toJson(data),
                //data: JSON.stringify(data),
                type: 'POST',
                async: false,
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json',
                    token: $http.defaults.headers.common['token']
                },
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    callback(response);
                }
            })
        }

        function EditSurvey(data, callback) {
            $.ajax({
                url: '/survey/' + data.survey_id,
                data: JSON.stringify(data),
                type: 'PUT',
                async: false,
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json',
                    token: $http.defaults.headers.common['token']
                },
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    callback(response);
                }
            })
        }

        function listAll() {
            return $http.get('/api/listPatientSurvey').then(handleSuccess, handleError('Error getting all users'));
        }

        function GetDetailSurvey(id, callback) {
            $.ajax({
                url: '/survey/' + id,
                type: 'GET',
                async: false,
                headers: {
                    token: $http.defaults.headers.common['token']
                },
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    callback(response);
                }
            });
        }

        function SearchSurvey(start, length, pt, dept) {
            if (pt == null || dept == null) {
                return $http.get('api/patient_survey', {
                    params: {
                        start: start,
                        length: length,
                    }
                }).then(handleSuccess, handleError('Err'));
            } else {
                return $http.get('api/patient_survey', {
                    params: {
                        start: start,
                        length: length,
                        patient_code: pt,
                        department_code: dept
                    }
                }).then(handleSuccess, handleError('Err'));
            }
        }

        //change status survey

        function ChangeStatus(data, callback) {
            $.ajax({
                url: '/survey/set_active/' + data,
                type: 'POST',
                async: false,
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json',
                    token: $http.defaults.headers.common['token']
                },
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    callback(response);
                }
            })
        }

        // For getting patient's survey information to do
        function doSurvey(id) {
            return $http.get('/survey/do_patient_survey/' + id).then(handleSuccess, handleError('Error getting all users'));
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

            $http.post('/survey/patient_survey', params, config)
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

        function exportPhr(id) {
            //return $http.get('/api/doSurvey?id=' + id).then(handleSuccess, handleError('Error getting all users'));
            return $http.get('/cms/hospital/export_phr/' + id).then(handleSuccess, handleError('Error getting all users'));
        }

        function getDetailPatientSurvey(id) {
            return $http.get('/survey/view_patient_survey/' + id).then(handleSuccess, handleError('Error getting all users'));
        }

        // survey setting
        function getSurveyRule(params, callback) {
            var url = '/survey/survey_rule/search?page_size=' + 10000 + '&page_index=' + 1 + '&column=&dir=';
            var config = {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json',
                    token: $http.defaults.headers.common['token']
                }
            };

            $http.post(url, params, config)
                .success(function (response) {
                    if (response.status == 1) {
                        response = {success: true, data: response.data};
                    } else {
                        response = {success: false, message: response.msg};
                    }
                    callback(response);
                }).error(function (response) {
                    response = {success: false, message: 'Username or password is incorrect'};
                    callback(response);
                });
        }

        // Save survey setting
        function saveSurveySetting(params, callback) {
            var config = {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json',
                    token: $http.defaults.headers.common['token']
                }
            };

            $http.post('/survey/save_survey_setting', params, config)
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