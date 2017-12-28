(function () {
    'use strict';

    angular
        .module('app')
        .controller('SurveySettingController', SurveySettingController);

    SurveySettingController.$inject = ['$scope', '$rootScope', '$routeParams', 'cssInjector', '$location', 'SurveysService', 'DTOptionsBuilder', '$compile', 'DTColumnDefBuilder', 'gettextCatalog', '$http', '$timeout', 'localStorageService', '$cookieStore', '$interval', 'PatientService'];
    function SurveySettingController($scope, $rootScope, $routeParams, cssInjector, $location, SurveysService, DTOptionsBuilder, $compile, DTColumnDefBuilder, gettextCatalog, $http, $timeout, localStorageService, $cookieStore, $interval, PatientService) {
        //var hospitalObj = $cookieStore.get('hospitalObj');
        $('body').removeClass('signwrapper');
        var hospitalObj = localStorageService.get('hospitalObj');
        cssInjector.add("css/quirk.css");
        cssInjector.add("css/custom.css");

        $scope.hospitalObj = hospitalObj.data;
        var vm = this;
        vm.user = null;
        vm.allUsers = [];

        //$scope.departmentList = hospitalObj.department_list;
        $scope.pt_survey = [];
        $scope.surveyList = [];
        $scope.surveyActiveList = [];
        $scope.departmentArr = new Object();
        $scope.recordsTotal = 0;
        $scope.dtInstance = {};
        $scope.previous_steps = gettextCatalog.getString("Previous");
        $scope.next_steps = gettextCatalog.getString("Next");
        $scope.answer_title = gettextCatalog.getString('Answer Survey');
        $scope.confirm_title = gettextCatalog.getString('Confirm result');
        $scope.agreement_title = gettextCatalog.getString('User agreement term');
        $scope.completed_title = gettextCatalog.getString('Completed');
        $scope.exit_title = gettextCatalog.getString('Interview Exit');
        $scope.main_title = $scope.answer_title;

        initController();
        function initController() {
            $.fn.dataTableExt.sErrMode = 'throw';
            $.fn.modal.Constructor.prototype.enforceFocus = function () {
                var that = this;
                $(document).on('focusin.modal', function (e) {
                    if ($(e.target).hasClass('select2-input')) {
                        return true;
                    }

                    if (that.$element[0] !== e.target && !that.$element.has(e.target).length) {
                        that.$element.focus();
                    }
                });
            };
            var language = gettextCatalog.getCurrentLanguage();
            if (typeof(language) != 'undefined') {
                moment.locale(language);
            } else {
                moment.locale('ja');
            }
            // For converting image to base64
            $scope.getDataUri($scope.hospitalObj.logo, function (dataUri) {
                $scope.hospitalLogo = dataUri;
            });
            $scope.healthStatus = [
                {
                    value: 0,
                    text: gettextCatalog.getString('Waiting')
                },
                {
                    value: 1,
                    text: gettextCatalog.getString('Finished')
                },
            ];


            //var hospitalObj = $cookieStore.get('hospitalObj');
            var hospitalObj = localStorageService.get('hospitalObj');
            $scope.hospitalObj = hospitalObj.data;
            $scope.departmentList = hospitalObj.data.department_list;
            $.each($scope.departmentList, function (index, value) {
                $scope.departmentArr[value.department_code] = value;
            });
            $scope.selectedType = '0';

            // List of department that changed survey_setting
            $scope.listDepartmentChanged = [];
            $scope.listEditedSurveyRule = [];
            $scope.listDeletedSurveyRule = [];

            var department_code_redirect = '';
            if ($rootScope.department_code_redirect != null) {
                department_code_redirect = $rootScope.department_code_redirect;
                delete $rootScope.department_code_redirect;
            }
            //alert(department_code_redirect);
            $scope.selectedId = department_code_redirect;

            $scope.colors = ['blue','red', 'green']

            $scope.initDataTable = function (params) { // Init datatable for all. Depending on parameters passed

                //alert(JSON.stringify(department_code_redirect));

                // Handle for department
                /*var department_code_redirect = '';
                 if($rootScope.department_code_redirect != null) {
                 department_code_redirect = $rootScope.department_code_redirect;
                 delete $rootScope.department_code_redirect;
                 }
                 //alert(department_code_redirect);
                 $scope.selectedId = department_code_redirect;*/

                $scope.params = params;
                //alert('params::: ' + JSON.stringify(params));
                $timeout(function () {
                    $scope.onlyNumbers = /^\d+$/;

                    $scope.dtOptions = DTOptionsBuilder.newOptions()
                        .withOption('ajax', function (data, callback, settings) {
                            var page_index = (data.start / data.length) + 1;
                            var order = data.order;
                            var sortStr = '';
                            if (order[0].column == 0) {
                                sortStr = '&column=department_name' + '&dir=' + order[0].dir;
                            }

                            var department_code_redirect1 = '';
                            if ($scope.selectedId != null && $scope.selectedId != '' && $scope.selectedId != '-1') {
                                department_code_redirect1 = $scope.selectedId;
                                //delete $rootScope.department_code_redirect;
                            }
                            //$scope.selectedId = department_code_redirect1;

                            var url = '/survey/survey_rule/search?page_size=' + data.length + '&page_index=' + page_index + sortStr + '&department_code_redirect=' + department_code_redirect1;
                            var config = {
                                headers: {
                                    'Content-Type': 'application/json',
                                    'Accept': 'application/json',
                                    token: $http.defaults.headers.common['token']
                                }
                            };
                            //alert(JSON.stringify($scope.params));
                            $http.post(url, $scope.params, config).then(
                                function (res) { // On success
                                    if (res.status == 0) { // If server response error
                                        var hosp_code = localStorageService.get('hosp_code');
                                        $location.path('/login?code=' + hosp_code);
                                    } else {
                                        // map your server's response to the DataTables format and pass it to
                                        $scope.surveyRuleList = res.data.data.survey_rule_list;
                                        var response = res.data.data;
                                        callback({
                                            recordsTotal: response.records_total,
                                            recordsFiltered: response.records_filtered,
                                            data: res.data.data
                                        });
                                        $scope.recordsTotal = response.records_total;
                                    }
                                },
                                function (res) { // On error invalid token
                                    if (res.status == 401) {
                                        var hosp_code = localStorageService.get('hosp_code');
                                        $location.path('/login?code=' + hosp_code);
                                    }
                                }
                            );

                            var urlGetAllSurvey = '/survey/get_all_survey';
                            $http.post(urlGetAllSurvey, $scope.params, config).then(
                                function (res) { // On success
                                    if (res.status == 0) { // If server response error
                                        var hosp_code = localStorageService.get('hosp_code');
                                        $location.path('/login?code=' + hosp_code);
                                    } else {
                                        // map your server's response to the DataTables format and pass it to
                                        //alert(JSON.stringify(res.data.data.survey_department_list[0]));
                                        //var aaa = {"surveyId": 0, "title":"", "departmentCode": ""};
                                        $scope.surveyDepartmentList = res.data.data.survey_department_list;
                                    }
                                },
                                function (res) { // On error invalid token
                                    if (res.status == 401) {
                                        var hosp_code = localStorageService.get('hosp_code');
                                        $location.path('/login?code=' + hosp_code);
                                    }
                                }
                            );

                        })
                        //.withOption('order', [1, 'desc'])
                        .withOption('order', [0, 'asc'])
                        .withDataProp('data')
                        .withOption('serverSide', true)
                        .withOption('processing', true)
                        .withOption('bFilter', false)
                        .withOption('bInfo', false)
                        .withOption('sDom', 't<"clearfix"<"pull-left"l><"pull-right"p>>')
                        .withOption('createdRow', function (row, x, data) {
                            // Recompiling so we can bind Angular directive to the DT
                            $compile(angular.element(row).contents())($scope);
                        })
                        .withLanguageSource('/languages/' + gettextCatalog.getCurrentLanguage() + '_branch.json')
                        //test
                        //.withLanguage({sZeroRecords: ' '})
                    //.withOption('bSortable', false)
                    ;

                    $scope.dtColumnDefs = [
                        //DTColumnDefBuilder.newColumnDef(0).notSortable(),
                        DTColumnDefBuilder.newColumnDef(0).withOption("mData", 'department_code'),
                        DTColumnDefBuilder.newColumnDef(1).notSortable(),
                        DTColumnDefBuilder.newColumnDef(2).notSortable(),
                        DTColumnDefBuilder.newColumnDef(3).notSortable(),
                        DTColumnDefBuilder.newColumnDef(4).notSortable()
                    ];
                }, 1);
            }

            if ($location.path() == '/survey/setting') { // If does not passing anything
                var params = {};
                $scope.initDataTable(params);
            }
        }

        /**
         * Search department survey
         */
        $scope.searchDepartmentSurvey = function () {
            //alert("searchDepartmentSurvey:: " + JSON.stringify($rootScope.department_code_redirect));
            var params = {};
            if ($scope.selectedId != '' && $scope.selectedId != '-1') {
                params.department_code = $scope.selectedId;
            }
            $scope.initDataTable(params);

            // Refresh data
            if ($scope.dtInstance) {
                $scope.dtInstance.rerender();
            }
        };

        function isInteger(n) {
            return /^[0-9]+$/.test(n);
        }

        // For add setting
        $scope.changeDuration = function (department, survey, index) {
            if (isInteger(survey.duration) == false) {
                var durationId = 'duration_' + department.department_code + '_' + survey.survey_rule_id;
                $('#' + durationId).val("");
                $('#' + durationId).parent().addClass('has-error');
                $('#' + durationId).focus();

                $.gritter.add({
                    title: gettextCatalog.getString('Input data is invalid'),
                    text: gettextCatalog.getString('Duration must be integer'),
                    class_name: 'with-icon times-circle danger'
                });
                return;
            }

            // Add to list changed department
            if ($scope.listDepartmentChanged.indexOf(department.department_code) < 0) {
                $scope.listDepartmentChanged.push(department.department_code);
            }

            if (survey.survey_rule_id != null) {
                // Key
                var keyEdit = department.department_code + '_' + survey.survey_rule_id;
                if ($scope.listEditedSurveyRule.indexOf(keyEdit) < 0) {
                    $scope.listEditedSurveyRule.push(keyEdit);
                }
            }

            // Duration can't be overlapse
            var listDurationOfDepartment = [];
            department.survey_list.forEach(function (survey, index_s) {
                listDurationOfDepartment.push(parseInt(survey.duration));
            });
            listDurationOfDepartment.splice(listDurationOfDepartment.indexOf(parseInt(survey.duration)), 1);
            if (listDurationOfDepartment.indexOf(parseInt(survey.duration)) >= 0) {
                var durationId = 'duration_' + department.department_code + '_' + survey.survey_rule_id;
                $('#' + durationId).parent().addClass('has-error');
                $('#' + durationId).focus();

                $.gritter.add({
                    title: gettextCatalog.getString('Input data is invalid'),
                    text: gettextCatalog.getString('Duration can not be overlapse'),
                    class_name: 'with-icon times-circle danger'
                });
            } else {
                var durationId = 'duration_' + department.department_code + '_' + survey.survey_rule_id;
                $('#' + durationId).parent().removeClass('has-error');
            }
        };

        $scope.changeSurveyRule = function (department, survey) {
            //alert("changeSurveyRule");
            // Add to list changed department
            if ($scope.listDepartmentChanged.indexOf(department.department_code) < 0) {
                $scope.listDepartmentChanged.push(department.department_code);
            }

            if (survey.survey_rule_id != null) {
                // Key
                var keyEdit = department.department_code + '_' + survey.survey_rule_id;
                if ($scope.listEditedSurveyRule.indexOf(keyEdit) < 0) {
                    $scope.listEditedSurveyRule.push(keyEdit);
                }
            }
        };

        $scope.changeSurveyRule2 = function (department, survey) {
            // Add to list changed department
            if ($scope.listDepartmentChanged.indexOf(department.department_code) < 0) {
                $scope.listDepartmentChanged.push(department.department_code);
            }

            if (survey.survey_rule_id != null) {
                // Key
                var keyEdit = department.department_code + '_' + survey.survey_rule_id;
                if ($scope.listEditedSurveyRule.indexOf(keyEdit) < 0) {
                    $scope.listEditedSurveyRule.push(keyEdit);
                }
            }
        };

        // For create new or edit HospitalSurveyRule
        $scope.saveDepartmentSurveyRule = function () {
            // Get parameter to check
            var dept = $('#department_selected').val();
            var type = parseInt($('#question-type').val());
            var question = $('#question').val();
            var description = $('#description').val();
            var numAns = 0;
            var checked = true;



            $scope.surveyRuleList.forEach(function (value, index) {
                //alert(JSON.stringify(value));

                var survey_list = value.survey_list;
                var survey_list = value.survey_list;
                survey_list.forEach(function (survey, index_s) {
                    //alert(survey.survey_id);
                    //alert(value.);
                    survey.survey_id = $("#sendSurvey_" + survey.department_code + "_" + index_s).val();
                });
            });

            //console.log(JSON.stringify($scope.surveyRuleList));

            // Save survey setting
            var dataSurveySetting = {
                hosp_code: $scope.hospitalObj.hosp_code,
                list_survey_setting: $scope.surveyRuleList,
                list_changed_department: $scope.listDepartmentChanged,
                list_edited_survey: $scope.listEditedSurveyRule,
                list_deleted_survey: $scope.listDeletedSurveyRule
            };

            SurveysService.saveSurveySetting(dataSurveySetting, function (response) {
                if (response.success) {
                    // Reload data
                    $scope.searchDepartmentSurvey();

                    // Notify Success
                    $.gritter.add({
                        title: gettextCatalog.getString('Survey setting exit'),
                        text: gettextCatalog.getString('Create survey setting successfully'),
                        class_name: 'with-icon check-circle success'
                    });
                } else {
                    if (response.message == 'fail.input') {
                        $.gritter.add({
                            title: gettextCatalog.getString('Input data is invalid'),
                            text: gettextCatalog.getString('Input data is invalid'),
                            class_name: 'with-icon times-circle danger'
                        });
                    } else if (response.message == 'survey.setting.duplicate.duration.in.department') {
                        $.gritter.add({
                            title: gettextCatalog.getString('Input data is invalid'),
                            text: gettextCatalog.getString('Duration can not be overlapse'),
                            class_name: 'with-icon times-circle danger'
                        });
                    } else {
                        $.gritter.add({
                            title: gettextCatalog.getString('Input data is invalid'),
                            text: gettextCatalog.getString('An error occurred when saving data'),
                            //text: response.message,
                            class_name: 'with-icon times-circle danger'
                        });
                    }
                }
            });

        };

        $scope.containsObject = function (obj, list) {
            var i;
            for (i = 0; i < list.length; i++) {
                if (angular.equals(list[i], obj)) {
                    return true;
                }
            }
            return false;
        };
        $scope.confirmSettingSurrvey = function (index, department, survey) {
            $("#hd_idx").val(index);
            $("#hd_department_code").val(department.department_code);
            $("#hd_survey_rule_id").val(survey.survey_rule_id);
            $('#setting-delete').modal('show');
        };
        // For delete SendSurvey
        $scope.deleteSendSurvey = function (idx, department, survey) { //del a question
                var lsDepartChange = $scope.listDepartmentChanged;
                if ($scope.listDepartmentChanged.indexOf(department.department_code) < 0) {
                    $scope.listDepartmentChanged.push(department.department_code);
                }

                // Key
                var keyDelete = department.department_code + '_' + survey.survey_rule_id;
                if ($scope.listDeletedSurveyRule.indexOf(keyDelete) < 0) {
                    $scope.listDeletedSurveyRule.push(keyDelete);
                }
                // Remove it in listEditedSurveyRule if existing
                if ($scope.listEditedSurveyRule.indexOf(keyDelete) >= 0) {
                    var index = $scope.listEditedSurveyRule.indexOf(keyDelete);
                    $scope.listEditedSurveyRule.splice(index, 1);
                }

                $scope.surveyRuleList.forEach(function (val) {
                    if (val.department_code == department.department_code) {
                        val.survey_list.splice(idx, 1);
                    }
                });
            $('#setting-delete').modal('hide');
        };

        $scope.deleteSendSurvey2 = function () {
            var lsDepartChange = $scope.listDepartmentChanged;
            if ($scope.listDepartmentChanged.indexOf($("#hd_department_code").val()) < 0) {
                $scope.listDepartmentChanged.push($("#hd_department_code").val());
            }

            // Key
            var keyDelete = $("#hd_department_code").val() + '_' + $("#hd_survey_rule_id").val();
            if ($scope.listDeletedSurveyRule.indexOf(keyDelete) < 0) {
                $scope.listDeletedSurveyRule.push(keyDelete);
            }
            // Remove it in listEditedSurveyRule if existing
            if ($scope.listEditedSurveyRule.indexOf(keyDelete) >= 0) {
                var index = $scope.listEditedSurveyRule.indexOf(keyDelete);
                $scope.listEditedSurveyRule.splice(index, 1);
            }

            $scope.surveyRuleList.forEach(function (val) {
                if (val.department_code == $("#hd_department_code").val()) {
                    val.survey_list.splice($("#hd_idx").val(), 1);
                }
            });
            $('#setting-delete').modal('hide');
        };

        // For add setting
        $scope.addSetting = function (item) {
            $scope.surveyRuleList.forEach(function (val) {
                // Add to list changed department
                if ($scope.listDepartmentChanged.indexOf(item.department_code) < 0) {
                    $scope.listDepartmentChanged.push(item.department_code);
                }
                if (val.department_code == item.department_code) {
                    var arr = [];
                    arr = val.survey_list;

                    var survey_rule = {
                        survey_rule_id: null,
                        department_code: item.department_code,
                        department_name: item.department_name,
                        examination_type: 2,
                        duration: 0,
                        survey_id: null,
                        survey_title: null,
                        active_flg: null
                    };
                    arr.push(survey_rule);
                    val.survey_list = arr;
                }
            });

        };
    }
})();