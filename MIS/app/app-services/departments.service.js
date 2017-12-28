/**
 * Created by CuongTV on 2/29/2016.
 */
(function () {
    'use strict';

    angular
        .module('app')
        .factory('DepartmentsService', DepartmentsService);

    DepartmentsService.$inject = ['$http', '$location', 'localStorageService'];
    function DepartmentsService($http, $location, localStorageService) {
        var service = {};

        service.GetAll = GetAll;
        service.GetPatient = GetPatient;
        service.Create = Create;
        service.Update = Update;
        service.Delete = Delete;

        return service;


        function GetAll() {
            return $http.get('/survey/home').then(handleSuccess, handleError);
        }

        function GetPatient(data) {
            return $http.get('/api/listPatient?search_text=' + data).then(handleSuccess, handleError('Err'));
        }

        function Create(user) {
            return $http.post('/api/users', user).then(handleSuccess, handleError('Error creating user'));
        }

        function Update(user) {
            return $http.put('/api/users/' + user.id, user).then(handleSuccess, handleError('Error updating user'));
        }

        function Delete(id) {
            return $http.delete('/api/users/' + id).then(handleSuccess, handleError('Error deleting user'));
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