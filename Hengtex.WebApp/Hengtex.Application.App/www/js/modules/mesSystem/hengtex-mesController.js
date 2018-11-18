
//报工列表
app.controller('MesListCtrl', [
    '$scope', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmMesAdd', '$ionicScrollDelegate', 'lrmBaseInfo', '$state',
  function ($scope, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmMesAdd, $ionicScrollDelegate, lrmBaseInfo, $state) {
      lrmMesAdd.getDfps().then(function (result) {

          $scope.bggxListAlls = result;
          if (result.length > 0) {
              $scope.editData.mpr_empNum = result[0].account;
              $scope.editData.mpr_empName = result[0].accountName;
          }

      }, function () {

          console.log('errror');
      });

   
      lrmMesAdd.allByDomainName("mesApps").then(function (result) {//绑定         
          $scope.data1 = result;         

      }, function () {

          console.log('errror');
      });
    
      $scope.editData = {
            "mpr_id":"",    
            "mpr_num":"",//报工单据号     
            "mpr_taskNum":"",//计划明细编号
            "mpr_date":"",//登记日期    
            "mpr_procedureID":"",//工序ID        
            "mpr_procedureName":"",//工序名称     
            "mpr_SEFlag":"",//开完工标志     
            "mpr_fcltNum":"",//机台号     
            "mpr_fcltName":"",//机台名称      
            "mpr_group":"",//班组     
            "mpr_batch":"",//批次     
            "mpr_pinhao":"",//品号    
            "mpr_color":"",//颜色      
            "mpr_attr":"",//属性      
            "mpr_count":"",//数量      
            "mpr_bl":"",//比例      
            "mpr_unit":"",//单位      
            "mpr_empNum":"",//职工编号     
            "mpr_empName":"",//职工名称      
            "mpr_salaryFlag":"",////工资标志
            "mpr_addFlag":"",//追加标志      
            "mpr_moreFlag":"",//超量标志    
            "mpr_placeFlag":"",//代报工标志
            "mpr_reworkFlag":"",//回修标志
            "mpr_reworkCount":"",//回修次数     
            "mpr_panNo":"",//盘头号      
            "mpr_hankCount":"",//绞数     
            "mpr_numDetail":"",//明细表单据号      
            "mpr_horseNo":"",//匹次      
            "mpr_timeCount":"",//遍数     
            "mpr_location":"",//货位     
            "mpr_locationName":"",//货位名称    
            "mpr_checkResult":"",//合格判定结果      
            "mpr_decript":"",//描述     
            "mpr_remarks":"",     
            "mpr_Person":"",//责任人     
            "creationDate":"",      
            "createdBy":"",     
            "createdByNum":"",      
            "lastUpdateDate":"",    
            "lastUpdatedBy":"",     
            "appUser":"",     
            "appDate":"",     
            "flagApp":"",     
            "delMan":"",    
            "delDate":"",     
            "flagDelete":""
      };
      //设置批次和颜色和品号
      $scope.setEditDataBatch = function (u) {
          $scope.editData.mpr_batch = u.b_num;
          $scope.editData.mpr_color = u.b_color;
          $scope.editData.mpr_pinhao = u.b_pinhao;
          $scope.editData.mpr_attr = u.b_attr;


      };
      $scope.setEditDataFclt = function (u) {
          $scope.editData.mpr_fcltNum = u.fclt_num;
          $scope.editData.mpr_fcltName = u.fclt_name;
          lrmMesAdd.getBatchTask(u.fclt_num).then(function (result) {
              
              if (result.length > 0) {
                  $scope.editData.mpr_taskNum = result[0].mpr_taskNum;
                  $scope.editData.mpr_batch = result[0].mpr_batch;
                  $scope.editData.mpr_color = result[0].mpr_color;
                  $scope.editData.mpr_pinhao = result[0].mpr_pinhao;
                  $scope.editData.mpr_attr = result[0].mpr_attr;
              } else {
                 
                  $scope.editData.mpr_taskNum = "";
                  $scope.editData.mpr_batch = "";

              }
             
          }, function () {

              console.log('errror');
          });
      };
     //设置货位
      $scope.setEditDataConPanPosition = function (u) {
          
          $scope.editData.mpr_location = u.dcpp_num;
          $scope.editData.mpr_locationName = u.dcpp_name;
         
      };
     
      $scope.mpr_procedureID = "";
      $scope.mpr_procedureName = "";
      //   $scope.bgdfps = lrmMesAdd.getDfpLists();
      //页面跳转开始------------------------
      $scope.closeMesAddPage = function () {
          $scope.mesAddModal1.remove();
      };
      $scope.OpenMesAddPage = function (num,name,url) {
         
         
          $scope.dfpnum = num;
          $scope.dfpname = name;
          if (url == ""||url==null ||url ==undefined) {
              $hengtexTopAlert.show({ text: name + "工序没有设置跳转页！请联系管理员！" });
              return;
          }
          if ($scope.mesAddModal1 != null) {
              $scope.mesAddModal1.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/' + url, {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.mesAddModal1 = modal;
              $scope.mesAddModal1.show();
          });

      };


      $scope.closeMesPage = function () {
          $scope.mesMesPageModal.remove();
      };
      $scope.OpenMesPage = function (name, url) {

          $scope.editData.mpr_procedureID = $scope.dfpnum;
          $scope.editData.mpr_procedureName = $scope.dfpname;
          $scope.hggz = "";
          $scope.checkType = "";
          if (name == "合格工资查询") {//合格工资和把关部分查询
              $scope.hggz = "合格工资查询";
              $scope.checkType = "合格";;
          } else if (name == "把关查询") {
              $scope.hggz = "把关查询";
              $scope.checkType = "把关";
          }
         
          if (url == "" || url == null || url == undefined) {
              $hengtexTopAlert.show({ text: name + "工序没有设置跳转页！请联系管理员！" });
              return;
          }
          if ($scope.mesMesPageModal != null) {
              $scope.mesMesPageModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/' + url, {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.mesMesPageModal = modal;
              $scope.mesMesPageModal.show();
          });

      };
      //页面跳转结束--------------------------
        
  }])


//报工登记
app.controller('MesAddCtrl', [
    '$scope', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmMesAdd', '$ionicScrollDelegate', 'lrmBaseInfo',
  function ($scope, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmMesAdd, $ionicScrollDelegate, lrmBaseInfo) {
      $scope.data = lrmMesAdd.getList();
    
      //
    


      //设置盘头号
      $scope.setEditDataConPanHead = function (u) {
          
          $scope.editData.mpr_panNo = u.dcph_no;         

      };
     
        
      $scope.pbpcPops = [{

              pbpc: 'pbpc1'
      }, {

              pbpc: 'pbpc2'
      }, {

              pbpc: 'pbpc3'
      }];
      $scope.toggleRight = function () {
          $ionicSideMenuDelegate.toggleRight();
      };
          //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
          $ionicScrollDelegate.resize();
      }, 450);
      $scope.doRefresh = function () {
          lrmMesAdd.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmMesAdd.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

          ////弹出坯布匹次
      $scope.dataPbpc = {
              pbpc: ''
      };
      $scope.closeMesPbpcListModal = function () {
          $scope.mesPbpcListModal.remove();
      };

      $scope.SelectedPbpc = "";

      $scope.createPbpc = function () {
          if ($scope.SelectedPbpc != "") {
              $scope.pbpcPops.push({
                  'pbpc': $scope.SelectedPbpc
              });

      }
          $scope.mesPbpcListModal.remove();
      };

      $scope.setSelectedPbpc = function (u) {

          $scope.SelectedPbpc = u.pbpc;
      };
      $scope.openMesPbpcList = function () {

          if ($scope.mesPbpcListModal != null) {
              $scope.mesPbpcListModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesAddpbpcPop.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right',
                  focusFirstInput: true
          }).then(function (modal) {
              $scope.mesPbpcListModal = modal;
              $scope.mesPbpcListModal.show();
          });

      };


          //报工记录页
      $scope.closeMesBgListModal = function () {
          $scope.mesBgListModal.remove();
      };
      $scope.openMesBgList = function () {
          if ($scope.mesBgListModal != null) {
              $scope.mesBgListModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/home-mesReport.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right',
                  focusFirstInput: true
          }).then(function (modal) {
              $scope.mesBgListModal = modal;
              $scope.mesBgListModal.show();
          });

      };
      $scope.doSearch = function () {
          lrmMesAdd.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmMesAdd.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

          //合格工资
      $scope.openSalaryModal = function () {

          if ($scope.salaryModal != null) {
              $scope.salaryModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesSalary.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.salaryModal = modal;
              $scope.salaryModal.show();
          });
      };
      $scope.closeSalaryModal = function () {
          $scope.salaryModal.remove();
      };

          //上班组报工记录
      $scope.openBgLastModal = function () {

          if ($scope.bgLastModal != null) {
              $scope.bgLastModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesSalary.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.bgLastModal = modal;
              $scope.bgLastModal.show();
          });
      };
      $scope.closeBgLastModal = function () {
          $scope.bgLastModal.remove();
      };
          //质检记录
      $scope.openZjModal = function () {

          if ($scope.zjModal != null) {
              $scope.zjModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesZjList.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.zjModal = modal;
              $scope.zjModal.show();
          });
      };
      $scope.closeZjModal = function () {
          $scope.zjModal.remove();
      };
          //把关
      $scope.openMesTestModal = function () {

          if ($scope.mesTestModal != null) {
              $scope.mesTestModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesTest.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.mesTestModal = modal;
              $scope.mesTestModal.show();
          });
      };
      $scope.closeMesTestModal = function () {
          $scope.mesTestModal.remove();
      };
          //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {
      };
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
      }
          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/business/businessEdit.html', {
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

      $scope.openGroupSelectModal = function () {//打开班组来源


          lrmMesAdd.getGroupSource().then(function (result) {//绑定  
           
              $hengtexSelectModal({
                  title: "班组",
                  bgAllColor: "royal-bg",
                  selectValue: $scope.editData.mpr_group,
                  text: "itemName",
                  value: "itemValue",
                  data: result,
                  onChange: function (item) {

                      $scope.editData.mpr_group = item.text;

                  }
              });
          }, function () {

              console.log('errror');
          });
          
      };
          //删除
      $scope.doDelete = function (business) {
          $hengtexPopup.confirm({
                  title: '<p> </p>确定要删除?<p> </p>',
                  okText: '删除',
                  ok: function () {
                  lrmMesAdd.remove(business);
                  if ($scope.detailsModal != null) {
                      $scope.detailsModal.remove();
                  }
          }
          });
      };
          //添加保存
      $scope.dobgSubmit = function () {
          //var res = $hengtexDataIsAll.isAll($scope.editData, lrmMesAdd.getEditDataEx());
          if ($scope.editData.mpr_fcltNum == "") {
              $hengtexTopAlert.show({
                  text:  " 机台号不能为空"
              });
          }else if($scope.editData.mpr_batch==""){
              $hengtexTopAlert.show({
                  text: " 批次不能为空"
              });
          }
          else {
              $ionicLoading.show();
              lrmMesAdd.editSubmit($scope.editData, function () {

                  $ionicLoading.hide();
                  $scope.editData.mpr_taskNum = "";
                  $scope.editData.mpr_date = "";
                 
                  $scope.editData.mpr_SEFlag = "";
                  $scope.editData.mpr_fcltName = "";
                  $scope.editData.mpr_fcltNum = "";
                  $scope.editData.mpr_group = "";
                  $scope.editData.mpr_batch = "";
                  $scope.editData.mpr_pinhao = "";
                  $scope.editData.mpr_color = "";
                  $scope.editData.mpr_attr = "";
                  $scope.editData.mpr_count = "";
                  $scope.editData.mpr_bl = "";
                  $scope.editData.mpr_panNo = "";
                  $scope.editData.mpr_hankCount = "";
                  $scope.editData.mpr_numDetail = "";
                  $scope.editData.mpr_horseNo = "";
                  $scope.editData.mpr_timeCount = "";
                  $scope.editData.mpr_location = "";
                  $scope.editData.mpr_decript = "";
                  $scope.editData.mpr_remarks = "";
                  $scope.editData.mpr_Person = "";                 

                  $scope.editData.mpr_locationName = "";

                
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
      }
      }


      //批次选择页
      $scope.closeBgBatchSearchModal = function () {
          $scope.searchBgBatchModal.remove();
      };
      $scope.openBgBatchSearch = function () {
          $scope.searchBgBatchData = lrmMesAdd.getBgBatchSearchList();
          console.log($scope.searchBgBatchData);
          if ($scope.searchBgBatchModal != null) {
              $scope.searchBgBatchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesBgBatchSearchPop.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchBgBatchModal = modal;
              $scope.searchBgBatchModal.show();
          });

      };
      $scope.doBgBatchSearch = function () {
          
          lrmMesAdd.searchBgBatchData();
      };
      $scope.loadMoreBgBatchSearch = function () {
          lrmMesAdd.searchBgBatchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      //机台选择页面
      $scope.closeBgFcltSearchModal = function () {
          $scope.searchBgFcltModal.remove();
      };
      $scope.openBgFcltSearch = function () {
          $scope.searchBgFcltData = lrmMesAdd.getBgFcltSearchList();
          console.log($scope.searchBgFcltData);
          if ($scope.searchBgFcltModal != null) {
              $scope.searchBgFcltModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesBgFcltSearchPop.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchBgFcltModal = modal;
              $scope.searchBgFcltModal.show();
          });

      };
      $scope.doBgFcltSearch = function () {

          lrmMesAdd.searchBgFcltData();
      };
      $scope.loadMoreBgFcltSearch = function () {
          lrmMesAdd.searchBgFcltDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      //盘头选择页面
      $scope.closeBgConPanHeadSearchModal = function () {
          $scope.searchBgConPanHeadModal.remove();
      };
      $scope.openBgConPanHeadSearch = function () {
          $scope.searchBgConPanHeadData = lrmMesAdd.getBgConPanHeadSearchList();
          console.log($scope.searchBgConPanHeadData);
          if ($scope.searchBgConPanHeadModal != null) {
              $scope.searchBgConPanHeadModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesBgPanHeadSearchPop.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchBgConPanHeadModal = modal;
              $scope.searchBgConPanHeadModal.show();
          });

      };
      $scope.doBgConPanHeadSearch = function () {

          lrmMesAdd.searchBgConPanHeadData();
      };
      $scope.loadMoreBgConPanHeadSearch = function () {
          lrmMesAdd.searchBgConPanHeadDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      //货位选择页面
      $scope.closeBgConPanPositionSearchModal = function () {
          $scope.searchBgConPanPositionModal.remove();
      };
      $scope.openBgConPanPositionSearch = function () {
        
          $scope.searchBgConPanPositionData = lrmMesAdd.getBgConPanPositionSearchList();
          console.log($scope.searchBgConPanPositionData);
          if ($scope.searchBgConPanPositionModal != null) {
              $scope.searchBgConPanPositionModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesBgPanPositionSearchPop.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchBgConPanPositionModal = modal;
              $scope.searchBgConPanPositionModal.show();
          });

      };
      $scope.doBgConPanPositionSearch = function () {
          lrmMesAdd.searchBgConPanPositionData();
      };
     
  }])
//合格工资
.controller('MesSalaryCtrl', [
    '$scope', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmMesSalary', '$ionicScrollDelegate', 'lrmBaseInfo',
  function ($scope, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmMesSalary, $ionicScrollDelegate, lrmBaseInfo) {
      $scope.data = lrmMesSalary.getList();
      $scope.editDataHgGz = {
          "mpc_id": "",
          "mpc_num": "",//报工单据号     
          "mpc_mprNum": "",//报工单据号     
          "mpc_date": "",//登记日期    
          "mpc_procedureID": "",//工序ID        
          "mpc_procedureName": "",//工序名称     
          "mpc_qid": "",//质量项目ID     
          "mpc_qname": "",//质量项目名称     
          "mpc_checkType": "",//考核方式      
          "mpc_group": "",//班组                   
          "mpc_pcs": "",//个数      
          "mpc_count": "",//数量      
          "mpc_price": "",//单价比例      
          "mpc_amount": "",//金额      
          "mpc_amountAdd": "",//追加金额     
          "mpc_checkAvg": "",//考核均分      
          "mpc_salaryFlag": "",////工资标志
          "mpc_TypeFlag": "",//分类                     
          "mpc_panNo": "",//盘头号                    
          "mpc_horseNo": "",//匹次      
          "mpc_proIDCheck": "",//把关工序ID        
          "mpc_proNameCheck": "",//把关工序名称    
          "mpc_depart": "",//部门    
          "mpc_departName": "",//部门名称      
          "mpc_decript": "",//描述     
          "mpc_remarks": "",
          "CreationDate": "",
          "CreatedBy": "",
          "CreatedByNum": "",
          "LastUpdateDate": "",
          "LastUpdatedBy": "",
          "AppUser": "",
          "AppDate": "",
          "FlagApp": "",
          "DelMan": "",
          "DelDate": "",
          "FlagDelete": ""
      };
      $scope.salaryTests = [];//质检记录
      $scope.salarybglists = [];//报工记录
      //设定合格工资把关工序以及考核项目
      //设置金额
      $scope.setAmount = function () {
          var count = $scope.editDataHgGz.mpc_pcs;
          alert(count);
          var reg = /^[0-9]+$/g;
          if ($scope.editDataHgGz.mpc_qname == "") {
              $hengtexTopAlert.show({
                  text: " 请先选择检验项目"
              });
          }else{
              if (reg.test(count)) {
                  if ($scope.editDataHgGz.mpc_checkType == "按个数") {
                      $scope.editDataHgGz.mpc_amount = $scope.editDataHgGz.mpc_pcs * $scope.editDataHgGz.mpc_price;
                      //alert("mpc_amount:" + $scope.editDataHgGz.mpc_amount);
                  } else {
                      //按固定金额
                  }
                 
              } else {
                  $scope.editDataHgGz.mpc_pcs = "";
                  $hengtexTopAlert.show({
                      text: " 请输入数字"
                  });
              }
          }
        
      }

      lrmMesSalary.getDfpCheckSalarys($scope.dfpnum).then(function (result) {
         
          var objReceive = result;
          if (objReceive.length > 0) {
              $scope.mpcs_proIDAc = objReceive[0].mpcs_proIDAc;//根据当前工序获取可把关工序
              $scope.mpcs_proNameAc = objReceive[0].mpcs_proNameAc;
             
              
              lrmMesSalary.getMesProCheckItems($scope.mpcs_proIDAc).then(function (result) {//根据可把关工序设置考核项目
                 
                  if (result.length > 0) {
                      $scope.editDataHgGz.mpc_qid = result[0].mpqi_id;
                      $scope.editDataHgGz.mpc_qname = result[0].mpqi_name;
                      $scope.editDataHgGz.mpc_checkType = result[0].mpqi_checkType;
                      $scope.editDataHgGz.mpc_price = result[0].mpqi_price;
                      $scope.editDataHgGz.mpc_amountAdd = result[0].mpqi_amountAdd;
                      $scope.editDataHgGz.mpc_checkAvg = result[0].mpqi_checkAvg;

                  } else {
                    
                      $hengtexTopAlert.show({ text: $scope.mpcs_proNameAc+"工序还没设定考核项目，请联系管理人员添加！" });
                  }
              }, function () {

              });

              var whereBg = "   mpr_procedureID   = " + $scope.mpcs_proIDAc + "  and mpr_checkResult is null ";
              lrmMesSalary.getMesBgListsByProIds(whereBg).then(function (result) {//根据把关工序获取报工记录                
                  if (result.length > 0) {

                      var objMesBgLists = [];
                      // objCheckItems.splice(0, objCheckItems.length);// cases=[];
                      for (var i = 0; i < result.length; i++) {
                          var item = result[i];
                          var obj = {};
                          obj.mpr_id = item.mpr_id;
                          obj.mpr_procedureID = item.mpr_procedureID;
                          obj.mpr_procedureName = item.mpr_procedureName;
                          obj.mpr_horseNo = item.mpr_horseNo;
                          obj.mpr_panNo = item.mpr_panNo;
                          obj.mpr_hankCount = item.mpr_hankCount;
                          obj.mpr_count = item.mpr_count;
                          obj.mpr_num = item.mpr_num;
                          objMesBgLists.push(obj);

                      }

                      $scope.salarybglists = objMesBgLists;//用来存放报工记录，在

                  } else {

                      $hengtexTopAlert.show({ text: $scope.dfpcheckName + "工序还没设定考核项目，请联系管理人员添加！" });
                  }
              }, function () {

              });
          }

         

      }, function () {
      });
            
      $scope.salarybg = {};//用来存放报工记录
          //报工记录弹出页
      $scope.openSalaryBgPopModal = function () {
         
          $scope.searchData = lrmMesSalary.getSearchList();//查询
          lrmMesSalary.searchData();
          if ($scope.SalaryBgPopModal != null) {
              $scope.SalaryBgPopModal.remove();
      }

          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesSalaryBgPop.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.SalaryBgPopModal = modal;
              $scope.SalaryBgPopModal.show();
          });
      };
      $scope.closeSalaryBgPopModal = function () {
          if ($scope.SalaryBgPopModal != null) {
              $scope.SalaryBgPopModal.remove();
      }
      };
      $scope.setSelectedSalaryBg = function (u) {
          
          $scope.editDataHgGz.mpc_procedureID = u.mpr_procedureID;

          $scope.editDataHgGz.mpc_procedureName = u.mpr_procedureName;
          $scope.editDataHgGz.mpc_mprNum = u.mpr_num;
         
          $scope.editDataHgGz.mpc_hankCount = u.mpr_hankCount;
          $scope.editDataHgGz.mpc_count = u.mpr_count;
          $scope.editDataHgGz.mpc_panNo = u.mpr_panNo;
          $scope.editDataHgGz.mpc_date = u.mpr_date;
          $scope.editDataHgGz.mpc_group = u.mpr_group;
          $scope.editDataHgGz.mpc_salaryFlag = u.mpr_salaryFlag;
          $scope.editDataHgGz.mpc_TypeFlag = '合格';
          $scope.editDataHgGz.mpc_batch = u.mpr_batch;
          $scope.editDataHgGz.mpc_panNo = u.mpr_panNo;
          $scope.editDataHgGz.mpc_horseNo = u.mpr_horseNo;
          $scope.editDataHgGz.mpc_proIDCheck = $scope.dfpnum;
          $scope.editDataHgGz.mpc_proNameCheck = $scope.dfpname;
          $scope.editDataHgGz.mpc_decript = u.mpr_decript;
          $scope.editDataHgGz.mpc_remarks = u.mpr_remarks;
          
      };
          //报工记录确认
      $scope.confirmSalaryBg = function () {
       

          if ($scope.SalaryBgPopModal != null) {
              $scope.SalaryBgPopModal.remove();
      }
      };
      
          //合格工资报工记录弹出窗口结束-----------------------------------------------------------


          //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
          $ionicScrollDelegate.resize();
      }, 450);
      $scope.doRefresh = function () {
          lrmMesSalary.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmMesSalary.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
          //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmMesSalary.getSearchList();
          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
      }
          $ionicModal.fromTemplateUrl('templates/homeApps/business/businessSearch.html', {
                  scope: $scope,
                  animation: 'lr-slide-in-right',
                  focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {
          lrmMesSalary.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmMesSalary.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
    
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
    
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };

    

          //删除
      $scope.doDelete = function (business) {
          $hengtexPopup.confirm({
                  title: '<p> </p>确定要删除?<p> </p>',
                  okText: '删除',
                  ok: function () {
                  lrmMesSalary.remove(business);
                  if ($scope.detailsModal != null) {
                      $scope.detailsModal.remove();
                  }
          }
          });
      };
          //添加保存
      //添加保存
      $scope.dobgSalarySubmit = function (checkResult) {
          var modelSalary = { 'editDataHgGz': $scope.editDataHgGz, 'checkResult': checkResult };
          //var res = $hengtexDataIsAll.isAll($scope.editData, lrmMesAdd.getEditDataEx());
          if ($scope.editDataHgGz.mpc_proIDCheck == "") {
              $hengtexTopAlert.show({
                  text: " 把关项目不能为空"
              });
          } else if ($scope.editDataHgGz.mpc_mprNum == "") {
              $hengtexTopAlert.show({
                  text: " 报工记录不能为空"
              });
          }
          else {
              $ionicLoading.show();
              lrmMesSalary.editSubmit(modelSalary, function () {
                  $ionicLoading.hide();


                  $scope.editDataHgGz.mpc_qid = "";
                  $scope.editDataHgGz.mpc_qname = "";
                  $scope.editDataHgGz.mpc_checkType = "";
                  $scope.editDataHgGz.mpc_price = "";
                  $scope.editDataHgGz.mpc_amountAdd = "";
                  $scope.editDataHgGz.mpc_checkAvg = "";
                  $scope.editDataHgGz.mpc_pcs = "";
                  $scope.editDataHgGz.mpc_amount = "";
                  $scope.editDataHgGz.mpc_procedureID = "";

                  $scope.editDataHgGz.mpc_procedureName = "";
                  $scope.editDataHgGz.mpc_mprNum = "";

                  $scope.editDataHgGz.mpc_hankCount = "";
                  $scope.editDataHgGz.mpc_count = "";
                  $scope.editDataHgGz.mpc_panNo = "";
                  $scope.editDataHgGz.mpc_date = "";
                  $scope.editDataHgGz.mpc_group = "";
                  $scope.editDataHgGz.mpc_salaryFlag = "";
                  $scope.editDataHgGz.mpc_TypeFlag = "";
                  $scope.editDataHgGz.mpc_batch = "";
                  $scope.editDataHgGz.mpc_panNo = "";
                  $scope.editDataHgGz.mpc_horseNo = "";
                  
                  $scope.editDataHgGz.mpc_decript = "";
                  $scope.editDataHgGz.mpc_remarks = "";
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }
  }])
//把关
.controller('MesTestCtrl', [
    '$scope', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmMesTest', '$ionicScrollDelegate', 'lrmBaseInfo',
  function ($scope, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmMesTest, $ionicScrollDelegate, lrmBaseInfo) {
      $scope.data = lrmMesTest.getList();
      $scope.editDataBg = {
          "mpc_id": "",
          "mpc_num": "",//报工单据号     
          "mpc_mprNum": "",//报工单据号     
          "mpc_date": "",//登记日期    
          "mpc_procedureID": "",//工序ID        
          "mpc_procedureName": "",//工序名称     
          "mpc_qid": "",//质量项目ID     
          "mpc_qname": "",//质量项目名称     
          "mpc_checkType": "",//考核方式      
          "mpc_group": "",//班组                   
          "mpc_pcs": "",//个数      
          "mpc_count": "",//数量      
          "mpc_price": "",//单价比例      
          "mpc_amount": "",//金额      
          "mpc_amountAdd": "",//追加金额     
          "mpc_checkAvg": "",//考核均分      
          "mpc_salaryFlag": "",////工资标志
          "mpc_TypeFlag": "",//分类                     
          "mpc_panNo": "",//盘头号                    
          "mpc_horseNo": "",//匹次      
          "mpc_proIDCheck": "",//把关工序ID        
          "mpc_proNameCheck": "",//把关工序名称    
          "mpc_depart": "",//部门    
          "mpc_departName": "",//部门名称      
          "mpc_decript": "",//描述     
          "mpc_remarks": "",
          "CreationDate": "",
          "CreatedBy": "",
          "CreatedByNum": "",
          "LastUpdateDate": "",
          "LastUpdatedBy": "",
          "AppUser": "",
          "AppDate": "",
          "FlagApp": "",
          "DelMan": "",
          "DelDate": "",
          "FlagDelete": ""
      };
      $scope.salaryTests = [];
      $scope.salarybglists = [];
      $scope.editDataBg.mpc_proIDCheck = $scope.dfpnum;
      $scope.editDataBg.mpc_proNameCheck = $scope.dfpname;
      lrmMesTest.getDfpCheckSalarys($scope.dfpnum).then(function (result) {

          var objReceive =result;
          if (objReceive.length > 0) {
              $scope.dfpcheckID = objReceive[0].mpcs_proIDCheck;//可把关工序
              $scope.dfpcheckName = objReceive[0].mpcs_proNameCheck;

              var where = "   mpqi_procedureID   in (" + $scope.dfpcheckID + ")";
              lrmMesTest.getMesProCheckItems(where).then(function (result) {//根据把关工序查询考核项目                
                  if (result.length > 0) {
                    
                     
                      var objCheckItems = [];
                      objCheckItems.splice(0, objCheckItems.length);// cases=[];
                      for (var i = 0; i < result.length; i++) {
                         
                          var item = result[i];
                         
                          var obj = {};
                          obj.mpqi_id = item.mpqi_id;
                          obj.mpqi_procedureID = item.mpqi_procedureID;
                          obj.mpqi_procedureName = item.mpqi_procedureName;
                          obj.mpqi_type = item.mpqi_type;
                          obj.mpqi_name = item.mpqi_name;
                          obj.mpqi_checkType = item.mpqi_checkType;
                          obj.mpqi_price = item.mpqi_price;
                          obj.mpqi_amountAdd = item.mpqi_amountAdd;
                          obj.mpqi_checkAvg = item.mpqi_checkAvg;
                          objCheckItems.push(obj);
                         
                      }

                      $scope.salaryTests = objCheckItems;
                     
                  } else {

                      $hengtexTopAlert.show({ text: $scope.dfpcheckName + "工序还没设定考核项目，请联系管理人员添加！" });
                  }
              }, function () {

              });

              var whereBg = "   mpr_procedureID   in (" + $scope.dfpcheckID + ")";
              lrmMesTest.getMesBgListsByProIds(whereBg).then(function (result) {//根据把关工序查询报工记录                
                  if (result.length > 0) {

                      var objMesBgLists = [];
                      // objCheckItems.splice(0, objCheckItems.length);// cases=[];
                      for (var i = 0; i < result.length; i++) {
                          var item = result[i];
                          var obj = {};
                          obj.mpr_id = item.mpr_id;
                          obj.mpr_procedureID = item.mpr_procedureID;
                          obj.mpr_procedureName = item.mpr_procedureName;
                          obj.mpr_horseNo = item.mpr_horseNo;
                          obj.mpr_panNo = item.mpr_panNo;
                          obj.mpr_hankCount = item.mpr_hankCount;
                          obj.mpr_count = item.mpr_count;
                          obj.mpr_num = item.mpr_num;
                          objMesBgLists.push(obj);

                      }

                      $scope.salarybglists = objMesBgLists;

                  } else {

                      $hengtexTopAlert.show({ text: $scope.dfpcheckName + "工序还没设定考核项目，请联系管理人员添加！" });
                  }
              }, function () {

              });
            
           }
         

      }, function () {

          console.log('errror');
      });

    
      //合格工资质检记录弹出窗口开始----------------------------------------------------
     
      $scope.afterSalary = {};//点击确认菜单时候存放质检记录
      $scope.salaryTest = {};//用来存放质检记录
      //质检弹出页
      $scope.openSalaryTestPopModal = function () {
          
          if ($scope.SalaryTestPopModal != null) {
              $scope.SalaryTestPopModal.remove();
          }

          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesSalaryTestPop.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.SalaryTestPopModal = modal;
              $scope.SalaryTestPopModal.show();
          });
      };
      $scope.closeSalaryTestPopModal = function () {
          if ($scope.SalaryTestPopModal != null) {
              $scope.SalaryTestPopModal.remove();
          }
      };
      $scope.setSelectedsalaryTest = function (u) {

          $scope.editDataBg.mpc_qid = u.mpqi_id;
          $scope.editDataBg.mpc_qname = u.mpqi_name;
          $scope.editDataBg.mpc_checkType = u.mpqi_checkType;
          $scope.editDataBg.mpc_price = u.mpqi_price;
          $scope.editDataBg.mpc_amountAdd = u.mpqi_amountAdd;
          $scope.editDataBg.mpc_checkAvg = u.mpqi_checkAvg;
        

      };
      //质检记录确认
      $scope.confirmSalaryTest = function () {
          $scope.afterSalary = $scope.salaryTest;
          if ($scope.SalaryTestPopModal != null) {
              $scope.SalaryTestPopModal.remove();
          }
      };
      $scope.toggleRight = function () {
          $ionicSideMenuDelegate.toggleRight();
      };
      //合格工资质检记录弹出窗口结束-----------------------------------------------------------


      //合格工资报工记录弹出窗口开始----------------------------------------------------
     
  
      
      $scope.setSelectedTestBg = function (u) {//根据报工记录填写

          $scope.editDataBg.mpc_procedureID = u.mpr_procedureID;

          $scope.editDataBg.mpc_procedureName = u.mpr_procedureName;
          $scope.editDataBg.mpc_mprNum = u.mpr_num;

          $scope.editDataBg.mpc_hankCount = u.mpr_hankCount;
          $scope.editDataBg.mpc_count = u.mpr_count;
          $scope.editDataBg.mpc_panNo = u.mpr_panNo;
          $scope.editDataBg.mpc_date = u.mpr_date;
          $scope.editDataBg.mpc_group = u.mpr_group;
          $scope.editDataBg.mpc_salaryFlag = u.mpr_salaryFlag;
          $scope.editDataBg.mpc_TypeFlag = '把关';
          $scope.editDataBg.mpc_batch = u.mpr_batch;
          $scope.editDataBg.mpc_panNo = u.mpr_panNo;
          $scope.editDataBg.mpc_horseNo = u.mpr_horseNo;
         
          $scope.editDataBg.mpc_decript = u.mpr_decript;
          $scope.editDataBg.mpc_remarks = u.mpr_remarks;

      };
      $scope.salarybg = {};//用来存放报工记录
      //报工记录弹出页
      $scope.openSalaryBgPopModal = function () {
          $scope.searchData = lrmMesTest.getSearchList();//查询
          lrmMesTest.searchData();
          if ($scope.SalaryBgPopModal != null) {
              $scope.SalaryBgPopModal.remove();
          }
        
          $ionicModal.fromTemplateUrl('templates/homeApps/mesSystem/mesPopModel/mesTestBgPop.html', {
              scope: $scope,
              animation: 'lr-slide-in-right'
          }).then(function (modal) {
              $scope.SalaryBgPopModal = modal;
              $scope.SalaryBgPopModal.show();
          });
      };
      $scope.closeSalaryBgPopModal = function () {
          if ($scope.SalaryBgPopModal != null) {
              $scope.SalaryBgPopModal.remove();
          }
      };
      $scope.setSelectedSalaryBg = function (u) {

          $scope.salarybg.mpr_procedureName = u.mpr_procedureName;
          $scope.salarybg.mpr_num = u.mpr_num;
          $scope.salarybg.pbpc = u.pbpc;
          $scope.salarybg.mpr_hankCount = u.mpr_hankCount;
          $scope.salarybg.mpr_count = u.mpr_count;
          $scope.salarybg.mpr_panNo = u.mpr_panNo;
          $scope.salarybg.mpr_date = u.mpr_date;
         

      };
      //报工记录确认
      $scope.confirmSalaryBg = function () {

          $scope.salaryTest.pth = $scope.salarybg.mpr_panNo;
          $scope.salaryTest.zrr = $scope.salarybg.mpr_num;

          if ($scope.SalaryBgPopModal != null) {
              $scope.SalaryBgPopModal.remove();
          }
      };

      //合格工资报工记录弹出窗口结束-----------------------------------------------------------


      $scope.toggleRight = function () {
          $ionicSideMenuDelegate.toggleRight();
      };
      //刷新数据
      $timeout(function () {
          $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
          $ionicScrollDelegate.resize();
      }, 450);
      $scope.doRefresh = function () {
          lrmMesTest.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmMesTest.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };


    
      $scope.doSearch = function () {
          lrmMesTest.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmMesTest.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
     
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
     
      //添加保存
      $scope.dobgTestSubmit = function (checkResult) {
          var modelSalary = { 'editDataHgGz': $scope.editDataBg, 'checkResult': checkResult };
          //var res = $hengtexDataIsAll.isAll($scope.editData, lrmMesAdd.getEditDataEx());
          if ($scope.editDataBg.mpc_proIDCheck == "") {
              $hengtexTopAlert.show({
                  text: " 把关项目不能为空"
              });
          } else if ($scope.editDataBg.mpc_mprNum == "") {
              $hengtexTopAlert.show({
                  text: " 报工记录不能为空"
              });
          }
          else {
              $ionicLoading.show();
              lrmMesTest.editSubmit(modelSalary, function () {
                  $ionicLoading.hide();

                  $scope.editDataBg.mpc_qid = "";
                  $scope.editDataBg.mpc_qname = "";
                  $scope.editDataBg.mpc_checkType = "";
                  $scope.editDataBg.mpc_price = "";
                  $scope.editDataBg.mpc_amountAdd = "";
                  $scope.editDataBg.mpc_checkAvg = "";
                  $scope.editDataBg.mpc_pcs = "";
                  $scope.editDataBg.mpc_amount = "";
                  $scope.editDataBg.mpc_procedureID = "";

                  $scope.editDataBg.mpc_procedureName = "";
                  $scope.editDataBg.mpc_mprNum = "";

                  $scope.editDataBg.mpc_hankCount = "";
                  $scope.editDataBg.mpc_count = "";
                  $scope.editDataBg.mpc_panNo = "";
                  $scope.editDataBg.mpc_date = "";
                  $scope.editDataBg.mpc_group = "";
                  $scope.editDataBg.mpc_salaryFlag = "";
                  $scope.editDataBg.mpc_TypeFlag = "";
                  $scope.editDataBg.mpc_batch = "";
                  $scope.editDataBg.mpc_panNo = "";
                  $scope.editDataBg.mpc_horseNo = "";
                  
                  $scope.editDataBg.mpc_decript = "";
                  $scope.editDataBg.mpc_remarks = "";
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }
  }])
//报工记录
.controller('MesAddListCtrl', [
    '$scope', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmMesAddList', '$ionicScrollDelegate', 'lrmBaseInfo',
  function ($scope, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmMesAddList, $ionicScrollDelegate, lrmBaseInfo) {
      $scope.data = lrmMesAddList.getList();
      //begin
      $scope.searchData = lrmMesAddList.getSearchList();//查询
      lrmMesAddList.searchData();
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
          lrmMesAddList.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmMesAddList.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmMesAddList.getSearchList();
          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/business/businessSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {
          lrmMesAddList.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmMesAddList.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {
          $scope.detailsData = lrmMesAddList.get(chanceId);
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/business/businessDetails.html', {
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
          $ionicModal.fromTemplateUrl('templates/homeApps/business/businessEdit.html', {
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

      $scope.openSourceSelectModal = function () {//打开选择商机来源
          $hengtexSelectModal({
              title: "商机来源",
              bgAllColor: "royal-bg",
              selectValue: $scope.editData.SourceId,
              text: "itemName",
              value: "itemValue",
              data: lrmMesAddList.getChanceSource(),
              onChange: function (item) {
                  $scope.editData.sourceId = item.value;
                  $scope.editData.sourceName = item.text;
              }
          });
      };
      $scope.openStageSelectModal = function () {//打开选择商机阶段
          $hengtexSelectModal({
              title: "商机阶段",
              selectValue: $scope.editData.StageId,
              text: "itemName",
              value: "itemValue",
              bgColor: "bgColor",
              data: lrmMesAddList.getChancePhases(),
              onChange: function (item) {
                  $scope.editData.stageId = item.value;
                  $scope.editData.stageName = item.text;
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
                  lrmMesAddList.remove(business);
                  if ($scope.detailsModal != null) {
                      $scope.detailsModal.remove();
                  }
              }
          });
      };
      //添加保存
      $scope.doSubmit = function () {
          var res = $hengtexDataIsAll.isAll($scope.editData, lrmMesAddList.getEditDataEx());
          if (res != null) {
              $hengtexTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              lrmMesAddList.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $hengtexTriggerRefresh.triggerRefresh('businesslist-content');
              });
          }
      }
  }])
//质检记录
.controller('MesTestListCtrl', [
    '$scope', '$ionicSideMenuDelegate', '$timeout', '$ionicModal', '$hengtexPopup', '$ionicLoading', '$hengtexTopAlert', '$hengtexTriggerRefresh', '$hengtexSelectModal', '$hengtexDataIsAll', 'lrmMesTestList', '$ionicScrollDelegate', 'lrmBaseInfo',
  function ($scope, $ionicSideMenuDelegate, $timeout, $ionicModal, $hengtexPopup, $ionicLoading, $hengtexTopAlert, $hengtexTriggerRefresh, $hengtexSelectModal, $hengtexDataIsAll, lrmMesTestList, $ionicScrollDelegate, lrmBaseInfo) {
      $scope.data = lrmMesTestList.getList();
      //begin
      $scope.searchData = lrmMesTestList.getSearchList();//查询
      $scope.searchData.checkrype = $scope.checkType;
      lrmMesTestList.searchData($scope.checkType);
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
          lrmMesTestList.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmMesTestList.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmMesTestList.getSearchList();
          console.log($scope.searchData);
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/business/businessSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {
          lrmMesTestList.searchData($scope.checkType);
      };
      $scope.loadMoreSearch = function () {
          lrmMesTestList.searchDataAdd($scope.checkType,function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (chanceId) {
          $scope.detailsData = lrmMesTestList.get(chanceId);
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/business/businessDetails.html', {
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
     
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };

    

      //删除
      $scope.doDelete = function (business) {
          $hengtexPopup.confirm({
              title: '<p> </p>确定要删除?<p> </p>',
              okText: '删除',
              ok: function () {
                  lrmMesTestList.remove(business);
                  if ($scope.detailsModal != null) {
                      $scope.detailsModal.remove();
                  }
              }
          });
      };
      
  }])
