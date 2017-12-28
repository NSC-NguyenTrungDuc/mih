/**
 * Created by quangbv on 27/02/2016.
 */

(function () {
    'use strict';

    angular
        .module('app')
        .controller('GlobalController', GlobalController);

    GlobalController.$inject = ['$scope', 'cssInjector', 'gettextCatalog', '$cookieStore', '$location', 'AuthenticationService', '$http', 'localStorageService'];
    function GlobalController($scope, cssInjector, gettextCatalog, $cookieStore, $location, AuthenticationService, $http, localStorageService) {
        cssInjector.add("css/quirk.css");
        $scope.cookie = $cookieStore.get('globals');
        $scope.select_dept_text = gettextCatalog.getString('Select department');
        $scope.select_patient_text = gettextCatalog.getString('Select patient');
        $scope.select_type_text = gettextCatalog.getString('Select type');
        $scope.select_patient = gettextCatalog.getString('Select patient');
        $scope.toDay = moment().format('YYYY/MM/DD');
        $scope.startWeek = moment().isoWeekday(1).format('YYYY/MM/DD');
        $scope.endWeek = moment().isoWeekday(7).format('YYYY/MM/DD');
        $scope.startMonth = moment().startOf('month').format('YYYY/MM/DD');
        $scope.endMonth = moment().endOf('month').format('YYYY/MM/DD');

        if (typeof ($scope.cookie) != 'undefined') {
            $http.defaults.headers.common['token'] = $scope.cookie.currentUser.token;
        }

        /**
         * Logout and remove storage
         */
        $scope.logout = function () {
            AuthenticationService.ClearCredentials();
            localStorage.removeItem('activeMenu');
            $cookieStore.remove('patient_only');
            $cookieStore.remove('globalLang');
            localStorageService.remove('globals');
            $cookieStore.remove('show_flg');
            window.pdfMake.vfs = {};
            var params = {code: localStorageService.get('hosp_code')};
            if (localStorageService.get('patient_only') == 1) {
                params.p = 1;
            }
            $location.path('/login').search(params);
        }

        /**
         *  get logo of current hospital
         * @param url
         * @param callback
         */

        $scope.getDataUri = function (url, callback) {
            var image = new Image();
            image.crossOrigin = "Anonymous";  // This enables CORS

            image.onload = function () {
                var canvas = document.createElement('canvas');
                canvas.width = this.naturalWidth; // or 'width' if you want a special/scaled size
                canvas.height = this.naturalHeight; // or 'height' if you want a special/scaled size

                canvas.getContext('2d').drawImage(this, 0, 0);

                // Get raw image data
                callback(canvas.toDataURL('image/png').replace(/^data:image\/(png|jpg);base64,/, ''));

                // ... or get as Data URI
                callback(canvas.toDataURL('image/png'));
            };

            image.src = url;
        }

        /**
         * Cut string UTF-8
         * @param str
         * @param n
         * @param opt
         * @returns {string}
         */
        $scope.cutInUTF8 = function (str, n, opt) {
            "use strict";
            var output = '';
            if (opt == 1) {
                output = str;
            } else {
                var j = 0;
                for (var i = 0; i < str.length; i++) {
                    if (j == n) {
                        output += ' ';
                        j = 0;
                    }
                    output += str[i];
                    j++;
                }
            }
            return output;
        }

        /**
         * format datetime data by language
         * @param data
         * @returns {*}
         */

        $scope.formatDateByLang = function (data) {
            var current = gettextCatalog.getCurrentLanguage();
            if (current == 'ja') {
                data = moment(data).format(formatDateJa);
            } else if (current == 'vi') {
                data = moment(data).format(formatDateVn);
            } else {
                data = moment(data).format(formatDateEn);
            }
            return data;
        }

        /**
         * Set datetime by type
         * @param type
         */
        $scope.setDateTime = function (type) {
            var searchObj = {};
            switch (type) {
                case "1":
                    $('#datepickerFrom').val($scope.toDay);
                    $('#datepickerTo').val($scope.toDay);
                    searchObj = {
                        reservation_from: $scope.toDay,
                        reservation_to: $scope.toDay
                    };
                    break;
                case "2":
                    $('#datepickerFrom').val($scope.startWeek);
                    $('#datepickerTo').val($scope.endWeek);
                    searchObj = {
                        reservation_from: $scope.startWeek,
                        reservation_to: $scope.endWeek
                    };
                    break;
                case "3":
                    $('#datepickerFrom').val($scope.startMonth);
                    $('#datepickerTo').val($scope.endMonth);
                    searchObj = {
                        reservation_from: $scope.startMonth,
                        reservation_to: $scope.endMonth
                    };
                    break;
                default:
                    $('#datepickerFrom').val();
                    $('#datepickerTo').val();
                    searchObj = {reservation_from: null, reservation_to: null};
                    break;
            }
            return searchObj;
        }
    }
})();