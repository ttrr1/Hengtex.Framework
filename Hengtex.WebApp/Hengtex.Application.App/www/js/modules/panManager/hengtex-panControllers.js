// add by lvh 
//盘头管理888
app.controller('PanManageCtrl', [
  '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'htPanManage', 'lrmBaseInfo',
  function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, htPanManage, lrmBaseInfo) {
    $scope.data = htPanManage.getList();
    //刷新数据
    $timeout(function () {
      $hengtexTriggerRefresh.triggerRefresh('panlist-content');
    }, 450);
    $scope.doRefresh = function () {
      htPanManage.update(function () {
        $scope.$broadcast('scroll.refreshComplete');
      });
    };
    $scope.doLoadMore = function () {
      htPanManage.add(function () {
        $scope.$broadcast('scroll.infiniteScrollComplete');
      });
    };
    //搜索页
    $scope.closeSearchModal = function () {
      $scope.searchModal.remove();
    };
    $scope.openSearch = function () {
      $scope.searchData = htPanManage.getSearchList();
      console.log($scope.searchData);
      if ($scope.searchModal != null) {
        $scope.searchModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/cases/pans/pansSearch.html', {
        scope: $scope,
        animation: 'lr-slide-in-right',
        focusFirstInput: true
      }).then(function (modal) {
        $scope.searchModal = modal;
        $scope.searchModal.show();
      });

    };
    $scope.doSearch = function () {
      htPanManage.searchData().then(function () { $scope.searchData = htPanManage.getSearchList(); });
    };
    $scope.loadMoreSearch = function () {
      htPanManage.searchDataAdd(function () {
        $scope.$broadcast('scroll.infiniteScrollComplete');
      });
    };
    //详情页
    $scope.openDetailsModal = function (panNum) {
      //alert(panNum);
      $scope.detailsData = htPanManage.get(panNum);
      if ($scope.detailsModal != null) {
        $scope.detailsModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/cases/pans/panDetails.html', {
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
      $ionicModal.fromTemplateUrl('templates/cases/pans/panEdit.html', {
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

    $scope.openStatusSelectModal = function () {//打开选择盘头状态
      $hengtexSelectModal({
        title: "盘头状态",
        bgAllColor: "royal-bg",
        selectValue: $scope.editData.dcph_status,
        text: "itemName",
        value: "itemValue",
        data: htPanManage.getPanStatus(),
        onChange: function (item) {
          $scope.editData.dcph_status = item.value;
          $scope.editData.dcph_status = item.text;
        }
      });
    };
    $scope.openPositionSelectModal = function () {//打开选择存放位置
      $hengtexSelectModal({
        title: "位置",
        selectValue: $scope.editData.dcph_position,
        text: "itemName",
        value: "itemValue",
        bgColor: "bgColor",
        data: htPanManage.getPositions(),
        onChange: function (item) {
          $scope.editData.dcph_position = item.value;
          $scope.editData.dcph_positionName = item.text;
          $scope.editData.bgStageColor = item.bgColor;
        }
      });
    };
    $scope.openTraceUserSelectModal = function () {
      $hengtexSelectModal({
        title: "跟进人员",
        bgAllColor: "calm-bg",
        selectValue: $scope.editData.TraceUserId,
        text: "RealName",
        value: "UserId",
        data: lrmBaseInfo.getUserInfoList("2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1"),
        onChange: function (item) {
          $scope.editData.traceUserId = item.value;
          $scope.editData.traceUserName = item.text;
        }
      });
    };

    //删除
    $scope.doDelete = function (business) {
      $hengtexPopup.confirm({
        title: '<p> </p>确定要删除?<p> </p>',
        okText: '删除',
        ok: function () {
          htPanManage.remove(business);
          if ($scope.detailsModal != null) {
            $scope.detailsModal.remove();
          }
        }
      });
    };
    //添加保存
    $scope.doSubmit = function () {
      var res = $hengtexDataIsAll.isAll($scope.editData, htPanManage.getEditDataEx());
      if (res != null) {
        $hengtexTopAlert.show({ text: res.name + " 不能为空" });
      } else {
        $ionicLoading.show();
        htPanManage.editSubmit($scope.editData, function () {
          $ionicLoading.hide();
          $scope.editModal.remove();
          $hengtexTriggerRefresh.triggerRefresh('panlist-content');
        });
      }
    }
  }])


  //盘头上织机管理
  .controller('PanUpManageCtrl', [
    '$scope', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'htPanUpManage', 'lrmBaseInfo',
    function ($scope, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, htPanUpManage, lrmBaseInfo) {
      $scope.data = htPanUpManage.getList();
      $scope.editData = {};
      $scope.editData.emps = [{ "phe_empNo": "lvh", "phe_name": "吕辉" }, { "phe_empNo": "xb", "phe_name": "熊斌" }];
      $scope.editData.emps = [];
      //$scope.editTitle = "新建";
      //$scope.editTitle = "新建";
      //if (item != undefined) {
      //    $scope.editData = item;
      //    $scope.editTitle = "编辑";
      //}
      //刷新数据
      $timeout(function () {
        $hengtexTriggerRefresh.triggerRefresh('panlist-content');
      }, 450);
      $scope.doRefresh = function () {
        htPanManage.update(function () {
          $scope.$broadcast('scroll.refreshComplete');
        });
      };
      $scope.doLoadMore = function () {
        htPanManage.add(function () {
          $scope.$broadcast('scroll.infiniteScrollComplete');
        });
      };
      //搜索页
      $scope.closeSearchModal = function () {
        $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
        $scope.searchData = htPanUpManage.getSearchList();
        console.log($scope.searchData);
        if ($scope.searchModal != null) {
          $scope.searchModal.remove();
        }
        $ionicModal.fromTemplateUrl('templates/cases/pans/pansSearch.html', {
          scope: $scope,
          animation: 'lr-slide-in-right',
          focusFirstInput: true
        }).then(function (modal) {
          $scope.searchModal = modal;
          $scope.searchModal.show();
        });

      };
      $scope.doSearch = function () {
        htPanUpManage.searchData().then(function () { $scope.searchData = htPanUpManage.getSearchList(); });
      };
      $scope.loadMoreSearch = function () {
        htPanUpManage.searchDataAdd(function () {
          $scope.$broadcast('scroll.infiniteScrollComplete');
        });
      };
      //详情页
      $scope.openDetailsModal = function (panNum) {
        //alert(panNum);
        $scope.detailsData = htPanUpManage.get(panNum);
        if ($scope.detailsModal != null) {
          $scope.detailsModal.remove();
        }
        $ionicModal.fromTemplateUrl('templates/cases/pans/panDetails.html', {
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
        $ionicModal.fromTemplateUrl('templates/cases/pans/panEdit.html', {
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

      $scope.openStatusSelectModal = function () {//打开选择盘头状态
        $hengtexSelectModal({
          title: "盘头状态",
          bgAllColor: "royal-bg",
          selectValue: $scope.editData.dcph_status,
          text: "itemName",
          value: "itemValue",
          data: htPanUpManage.getPanStatus(),
          onChange: function (item) {
            $scope.editData.dcph_status = item.value;
            $scope.editData.dcph_status = item.text;
          }
        });
      };
      $scope.openPositionSelectModal = function () {//打开选择存放位置
        $hengtexSelectModal({
          title: "位置",
          selectValue: $scope.editData.dcph_position,
          text: "itemName",
          value: "itemValue",
          bgColor: "bgColor",
          data: htPanUpManage.getPositions(),
          onChange: function (item) {
            $scope.editData.dcph_position = item.value;
            $scope.editData.dcph_positionName = item.text;
            $scope.editData.bgStageColor = item.bgColor;
          }
        });
      };
      $scope.openTraceUserSelectModal = function () {
        $hengtexSelectModal({
          title: "跟进人员",
          bgAllColor: "calm-bg",
          selectValue: $scope.editData.TraceUserId,
          text: "RealName",
          value: "UserId",
          data: lrmBaseInfo.getUserInfoList("2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1"),
          onChange: function (item) {
            $scope.editData.traceUserId = item.value;
            $scope.editData.traceUserName = item.text;
          }
        });
      };

      //删除
      $scope.doDelete = function (business) {
        $hengtexPopup.confirm({
          title: '<p> </p>确定要删除?<p> </p>',
          okText: '删除',
          ok: function () {
            htPanManage.remove(business);
            if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
            }
          }
        });
      };
      //添加保存
      $scope.doSubmit = function () {
        alert(JSON.stringify($scope.editData) + "sdd");
        //var childEntryJson = [];
        //$('#gridTable').find('input[name="phe_empNo"]').each(function (i) {
        //    if (!!$(this).find('input[name="phe_empNo"]').val()) {
        //        childEntryJson.push({
        //            phe_empNo: $(this).find('input[name="phe_empNo"]').val(),
        //            phe_name: $(this).find('input[name="phe_name"]').val()
        //        });
        //    }
        //});

        var res = $hengtexDataIsAll.isAll($scope.editData, htPanUpManage.getEditDataEx());
        if (res != null) {
          $hengtexTopAlert.show({ text: res.name + " 不能为空" });
        } else {
          $ionicLoading.show();
          alert(JSON.stringify($scope.editData) + "sdd2");
          htPanUpManage.editSubmit($scope.editData, function () {
            $ionicLoading.hide();
            $scope.editModal.remove();
            $hengtexTriggerRefresh.triggerRefresh('panlist-content');
          });
        }
      }
    }])

