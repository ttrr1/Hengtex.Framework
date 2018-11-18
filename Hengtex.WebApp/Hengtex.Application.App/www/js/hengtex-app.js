// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
var app = angular.module('starter', ['ionic', 'base64', 'angular-md5', 'ionic-datepicker', 'ngCordova', 'highcharts-ng', 'monospaced.elastic', 'ngSanitize'])
.run(['$ionicPlatform', '$rootScope', '$state', 'UserInfo', '$http', '$ionicActionSheet', '$timeout', '$cordovaAppVersion', '$ionicPopup', '$ionicLoading', '$cordovaFileTransfer', '$cordovaFile', '$cordovaFileOpener2',
  function ($ionicPlatform, $rootScope, $state, UserInfo, $http, $ionicActionSheet, $timeout, $cordovaAppVersion, $ionicPopup, $ionicLoading, $cordovaFileTransfer, $cordovaFile, $cordovaFileOpener2) {
      $ionicPlatform.ready(function () {
          // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
          // for form inputs)
          if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
              cordova.plugins.Keyboard.hideKeyboardAccessoryBar(false);
              cordova.plugins.Keyboard.disableScroll(true);
          }
          // add by lvh 

          //�������ϱ���汾��Ϣ
          $http.get('http://192.168.0.103:9009/app/ver.json?unique=' + new Date().getTime())
          .then(function (data) {
              var serverAppVersion = data.data.verInfo;//������ �汾
              //console.log("====>>������" + serverAppVersion);
              $cordovaAppVersion.getVersionNumber().then(function (version) {
                  //console.log("version=====����>>>" + version + "====>>������" + serverAppVersion);
                  if (version != serverAppVersion) {
                      $ionicLoading.show({
                          template: "�Ѿ����أ�0%"
                      });
                      var url = "http://192.168.0.103:9009/app/android-debug.apk";
                      var targetPath = "file:///mnt/sdcard/Download/android-debug.apk";
                      var trustHosts = true
                      var options = {};
                      $cordovaFileTransfer.download(url, targetPath, options, trustHosts).then(function (result) {
                          $cordovaFileOpener2.open(targetPath, 'application/vnd.android.package-archive'
                          ).then(function () {
                          }, function (err) {
                          });
                          $ionicLoading.hide();
                      }, function (err) {
                          alert(JSON.stringify(err));
                          alert('����ʧ��');
                      }, function (progress) {
                          $timeout(function () {
                              var downloadProgress = (progress.loaded / progress.total) * 100;
                              $ionicLoading.show({
                                  template: "�Ѿ����أ�" + Math.floor(downloadProgress) + "%"
                              });
                              if (downloadProgress > 99) {
                                  $ionicLoading.hide();
                              }
                          })
                      });
                  }
              });
          }).then(function () {
              // add 
              /*�жϵ�ǰ�Ƿ��е�¼��Ϣ*/

              $rootScope.$on('$stateChangeStart',
              function (event, toState) {
                  if (toState.name != 'login' && UserInfo.get().isLogin != true) {
                      event.preventDefault();
                      $state.go('login');
                  }
              });
              if ($state.current.name != 'login') {
                  if (UserInfo.get().isLogin != true) {
                      $state.go('login');
                  }
              }
          });
      });
  }])

app.filter('trustHtml', ['$sce', function ($sce) {
    return function (input) {
        return $sce.trustAsHtml(input);
    }
}])

.config(['$ionicConfigProvider', function ($ionicConfigProvider) {
    $ionicConfigProvider.backButton.previousTitleText(false);
    $ionicConfigProvider.backButton.text('').icon('ion-ios-arrow-left');
    $ionicConfigProvider.scrolling.jsScrolling(true);
    $ionicConfigProvider.platform.ios.tabs.style('standard');
    $ionicConfigProvider.platform.ios.tabs.position('bottom');
    $ionicConfigProvider.platform.android.tabs.style('standard');
    $ionicConfigProvider.platform.android.tabs.position('bottom');
    $ionicConfigProvider.platform.ios.navBar.alignTitle('center');
    $ionicConfigProvider.platform.android.navBar.alignTitle('center');
    $ionicConfigProvider.platform.ios.views.transition('ios');
    $ionicConfigProvider.platform.android.views.transition('android');
    $ionicConfigProvider.tabs.position('bottom'); // other values: top
}])
.config(['ionicDatePickerProvider', function (ionicDatePickerProvider) {
    var datePickerObj = {
        inputDate: new Date(),
        setLabel: 'Set',
        todayLabel: 'Today',
        closeLabel: 'Close',
        mondayFirst: false,
        weeksList: ["S", "M", "T", "W", "T", "F", "S"],
        monthsList: ["Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec"],
        templateType: 'popup',
        from: new Date(2014, 8, 1),
        to: new Date(2020, 8, 1),
        showTodayButton: true,
        dateFormat: 'yyyy-MMMM-dd',
        closeOnSelect: false,
        disableWeekdays: [6],
    };
    ionicDatePickerProvider.configDatePicker(datePickerObj);
}]);

