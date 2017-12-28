(function () {
    'use strict';

    angular
        .module('app')
        .controller('PatientSurveyController', PatientSurveyController);

    PatientSurveyController.$inject = ['$document', '$rootScope', '$route', '$scope', '$routeParams', 'cssInjector', '$location', 'PatientSurveysService', 'DTOptionsBuilder', '$compile', 'DTColumnDefBuilder', 'gettextCatalog', '$http', '$timeout', 'localStorageService', '$cookieStore', '$interval', 'PatientService'];
    function PatientSurveyController($document, $rootScope, $route, $scope, $routeParams, cssInjector, $location, PatientSurveysService, DTOptionsBuilder, $compile, DTColumnDefBuilder, gettextCatalog, $http, $timeout, localStorageService, $cookieStore, $interval, PatientService) {

        $('body').removeClass('signwrapper');
        //var hospitalObj = localStorageService.get('hospitalObj');
        var localeKey = null;
        var hospCodeKey = null;
        var hospNameKey = null;
        var hospAddKey = null;

        cssInjector.add("css/quirk.css");
        cssInjector.add("css/custom.css");

        // Clear localStorageService
        localStorageService.remove('hosp_code');
        localStorageService.remove('hospitalObj');

        var existHospital = false;
        var link = document.createElement("script");
        link.type = "text/javascript";
        link.src = fontVn;
        document.getElementsByTagName("head")[0].appendChild(link);

        //$scope.hospitalObj = hospitalObj.data;
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

            // Call MIS api get Hospital Info
            var url = '/cms/hospital/search_token?token=' + $routeParams.patient_sid;
            $http.get(url).then(function (res) {

                // Get locale
                gettextCatalog.setCurrentLanguage(res.data.data.locale.toLowerCase());
                $rootScope.langGlobal = gettextCatalog.getCurrentLanguage();
                var language = gettextCatalog.getCurrentLanguage();
                if (typeof(language) != 'undefined') {
                    moment.locale(language);
                } else {
                    moment.locale('ja');
                }

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

                $scope.healthStatus = [
                    {
                        value: 0,
                        text: gettextCatalog.getString('Waiting')
                    },
                    {
                        value: 1,
                        text: gettextCatalog.getString('Finished')
                    }
                ];
                // Handle for department
                $scope.selectedId = '';
                $scope.selectedType = '0';
                $scope.hopspital_code_common = res.data.data.hosp_code;
                $scope.hopspital_name_common = res.data.data.hosp_name;
                $scope.hopspital_address_common = res.data.data.address;

                // Add hospital info
                hospCodeKey = res.data.data.hosp_code;
                hospNameKey = res.data.data.hosp_name;
                hospAddKey = res.data.data.address;

                if(res.data.data.locale.toLowerCase() == 'ja'){
                    localeKey = 'ja';
                    var link = document.createElement("script");
                    link.type = "text/javascript";
                    link.src = fontJa;
                    document.getElementsByTagName("head")[0].appendChild(link);
                } else if(res.data.data.locale.toLowerCase() == 'vi'){
                    localeKey = 'vi';
                    var link = document.createElement("script");
                    link.type = "text/javascript";
                    link.src = fontVn;
                    document.getElementsByTagName("head")[0].appendChild(link);
                } else {
                    localeKey = 'en';
                    var link = document.createElement("script");
                    link.type = "text/javascript";
                    link.src = fontVn;
                    document.getElementsByTagName("head")[0].appendChild(link);
                }

                $scope.previous_steps = gettextCatalog.getString("Previous");
                $scope.next_steps = gettextCatalog.getString("Next");
                $scope.answer_title = gettextCatalog.getString('Answer Survey');

                $('.actions > ul > li:first-child a').text($scope.previous_steps);
                $('.actions > ul > li:last-child a').text($scope.next_steps);
                $scope.main_title = $scope.answer_title;
                $document.title = $scope.answer_title;

                $scope.confirm_title = gettextCatalog.getString('Confirm result');
                $scope.agreement_title = gettextCatalog.getString('User agreement term');
                $scope.completed_title = gettextCatalog.getString('Completed');
                $scope.exit_title = gettextCatalog.getString('Interview Exit');
                $scope.main_title = $scope.answer_title;

                if ($location.path() == '/patient/do-survey-only-mt/' + $routeParams.patient_sid) { // For do survey page
                    $scope.missing_answer = gettextCatalog.getString('Missing answer');
                    $scope.missing_answer_text = gettextCatalog.getString('Please answer all required questions.');
                    $scope.accept_term = gettextCatalog.getString('User agreement term');
                    $scope.accept_term_text = gettextCatalog.getString('You must accept the agreement.');
                    // Get detail about survey
                    PatientSurveysService.doSurvey($routeParams.patient_sid).then(function (res) {
                        if (res.status == 1) {

                            // If branching then switch do_survey_only_mt_branching
                            if(res.data.survey_information != undefined && res.data.survey_information.survey_type != undefined && res.data.survey_information.survey_type == 2) {
                                $location.path('/patient/do-survey-only-mt-branching/' + $routeParams.patient_sid);
                            }

                            $scope.surveyObj = res.data;

                            if ($scope.surveyObj.survey_status == 1) {
                                $.gritter.add({
                                    title: gettextCatalog.getString('Do survey'),
                                    text: gettextCatalog.getString('Survey already was done.'),
                                    class_name: 'with-icon check-circle warning'
                                });
                                $location.path('/patient');
                            } else {
                                res.data.reservation_date = $scope.formatDateByLang(res.data.reservation_date);
                                res.data.answer_date = $scope.formatDateByLang(res.data.answer_date);
                                $.each($scope.surveyObj.survey_information.question_group, function (index, value) {
                                    $.each(value.question_list, function (idx, val) {
                                        $.each(val.answer_list, function (i, v) {
                                            v.is_selected = false;
                                        });
                                    });
                                    //value.is_selected = (value.is_selected == 1) ? true : false;
                                });
                            }
                        } else {
                            $location.path('/patient');
                        }
                    });
                } else if ($location.path() == '/patient/list_waiting') {
                    $scope.selectedId = '-1';
                }

            }, function (res) {
            });

        }

        /**
         * Parse data before answer survey
         */
        $scope.finishedSurvey = function () {
            $scope.saveSurveyObj = {};
            $scope.question_group = {};

            //Token
            $scope.saveSurveyObj.token = $routeParams.patient_sid;

            $scope.saveSurveyObj.hosp_code = $scope.surveyObj.survey_information.hosp_code;
            $scope.saveSurveyObj.patient_code = $scope.surveyObj.patient_code;
            $scope.saveSurveyObj.patient_survey_id = $scope.surveyObj.survey_patient_id;
            $scope.question_group.survey_title = $scope.surveyObj.survey_information.survey_title;
            $scope.question_group.description = $scope.surveyObj.survey_information.description;
            $scope.question_group.group = $scope.surveyObj.survey_information.question_group;
            $.each($scope.question_group.group, function (index, value) {
                value.id = value.group_id;
                delete value.group_id;
                value.question = value.question_list;
                delete value.question_list;
                $.each(value.question, function (i, v) {
                    v.answer = v.answer_list;
                    delete v.answer_list;
                        $.each(v.answer, function (i1, v1) {
                            v1.is_selected = (v1.is_selected) ? 1 : 0;
                            v1.id = v1.answer_id;
                            delete v1.answer_id;
                            v1.content = v1.title;
                            delete v1.title;
                        });
                    // Fix bug MED-13160
                    if (typeof(v.has_other_text) == 'undefined') {
                        v.has_other_text = null;
                    }
                });
            });
            //Add agreement flag
            if ($('#agreeTerm').is(':checked')) {
                $scope.saveSurveyObj.agreement_flg = 1;
            } else {
                $scope.saveSurveyObj.agreement_flg = 0;
            }
            $scope.saveSurveyObj.question_group = $scope.question_group;
            PatientSurveysService.doneSurvey($scope.saveSurveyObj, function (response) {
                if (response.success) {
                    // Success
                    $.gritter.add({
                        title: gettextCatalog.getString('Interview Exit'),
                        text: gettextCatalog.getString('Thanks you for completed our health survey'),
                        class_name: 'with-icon check-circle success'
                    });
                } else {
                    if (response.message == 'fail.input') {
                        $.gritter.add({
                            title: gettextCatalog.getString('Interview Exit'),
                            text: gettextCatalog.getString('Error'),
                            class_name: 'with-icon times-circle danger'
                        });
                    } else {
                        $.gritter.add({
                            title: gettextCatalog.getString('Interview Exit'),
                            text: gettextCatalog.getString('Error'),
                            class_name: 'with-icon times-circle danger'
                        });
                    }
                }
            });
        };

        /**
         * Define template PDF file Phr
         * @param item
         */
        $scope.exportPhr = function (item) {
            //var hospitalObj = localStorageService.get('hospitalObj');
            var fontDefault = null;
            var noteText = '';
            if (localeKey.toLowerCase() == 'ja') {
                noteText = 'Karte.clinic　カルテ参照サービスのご案内\n\nKarte.clinicのご利用ありがとうございます。以下のID/パスワードをご利用いただくことで、他医院へのカルテ情報連携サービスや\nご自身のカルテ情報閲覧サービスをご利用いただくことができます。\n\n個人情報が含まれますので　大切に保管ください。';
                fontDefault = 'MS PGothic';
            } else if (localeKey.toLowerCase() == 'vi') {
                noteText = 'Hướng dẫn các dịch vụ tham khảo y tế Karte.Clinic \n Cám ơn bạn đã ghé thăm karte.clinic. ID và mật khẩu dưới đây, bạn có thể sử dụng dịch vụ của y tế cá nhân và dịch vụ thông tin y tế của phòng khám khác. \n\n Hãy giữ, bởi vì nó có chứa thông tin cá nhân.';
                fontDefault = 'Times New Roman';
            } else {
                noteText = 'Guide of Karte.Clinic medical reference services\n\nThank you for visiting karte.clinic.By using the ID and password below, you can use your own medical service and \n medical information services of other clinics.\n\nPlease keep, because it contains personal information.';
                fontDefault = 'Times New Roman';
            }
            $('#phr_' + item).hide();
            $('#phr_' + item).after('<img id="loading_icon" src="/images/loading_729.gif" width="28px" style="margin-left: 35px;"/>');
            PatientSurveysService.exportPhrByToken(item, $routeParams.patient_sid).then(function (res) {
                $('#loading_icon').remove();
                $('#phr_' + item).show();
                if (res.status == 1) {
                    $scope.phrAccount = res.data;
                    var dd = {
                        info: {
                            title: 'PHR account',
                            author: 'MED CMS',
                            subject: 'Your PHR account'
                            //keywords: 'keywords for document',
                        },
                        pageSize: 'A4',
                        pageMargins: 72,
                        //headerRows: 1,
                        widths: ['*', 'auto', 100, '*'],
                        header: function (currentPage, pageCount) {
                            if (typeof($scope.hospitalLogo) != 'undefined') {
                                return {
                                    columns: [
                                        {
                                            text: (hospNameKey == null) ? ' ' : hospNameKey,
                                            style: 'header',
                                            decoration: 'underline',
                                            width: 250
                                        },
                                        {
                                            image: $scope.hospitalLogo,
                                            //margin: [65-(pageCount)*5, 5, 5, 5],
                                            margin: [0, 20, 20, 0],
                                            fit: [120, 120],
                                            alignment: 'right'
                                        }
                                    ],
                                    font: fontDefault
                                };
                            } else {
                                return {
                                    columns: [
                                        {
                                            text: hospNameKey,
                                            style: 'header',
                                            decoration: 'underline',
                                            width: 250
                                        },
                                    ],
                                    font: fontDefault
                                };
                            }
                        },
                        footer: function (currentPage, pageCount) {
                            return {
                                stack: [
                                    {text: (currentPage == pageCount) ? gettextCatalog.getString('Thank you for your cooperation.'):'' , alignment: 'right', fontSize: 10, margin: [0, 0, 30, 0]},
                                    {canvas: [{type: 'line', x1: 30, y1: 5, x2: 580, y2: 5, lineWidth: 0.2}]},
                                    {text: (hospNameKey == null) ? ' ' : hospNameKey, alignment: 'right', fontSize: 10, color: '#0000ff', margin: [0, 0, 30, 0]},
                                    {text: (hospAddKey == null) ? ' ' : hospAddKey, fontSize: 10, alignment: 'right', margin: [0, 0, 30, 0]}

                                ],
                                font: fontDefault
                            };
                        },
                        defaultStyle: {
                            //font: 'ipam',
                            font: fontDefault
                        },
                        content: [
                            {
                                text: gettextCatalog.getString('Patient account information'),
                                fontSize: 24,
                                margin: [0, 50, 0, 20],
                                alignment: 'center',
                                font: fontDefault
                            },
                            {
                                table: {
                                    widths: [150, 150],
                                    headerRows: 2,
                                    // keepWithHeaderRows: 1,
                                    body: [
                                        [{text: gettextCatalog.getString('Patient code'), font: fontDefault}, ($scope.phrAccount.patien_id == null) ? '' : $scope.phrAccount.patien_id],
                                        [{text: gettextCatalog.getString('Patient name'), font: fontDefault}, ($scope.phrAccount.patient_name == null) ? '' : $scope.phrAccount.patient_name],
                                        [{text: gettextCatalog.getString('Answered date'), font: fontDefault}, ($scope.phrAccount.answer_date == null) ? '' : $scope.phrAccount.answer_date]
                                    ],
                                    font: fontDefault
                                },
                                margin: [65, 0, 0, 0]
                            },

                            {
                                text: gettextCatalog.getString('PHR account'),
                                fontSize: 14,
                                color: '#ff0000',
                                margin: [0, 50, 0, 5],
                                alignment: 'left',
                                font: fontDefault
                            },
                            {
                                canvas: [{type: 'line', x1: 0, y1: 5, x2: 500, y2: 5, lineWidth: 1}],
                                margin: [0, 0, 0, 30]
                            },
                            {
                                stack: [
                                    {
                                        columns: [
                                            {
                                                text: gettextCatalog.getString('Hospital'),
                                                font: fontDefault
                                            },
                                            {
                                                text: ($scope.phrAccount.hosp_code == null) ? '' : $scope.phrAccount.hosp_code
                                            }
                                        ],
                                        margin: [20, 0, 0, 10],
                                        font: fontDefault
                                    },
                                    {
                                        columns: [
                                            {
                                                text: gettextCatalog.getString('Patient code'),
                                                font: fontDefault
                                            },
                                            {
                                                text: ($scope.phrAccount.patien_id == null) ? '' : $scope.phrAccount.patien_id
                                            }
                                        ],
                                        margin: [20, 0, 0, 10],
                                        font: fontDefault
                                    },
                                    {
                                        columns: [
                                            {
                                                text: gettextCatalog.getString('Password'),
                                                font: fontDefault
                                            },
                                            {
                                                text: ($scope.phrAccount.password == null) ? '' : $scope.phrAccount.password
                                            }
                                        ],
                                        margin: [20, 0, 0, 10],
                                        font: fontDefault
                                    }
                                ]
                            },
                            {
                                text: gettextCatalog.getString('Note'),
                                fontSize: 14,
                                color: '#ff0000',
                                margin: [0, 50, 0, 5],
                                alignment: 'left',
                                font: fontDefault
                            },
                            {
                                canvas: [{type: 'line', x1: 0, y1: 5, x2: 500, y2: 5, lineWidth: 1}],
                                margin: [0, 0, 0, 30]
                            },
                            {
                                text: noteText,
                                lineHeight: 2,
                                margin: [20, 0, 30, 0],
                                font: fontDefault
                            }
                        ],
                        styles: {
                            header: {
                                fontSize: 15,
                                bold: true,
                                alignment: 'left',
                                margin: [40, 20, 0, 0]
                            },
                            subheader: {
                                fontSize: 14
                            },
                            superMargin: {
                                margin: [20, 0, 40, 0],
                                fontSize: 15
                            },
                            vnfont: {
                                font: "Times New Roman"
                            },
                            jpfont: {
                                font: "MS PGothic"
                            }
                        }
                    };

                    pdfMake.fonts = {
                        Roboto: {
                            normal: 'Roboto-Regular.ttf',
                            bold: 'Roboto-Medium.ttf',
                            italics: 'Roboto-Italic.ttf',
                            bolditalics: 'Roboto-Italic.ttf'
                        },
                        /*ipam: {
                         normal: 'ipam.ttf',
                         bold: 'ipam.ttf',
                         italics: 'ipam.ttf',
                         bolditalics: 'ipam.ttf'
                         }*/
                        "Times New Roman": {
                            normal: 'times.ttf',
                            bold: 'times.ttf',
                            italics: 'times.ttf',
                            bolditalics: 'times.ttf'
                        },
                        "MS PGothic": {
                            normal: 'mspgothic.ttf',
                            bold: 'mspgothic.ttf',
                            italics: 'mspgothic.ttf',
                            bolditalics: 'mspgothic.ttf'
                        }
                    };
                    pdfMake.createPdf(dd).download(hospCodeKey  + '_' + $scope.phrAccount.patien_id + '_account.pdf');
                }
            });
        };

        /**
         * Define template PDF patient survey.
         * @param patient_survey_id
         */
        $scope.exportPdf = function (patient_survey_id) {
            var fontDefault = null;
            var fontFlg = 1;

            /*var link = document.createElement("script");
            link.type = "text/javascript";
            link.src = fontVn;
            document.getElementsByTagName("head")[0].appendChild(link);*/
            /**
             * Check locale to set font of PDF file.
             */
            if (localeKey.toLowerCase() == 'ja') {
                fontFlg = 2;
                fontDefault = 'MS PGothic';
            } else if (localeKey.toLowerCase() == 'vi') {
                fontFlg = 1;
                fontDefault = 'Times New Roman';
            }

            var hospCode = null;
            var hospName = null;
            var hospAdd = null;
            var hospLocale = null;

            var patientCode = null;
            var patientName = null;
            var answerDate = null;
            var surveyTitle = null;
            var hospitalLogo = null;

            /**
             * Get data from API to generate PDF
             */
            PatientSurveysService.getDetailPatientSurveyByToken(patient_survey_id, $routeParams.patient_sid).then(function (res) {

                // If can not obtain data => redirect to patient's survey page
                if (res.status != 1) {
                    $location.path('/patient');
                } else {
                    $scope.surveyObjPdf = res.data;
                    var stack = [];

                    // Hospital data
                    hospCode = $scope.surveyObjPdf.hospital_info.hosp_code;
                    hospName = $scope.surveyObjPdf.hospital_info.hosp_name;
                    hospAdd = $scope.surveyObjPdf.hospital_info.address;
                    hospLocale = $scope.surveyObjPdf.hospital_info.locale;
                    hospitalLogo = $scope.surveyObjPdf.hospital_info.logo;

                    patientCode = $scope.surveyObjPdf.patient_code;
                    patientName = $scope.surveyObjPdf.patient_name;
                    answerDate = $scope.surveyObjPdf.answer_date;
                    surveyTitle = $scope.surveyObjPdf.survey_title;
                    // hoanpc add
                    $scope.getDataUri($scope.surveyObjPdf.hospital_info.logo, function (dataUri) {
                        $scope.hospitalLogo = dataUri;
                    });

                    $.each($scope.surveyObjPdf.group, function (index, value) {
                        stack.push({canvas: [{type: 'line', x1: 0, y1: 5, x2: 455, y2: 5, lineWidth: 1}]});
                        stack.push(
                            {
                                text: (value.title == null) ? ' ' : $scope.cutInUTF8(value.title, 35, fontFlg),
                                fontSize: 14,
                                bold: true,
                                margin: [0, 10, 0, 5],
                                alignment: 'left',
                                font: fontDefault
                            }
                        );
                        stack.push({canvas: [{type: 'line', x1: 0, y1: 5, x2: 455, y2: 5, lineWidth: 1}]});

                        $.each(value.question, function (idx, val) {
                            // using internal functions, but is not very fast due to try/catch
                            stack.push(
                                {
                                    text: (val.question_content == null) ? '' : $scope.cutInUTF8(val.question_content, 40, fontFlg),
                                    fontSize: 12,
                                    margin: [30, 20, 0, 10],
                                    color: '#ff0000',
                                    alignment: 'left',
                                    font: fontDefault

                                }
                            );

                            $.each(val.answer, function (i, v) {
                                if (val.question_type == '1') {
                                    if (v.is_selected == 1) {
                                        stack.push(
                                            {
                                                columns: [
                                                    {
                                                        // you can also fit the image inside a rectangle
                                                        image: 'data:image/png;base64,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',
                                                        width: 20,
                                                        fit: [14, 14],
                                                        margin: [40, 0, 20, 0]
                                                    },
                                                    {
                                                        text: (v.content == null) ? ' ' : $scope.cutInUTF8(v.content, 35, fontFlg),
                                                        margin: [45, 0, 0, 0]
                                                    }
                                                ],
                                                font: fontDefault
                                            }
                                        );
                                    } else {
                                        stack.push(
                                            {
                                                columns: [
                                                    {
                                                        // you can also fit the image inside a rectangle
                                                        image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAALUAAAC5CAMAAABZT47gAAAAeFBMVEX///8AAADNzc2UlJRFRUVYWFiPj4/T09P19fVOTk7x8fH5+fmysrLs7Ox7e3v4+PiJiYklJSVwcHC6uroWFhafn5+BgYHExMSnp6ehoaE2Njbb29saGhovLy9NTU1DQ0NdXV1mZmYNDQ1sbGzl5eUqKioSEhIhISGzrm8qAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4AQOCAM2JUv3MwAAA8RJREFUeNrtne1yqkAMhtkFYdEVBbUoaNVK2/u/w9P2fNS2ZHdRYeOZ9/0JOPNMDEk2zCRBAPHTtJZyrcO4D620lrJWtwVudLZfiv71GsWL8W1MrE9DAH+qysrJdcgzPRIe9FSUVzhGJrxpGU4vYpap8Kui6cxc+2Z+V9bN3tNC8FDYAVoLNtomjsxqJDhp7gS9EMyUO7yVK8FP0gZ9Ehy1MUOngqeMsWQvuCq+P0sbrb0XnEVYOxO8tbiXkPdVdUuJxx5aPP0456gX/tRi9J26EPcg/RW6dDtgVLtRL0qrndt//cVHJtbfbIt1Mu21c9Ekq6OV+nD+i9B2qJDD9FxmpS3RnZXbyvzkSgXDyXLEfvx8cm608zgYVvWjU9U6NvmzDIbX2tTk+fvQxhAhVeBD9Ys9Q+5o7/DVCp1FNibJD/otFtPOPft44MgQ2uQBHwlyQt1NPffLjdVIYv4n/In03PdGcdylCB9UmSFkR45V4fBSdDdK2RO+N4WkQWtLCvIpImkvZ1T/VLP47naiquzQofz2pgX1Oh5ar0c8vnESLrImQkjB5NPsc3vBH+TEdR46Et2zV6YpxpRosuDCPrdX6oI5dUzUdbypQyLCgRrUoAY1qEENalCDGtSgBjWoQQ1qUIMa1KAGNahBDWpQgxrUoAY1qEENalCDGtSgBjWoQQ1qUIMa1KAGNahBDWpQgxrUoAY1qEENalCDGtSgBjWoQf2/UO+ZUz+00p2C9jlnJRPqjKDOiWkoPFQQ80Oq1usPTKj3BHX7oMcjD2hixtqG8HcxYUFNzFhbUNMSE8aBTzTU/FceQ4i27XCKHJWpGEATFt2/OXz7ECLHNQH9KqL9gJprPPUOTW1O0IZ7qW9ocqLu+9aFhrrpOz8eCa78425FYfstRsgxwL+n6dPzbX0GbXrvSm32H58FK23KkbGw+pM7mbnH55TGhH7ET/E3Ns3u/lchmQZOVzWbOH32LtqM/ZaKhs03SWSkOStGD8LMPVwwKS3rj843zdTCoudwAPBZmdlm+W8dzsLfUnwWay2TPlTq9byoHBhKp0qWmb5X/fIeoJfKrV/CSy2F0SN76LZtPoq7a7d3Oxre0DsiXrJ+I/Nxx6YJC2hDW0nen6WdUrsfVZYGXvPMEPp0+dHYn8Lrjmx+5Hh4bTgtvCvce9JstsdtO/VkxjxW9W26Hixq/2/l/JJudOO1eN1evM9LbSJPzIfr2kfNqhoceaRv8KGiKR+GW1h6COXtVoCoZrGZp+lr/tTPgTDfpYd4XU59bz2CfugXlVNVBJHX5EYAAAAASUVORK5CYII=',
                                                        width: 20,
                                                        fit: [14, 14],
                                                        margin: [40, 0, 20, 0]
                                                    },
                                                    {
                                                        text: (v.content == null) ? ' ' : $scope.cutInUTF8(v.content, 35, fontFlg),
                                                        margin: [45, 0, 0, 0]
                                                    }

                                                ],
                                                font: fontDefault
                                            }
                                        );
                                    }

                                }  else if (val.question_type == '0') {
                                    if (v.is_selected == 1) {
                                        stack.push(
                                            {
                                                columns: [
                                                    {
                                                        // you can also fit the image inside a rectangle
                                                        image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGsAAABqCAMAAACMPV+bAAAAclBMVEX///8AAADGxsYREREVFRXn5+e7u7v29vYvLy+tra0bGxve3t7z8/Pv7+9dXV3r6+vMzMwgICBISEhBQUGgoKBfX1+JiYlWVlbT09M7OzuUlJR0dHRFRUVqamp7e3vExMQqKiqFhYVPT0+bm5s0NDS0tLQpIwuKAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4AQOCAoFS1ktbAAABKRJREFUaN7NWmfbqjAMlcoUxQoiKMP18v//4lUUuqELn9tvCJKSk3GaZLX6L9d278FLk22c79pkzQV6+611QTGImpvDWbcmArFFQV7Ups7EStvIsyOprM5rZ2atz1VpLGjX3RzJFXY7E0n7KHMUVhbtdSUFXeIorqQL9EyvWDvKa51oGGVwYd8Tpnl7BLH32nvgxeDY5mnI7uei+mmQVt8mOUUcUyujU7KhFalmks8/8u/1EQo9yIPHmnz676gg6k7+t4Az1ryDBfmPk3SYIPR3q6TQjqsDoUe5QFLie3RbKA1xhdtJIQNajLtvelUwqsDHo2Y2r44Yf/6kmDC2J3yfc8JK7KsyqO6WEP//tBo9DKtWKy3FLYbZpIFgFngKNKMopsdczq8ugXbIvsj42ROFvsgkFUXI+EURBKLAZCTqJQyFK759bJFdXEzTOVJjEkzfPwWmsjAD4e07RsZuLOolDJk+6zpBoRBcZPzsPGqRudeNtgNXVhYcbbqjGVOinHrm1ghZvhdYaWqNn29TvgfthpDpXu1Rc3+ApSbSemfTBkdzq4a3+vjPA5G+wZXFBQdaEPJspjJ69QugB7HZ8cNKzm8mruW7PY8sefEBfYM3+F1hIOq65rxjCBDnPZMDDNC6jmcnnkOjHNVybVPPvklZoy+1NHU66otCnL7gpt+BVIHheABNsXqtA5kc4bAJQManxDPGynF9ATH7ALZtDKMuhlUIRBG46ePs/mbGZzCsXCCkHmFv9d5wpVc1ABhWPodIh9+bHu4DqZ4oMVafleK+e5EgqXpYEVS65zgN5W72sCICRfO+yPQ9eQarfh2HoPS+oLzNJlZ4pDi8L4T5BD7ofKSKFZFXcFl01ICffOQbYIW7FCGLZhqPr4sDfax61sGTRT80Fh2ANlYr+v1zspy1r4uVUJZAh1zMJLHqQ7uUbaD30ZjJYiW0jXhCTyRm8ljRNi/2ZeydOGYKWNG+PBGjMF0hzBSwYmLUVOz1WcxUsGJi72ROYTBTworJKdO5ksJMDSsmV85wAByz61UNK4YDzHEbDLPbTQ0rhtvMcjafU6d3JUVRnG2eiwKmpxLKJlaKi0pwbEB9mSudw2mOLXF28Il6vyxW2NnhEcufiXDMXHlR45nornLWQ5iFCiSIPetJnWEHzFwVvsWeYeXO5h/MFLDins1XpVTN4d2QKJQOGLyaw2oIJAertRTAq6WgGlG1fI1otM21b0+WoPa1SE2vFlTFF6hV3kW1Svs1WCCswa6CZKnacr54zXy0QcdbuheAukBP7v1kiR5Hzt93+bveDaKoP+hJYeX75XttdnqId7keoo3eaCXbGyV6vmeNCALO2MDC3GbNetn40MJDonFO9Oh9pR49PltRy0BAzB6sK2lFAnL2QA5tcqbioDVTkUvXjk8/mxV5RxBqBiZ7Ts3APDODGZgXaMxsTyGa7Sno2Z68NIg0I7tOk2FmadvPLCVpyD711Ag4caIzi5VrNhS6XFVU3mknh31Uq0iq9Wfnemv2Q+mZQN9oJvBjar+adfyqcnqG83E3Ux5tlCBquNoMLc+mfhNGP3Nbj2HvUC80c2tj/QNgFUALEws/TQAAAABJRU5ErkJggg==',
                                                        width: 20,
                                                        fit: [15, 15],
                                                        margin: [40, 0, 20, 0]
                                                    },
                                                    {
                                                        text: (v.content == null) ? ' ' : $scope.cutInUTF8(v.content, 35, fontFlg),
                                                        margin: [45, 0, 0, 0]
                                                    }
                                                ],
                                                font: fontDefault
                                            }
                                        );
                                    } else {
                                        stack.push(
                                            {
                                                columns: [
                                                    {
                                                        // you can also fit the image inside a rectangle
                                                        image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGsAAABqCAMAAACMPV+bAAAAclBMVEX///8AAADGxsYREREVFRXn5+e7u7v29vYvLy+tra0bGxve3t7z8/Pv7+9dXV3r6+vMzMwgICBISEhBQUGgoKBfX1+JiYlWVlbT09M7OzuUlJR0dHRFRUVqamp7e3vExMQqKiqFhYVPT0+bm5s0NDS0tLQpIwuKAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4AQOCAoewTzkgAAAA7dJREFUaN7NWtuCojAMBdxyESyVu9xGh+H/f3HVtVCgQIG0s3lDwJT05CRNomn/pXg+InkVnvWPnMMqJ8j3wBW5hlPddY7cK8dwARUhpw70BQlqB8FoyorbSV+R063IDiu6tHddUOz2ckST74T6Bgkdf68mq8X6RsGttQ966UnfLCe8A5RWPv0fO4jryHDRc+0Wco2ojgN7up5866eRsfnOOHE4UMucBJ/HhtwGyeZn+HoZkVkPQiQqh0//RBtUPYbvpmQFzReSDt9IhGliYL97IbTbbnEd2FGMSDJ2jX9qIrzFBYuTVGTTXNZ9g68NoLJMljXDdXO47PPJxoDhJew615RlzFeFZLtbEvb9ZTMiZq/qXWHJrZk9WwQIg8DE2smijB1jMb/Krd2UnYv4WdNTn3MkFDk9+OcYhPTEdEjVU1lPV3x8eD0u8qPhvDcjtpbvJ9ZRXQxAeOt2e7AfVvVU1kN/6jpWuoFcRPzs1llxcq/tsEM0ECEdpttxxoQ3h5416bYs9mdQGoDl517A96ALpcw/X3CpuUm3pRyE9RYSgx3cCvqvJvszTaTvRAMUQtMCm4eZAvYk1X1YxvnNhdXlTr8BUb9LoY+IlCBu/iQGEGhdZBKjai42IaTzpXqcOkUauDSjpMqgxwMCr4vQg4Ux5CeM4HV1idm/DfMqaNblMXD15ln/DpHPrKUe9hv1iF5lMnRl9ufvEesDgZzSUsD6bi6QpB4QzOY41cjdgIUSRfW6COV58ksiSkqvi5G3QQtliuvrQlI8mcQVVheSowvxdFlydFk8XbJqt7+tS5INvd/GhgrMq/RllRylkntVxhSVsVJlDqAyt1GZs6nMRZXm2CrODt+uujPR4zfOeirPsCrP5lqmsOagUSK5gu6Ywaul9DWiQn6NqMPmyZRe+5JS0ytnquISapWPuVolfA3WmK3BahaWVVuOF/wOpmbeYZCb44L2AvouUMO9j2X0OGL+ujN1vZs+RVXQk2LK9/J7bTA9xIdYDxGiN1qI9kYHPd/bDgYxbszAwtpij/Wy2aGFb4HG+aBHb27q0bOzFaXIFgxmD06FsCGN4eyB2G4PZyquu2YqYuF8PVE2K/JikNEMTNgszcA04YEZmOemTWZ70rnZnnQ82xNnB5immyILMJ1Z8t4zSziwp081OwjHxXtmseKdh7g23qoqbncHB98pt2gq98/OvdFs2sIzgebx45uyWcePKZdnOL8fx4w3BqXhVFxr2sCzqZ+A8Z65LTvau5aSZm4h5C89wTYq8aci6wAAAABJRU5ErkJggg==',
                                                        width: 20,
                                                        fit: [15, 15],
                                                        margin: [40, 0, 20, 0]
                                                    },
                                                    {
                                                        text: (v.content == null) ? ' ' : $scope.cutInUTF8(v.content, 35, fontFlg),
                                                        margin: [45, 0, 0, 0]
                                                    }
                                                ],
                                                font: fontDefault
                                            }
                                        );
                                    }
                                } else if (val.question_type == '2') {
                                    if (val.input_text != null) {
                                        stack.push(
                                            {
                                                columns: [
                                                    {
                                                        text:  val.input_text,
                                                        margin: [40, 15, 10, 0]
                                                    }

                                                ],
                                                font: fontDefault
                                            }
                                        );
                                    } else {
                                        //Fix bug MED-13160
                                        stack.push(
                                            {
                                                columns: [
                                                    {
                                                        text: gettextCatalog.getString("Input") + ': ____________________',
                                                        margin: [40, 15, 10, 0]
                                                    }

                                                ],
                                                font: fontDefault
                                            }
                                        );
                                    }
                                }
                            });

                            if (val.has_other_answer == 1) {
                                if (val.has_other_text != null) {
                                    stack.push(
                                        {
                                            columns: [
                                                {
                                                    text: gettextCatalog.getString("Other") + ': ' + val.has_other_text,
                                                    margin: [40, 15, 10, 0]
                                                }

                                            ],
                                            font: fontDefault
                                        }
                                    );
                                } else {
                                    //Fix bug MED-13160
                                    stack.push(
                                        {
                                            columns: [
                                                {
                                                    text: gettextCatalog.getString("Other") + ': ____________________',
                                                    margin: [40, 15, 10, 0]
                                                }

                                            ],
                                            font: fontDefault
                                        }
                                    );
                                }
                            }
                        });
                    });

                    var dd = {
                        info: {
                            title: 'Export PDF',
                            author: 'CMS Team',
                            subject: 'Survey information'
                            //keywords: 'keywords for document',
                        },
                        pageSize: 'A4',
                        pageMargins: 72,
                        //headerRows: 1,
                        widths: ['*', 'auto', 100, '*'],
                        header: function (currentPage, pageCount) {
                            if (typeof($scope.hospitalLogo) != 'undefined') {
                                return {
                                    columns: [
                                        {
                                            text: (hospName == null) ? ' ' : $scope.cutInUTF8(hospName, 35, fontFlg),
                                            style: 'header'
                                        },

                                        {
                                            image: $scope.hospitalLogo,
                                            //margin: [65-(pageCount)*5, 5, 5, 5],
                                            margin: [0, 20, 20, 0],
                                            fit: [120, 120],
                                            alignment: 'right'
                                        }
                                    ],
                                    font: fontDefault
                                };
                            } else {
                                return {
                                    columns: [
                                        {
                                            text: (hospName == null) ? ' ' : $scope.cutInUTF8(hospName, 35, fontFlg),
                                            style: 'header'
                                        }
                                    ],
                                    font: fontDefault
                                };
                            }
                        },
                        footer: function (currentPage, pageCount) {
                            return {
                                stack: [
                                    {text: (currentPage == pageCount) ? gettextCatalog.getString('Thank you for your cooperation.'):'' , alignment: 'right', fontSize: 10, margin: [0, 0, 30, 0]},
                                    {text: (hospName == null) ? ' ' : hospName, alignment: 'right', fontSize: 10, color: '#0000ff', margin: [0, 0, 30, 0]},
                                    {text: (hospAdd == null) ? ' ' : hospAdd, fontSize: 10, alignment: 'right', margin: [0, 0, 30, 0]}
                                ],
                                font: fontDefault
                            };
                        },
                        defaultStyle: {
                            font: fontDefault
                            //font: 'Times New Roman'
                        },
                        content: [
                            {
                                //text: ($scope.surveyObjPdf.survey_title == null) ? ' ' : $scope.surveyObjPdf.survey_title,
                                text: ($scope.surveyObjPdf.survey_title == null) ? ' ' : $scope.cutInUTF8($scope.surveyObjPdf.survey_title, 20, fontFlg),
                                fontSize: 24,
                                widths: [300, 300],
                                margin: [0, 50, 0, 20],
                                alignment: 'center',
                                font: fontDefault
                            },
                            {
                                table: {
                                    widths: [150, 150],
                                    headerRows: 2,
                                    // keepWithHeaderRows: 1,
                                    body: [
                                        [{text: gettextCatalog.getString('Patient code'), font: fontDefault}, ($scope.surveyObjPdf.patient_code != null && $scope.surveyObjPdf.patient_code != '' ) ? $scope.surveyObjPdf.patient_code : ' '],
                                        [{text: gettextCatalog.getString('Patient name'), font: fontDefault}, ($scope.surveyObjPdf.patient_name != null && $scope.surveyObjPdf.patient_name != '') ? $scope.surveyObjPdf.patient_name : ' '],
                                        [{text: gettextCatalog.getString('Answered date'), font: fontDefault}, ($scope.surveyObjPdf.answer_date != null && $scope.surveyObjPdf.answer_date != '') ? $scope.surveyObjPdf.answer_date : ' ']
                                    ]
                                },
                                margin: [65, 0, 0, 0],
                                font: fontDefault
                            },

                            {
                                text: gettextCatalog.getString('Please help us make the following survey.'),
                                fontSize: 18,
                                margin: [0, 50, 0, 20],
                                alignment: 'left',
                                font: fontDefault
                            },
                            {
                                stack: stack,
                                font: fontDefault
                            }
                        ],
                        styles: {
                            header: {
                                fontSize: 15,
                                bold: true,
                                alignment: 'left',
                                margin: [40, 20, 0, 0]
                            },
                            subheader: {
                                fontSize: 14
                            },
                            superMargin: {
                                margin: [20, 0, 40, 0],
                                fontSize: 15
                            },
                            vnfont: {
                                font: "Times New Roman"
                            },
                            jpfont: {
                                font: "MS PGothic"
                            }
                        }
                    };

                    pdfMake.fonts = {
                        Roboto: {
                            normal: 'Roboto-Regular.ttf',
                            bold: 'Roboto-Medium.ttf',
                            italics: 'Roboto-Italic.ttf',
                            bolditalics: 'Roboto-Italic.ttf'
                        },
                        "Times New Roman": {
                            normal: 'times.ttf',
                            bold: 'times.ttf',
                            italics: 'times.ttf',
                            bolditalics: 'times.ttf'
                        },
                        "MS PGothic": {
                            normal: 'mspgothic.ttf',
                            bold: 'mspgothic.ttf',
                            italics: 'mspgothic.ttf',
                            bolditalics: 'mspgothic.ttf'
                        }
                    };
                    pdfMake.createPdf(dd).download(hospCode + '_' + $scope.surveyObjPdf.patient_code + '_survey.pdf');
                }
            });
        };

        // Click on radio box
        $scope.setCorrectForRadio = function (group, question, answer) {
            $.each($scope.surveyObj.survey_information.question_group[group].question_list[question].answer_list, function (index, value) {
                value.is_selected = false;
            });
            $scope.surveyObj.survey_information.question_group[group].question_list[question].answer_list[answer].is_selected = true;
            $scope.surveyObj.survey_information.question_group[group].question_list[question].has_other_text = "";

        };

        // Click on checkbox
        $scope.setCorrectForCheckbox = function (group, question, answer) {
            $scope.surveyObj.survey_information.question_group[group].question_list[question].has_other_text = "";
        };

        // Click on input
        $scope.setCorrectForInput = function (group, question, answer) {
            $.each($scope.surveyObj.survey_information.question_group[group].question_list[question].answer_list, function (index, value) {
                value.is_selected = false;
            });
        };

        // Click on input
        $scope.setCorrectForInput2 = function (group, question, answer) {
            $.each($scope.surveyObj.survey_information.question_group[group].question_list[question].answer_list, function (index, value) {
                value.is_selected = false;
            });
        };

    }
})();