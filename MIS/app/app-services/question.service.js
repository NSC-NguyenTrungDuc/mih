/**
 * Created by quangbv on 02/03/2016.
 */
(function () {
    'use strict';

    angular
        .module('app')
        .factory('QuestionService', QuestionService);
    QuestionService.$inject = ['$http', 'gettextCatalog'];
    function QuestionService($http, gettextCatalog) {
        var service = {};

        service.GetAll = GetAll;
        service.SearchQuestion = SearchQuestion;
        service.DeleteQuestion = DeleteQuestion;
        service.createQuestion = createQuestion;
        service.getDetailQuestion = getDetailQuestion;

        return service;
        function GetAll(department_code, question_type, text, callback) {
            var config = {
                headers: {
                    //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            };
            var params = {};

            if (department_code != '' && department_code != null) {
                params.department_code = department_code;
            }

            if (question_type != '' && question_type != -1) {
                params.question_type = question_type;
            }

            if (text != null) {
                params.question_content = text;
            }
            var url = '/cms/questions?page_size=' + 10000 + '&page_index=' + 1;
            $http.post(url, params, config).success(function (res) {
                if (res.status == 0) { // If server response error
                    return;
                } else {
                    callback(res);
                }
            });
        }

        function SearchQuestion(dept, type, text, callback) {
            var data = $.param({
                dept: dept,
                type: type,
                text: text
            });

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            };
            $http.post('api/questionList', data, config)
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

        function DeleteQuestion(ids, callback) {
            if (ids.length > 0) {
                var config = {
                    headers: {
                        //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                        'Content-Type': 'application/json',
                        'Accept': 'application/json'
                    }
                };
                $http.post('/cms/question/delete', ids, config)
                    .success(function (response) {
                        if (response.status == 1) {
                            response = {success: true, data: response.data};
                        } else {
                            response = {success: false, message: response.msg};
                        }
                        callback(response);
                    }).error(function (response) {
                    response = {success: false, message: 'Unknown error'};
                    callback(response);
                });
            } else {
                var res = {success: false, message: gettextCatalog.getString('Please, choose question.')};
                callback(res);
            }
        }

        function createQuestion(params, callback) {
            /*var data = $.param({
             dept: dept
             });*/

            var config = {
                headers: {
                    // 'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            };

            if (typeof(params.question_id) != 'undefined') {
                $http.put('/cms/question', params, config)
                    .success(function (response) {
                        if (response.status == 1) {
                            response = {success: true, data: response.data};
                        } else {
                            response = {success: false, message: response.msg};
                        }
                        callback(response);
                    }).error(function (response) {
                    response = {success: false, message: 'Unknown error'};
                    callback(response);
                });
            } else {
                $http.post('/cms/question', params, config)
                    .success(function (response) {
                        if (response.status == 1) {
                            response = {success: true, data: response.data};
                        } else {
                            response = {success: false, message: response.msg};
                        }
                        callback(response);
                    }).error(function (response) {
                    response = {success: false, message: 'Unknown error'};
                    callback(response);
                });
            }
        }

        function getDetailQuestion(id) {
            //return $http.get('/api/questionDetail/' + id).then(handleSuccess, handleError('Error getting all users'));
            return $http.get('/cms/question/' + id).then(handleSuccess, handleError('Error getting all users'));
        }

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return {success: false, message: error};
            };
        }
    }
})();