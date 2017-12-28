/**
 * Login Controller
 */
(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$route', '$http', '$location', '$cookieStore', 'AuthenticationService', 'FlashService', 'cssInjector', '$routeParams', '$cookies', 'gettextCatalog', 'localStorageService', '$rootScope'];
    function LoginController($route, $http, $location, $cookieStore, AuthenticationService, FlashService, cssInjector, $routeParams, $cookies, gettextCatalog, localStorageService, $rootScope) {
        cssInjector.add("css/quirk.css");
        cssInjector.add("css/custom.css");
        var vm = this;
        vm.hospitalObj = [];
        vm.login = login;
        var expireDate = new Date();
        expireDate.setDate(expireDate.getDate() + 30);

        (function initController() {
            var code = $routeParams.code;
            //If no hospital code, redirect to portal
            if (!code) {
                window.location.href = urlRedirect;
            }

            //If change hopital, logout user
            if(localStorageService.get('hosp_code') && $routeParams.code != localStorageService.get('hosp_code')){
                localStorageService.remove('hosp_code');
                localStorageService.remove('hospitalObj');
                localStorageService.remove('globals');
                $cookieStore.remove('globals');
                $route.reload();
                return;
            }
            localStorageService.set('hosp_code', code);
            //if change user, don't care already login or not, logout
            if($routeParams.p !=  localStorageService.get('patient_only')){
                //set on local store firstly
                if($routeParams.p == 1){
                    localStorageService.set('patient_only', 1);
                }else{
                    localStorageService.remove('patient_only');
                }
                //remove login information
                localStorageService.remove('globals');
                $cookieStore.remove('globals');
                $route.reload();
                return;
            }

            //If already login, go to home
            if ($cookieStore.get('globals')) {
                $location.path("/");
                return;
            }

            var url = '/cms/hospital/' + code;
            $http.get(url).then(function (res) {
                if (res.data.status == 0) {
                    FlashService.Error(res.data.msg);
                } else {
                    vm.hospitalObj = res.data;
                    if (vm.hospitalObj.data.hosp_code == null) {
                        window.location.href = urlRedirect;
                    } else {
                        /**
                         * If has not hospital code or hospital code has changed. Set new hospitalObj
                         */
                        if (!localStorageService.get('hosp_code') || (vm.hospitalObj.data.hosp_code != localStorageService.get('hosp_code'))) {
                            localStorageService.set('hospitalObj', vm.hospitalObj);
                        }
                        gettextCatalog.setCurrentLanguage(vm.hospitalObj.data.locale.toLowerCase());
                    }
                }
            }, function (res) {
            });
        })();

        /**
         * Login to MIS system
         */
        function login() {
            vm.dataLoading = true;
            if (localStorageService.get('hosp_code') == $routeParams.code) {
                AuthenticationService.Login(vm.username, vm.password, $routeParams.code, function (response) {
                    if (response.success == true) {
                        AuthenticationService.SetCredentials(vm.username, vm.password, response.data.full_name);
                        //var loggedIn = $cookieStore.get('globals');
                        //var hospitalObj = $cookieStore.get('hospitalObj');
                        var hospitalObj = localStorageService.get('hospitalObj');
                        if (hospitalObj.data.locale.toLowerCase() == 'ja') {
                            var link = document.createElement("script");
                            link.type = "text/javascript";
                            link.src = fontJa;
                            document.getElementsByTagName("head")[0].appendChild(link);
                        } else {
                            var link = document.createElement("script");
                            link.type = "text/javascript";
                            link.src = fontVn;
                            document.getElementsByTagName("head")[0].appendChild(link);
                        }

                        hospitalObj.data.department_list = response.data.department_list;
                        localStorageService.set('hospitalObj', hospitalObj);

                        $location.search({});
                        if (localStorageService.get('patient_only') == 1) {
                            $location.path('/patient/list_waiting');
                        } else {
                            $location.path('/');
                        }
                    } else {
                        FlashService.Error(response.message);
                        vm.dataLoading = false;
                    }
                });
            } else {
                if (localStorageService.get('globals') == null) {
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                } else {
                    $location.path('/');
                }
            }
        }
    }
})();
