(function () {
    'use strict';
    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$http', 'BaseService', 'SurveysService', 'QuestionService', '$scope', '$rootScope', '$routeParams', '$cookieStore', '$timeout', '$location', 'DTOptionsBuilder', '$compile', 'DTColumnDefBuilder', 'gettextCatalog', 'cssInjector', 'localStorageService', '$interval'];
    function HomeController($http, BaseService, SurveysService, QuestionService, $scope, $rootScope, $routeParams, $cookieStore, $timeout, $location, DTOptionsBuilder, $compile, DTColumnDefBuilder, gettextCatalog, cssInjector, localStorageService, $interval) {
        $('body').removeClass('signwrapper');
        cssInjector.add("css/quirk.css");
        cssInjector.add("css/custom.css");
        $scope.search_text = "";
        $scope.department = null;
        $scope.department_code = "";
        $scope.departmentArr = new Object();
        $scope.page_index = 1;
        $scope.page_size = 7;
        $scope.dtInstance = {};
        $scope.pageSizeGlobal = 10;
        $scope.listClass = [
            'panel-blue',
            'panel-orange',
            'panel-green',
            'panel-brown',
            'panel-pink',
            'panel-red',
            'panel-green2'
        ];

        $scope.listIcon = [
            'panel-icon-1.png',
            'panel-icon-2.png',
            'panel-icon-2.png',
            'panel-icon-4.png',
            'panel-icon-5.png',
            'panel-icon-6.png',
            'panel-icon-7.png'
        ];
        $scope.type = 1;

        initController();

        function initController() {
            $.fn.dataTableExt.sErrMode = 'throw';
            var hospitalObj = localStorageService.get('hospitalObj');
            $scope.hospitalObj = hospitalObj.data;
            $scope.departmentList = $scope.hospitalObj.department_list;
            $.each($scope.departmentList, function (index, value) {
                $scope.departmentArr[value.department_code] = value;
            });
            /**
             * init datatable
             */
            $scope.initDataTable = function () {
                $timeout(function () {
                    $scope.dtOption = DTOptionsBuilder.newOptions()
                        .withSource(function (data, callback) {
                            var lang = gettextCatalog.getCurrentLanguage();
                            if (gettextCatalog.getCurrentLanguage() != 'undefined') {
                                moment.locale(lang);
                            } else {
                                moment.locale('ja');
                            }
                            data.order[0].column = data.columns[data.order[0].column].data;

                            // The column in database is 'title', not 'survey_title'
                            if (data.order[0].column == 'survey_title') {
                                data.order[0].column = 'title';
                            }

                            var select_patient = $scope.search_text;
                            if(select_patient != undefined && select_patient !== '') {
                                while (select_patient.length < 9) {
                                    select_patient = "0" + select_patient;
                                }
                            }
                            var params = {
                                page_index: (data.start / data.length) + 1,
                                page_size: data.length,
                                column: data.order[0].column,
                                dir: data.order[0].dir,
                                search_text: select_patient,
                                dept_code: $scope.department_code
                            };

                            SurveysService.LastestSurvey(params, function (res) {
                                if (res.status == 1) {
                                    res.data.patient_survey_list.forEach(function (val) {
                                        if (gettextCatalog.getCurrentLanguage() == 'en') {
                                            val.reservation_date = moment(val.reservation_date).format('ddd MMMM Do YYYY');
                                        } else if (gettextCatalog.getCurrentLanguage() == 'vi') {
                                            val.reservation_date = moment(val.reservation_date).format('dddd, Do MMM YYYY');
                                        } else {
                                            val.reservation_date = moment(val.reservation_date).format('ddd LL');
                                        }
                                        if (val.reservation_time != null) {
                                            var hour = val.reservation_time.substr(0, 2);
                                            var min = val.reservation_time.substr(2, 2);
                                            val.reservation_time = hour + ':' + min;
                                        }
                                    });
                                    callback({
                                        data: res.data.patient_survey_list,
                                        recordsTotal: res.data.records_total,
                                        recordsFiltered: res.data.records_filtered
                                    });
                                } else if (res.status == 401) {
                                    $cookieStore.remove('globals');
                                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                                }
                            });
                        })
                        .withDataProp('data')
                        .withOption('serverSide', true)
                        .withOption('processing', true)
                        .withOption('bFilter', false)
                        .withOption('bInfo', false)
                        .withOption('order', [2, 'desc'])
                        .withOption('sDom', 't<"clearfix"<"pull-left"l><"pull-right"p>>')
                        .withOption('createdRow', function (row) {
                            // Recompiling so we can bind Angular directive to the DT
                            $compile(angular.element(row).contents())($scope);
                        })
                        .withOption('iDisplayLength', $scope.pageSizeGlobal)
                        .withLanguage($scope.langObj);

                    $scope.dtColumnDef = [
                        DTColumnDefBuilder.newColumnDef(0).renderWith(function (x, y, z, meta) {
                            return meta.row + 1 + meta.settings._iDisplayStart;
                        }).notSortable(),
                        DTColumnDefBuilder.newColumnDef(1).withOption("mData", 'department_name'),
                        DTColumnDefBuilder.newColumnDef(2).withOption("mData", 'reservation_date'),
                        DTColumnDefBuilder.newColumnDef(3).withOption("mData", 'reservation_time'),
                        DTColumnDefBuilder.newColumnDef(4).withOption("mData", 'patient_code'),
                        DTColumnDefBuilder.newColumnDef(5).withOption("mData", 'patient_name'),
                        DTColumnDefBuilder.newColumnDef(6).withOption("mData", 'survey_title'),
                        DTColumnDefBuilder.newColumnDef(7).renderWith(function (x, y, data) {
                            return '<button ng-click="answer(\'' + data.survey_patient_id + '\');" class="btn btn-block btn-xs btn-danger"><translate>Do survey</translate></button>';
                        }).notSortable()
                    ];
                }, 1);
            };
            $scope.initDataTable();


            $scope.dashboard = function () {
                BaseService.Report($scope.type, $scope.page_index, $scope.page_size).then(function (res) {
                    if (res.status == 1) {
                        res.data.department.forEach(function (value, index) {
                            var idxClass = (index % 7 == 0) ? 6 : (index % 7 - 1);
                            var idxIcon = (index % 7 == 0) ? 6 : (index % 7 - 1);
                            value.class = $scope.listClass[idxClass];
                            value.src = $scope.listIcon[idxIcon];
                            value.title = value.name;
                            if (value.name != null) {
                                value.name = value.name.substr(0, 25);
                            }
                        });
                        $scope.department_list = res.data.department;
                        $scope.recordsTotal = res.data.records_total;
                        $scope.answered = res.data.total_answered;
                        $scope.waiting = res.data.total_waiting;
                        $('.nav-prev').attr("style", "pointer-events: none;");
                        $('.nav-next').attr("style", "pointer-events: none;");
                        if ($scope.page_index - 1 > 0) {
                            $('.nav-prev').attr("style", "pointer-events: auto;");
                        }

                        if ($scope.page_index * $scope.page_size < $scope.recordsTotal) {
                            $('.nav-next').attr("style", "pointer-events: auto;");
                        }
                    } else if (res.status == 401) {
                        $location.path('/login').search({code: localStorageService.get('hosp_code')});
                        $cookieStore.remove('globals');
                    }
                });
            };
            $scope.dashboard();
            var i = function () {
                $scope.dashboard();
                $scope.search();
                // For rebuild on event
                $('#table-survey_length select').on('click', function () {
                    $scope.pageSizeGlobal = $(this).val();
                });
            };

            /**
             * Reload data on screen each 15 seconds.
             */
            var timer = $interval(i, 15000);
            $scope.$on('$routeChangeStart', function () {
                $interval.cancel(timer);
            });
        }

        // For GET display length in table waiting survey
        $timeout(function () {
            $('#table-survey_length select').on('click', function () {
                $scope.pageSizeGlobal = $(this).val();
            });
        }, 1000);

        /**
         * Change period time on dashboard screen
         * @param type
         */
        $scope.chooseDate = function (type) {
            $scope.type = type;
            BaseService.Report($scope.type, $scope.page_index, $scope.page_size).then(function (res) {
                if (res.status == 1) {
                    res.data.department.forEach(function (value, index) {
                        var idxClass = (index % 7 == 0) ? 6 : (index % 7 - 1);
                        var idxIcon = (index % 7 == 0) ? 6 : (index % 7 - 1);
                        value.class = $scope.listClass[idxClass];
                        value.src = $scope.listIcon[idxIcon];
                        value.title = value.name;
                        if (value.name != null) {
                            value.name = value.name.substr(0, 25);
                        }
                    });
                    $scope.department_list = res.data.department;
                    $scope.recordsTotal = res.data.records_total;
                    $scope.answered = res.data.total_answered;
                    $scope.waiting = res.data.total_waiting;
                    $('.nav-prev').attr("style", "pointer-events: none;");
                    $('.nav-next').attr("style", "pointer-events: none;");
                    if ($scope.page_index - 1 > 0) {
                        $('.nav-prev').attr("style", "pointer-events: auto;");
                    }
                    if ($scope.page_index * $scope.page_size < $scope.recordsTotal) {
                        $('.nav-next').attr("style", "pointer-events: auto;");
                    }
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                }
            });

            $.each($('.btn-default-active'), function () {
                if ($(this).hasClass('active')) {
                    $(this).removeClass('active')
                }
            })
        };

        $scope.next = function () {
            $scope.page_index++;
            $('.nav-prev').attr("style", "pointer-events: none;");
            $('.nav-next').attr("style", "pointer-events: none;");
            if ($scope.page_index - 1 > 0) {
                $('.nav-prev').attr("style", "pointer-events: auto;");
            }

            if ($scope.page_index * $scope.page_size < $scope.recordsTotal) {
                $('.nav-next').attr("style", "pointer-events: auto;");
            }
            $scope.chooseDate($scope.type);
        };

        $scope.previous = function () {
            $scope.page_index--;
            $('.nav-prev').attr("style", "pointer-events: none;");
            $('.nav-next').attr("style", "pointer-events: none;");
            if ($scope.page_index - 1 > 0) {
                $('.nav-prev').attr("style", "pointer-events: auto;");
            }

            if ($scope.page_index * $scope.page_size < $scope.recordsTotal) {
                $('.nav-next').attr("style", "pointer-events: auto;");
            }
            $scope.chooseDate($scope.type);
        };

        $scope.answer = function (item) {
            window.open('#/patient/answers-survey/' + item);
        };

        /**
         * Search waiting patient survey.
         */
        $scope.search = function () {
            if ($scope.department == null) {
                $scope.department_code = null;
            } else {
                $scope.department_code = $scope.department;
            }

            $scope.initDataTable();
            if ($scope.dtInstance) {
                $scope.dtInstance.rerender()
            }
        }
    }
})();