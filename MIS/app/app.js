(function () {
    'use strict';

    angular
        .module('app', ['ngRoute', 'LocalStorageModule', 'ngCookies', 'angular.css.injector', 'gettext', 'datatables', 'ui.select2', 'ui.sortable', 'monospaced.elastic'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider', 'localStorageServiceProvider', '$locationProvider'];
    function config($routeProvider, localStorageServiceProvider, $locationProvider) {
        /**
         * Routing
         */
        $routeProvider
            .when('/', {
                title: 'Home page',
                controller: 'HomeController',
                templateUrl: 'modules/home/home.view.html',
                controllerAs: 'vm',
                authenticate: false
            })
            .when('/login', {
                title: 'Sign in',
                controller: 'LoginController',
                templateUrl: 'modules/login/login.view.html',
                controllerAs: 'vm',
                authenticate: true
            })
            /*.when('/login/:code', {
             title: 'Sign in',
             controller: 'LoginController',
             templateUrl: 'modules/login/login.view.html',
             controllerAs: 'vm'
             })*/
            //patient module
            .when('/patient', { // For listing all patient's survey
                title: 'Patient survey',
                controller: 'PatientController',
                templateUrl: 'modules/patient/patient.view.html',
                //controllerAs: 'vm',
                authenticate: true
            })
            .when('/patient/do-survey/:patient_id/:sid', {
                title: 'Answer survey',
                templateUrl: 'modules/patient/do-survey1.html',
                controller: 'PatientController',
                authenticate: true
            })
            .when('/patient/answers-survey/:patient_sid', { // For doing specific patient's survey
                title: 'Answer Survey',
                templateUrl: 'modules/patient/do-survey.html',
                controller: 'PatientController',
                authenticate: true
            })
            .when('/patient/answers-survey-branching/:patient_sid', { // For doing specific patient's survey
                title: 'Answer survey',
                templateUrl: 'modules/patient/do-survey-branching.html',
                controller: 'PatientBranchingController',
                authenticate: true
            })
            .when('/patient/do-survey-only/:patient_sid', { // For doing specific patient's survey
                title: 'Answer survey',
                templateUrl: 'modules/patient/do_survey_only.html',
                controller: 'PatientController',
                authenticate: true
            })
            .when('/patient/do-survey-only-branching/:patient_sid', { // For doing specific patient's survey
                title: 'Answer survey',
                templateUrl: 'modules/patient/do-survey-only-branching.html',
                controller: 'PatientBranchingController',
                authenticate: true
            })
            .when('/patient/do-survey-only-mt/:patient_sid', { // For doing specific patient's survey
                title: 'Answer survey',
                templateUrl: 'modules/patient_survey/do_survey_only.html',
                controller: 'PatientSurveyController',
                authenticate: false
            })
            .when('/patient/do-survey-only-notification', { // For doing specific patient's survey
                title: 'Answer survey',
                templateUrl: 'modules/patient_survey/notifacation.html',
                controller: 'PatientSurveyController',
                authenticate: false
            })
            .when('/patient/do-survey-only-mt-branching/:patient_sid', { // For doing specific patient's survey
                title: 'Answer survey',
                templateUrl: 'modules/patient_survey/do_survey_only_branching.html',
                controller: 'PatientSurveyBranchingController',
                authenticate: false
            })
            .when('/patient/view-survey/:id', {
                title: 'View',
                templateUrl: 'modules/patient/view-survey.html',
                controller: 'PatientController',
                authenticate: false
            })
            .when('/patient/status/:status/:type', { // for listing patient's survey by status
                title: 'List survey',
                controller: 'PatientController',
                templateUrl: 'modules/patient/patient.view.html',
                authenticate: true
            })
            .when('/patient/dept/:deptid/:type', { // for listing patient's survey by department
                title: 'List survey',
                controller: 'PatientController',
                templateUrl: 'modules/patient/patient.view.html',
                authenticate: true
            })
            .when('/patient/dept/:deptid/:status/:type', { // for listing patient's survey by department and status
                title: 'List survey',
                controller: 'PatientController',
                templateUrl: 'modules/patient/patient.view.html',
                authenticate: true
            })
            .when('/patient/printpdf', { // for listing patient's survey by department and status
                controller: 'PatientController',
                templateUrl: 'modules/patient/print.view.html',
                authenticate: true
            })
            .when('/patient/list_waiting', {
                title: 'Quick survey',
                controller: 'PatientController',
                templateUrl: 'modules/patient/list_waiting.html',
                authenticate: true
            })
            // Question module
            .when('/questions/list', { // Default listing question page
                title: 'Question Library',
                controller: 'QuestionsController',
                templateUrl: 'modules/questions/list.view.html',
                authenticate: true
            })
            .when('/questions/create', { // Create new question
                title: 'Create Question',
                controller: 'QuestionsController',
                templateUrl: 'modules/questions/create.view.html',
                authenticate: true
            })
            .when('/questions/edit/:id', { // Edit question
                title: 'Edit question',
                controller: 'QuestionsController',
                templateUrl: 'modules/questions/edit.view.html',
                authenticate: true
            })
            // Survey module
            .when('/survey/setting', {
                title: 'Survey Setting',
                controller: 'SurveySettingController',
                templateUrl: 'modules/survey/survey.setting.view.html',
                authenticate: true
            })
            .when('/survey/list', {
                title: 'Survey Library',
                templateUrl: 'modules/survey/list.view.html',
                controller: 'SurveyController',
                authenticate: true
            })
            .when('/survey/create', {
                title: 'Create Survey',
                templateUrl: 'modules/survey/create.view.html',
                controller: 'SurveyController',
                authenticate: true
            })
            .when('/survey/create/:department_code', {
                title: 'Create new survey',
                templateUrl: 'modules/survey/create.view.html',
                controller: 'SurveyController',
                authenticate: true
            })
            .when('/notfound', {
                title: 'Page not found',
                controller: 'GlobalController',
                templateUrl: 'views/404.html',
                authenticate: false
            })
            .when('/maintaince', { // Maintaince page
                controller: 'GlobalController',
                templateUrl: 'views/maintaince.html',
                authenticate: false
            })
            .otherwise({redirectTo: '/notfound'});
        localStorageServiceProvider
            .setPrefix('cms')
            .setStorageCookie(30);
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http', 'gettextCatalog', 'DTOptionsBuilder', '$routeParams', '$route', 'localStorageService'];
    function run($rootScope, $location, $cookieStore, $http, gettextCatalog, DTOptionsBuilder, $routeParams, $route, localStorageService) {
        var url = $location.path().split('/')[1];
        var hospitalObj = localStorageService.get('hospitalObj');
        var loggedIn = typeof ($cookieStore.get('globals')) == 'undefined' ? false : true;
        var restrictedPage = $.inArray(url, ['login', 'register']) === 0; // if /login return true
        var globals = localStorageService.get('globals');

        /**
         * if exist hospital then set language and get font of it.
         */
        if (hospitalObj) {
            var savedLang = hospitalObj.data.locale.toLowerCase();
            if (typeof(savedLang) != 'undefined' && savedLang != null) {
                gettextCatalog.setCurrentLanguage(savedLang);
            } else {
                gettextCatalog.setCurrentLanguage('ja');
            }

            /**
             * If logged in require font file.
             */
            if (globals != null) {
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
            }
        } else {
            gettextCatalog.setCurrentLanguage('ja');
        }

        /**
         * keep user logged in after page refresh
         */
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        // authentication route
        $rootScope.$on('$routeChangeStart', function (event, next, current) {
            /**
             * User access to login
             */
            if (next['$$route'].controller == "LoginController") {
                return;
            }
            /**
             * User logged in
             */
            if ($cookieStore.get('globals')) {
                /**
                 * Check change hospital

                 /**
                 * Check change page patient only
                 */
                if (localStorageService.get('patient_only') == 1) {
                    var urlPatient = $location.path().split('/')[2];
                    if (typeof (urlPatient) == 'undefined' || $.inArray(urlPatient, ['list_waiting', 'do-survey-only', 'do-survey-only-branching']) < 0) {
                        if ($location.path().indexOf('login') == -1) {
                            $location.path('/patient/list_waiting');
                        }
                    }
                }
                return;
            }
            /**
             * User do not login
             */
            var params = {code: localStorageService.get('hosp_code')};
            if (localStorageService.get('patient_only') == 1) {
                params.p = 1;
            }
            if(next.authenticate) {
                $location.path('/login').search(params);
            }

        });

        $rootScope.$on('$routeChangeSuccess', function (event, next, current) {
            document.title = gettextCatalog.getString($route.current.title);
            var lang = gettextCatalog.getCurrentLanguage();
            $rootScope.langGlobal = gettextCatalog.getCurrentLanguage();
            if (typeof (lang) != 'undefined') {
                if (lang == 'vi') {
                    $rootScope.langObj = vietnamese;
                } else if (lang == 'en') {
                    $rootScope.langObj = english;
                } else {
                    $rootScope.langObj = japanese;
                }
            } else {
                $rootScope.langObj = japanese;
            }

            $rootScope.dtOptions = DTOptionsBuilder
                .newOptions()
                .withOption('order', [1, 'desc'])
                .withOption('dom', '<"top"i>rt<"bottom"flp><"clear">')
                .withOption('bFilter', false)
                .withOption('columnDefs', [{
                    "targets": 'no-sort',
                    "orderable": false
                }])
                .withOption('fnRowCallback', function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                    var $cell = $('td:eq(0)', nRow);
                    $cell.text(iDisplayIndex + 1);
                    return nRow;
                })
                .withLanguage($rootScope.langObj);
        });
    }
})();