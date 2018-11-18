    //样品管理
app.controller('SampleStockCtrl', [
    '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmSamleStock', 'lrmBaseInfo',
  function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmSamleStock, lrmBaseInfo) {
      $scope.data = lrmSamleStock.getList();

      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
      }, 450);
      $scope.doRefresh = function () {
          lrmSamleStock.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmSamleStock.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmSamleStock.getSearchList();

          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/SampleSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {

          lrmSamleStock.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmSamleStock.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {

          $scope.detailsData = lrmSamleStock.get(chanceId);


          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/SampleDetails.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {};
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
          }
          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/businessEdit.html', {
              scope: $scope,
              animation: 'slide-in-up',
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($hengtexDataIsAll.isHave($scope.editData)) {
              $hengtexPopup.confirm({
                  title: '<p> </p>你输入的内容未保存，是否放弃本次编辑?<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };



      //添加保存
      $scope.doSubmit = function () {
          var res = $hengtexDataIsAll.isAll($scope.editData, lrmSamleStock.getEditDataEx());
          if (res != null) {
              $hengtexTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              lrmSamleStock.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }

      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
      $scope.openSourceSelectModal = function () {//打开查询条件

          $hengtexSelectModal({
              title: "查询条件",
              bgAllColor: "royal-bg",
              selectValue: $scope.searchData.condation,
              text: "itemName",
              value: "itemValue",
              data: lrmSamleStock.getChanceSource(),
              onChange: function (item) {
                  $scope.searchData.condation = item.text;

                  $scope.searchData.conditionvalue = item.value;

              }
          });
      };
  }])
    //发货管理
.controller('proDeliveryCtrl', [
    '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmProDelevery', 'lrmBaseInfo',
  function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmProDelevery, lrmBaseInfo) {

      $scope.data = lrmProDelevery.getList();

      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
      }, 450);
      $scope.doRefresh = function () {
          lrmProDelevery.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmProDelevery.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmProDelevery.getSearchList();

          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProDeliverySearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {

          lrmProDelevery.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmProDelevery.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {

          $scope.detailsData = lrmProDelevery.get(chanceId);
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProDeliveryDetails.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {};
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
          }
          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/businessEdit.html', {
              scope: $scope,
              animation: 'slide-in-up',
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($hengtexDataIsAll.isHave($scope.editData)) {
              $hengtexPopup.confirm({
                  title: '<p> </p>你输入的内容未保存，是否放弃本次编辑?<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };



      //添加保存
      $scope.doSubmit = function () {
          var res = $hengtexDataIsAll.isAll($scope.editData, lrmProDelevery.getEditDataEx());
          if (res != null) {
              $hengtexTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              lrmProDelevery.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }

      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
      $scope.openSourceSelectModal = function () {//打开查询条件

          $hengtexSelectModal({
              title: "查询条件",
              bgAllColor: "royal-bg",
              selectValue: $scope.searchData.condation,
              text: "itemName",
              value: "itemValue",
              data: lrmProDelevery.getChanceSource(),
              onChange: function (item) {
                  $scope.searchData.condation = item.text;

                  $scope.searchData.conditionvalue = item.value;

              }
          });
      };
  }])
    //染整管理
.controller('proRzStockCtrl', [
    '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmProRzStock', 'lrmBaseInfo',
  function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmProRzStock, lrmBaseInfo) {

      $scope.data = lrmProRzStock.getList();

      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
      }, 450);
      $scope.doRefresh = function () {
          lrmProRzStock.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmProRzStock.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmProRzStock.getSearchList();

          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProRzStockSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {

          lrmProRzStock.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmProRzStock.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      $scope.loadMoreDetails = function () {
          lrmProRzStock.detailDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {
          $scope.detailsData = lrmProRzStock.getSearchList();
          console.log($scope.searchData);
          lrmProRzStock.get(chanceId);


          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/proRzStockDetails.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {};
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
          }
          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/businessEdit.html', {
              scope: $scope,
              animation: 'slide-in-up',
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($hengtexDataIsAll.isHave($scope.editData)) {
              $hengtexPopup.confirm({
                  title: '<p> </p>你输入的内容未保存，是否放弃本次编辑?<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };



      //添加保存
      $scope.doSubmit = function () {
          var res = $hengtexDataIsAll.isAll($scope.editData, lrmProRzStock.getEditDataEx());
          if (res != null) {
              $hengtexTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              lrmProRzStock.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }

      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
      $scope.openSourceSelectModal = function () {//打开查询条件

          $hengtexSelectModal({
              title: "查询条件",
              bgAllColor: "royal-bg",
              selectValue: $scope.searchData.condation,
              text: "itemName",
              value: "itemValue",
              data: lrmProRzStock.getChanceSource(),
              onChange: function (item) {
                  $scope.searchData.condation = item.text;

                  $scope.searchData.conditionvalue = item.value;

              }
          });
      };
  }])
    //绒布库存管理
.controller('proRbStockCtrl', [
    '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmProRbStock', 'lrmBaseInfo',
  function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmProRbStock, lrmBaseInfo) {

      $scope.data = lrmProRbStock.getList();

      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
      }, 450);
      $scope.doRefresh = function () {
          lrmProRbStock.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmProRbStock.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmProRbStock.getSearchList();

          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProRbStockSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {

          lrmProRbStock.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmProRbStock.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      $scope.loadMoreDetails = function () {

          lrmProRbStock.detailDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {
          $scope.detailsData = lrmProRbStock.getSearchList();
          console.log($scope.searchData);
          lrmProRbStock.get(chanceId);


          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/proRbStockDetails.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {};
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
          }
          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/businessEdit.html', {
              scope: $scope,
              animation: 'slide-in-up',
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($hengtexDataIsAll.isHave($scope.editData)) {
              $hengtexPopup.confirm({
                  title: '<p> </p>你输入的内容未保存，是否放弃本次编辑?<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };



      //添加保存
      $scope.doSubmit = function () {
          var res = $hengtexDataIsAll.isAll($scope.editData, lrmProRbStock.getEditDataEx());
          if (res != null) {
              $hengtexTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              lrmProRbStock.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }

      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
      $scope.openSourceSelectModal = function () {//打开查询条件

          $hengtexSelectModal({
              title: "查询条件",
              bgAllColor: "royal-bg",
              selectValue: $scope.searchData.condation,
              text: "itemName",
              value: "itemValue",
              data: lrmProRbStock.getChanceSource(),
              onChange: function (item) {
                  $scope.searchData.condation = item.text;

                  $scope.searchData.conditionvalue = item.value;

              }
          });
      };
  }])
    //绒布订单管理
.controller('proRbOrderCtrl', [
    '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmProRbOrder', 'lrmBaseInfo',
  function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmProRbOrder, lrmBaseInfo) {

      $scope.data = lrmProRbOrder.getList();

      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
      }, 450);
      $scope.doRefresh = function () {
          lrmProRbOrder.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmProRbOrder.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmProRbOrder.getSearchList();

          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProRbOrderSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {

          lrmProRbOrder.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmProRbOrder.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {
          $scope.detailsData = lrmProRbOrder.get(chanceId);
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProRbOrderDetails.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {};
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
          }
          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/businessEdit.html', {
              scope: $scope,
              animation: 'slide-in-up',
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($hengtexDataIsAll.isHave($scope.editData)) {
              $hengtexPopup.confirm({
                  title: '<p> </p>你输入的内容未保存，是否放弃本次编辑?<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };



      //添加保存
      $scope.doSubmit = function () {
          var res = $hengtexDataIsAll.isAll($scope.editData, lrmProRbOrder.getEditDataEx());
          if (res != null) {
              $hengtexTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              lrmProRbOrder.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }

      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
      $scope.openSourceSelectModal = function () {//打开查询条件

          $hengtexSelectModal({
              title: "查询条件",
              bgAllColor: "royal-bg",
              selectValue: $scope.searchData.condation,
              text: "itemName",
              value: "itemValue",
              data: lrmProRbOrder.getChanceSource(),
              onChange: function (item) {
                  $scope.searchData.condation = item.text;

                  $scope.searchData.conditionvalue = item.value;

              }
          });
      };
  }])
    //染整订单管理
.controller('proRzOrderCtrl', [
    '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmProRzOrder', 'lrmBaseInfo',
  function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmProRzOrder, lrmBaseInfo) {

      $scope.data = lrmProRzOrder.getList();

      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
      }, 450);
      $scope.doRefresh = function () {
          lrmProRzOrder.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmProRzOrder.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmProRzOrder.getSearchList();

          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProRzOrderSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {

          lrmProRzOrder.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmProRzOrder.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {
          $scope.detailsData = lrmProRzOrder.get(chanceId);
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/ProRzOrderDetails.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {};
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
          }
          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/cases/sale/businessEdit.html', {
              scope: $scope,
              animation: 'slide-in-up',
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($hengtexDataIsAll.isHave($scope.editData)) {
              $hengtexPopup.confirm({
                  title: '<p> </p>你输入的内容未保存，是否放弃本次编辑?<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };



      //添加保存
      $scope.doSubmit = function () {
          var res = $hengtexDataIsAll.isAll($scope.editData, lrmProRzOrder.getEditDataEx());
          if (res != null) {
              $hengtexTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              lrmProRzOrder.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }

      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
      $scope.openSourceSelectModal = function () {//打开查询条件

          $hengtexSelectModal({
              title: "查询条件",
              bgAllColor: "royal-bg",
              selectValue: $scope.searchData.condation,
              text: "itemName",
              value: "itemValue",
              data: lrmProRzOrder.getChanceSource(),
              onChange: function (item) {
                  $scope.searchData.condation = item.text;

                  $scope.searchData.conditionvalue = item.value;

              }
          });
      };
  }])