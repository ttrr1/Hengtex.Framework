    //电表管理
app
.controller('AmmeListCtrl', [
    '$scope', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmAmmeList', '$ionicScrollDelegate', 'lrmBaseInfo',
  function ($scope, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmAmmeList, $ionicScrollDelegate, lrmBaseInfo) {
      $scope.data = lrmAmmeList.getList();
      //begin
      $scope.searchData = lrmAmmeList.getSearchList();//查询
      lrmAmmeList.searchData();
      //end
      $scope.toggleRight = function () {
          $ionicSideMenuDelegate.toggleRight();
      };
      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
          $ionicScrollDelegate.resize();
      }, 450);
      $scope.doRefresh = function () {
          lrmAmmeList.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmAmmeList.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
     
      $scope.doSearch = function () {
          lrmAmmeList.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmAmmeList.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
    
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
    
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };

  }])
    //电表日报表
.controller('AmmeDailayListCtrl', [
    '$scope', 'ionicDatePicker', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmAmmeDayList', '$ionicScrollDelegate', 'lrmBaseInfo',
  function ($scope,ionicDatePicker, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmAmmeDayList, $ionicScrollDelegate, lrmBaseInfo) {
      $scope.data = lrmAmmeDayList.getList();
      //begin
      $scope.searchData = lrmAmmeDayList.getSearchList();//查询
      lrmAmmeDayList.searchData("");
      //end
      $scope.toggleRight = function () {
          $ionicSideMenuDelegate.toggleRight();
      };
      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
          $ionicScrollDelegate.resize();
      }, 450);
      $scope.doRefresh = function () {
          lrmAmmeDayList.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmAmmeDayList.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      $scope.doSearch = function () {
          lrmAmmeDayList.searchData("");
      };
      $scope.loadMoreSearch = function () {
          lrmAmmeDayList.searchDataAdd("",function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };

      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };


      //条件筛选页面
      $scope.openSearchPopModal = function () {

          if ($scope.SearchPopModal != null) {
              $scope.SearchPopModal.remove();
          }

          $ionicModal.fromTemplateUrl('templates/cases/amme/mesPopModel/mesSalaryTestPop.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.SearchPopModal = modal;
              $scope.SearchPopModal.show();
          });
      };
      $scope.closeSearchPopModal = function () {
          if ($scope.SearchPopModal != null) {
              $scope.SearchPopModal.remove();
          }
      };


      //date
      $scope.validedTime = new Date();
 
      var datePickerObj = {
          //选择日期后的回掉
          callback: function (val) {
              if (typeof (val) === 'undefined') {
              } else {
                  var nowdate = new Date(val);
                  var year = nowdate.getFullYear();
                  var month = nowdate.getMonth() + 1;
                  var day = nowdate.getDate();
                  var currentDay = year + "-" + month + "-" + day;;
                  // $scope.validedTime = $filter('date')(new Date(val), 'yyyy-MM-dd');
                  $scope.validedTime = currentDay;

                  datePickerObj.inputDate = new Date(val); //更新日期弹框上的日期
                 // $scope.datepickerObjectEnd.inputDate = new Date(val); //更新日期弹框上的日期

              }
          },
          disabledDates: [
            new Date(2016, 2, 16),
            new Date(2015, 3, 16),
            new Date(2015, 4, 16),
            new Date(2015, 5, 16),
            new Date('Wednesday, August 12, 2015'),
            new Date("2019-08-16"),
            new Date(1439676000000)
          ],
          from: new Date(2010, 1, 1),
          to: new Date(2038, 10, 30),
          inputDate: new Date(),
          mondayFirst: true,
          disableWeekdays: [], //设置不能选中
          closeOnSelect: false,
          dateFormat: 'yyyy-MM-dd',
          templateType: 'popup',
      };
       
      //打开日期选择框
      $scope.openDatePicker = function () {
          ionicDatePicker.openDatePicker(datePickerObj);
      };
 
      $scope.navigate = function (state) {
          nav.navigate(state);
      };
  


  }])