// Karma configuration
// Generated on 2016-02-24

module.exports = function(config) {
  'use strict';

  config.set({
    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: true,

    // base path, that will be used to resolve files and exclude
    basePath: '../',

    // testing framework to use (jasmine/mocha/qunit/...)
    // as well as any additional frameworks (requirejs/chai/sinon/...)
    frameworks: [
      'jasmine'
    ],

    // list of files / patterns to load in the browser
    files: [
      // bower:js
      'bower_components/jquery/dist/jquery.js',
      'bower_components/angular/angular.js',
      'bower_components/bootstrap/dist/js/bootstrap.js',
      'bower_components/angular-resource/angular-resource.js',
      'bower_components/angular-route/angular-route.js',
      'bower_components/angular-ui-router/release/angular-ui-router.js',
      'bower_components/angular-cookies/angular-cookies.js',
      'bower_components/angular-css-injector/angular-css-injector.js',
      'bower_components/jquery-toggles/toggles.js',
      'bower_components/angular-gettext/dist/angular-gettext.js',
      'bower_components/select2/dist/js/select2.js',
      'bower_components/rowsorter/dist/RowSorter.js',
      'bower_components/datatables/media/js/jquery.dataTables.js',
      'bower_components/datatables-bootstrap3/BS3/assets/js/datatables.js',
      'bower_components/moment/moment.js',
      'bower_components/angular-datatables/dist/angular-datatables.js',
      'bower_components/jquery-ui/ui/core.js',
      'bower_components/jquery-ui/ui/widget.js',
      'bower_components/jquery-ui/ui/menu.js',
      'bower_components/jquery-ui/ui/position.js',
      'bower_components/jquery-ui/ui/selectmenu.js',
      'bower_components/jquery-ui/ui/tabs.js',
      'bower_components/jquery-ui/ui/autocomplete.js',
      'bower_components/angular-bootstrap/ui-bootstrap-tpls.js',
      'bower_components/jquery.steps/build/jquery.steps.js',
      'bower_components/angular-mocks/angular-mocks.js',
      // endbower
      'app/scripts/**/*.js',
      'test/mock/**/*.js',
      'test/spec/**/*.js'
    ],

    // list of files / patterns to exclude
    exclude: [
    ],

    // web server port
    port: 8080,

    // Start these browsers, currently available:
    // - Chrome
    // - ChromeCanary
    // - Firefox
    // - Opera
    // - Safari (only Mac)
    // - PhantomJS
    // - IE (only Windows)
    browsers: [
      'PhantomJS'
    ],

    // Which plugins to enable
    plugins: [
      'karma-phantomjs-launcher',
      'karma-jasmine'
    ],

    // Continuous Integration mode
    // if true, it capture browsers, run tests and exit
    singleRun: false,

    colors: true,

    // level of logging
    // possible values: LOG_DISABLE || LOG_ERROR || LOG_WARN || LOG_INFO || LOG_DEBUG
    logLevel: config.LOG_INFO,

    // Uncomment the following lines if you are using grunt's server to run the tests
    // proxies: {
    //   '/': 'http://localhost:9000/'
    // },
    // URL root prevent conflicts with the site root
    // urlRoot: '_karma_'
  });
};
