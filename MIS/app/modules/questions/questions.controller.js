/**
 * Created by quangbv on 02/03/2016.
 */

(function () {
    'use strict';

    angular
        .module('app')
        .controller('QuestionsController', QuestionsController);

    QuestionsController.$inject = ['$scope', '$location', 'cssInjector', 'QuestionService', '$cookieStore', '$routeParams', 'DTOptionsBuilder', '$compile', 'DTColumnDefBuilder', 'gettextCatalog', '$http', '$timeout', 'localStorageService'];
    function QuestionsController($scope, $location, cssInjector, QuestionService, $cookieStore, $routeParams, DTOptionsBuilder, $compile, DTColumnDefBuilder, gettextCatalog, $http, $timeout, localStorageService) {
        cssInjector.add("css/quirk.css");
        cssInjector.add("css/custom.css");

        $scope.questionArr = [];
        $scope.answerList = [];
        $scope.departmentArr = new Object();
        $scope.dtInstance = {};
        $scope.recordsTotal = 0;
        $scope.questionObj = {};
        $scope.questionType = [];
        initController();

        function initController() {
            $.fn.dataTableExt.sErrMode = 'throw';
            var language = gettextCatalog.getCurrentLanguage();
            if (typeof(language) != 'undefined') {
                moment.locale(language);
            } else {
                moment.locale('ja');
            }
            // Get hospital information
            //var hospitalObj = $cookieStore.get('hospitalObj');
            var hospitalObj = localStorageService.get('hospitalObj');
            $scope.hospitalObj = hospitalObj.data;
            $scope.departmentList = hospitalObj.data.department_list;
            $.each($scope.departmentList, function (index, value) {
                $scope.departmentArr[value.department_code] = value;
            });

            $scope.questionType = [
                {
                    question_type: -1,
                    text: gettextCatalog.getString('All')
                },
                {
                    question_type: 0,
                    text: gettextCatalog.getString('Single choice')
                },
                {
                    question_type: 1,
                    text: gettextCatalog.getString('Multiple choice')
                },
                {
                    question_type: 2,
                    text: gettextCatalog.getString('Input text')
                }
            ];

            $scope.questionSelectList = $scope.questionType.slice(1);
            $scope.initDataTable = function (params) {
                $scope.params = params;
                //var url = '/api/questionList';
                $timeout(function () {
                    $scope.dtOptions = DTOptionsBuilder.newOptions()
                        .withOption('ajax', function (data, callback, settings) {
                            var config = {
                                headers: {
                                    //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                                    'Content-Type': 'application/json',
                                    'Accept': 'application/json'
                                },
                                unique: true
                            };
                            /*$scope.params.start = data.start;
                             $scope.params.length = data.length;
                             $scope.params.page_size = data.length;
                             $scope.params.page_index = (data.start / data.length) + 1;*/
                            /*data.order[0].column = data.columns[data.order[0].column].data;
                             $scope.params.order = data.order[0];*/

                            var order = data.order[0];

                            if (data.columns[order.column].data == 'question_content') {
                                var column = 'content';
                            } else {
                                column = data.columns[order.column].data;
                            }
                            var orderStr = '&column=' + column + '&dir=' + order.dir;
                            var page_index = (data.start / data.length) + 1;
                            var url = '/cms/questions?page_size=' + data.length + '&page_index=' + page_index + orderStr;
                            $http.post(url, $scope.params, config).then(
                                function (res) { // On success
                                    if (res.status == 0) { // If server response error
                                        var hosp_code = localStorageService.get('hosp_code');
                                        $location.path('/login?code=' + hosp_code);
                                    } else {
                                        // map your server's response to the DataTables format and pass it to
                                        // DataTables' callback
                                        var response = res.data.data;
                                        callback({
                                            recordsTotal: response.records_total,
                                            recordsFiltered: response.records_filtered,
                                            data: response.question_list
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
                        })
                        .withOption('order', [2, 'desc'])
                        .withDataProp('data')
                        .withOption('serverSide', true)
                        .withOption('processing', true)
                        .withOption('bFilter', false)
                        .withOption('bInfo', false)
                        .withOption('sDom', 't<"clearfix"<"pull-left"l><"pull-right"p>>')
                        .withOption('createdRow', function (row) {
                            // Recompiling so we can bind Angular directive to the DT
                            $compile(angular.element(row).contents())($scope);
                        })
                        .withLanguageSource('/languages/' + gettextCatalog.getCurrentLanguage() + '.json');

                    $scope.dtColumnDefs = [
                        DTColumnDefBuilder.newColumnDef(0).notSortable().renderWith(function (x, y, data) {
                            return '<label class="ckbox"><input type="checkbox"  value="' + data.question_id + '"/><span></span></label>';
                        }),
                        DTColumnDefBuilder.newColumnDef(1).renderWith(function (data, type, full, meta) {
                            return meta.row + 1 + meta.settings._iDisplayStart;
                        }).notSortable(),
                        DTColumnDefBuilder.newColumnDef(2).withOption("mData", 'department_name'),
                        DTColumnDefBuilder.newColumnDef(3).renderWith(function (x, y, data) {
                            return '<span ng-switch on="\'' + data.question_type + '\'"><span ng-switch-when="1"><translate>Multiple choice</translate></span><span ng-switch-when="2"><translate>Input text</translate></span><span ng-switch-default><translate>Single choice</translate></span></span>';
                        }).withOption("mData", 'question_type'),
                        DTColumnDefBuilder.newColumnDef(4).withTitle(gettextCatalog.getString('Question')).withOption("mData", 'question_content'),
                        DTColumnDefBuilder.newColumnDef(5).renderWith(function (x, y, data) {
                            return '<a class="btn btn-warning btn-xs btn-block" ng-click="editQuestion(\'' + data.question_id + '\')"><translate>Edit</translate></a>';
                        }).notSortable(),
                        DTColumnDefBuilder.newColumnDef(6).renderWith(function (x, y, data) {
                            return '<button class="btn btn-success btn-xs btn-block" data-toggle="modal" ng-click="viewDetail(\'' + data.question_id + '\')"><translate>View</translate></button>';
                        }).notSortable()
                    ];
                }, 1000);
            }


            if ($location.path() == '/questions/create') { // For create question
            } else if ($location.path() == '/questions/edit/' + $routeParams.id) { // For edit question
                var cookie = $cookieStore.get('globals');
                $.ajax({
                    url: 'cms/question/' + $routeParams.id,
                    type: 'GET',
                    headers: {
                        token: cookie.currentUser.token
                    },
                    async: false,
                    success: function (response) {
                        var data = response.data;
                        if (response.status == 1) {
                            $scope.department_code = data.department_code;
                            $scope.question_type = data.question_type;
                            $scope.questionObj.question_type = 0;
                            $scope.questionObj = data;
                            $scope.answerList = data.answer_list;
                            if($scope.question_type== 2)
                            {
                                $('.pull-left').hide();
                                $('#addAnswer').hide();
                            }
                            else {
                                $('.pull-left').show();
                                $('#addAnswer').show();
                            };
                            // Set is_correct to true | false to use for ng-modal
                            /*$.each($scope.answerList, function (index, value) {
                                value.is_correct = (value.is_correct == 1) ? true : false;
                            });*/
                        }
                    },
                    error: function (response) {
                        //$location.path('/');
                    }
                });
            } else if ($location.path() == '/questions/list') { // For listing page
                var params = {};
                $scope.initDataTable(params);
            }

            // For click change limit answer
            $('#limit_answer').on('change', function () {
                //$scope.question_type = $('#limit_answer').val();
                if ($('#limit_answer').val() < $scope.answerList.length) {
                    $scope.answerList = $scope.answerList.slice(0, $('#limit_answer').val());
                    $scope.$apply();
                }
            });
        }

        // For view detail question (Click view icon)
        $scope.viewDetail = function (item) {
            QuestionService.getDetailQuestion(item).then(function (res) {
                if (res.status == 1) {
                    $scope.questionObj = res.data;
                    $('#question-title').text('');
                    $('#question-title').append($scope.questionObj.question_content + '<br><div style="font-size: 12px;color: #FFFFFF;">' + $scope.questionObj.description + '</div>');
                    $('#question-popup ul.box-list-item').html('');
                    if($scope.questionObj.question_type!=2)
                    {
                        $.each($scope.questionObj.answer_list, function (index, value) {
                            if ($scope.questionObj.question_type == 1) { // Checkbox
                                $('#question-popup ul.box-list-item').append('<li><label class="ckbox"><input type="checkbox" disabled="disable" />&nbsp;<span class="item_name">' + value.title + '</span></label></li>');
                            } else if ($scope.questionObj.question_type == 0) { // Radio
                                $('#question-popup ul.box-list-item').append('<li><label class="rdio form-control"><input type="radio" disabled="disable" />&nbsp;<span class="item_name">' + value.title + '</span></label></li>');
                            }
                        });
                    }
                    else
                    {
                        $('#question-popup ul.box-list-item').append('<li><label class="rdio form-control">&nbsp;<span class="item_name"></span></label></li>');
                    }


                    if ($scope.questionObj.has_other_answer == true) {
                        var text = 'Input other answer';
                        $('#question-popup ul.box-list-item').append('<li><input type="text" class="form-control" disabled="disabled" placeholder="' + gettextCatalog.getString(text) + '"/></li>');
                    }

                    // For filtering on list quesion
                    $("#filter").bind("keyup", function () {
                        var text = $(this).val().toLowerCase();
                        var items = $(".item_name");

                        //first, hide all:
                        items.parent().parent().hide();

                        //show only those matching user input:
                        items.filter(function () {
                            return $(this).text().toLowerCase().indexOf(text) > -1;
                        }).parent().parent().show();
                    });

                    $('#question-popup').modal('show');
                }
            });
        };

        $scope.checkAll = function () {
            if ($('#checkAll').is(':checked')) {
                $('#question_list input:checkbox').prop('checked', true);
            } else {
                $('#question_list input:checkbox').prop('checked', false);
            }

        };

        /**
         * For click "Search now" button
         */
        $scope.searchQuestion = function () {
            // Refresh data
            //if($scope.dtInstance) {$scope.dtInstance.rerender();}

            // Set parameters
            var params = {};
            if ($('#title').val() != '') {
                params.question_content = $('#title').val();
            }
            if ($('#select2').val() != '' && $('#select2').val() != -1) {
                params.question_type = $('#select2').val();
            }
            if ($('#select1').val() != '' && $('#select1').val() != -1) {
                params.department_code = $('#select1').val();
            }

            $scope.initDataTable(params);

            // Refresh data
            if ($scope.dtInstance) {
                $scope.dtInstance.rerender();
            }
        };

        $scope.confirmQuestion = function () {
            $('#question-delete').modal('show');
        };

        /**
         * Delete question from list page
         */
        $scope.deleteQuestion = function () {
            var ids = [];
            $.each($("#question_list_wrapper tbody input:checked"), function () {
                ids.push({id: $(this).val()});
            });
            QuestionService.DeleteQuestion(ids, function (response) {
                if (response.success) {
                    // Success
                    $.gritter.add({
                        title: gettextCatalog.getString('Delete Question'),
                        text: gettextCatalog.getString('Delete question successful.'),
                        class_name: 'with-icon check-circle success'
                    });

                    if ($scope.dtInstance) {
                        $scope.dtInstance.rerender();
                    }
                    $('#question-delete').modal('hide');
                } else {
                    $.gritter.add({
                        title: gettextCatalog.getString('Delete Question'),
                        text: response.message,
                        class_name: 'with-icon times-circle danger'
                    });
                }
            });
        };

        // Add 
        $scope.addOption = function () {
            var idx = 0;
            if ($('#question-type').val() == 0) {
                var obj = {
                    type: 'radio',
                    name: 'rdio',
                    title: '',
                    is_correct: false
                }
            } else  if ($('#question-type').val() == 1) {
                var obj = {
                    type: 'checkbox',
                    name: 'rdio',
                    title: '',
                    is_correct: false
                }
            }
            else {
                var obj = {
                    type: 'textarea',
                    name: 'txtArea',
                    title: '',
                    is_correct: false
                }
            }

            if ($scope.answerList.length >= limitAnswer) {
                var msg = 'Please enter no more than 10 answers';
                $.gritter.add({
                    title: gettextCatalog.getString('Create question'),
                    text: gettextCatalog.getString(msg),
                    class_name: 'with-icon times-circle danger'
                });
                return;
            }
            obj.sequence = $scope.answerList.length + 1;
            $scope.answerList.push(obj);
            $scope.answerList.forEach(function (value, index) {
                idx = index;
            });
            setTimeout(function () {
                $('#input-answer' + idx).focus();
            }, 100);
        };

        // Remove an answer from list
        $scope.removeAnswer = function (id) {
            if (id > -1) {
                $scope.answerList.splice(id, 1);
            }
            $('#answer_item' + id).remove();

            // Update index
            $.each($scope.answerList, function (index, value) {
                value.sequence = index + 1;
            });
        };

        // Click change question type
        $scope.changeType = function () {

            $scope.answerList = [];
            $('#question-type').next().removeClass('errorMsg');
            if($scope.selectedType == 2 || $scope.question_type == 2)
            {
                $('.pull-left').hide();
                $('#addAnswer').hide();
                $('#table-answer').hide();
            }
            else {
                $('.pull-left').show();
                $('#addAnswer').show();
                $('#table-answer').show();
            }
        };

        $scope.changeDepartment = function () {
            $('#department-select').next().removeClass('errorMsg');
        };

        // Create new or edit question
        $scope.saveQuestion = function () {
            // Get parameter to check
            var dept = $('#department-select').val();
            var deptName = $('#department-select :selected').text();
            var type = parseInt($('#question-type').val());
            var question = $('#question').val();
            var description = $('#description').val();
            var numAns = 0;

            if (dept == '') {
                $.gritter.add({
                    title: gettextCatalog.getString('Create question'),
                    text: gettextCatalog.getString('Department') + ' ' + gettextCatalog.getString('cannot be empty!'),
                    class_name: 'with-icon times-circle danger'
                });
                if ($scope.createQuestionForm.departmentQuestion.$error.required) {
                    $scope.createQuestionForm.departmentQuestion.$pristine = false;
                }
                $('#department-select').focus();
            } else if (isNaN(type)) {
                $.gritter.add({
                    title: gettextCatalog.getString('Create question'),
                    text: gettextCatalog.getString('Question type') + ' ' + gettextCatalog.getString('cannot be empty!'),
                    class_name: 'with-icon times-circle danger'
                });
                if ($scope.createQuestionForm.typeQuestion.$error.required) {
                    $scope.createQuestionForm.typeQuestion.$pristine = false;
                }
            } else if (question == '') {
                if ($scope.createQuestionForm.contentQuestion.$error.required) {
                    $scope.createQuestionForm.contentQuestion.$pristine = false;
                }
                $.gritter.add({
                    title: gettextCatalog.getString('Create question'),
                    text: gettextCatalog.getString('Question') + ' ' + gettextCatalog.getString('cannot be empty!'),
                    class_name: 'with-icon times-circle danger'
                });
                $('#question').focus();
            } else {
                if (question.length <= 0 || question.length > 256) {
                    return;
                }

                if (description.length > 512) {
                    return;
                }
                // If data is validated
                if ($scope.answerList.length < 1) {
                    // Check if does not have any answer => must have to have other answer
                    if(type != 2)
                    {
                        $.gritter.add({
                        title: gettextCatalog.getString('Question'),
                        text: gettextCatalog.getString('Question must have at least one answer'),
                        class_name: 'with-icon times-circle danger'
                        });
                        return false;
                    }
                    //}
                }

                var checked = true;
                if(type !=2) {
                    $.each($scope.answerList, function (index, value) {
                        if (value.title == '' || typeof (value.title) == 'undefined' || value.title.length > 128) {
                            checked = false;
                            numAns++;
                            $('#input-answer' + index).parent().addClass('has-error');
                            $('#input-answer' + index).focus();
                        } else {
                            $('#input-answer' + index).parent().removeClass('has-error');
                        }
                    });

                    if (numAns > 0) {
                        $.gritter.add({
                            title: gettextCatalog.getString('Edit question'),
                            text: gettextCatalog.getString('Missing required fields') + "<br>" + gettextCatalog.getString('Please enter answer for this question'),
                            class_name: 'with-icon times-circle danger'
                        });
                        return;
                    }
                }
                // If question has all information then set parameters
                if (checked) {
                    $scope.questionObj.hosp_code = $scope.hospitalObj.hosp_code;
                    $scope.questionObj.department_code = dept;
                    $scope.questionObj.department_name = deptName;
                    $scope.questionObj.question_type = type;
                    $scope.questionObj.question_content = question;
                    $scope.questionObj.description = description;
                    if ($('#has_other_answer').is(':checked')) {
                        $scope.questionObj.has_other_answer = true;
                    } else {
                        $scope.questionObj.has_other_answer = false;
                    }

                    $scope.questionObj.limit_answer = parseInt($('#limit_answer').val());

                    // Delete unused option
                    var newObject = JSON.parse(JSON.stringify($scope.answerList));
                    // Change data type
                    $.each(newObject, function (index, value) {
                        // Re-set is_correct value to 1 | 0
                        if (value.is_correct) {
                            value.is_correct = 1;
                        } else {
                            value.is_correct = 0;
                        }
                        delete value.name;
                        delete value.type;
                        delete value.checked;
                    });
                    $scope.questionObj.answer_list = newObject;

                    $('#btnSave').prop('disabled', true);
                    QuestionService.createQuestion($scope.questionObj, function (response) {
                        if (response.success) {
                            // Success
                            $.gritter.add({
                                title: gettextCatalog.getString('Save question'),
                                text: gettextCatalog.getString('Question was saved successful.'),
                                class_name: 'with-icon check-circle success'
                            });
                            $location.path('questions/list');
                        } else {
                            $.gritter.add({
                                title: gettextCatalog.getString('Delete'),
                                text: response.message,
                                class_name: 'with-icon times-circle danger'
                            });
                        }
                        $('#btnSave').prop('disabled', false);
                    });
                }
            }
        };

        // If question type is radio
        $scope.setCorrectAnser = function (idx) {
            if ($('#question-type').val() == 0) {
                $.each($scope.answerList, function (index, value) {
                    value.is_correct = 0;
                });
                $scope.answerList[idx].is_correct = 1;
                $('#radio' + idx).prop('checked', true);
            }
            $scope.answerList[idx].checked = 1;
        };

        $scope.editQuestion = function (item) {
            $location.path('/questions/edit/' + item);
        };

        $scope.validateAnswer = function (idx) {
            if ($('#input-answer' + idx).val() != '' || $('input-answer' + idx).val() != null) {
                $('#input-answer' + idx).parent().removeClass('has-error');
            } else {
                $('#input-answer' + idx).parent().addClass('has-error');
            }
        }
    }
})();