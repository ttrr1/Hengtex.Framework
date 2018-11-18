//报工登记
app.factory('lrmMesAdd',['$hengtexFormatDate','$hengtexGetDataItem','$hengtexHttp','ApiUrl','$hengtexTopAlert','UserInfo','$q',
function ($hengtexFormatDate,$hengtexGetDataItem,$hengtexHttp,ApiUrl,$hengtexTopAlert,UserInfo,$q) {
      //商机列表数据
      var businessList ={
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          businesss: []
      };
      var businessListSearch = {};//搜索列表数据
      var bgBatchListSearch = {};//搜索批次数据
      var bgFcltListSearch = {};//搜索档案数据
      var bgConPanHeadListSearch = {};//搜索盘头数据
      var bgConPanPositionListSearch = {};//搜索货位数据
      var chancePhases = {};//商机阶段
      var chanceSource = {};//商机来源
      var groupSource =[];//班组来源

      var dfpLists = [];//工序列表
    
      //方法函数(数据遍历转化)
      function translateData(data,obj) {
          //console.log(data);
          for (var i in data) {
              var item = data[i];
              //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
              //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
              data[i].stageName = data[i].stageId;
              data[i].bgStageColor = 'calm-bg';
              //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
              data[i].sourceName = data[i].sourceId;

              data[i].lastDate =  $hengtexFormatDate(item.modifyDate, 'MM-dd');
              data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
              data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
              data[i].dealDate = $hengtexFormatDate(item.dealDate, 'yyyy-MM-dd');
              obj.push(data[i]);
          }
      };
      //获取数据方法
      function getData(page,queryData,obj,callback) {
          $hengtexHttp.post({
              "url": ApiUrl.chanceListApi,
              "data": { "page": page, "rows": 10, "sidx": "ModifyDate", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if(page == 1) {
                      obj.businesss =[];
                  }
                  translateData(data.result.rows, obj.businesss);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page+1;
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }

    //方法函数(数据遍历转化)
      function translateBatchData(data, obj) {
          //console.log(data);
          for (var i in data) {
             
              obj.push(data[i]);
          }
      };
      function translatePanPositionData(data, obj) {
          //console.log(data);
          for (var i in data) {

              obj.push(data[i]);
          }
      };
      function getBgBatchData(page, queryData, obj, callback) {
         
          $hengtexHttp.post({
              "url": ApiUrl.getbgbatchModuleList,
              "data": { "page": page, "rows": 10, "sidx": "b_num", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.BgBatchs = [];
                  }
                  translateBatchData(data.result.rows, obj.BgBatchs);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }

      function getBgFcltData(page, queryData, obj, callback) {

          $hengtexHttp.post({
              "url": ApiUrl.getbgFcltModuleListApi,
              "data": { "page": page, "rows": 10, "sidx": "CreationDate", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.BgFclts = [];
                  }
                  translateBatchData(data.result.rows, obj.BgFclts);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }
      function getBgConPanHeadData(page, queryData, obj, callback) {

          $hengtexHttp.post({
              "url": ApiUrl.getbgConPanHeadModuleListApi,
              "data": { "page": page, "rows": 30, "sidx": "CreationDate", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.BgConPanHeads = [];
                  }
                  translateBatchData(data.result.rows, obj.BgConPanHeads);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }

    
      function getBgConPanPositionData(field, value, obj, callback) {
          
          $hengtexHttp.post({
              "url": ApiUrl.getbgConPanPositionModuleListApi,
              "data": { "filed": field, "value": value },
              "isverify": true,
              "success": function (data) {
                  obj.BgConPanPositions.splice(0, obj.BgConPanPositions.length);// cases=[];
                  translateBatchData(data.result, obj.BgConPanPositions);
                  obj.records = data.resul.length;
              }, 
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }
      return {

          init: function () {//初始化信息
              $hengtexGetDataItem({
                  "itemName": 'bgpc',
                  "callback": function (data) {
                      chanceSource = data;
                  }
              });
            

          },
          getList: function () {
              return businessList;
          },
          getDfps: function () {
              var deferred = $q.defer();
              var promise = deferred.promise;
             
              
              $hengtexHttp.post({
                  "url": ApiUrl.getdocflowprocedures,
                  "data": { "Account": UserInfo.Account },
                  "async":false,
                  "success": function (data) {
                     
                      dfpLists.splice(0, dfpLists.length);// cases=[];
                      for (var i=0;i<data.result.count;i++ ) {
                          var item = data.result.dfpLists[i];
                          var obj = {};
                          obj.num = item.dfp_num;
                          obj.name = item.dfp_name;
                          obj.account = data.result.account;
                          obj.accountName = data.result.accountName;
                          obj.url = item.dfp_appUrl;

                          dfpLists.push(obj);
                      }
                      deferred.resolve(dfpLists);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "工序权限取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });
              
              return promise;
          },
         
          allByDomainName: function (domainName) {
              var deferred = $q.defer();
              var promise = deferred.promise;
              var casesDomainName = [];
              $hengtexHttp.post({
                  "url": ApiUrl.getUserModuleListApi,
                  "data": { "Account": UserInfo.Account, "DomainName": domainName },
                  "success": function (data) {
                      
                      casesDomainName.splice(0, casesDomainName.length);// cases=[];
                      for (var i in data.result) {
                          var item = data.result[i];
                          var obj = {};
                          obj.id = data.result[i].sortCode;
                          obj.name = data.result[i].fullName;
                          obj.icon = data.result[i].icon;
                          obj.bgcolor = data.result[i].color;
                          obj.viewid = data.result[i].urlAddress;
                          obj.encode = data.result[i].enCode;



                          casesDomainName.push(obj);
                          deferred.resolve(casesDomainName);
                      }

                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "mes权限取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });
              return promise;
          },
          getBatchTask: function (fcltNo) {
              var deferred = $q.defer();
              var promise = deferred.promise;
              var batchTaskLists = [];
              
              $hengtexHttp.post({
                  "url": ApiUrl.getBatchTasksDataApi,
                  "data": { "FcltNo": fcltNo },
                  
                  "success": function (data) {
                      batchTaskLists.splice(0, batchTaskLists.length);// qingkong;

                          var item = data.result;
                          var obj = {};
                          obj.mpr_taskNum = item.bpt_taskNum;
                          obj.mpr_batch = item.bpt_batch;
                          obj.mpr_color = item.bpt_color;
                          obj.mpr_pinhao = item.bpt_pinhao;
                          obj.mpr_attr = item.bpt_attr;
                          batchTaskLists.push(obj);
                      deferred.resolve(batchTaskLists);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "工序权限取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });

              return promise;
          },
          getDfpLists: function () {
              return dfpLists;
          },
          update: function (callback) {//刷新数据
              getData(1,{},businessList,callback);
          },
          add:function(callback) {
              getData(businessList.page,{},businessList,callback);
          },
          getSearchList: function () {
              businessListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  businesss: [],
                  keyword: ""
              };
              return businessListSearch;
          },
          searchData: function () {
              if (businessListSearch.keyword == "") {
                  return false;
              }
              getData(1,{ "condition": "All", "keyword": businessListSearch.keyword },businessListSearch, function () {});
          },
          searchDataAdd:function (callback){
              if (businessListSearch.keyword == "") {
                  return false;
              }
              getData(businessListSearch.page,{ "condition": "All", "keyword": businessListSearch.keyword },businessListSearch,callback);
          },
          getBgBatchSearchList: function () {
              bgBatchListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  BgBatchs: [],
                  conditionvalue: "",
                  keyword: ""
              };
              return bgBatchListSearch;
          },
          searchBgBatchData: function () {
            
              
              getBgBatchData(1, { "condition": bgBatchListSearch.conditionvalue, "keyword": bgBatchListSearch.keyword }, bgBatchListSearch, function () { });

              //getBgBatchData(1, { "condition": "All", "keyword": bgBatchListSearch.keyword }, bgBatchListSearch, function () { });
          },
          searchBgBatchDataAdd: function (callback) {
             
              getBgBatchData(bgBatchListSearch.page, { "condition":  bgBatchListSearch.conditionvalue, "keyword": bgBatchListSearch.keyword }, bgBatchListSearch, callback);
          },
          getBgFcltSearchList: function () {
              bgFcltListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  BgFclts: [],
                  conditionvalue: "All",
                  keyword: ""
              };
              return bgFcltListSearch;
          },
          searchBgFcltData: function () {


              getBgFcltData(1, { "condition": bgFcltListSearch.conditionvalue, "keyword": bgFcltListSearch.keyword }, bgFcltListSearch, function () { });

          },
          searchBgFcltDataAdd: function (callback) {

              getBgFcltData(bgFcltListSearch.page, { "condition": bgFcltListSearch.conditionvalue, "keyword": bgFcltListSearch.keyword }, bgFcltListSearch, callback);
          },
          getBgConPanHeadSearchList: function () {
              bgConPanHeadListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  BgConPanHeads: [],
                  conditionvalue: "All",
                  keyword: ""
              };
              return bgConPanHeadListSearch;
          },
          searchBgConPanHeadData: function () {
              getBgConPanHeadData(1, { "condition": bgConPanHeadListSearch.conditionvalue, "keyword": bgConPanHeadListSearch.keyword }, bgConPanHeadListSearch, function () { });


          },
          searchBgConPanHeadDataAdd: function (callback) {

              getBgConPanHeadData(bgConPanHeadListSearch.page, { "condition": bgConPanHeadListSearch.conditionvalue, "keyword": bgConPanHeadListSearch.keyword }, bgConPanHeadListSearch, callback);
          },
          getBgConPanPositionSearchList: function () {
              bgConPanPositionListSearch = {
                  records: 0,
                  BgConPanPositions: [],
                  conditionvalue: "All",
                  keyword: ""
              };
              return bgConPanPositionListSearch;
          },
          searchBgConPanPositionData: function () {
             
              getBgConPanPositionData("All", bgConPanPositionListSearch.keyword, bgConPanPositionListSearch, function () { });

              
          },
        
          get: function (chanceId) {
              for (var i = 0; i < businessList.businesss.length; i++) {
                  if (businessList.businesss[i].chanceId === chanceId) {
                      return businessList.businesss[i];
                  }
              }
              if(businessListSearch.businesss != undefined){
                  for (var i = 0; i < businessListSearch.businesss.length; i++) {
                      if (businessListSearch.businesss[i].chanceId === chanceId) {
                          return businessListSearch.businesss[i];
                      }
                  }
              }
              return null;
          },
          getChancePhases: function () {
              return chancePhases;
          },
          getChanceSource: function () {
              return chanceSource;
          },       
          getGroupSource: function () {
              var deferred = $q.defer();
              var promise = deferred.promise;


              $hengtexHttp.post({
                  "url": ApiUrl.getbgGroupListApi,
                  "data": { "value": 312 },
                  "async": false,
                  "success": function (data) {

                      groupSource.splice(0, groupSource.length);// cases=[];
                      for (var i = 0; i < data.result.length; i++) {
                          var item = data.result[i];
                          var obj = {};
                          obj.itemName = item.nativeName;
                          obj.itemValue = item.nativeName;


                          groupSource.push(obj);
                      }
                      deferred.resolve(groupSource);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "工序权限取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });

              return promise;
          },

          getEditDataEx:function(){
              return editDataEx;
          },
          remove: function (business) {
              $hengtexHttp.post({
                  "url": ApiUrl.deleteChanceApi,
                  "data": { "chanceId": business.chanceId },
                  "success": function () {
                      if(businessListSearch.records > 0) {
                          businessListSearch.businesss.splice(businessListSearch.businesss.indexOf(business), 1);
                          businessListSearch.records = businessListSearch.records -1;
                          for (var i = 0; i < businessList.businesss.length; i++) {
                              if (businessList.businesss[i].chanceId === business.chanceId) {
                                  business = businessList.businesss[i];
                              }
                          }
                      }
                      businessList.businesss.splice(businessList.businesss.indexOf(business), 1);
                      businessList.records = businessList.records -1;
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "删除失败！" });
                  }
              });
          },
          editSubmit: function (editData,callback) {
              $hengtexHttp.post({
                  "url": ApiUrl.saveBgAddApi,
                  "data": editData,
                  "isverify": true,
                  "success": function (data) {
                      $hengtexTopAlert.show({ text: "保存成功!" });
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "保存失败！" });
                  },
                  "finally":function(){
                      callback();
                  }
              });
          }
      };
  }])
//合格工资
.factory('lrmMesSalary', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert','$q',
  function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert,$q) {
      //商机列表数据
      var businessList = {
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          businesss: []
      };
      var businessListSearch = {};//搜索列表数据
      var chancePhases = {};//商机阶段
      var chanceSource = {};//商机来源
      

      //方法函数(数据遍历转化)
      function translateData(data, obj) {
          //console.log(data);
          for (var i in data) {
              var item = data[i];

              obj.push(data[i]);
          }
      };
      //获取数据方法
      function getData(page, queryData, obj, callback) {
         
          $hengtexHttp.post({
              "url": ApiUrl.getbgAddModuleListApi,
              "data": { "page": page, "rows": 10, "sidx": "mpr_date", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.businesss = [];
                  }
                  translateData(data.result.rows, obj.businesss);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }
      return {
          init: function () {//初始化信息
              $hengtexGetDataItem({
                  "itemName": 'Client_ChancePhase',
                  "callback": function (data) {
                      //console.log(data);
                      chancePhases = data;
                  }
              });
              $hengtexGetDataItem({
                  "itemName": 'Client_ChanceSource',
                  "callback": function (data) {
                      chanceSource = data;
                  }
              });
          },
          getList: function () {
              return businessList;
          },
         getDfpCheckSalarys: function (dfpnum) {
              var dfpCheckLists = [];
              var deferred = $q.defer();
              var promise = deferred.promise;
             
              $hengtexHttp.post({
                  "url": ApiUrl.getDfpCheckApi,
                  "data": { "dfpID": dfpnum },
                  "success": function (data) {
                     
                      dfpCheckLists.splice(0, dfpCheckLists.length);// cases=[];
                      for (var i = 0; i < data.result.length; i++) {
                          var item = data.result[i];
                          var obj = {};
                          obj.mpcs_proIDAc = item.mpcs_proIDAc;
                          obj.mpcs_proNameAc = item.mpcs_proNameAc;
                          
                          dfpCheckLists.push(obj);
                      }
                      
                      deferred.resolve(dfpCheckLists);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "合格工资页面把关工序取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });

              return promise;
         },
         getMesProCheckItems: function (proId) {
             var mesProCheckItems = [];
             var deferred = $q.defer();
             var promise = deferred.promise;

             $hengtexHttp.post({
                 "url": ApiUrl.getMesProCheckItemsApi,
                 "data": { "filed": "mpqi_procedureID", "value": proId },
                 "success": function (data) {

                     mesProCheckItems.splice(0, mesProCheckItems.length);// cases=[];
                     for (var i = 0; i < data.result.length; i++) {
                         var item = data.result[i];
                         var obj = {};
                         obj.mpqi_id = item.mpqi_id;
                         obj.mpqi_procedureID = item.mpqi_procedureID;
                         obj.mpqi_procedureName = item.mpqi_procedureName;
                         obj.mpqi_type = item.mpqi_type;
                         obj.mpqi_name = item.mpqi_name;
                         obj.mpqi_sort = item.mpqi_sort;
                         obj.mpqi_checkType = item.mpqi_checkType;
                         obj.mpqi_price = item.mpqi_price;
                         obj.mpqi_amountAdd = item.mpqi_amountAdd;
                         obj.mpqi_checkAvg = item.mpqi_checkAvg;
                         obj.mpqi_remarks = item.mpqi_remarks;
                         obj.CreationDate = item.CreationDate;
                         obj.CreatedBy = item.CreatedBy;
                         mesProCheckItems.push(obj);
                     }

                     deferred.resolve(mesProCheckItems);
                 },
                 "error": function () {
                     $hengtexTopAlert.show({ text: "合格工资页面把关工序取得失败！请联系管理员！" });
                     deferred.reject();
                 }
             });

             return promise;
         },
         getMesBgListsByProIds: function (proIds) {
             var mesBgLists = [];
             var deferred = $q.defer();
             var promise = deferred.promise;

             $hengtexHttp.post({
                 "url": ApiUrl.getbgAddModuleListByWhereApi,
                 "data": { "filed": "where", "value": proIds },
                 "success": function (data) {

                     mesBgLists.splice(0, mesBgLists.length);// cases=[];
                     for (var i = 0; i < data.result.length; i++) {
                         var item = data.result[i];
                         var obj = {};
                         obj.mpr_Person = item.mpr_Person;
                         obj.mpr_num = item.mpr_num;
                         obj.mpr_date = item.mpr_date;
                         obj.mpr_procedureID = item.mpr_procedureID;
                         obj.mpr_procedureName = item.mpr_procedureName;
                         obj.mpr_fcltNum = item.mpr_fcltNum;
                         obj.mpr_fcltName = item.mpr_fcltName;
                         obj.mpr_group = item.mpr_group;
                         obj.mpr_batch = item.mpr_batch;
                         obj.mpr_pinhao = item.mpr_pinhao;
                         obj.mpr_color = item.mpr_color;
                         obj.mpr_panNo = item.mpr_panNo;
                         obj.mpr_hankCount = item.mpr_hankCount;
                         obj.mpr_horseNo = item.mpr_horseNo;
                         obj.mpr_timeCount = item.mpr_timeCount;
                         obj.mpr_count = item.mpr_count;
                         obj.mpr_id = item.mpr_id;
                         obj.mpr_bl = item.mpr_bl;
                         obj.mpr_empNum = item.mpr_empNum;
                         obj.mpr_empName = item.mpr_empName;
                         mesBgLists.push(obj);
                     }

                     deferred.resolve(mesBgLists);
                 },
                 "error": function () {
                     $hengtexTopAlert.show({ text: "无法获取报工记录！请联系管理员！" });
                     deferred.reject();
                 }
             });

             return promise;
         },
          update: function (callback) {//刷新数据
              getData(1, {}, businessList, callback);
          },
          add: function (callback) {
              getData(businessList.page, {}, businessList, callback);
          },
          getSearchList: function () {
              businessListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  businesss: [],
                  keyword: ""
              };
              return businessListSearch;
          },
          searchData: function () {
             
              getData(1, { "condition": "All", "keyword": businessListSearch.keyword }, businessListSearch, function () { });
          },
          searchDataAdd: function (callback) {
             
              getData(businessListSearch.page, { "condition": "All", "keyword": businessListSearch.keyword }, businessListSearch, callback);
          },
          get: function (chanceId) {
              for (var i = 0; i < businessList.businesss.length; i++) {
                  if (businessList.businesss[i].chanceId === chanceId) {
                      return businessList.businesss[i];
                  }
              }
              if (businessListSearch.businesss != undefined) {
                  for (var i = 0; i < businessListSearch.businesss.length; i++) {
                      if (businessListSearch.businesss[i].chanceId === chanceId) {
                          return businessListSearch.businesss[i];
                      }
                  }
              }
              return null;
          },
          getChancePhases: function () {
              return chancePhases;
          },
          getChanceSource: function () {
              return chanceSource;
          },
          getEditDataEx: function () {
              return editDataEx;
          },
          remove: function (business) {
              $hengtexHttp.post({
                  "url": ApiUrl.deleteChanceApi,
                  "data": { "chanceId": business.chanceId },
                  "success": function () {
                      if (businessListSearch.records > 0) {
                          businessListSearch.businesss.splice(businessListSearch.businesss.indexOf(business), 1);
                          businessListSearch.records = businessListSearch.records - 1;
                          for (var i = 0; i < businessList.businesss.length; i++) {
                              if (businessList.businesss[i].chanceId === business.chanceId) {
                                  business = businessList.businesss[i];
                              }
                          }
                      }
                      businessList.businesss.splice(businessList.businesss.indexOf(business), 1);
                      businessList.records = businessList.records - 1;
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "删除失败！" });
                  }
              });
          },
          editSubmit: function (editData, callback) {
              
              $hengtexHttp.post({
                  "url": ApiUrl.saveBgSalaryCheckApi,
                  "data": editData,
                  "isverify": true,
                  "success": function (data) {
                      $hengtexTopAlert.show({ text: "保存成功!" });
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "保存失败！" });
                  },
                  "finally": function () {
                      callback();
                  }
              });
          }
      };
  }])
//把关
.factory('lrmMesTest', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert','$q',
function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert,$q) {
      //商机列表数据
      var businessList = {
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          businesss: []
      };
      var businessListSearch = {};//搜索列表数据
      var chancePhases = {};//商机阶段
      var chanceSource = {};//商机来源
    

    //方法函数(数据遍历转化)
      function translateData(data, obj) {
          //console.log(data);
          for (var i in data) {
              var item = data[i];

              obj.push(data[i]);
          }
      };
    //获取数据方法
      function getData(page, queryData, obj, callback) {
          
          $hengtexHttp.post({
              "url": ApiUrl.getbgAddModuleListApi,
              "data": { "page": page, "rows": 10, "sidx": "mpr_date", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                 
                  if (page == 1) {
                      obj.businesss = [];
                  }
                  translateData(data.result.rows, obj.businesss);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }
      return {
          init: function () {//初始化信息
              $hengtexGetDataItem({
                  "itemName": 'Client_ChancePhase',
                  "callback": function (data) {
                      //console.log(data);
                      chancePhases = data;
                  }
              });
              $hengtexGetDataItem({
                  "itemName": 'Client_ChanceSource',
                  "callback": function (data) {
                      chanceSource = data;
                  }
              });
          },
          getDfpCheckSalarys: function (dfpnum) {
              var dfpCheckLists = [];
              var deferred = $q.defer();
              var promise = deferred.promise;
             
              $hengtexHttp.post({
                  "url": ApiUrl.getDfpCheckApi,
                  "data": { "dfpID": dfpnum },
                  "success": function (data) {
                     
                      dfpCheckLists.splice(0, dfpCheckLists.length);// cases=[];
                      for (var i = 0; i < data.result.length; i++) {
                          var item = data.result[i];
                          var obj = {};
                          obj.mpcs_proIDCheck = item.mpcs_proIDCheck;
                          obj.mpcs_proNameCheck = item.mpcs_proNameCheck;
                          
                          dfpCheckLists.push(obj);
                      }
                      
                      deferred.resolve(dfpCheckLists);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "工序权限取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });

              return promise;
          },
          getMesProCheckItems: function (proIds) {
              var mesProCheckItems = [];
              var deferred = $q.defer();
              var promise = deferred.promise;

              $hengtexHttp.post({
                  "url": ApiUrl.getMesProCheckItemsApi,
                  "data": { "filed": "all", "value": proIds },
                  "success": function (data) {
                      
                      mesProCheckItems.splice(0, mesProCheckItems.length);// cases=[];
                      for (var i = 0; i < data.result.length; i++) {
                          var item = data.result[i];
                          var obj = {};
                          obj.mpqi_id = item.mpqi_id;
                          obj.mpqi_procedureID = item.mpqi_procedureID;
                          obj.mpqi_procedureName = item.mpqi_procedureName;
                          obj.mpqi_type = item.mpqi_type;
                          obj.mpqi_name = item.mpqi_name;
                          obj.mpqi_sort = item.mpqi_sort;
                          obj.mpqi_checkType = item.mpqi_checkType;
                          obj.mpqi_price = item.mpqi_price;
                          obj.mpqi_amountAdd = item.mpqi_amountAdd;
                          obj.mpqi_checkAvg = item.mpqi_checkAvg;
                          obj.mpqi_remarks = item.mpqi_remarks;
                          obj.CreationDate = item.CreationDate;
                          obj.CreatedBy = item.CreatedBy;
                          mesProCheckItems.push(obj);
                      }

                      deferred.resolve(mesProCheckItems);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "合格工资页面把关工序取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });

              return promise;
          },
          getMesBgListsByProIds: function (proIds) {
              var mesBgLists = [];
              var deferred = $q.defer();
              var promise = deferred.promise;

              $hengtexHttp.post({
                  "url": ApiUrl.getbgAddModuleListByWhereApi,
                  "data": { "filed": "where", "value": proIds },
                  "success": function (data) {

                      mesBgLists.splice(0, mesBgLists.length);// cases=[];
                      for (var i = 0; i < data.result.length; i++) {
                          var item = data.result[i];
                          var obj = {};
                          obj.mpr_Person = item.mpr_Person;
                          obj.mpr_num = item.mpr_num;
                          obj.mpr_date = item.mpr_date;
                          obj.mpr_procedureID = item.mpr_procedureID;
                          obj.mpr_procedureName = item.mpr_procedureName;
                          obj.mpr_fcltNum = item.mpr_fcltNum;
                          obj.mpr_fcltName = item.mpr_fcltName;
                          obj.mpr_group = item.mpr_group;
                          obj.mpr_batch = item.mpr_batch;
                          obj.mpr_pinhao = item.mpr_pinhao;
                          obj.mpr_color = item.mpr_color;
                          obj.mpr_panNo = item.mpr_panNo;
                          obj.mpr_hankCount = item.mpr_hankCount;
                          obj.mpr_horseNo = item.mpr_horseNo;
                          obj.mpr_timeCount = item.mpr_timeCount;
                          obj.mpr_count = item.mpr_count;
                          obj.mpr_id = item.mpr_id;
                          obj.mpr_bl = item.mpr_bl;
                          obj.mpr_empNum = item.mpr_empNum;
                          obj.mpr_empName = item.mpr_empName;
                          mesBgLists.push(obj);
                      }

                      deferred.resolve(mesBgLists);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "无法获取报工记录！请联系管理员！" });
                      deferred.reject();
                  }
              });

              return promise;
          },
          getList: function () {
              return businessList;
          },
          update: function (callback) {//刷新数据
              getData(1, {}, businessList, callback);
          },
          add: function (callback) {
              getData(businessList.page, {}, businessList, callback);
          },
          getSearchList: function () {
              businessListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  businesss: [],
                  keyword: ""
              };
              return businessListSearch;
          },
          searchData: function () {
             
              getData(1, { "condition": "All", "keyword": businessListSearch.keyword }, businessListSearch, function () { });
          },
          searchDataAdd: function (callback) {
              
              getData(businessListSearch.page, { "condition": "All", "keyword": businessListSearch.keyword }, businessListSearch, callback);
          },
          get: function (chanceId) {
              for (var i = 0; i < businessList.businesss.length; i++) {
                  if (businessList.businesss[i].chanceId === chanceId) {
                      return businessList.businesss[i];
                  }
              }
              if (businessListSearch.businesss != undefined) {
                  for (var i = 0; i < businessListSearch.businesss.length; i++) {
                      if (businessListSearch.businesss[i].chanceId === chanceId) {
                          return businessListSearch.businesss[i];
                      }
                  }
              }
              return null;
          },
          getChancePhases: function () {
              return chancePhases;
          },
          getChanceSource: function () {
              return chanceSource;
          },
          getEditDataEx: function () {
              return editDataEx;
          },
          remove: function (business) {
              $hengtexHttp.post({
                  "url": ApiUrl.deleteChanceApi,
                  "data": { "chanceId": business.chanceId },
                  "success": function () {
                      if (businessListSearch.records > 0) {
                          businessListSearch.businesss.splice(businessListSearch.businesss.indexOf(business), 1);
                          businessListSearch.records = businessListSearch.records - 1;
                          for (var i = 0; i < businessList.businesss.length; i++) {
                              if (businessList.businesss[i].chanceId === business.chanceId) {
                                  business = businessList.businesss[i];
                              }
                          }
                      }
                      businessList.businesss.splice(businessList.businesss.indexOf(business), 1);
                      businessList.records = businessList.records - 1;
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "删除失败！" });
                  }
              });
          },
          editSubmit: function (editData, callback) {
              $hengtexHttp.post({
                  "url": ApiUrl.saveBgSalaryCheckApi,
                  "data": editData,
                  "isverify": true,
                  "success": function (data) {
                      $hengtexTopAlert.show({ text: "保存成功!" });
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "保存失败！" });
                  },
                  "finally": function () {
                      callback();
                  }
              });
          }
      };
  }])
//报工记录
.factory('lrmMesAddList', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
  function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
      //商机列表数据
      var businessList = {
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          businesss: []
      };
      var businessListSearch = {};//搜索列表数据
      var chancePhases = {};//商机阶段
      var chanceSource = {};//商机来源
    

      //方法函数(数据遍历转化)
      function translateData(data, obj) {
          //console.log(data);
          for (var i in data) {
              var item = data[i];
             
              obj.push(data[i]);
          }
      };
      //获取数据方法
      function getData(page, queryData, obj, callback) {
          $hengtexHttp.post({
              "url": ApiUrl.getbgAddModuleListApi,
              "data": { "page": page, "rows": 10, "sidx": "mpr_date", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.businesss = [];
                  }
                  translateData(data.result.rows, obj.businesss);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }
      return {
          init: function () {//初始化信息
              $hengtexGetDataItem({
                  "itemName": 'Client_ChancePhase',
                  "callback": function (data) {
                      //console.log(data);
                      chancePhases = data;
                  }
              });
              $hengtexGetDataItem({
                  "itemName": 'Client_ChanceSource',
                  "callback": function (data) {
                      chanceSource = data;
                  }
              });
          },
          getList: function () {
              return businessList;
          },
          update: function (callback) {//刷新数据
              getData(1, {}, businessList, callback);
          },
          add: function (callback) {
              getData(businessList.page, {}, businessList, callback);
          },
          getSearchList: function () {
              businessListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  businesss: [],
                  keyword: ""
              };
              return businessListSearch;
          },
          searchData: function () {
             
              getData(1, { "condition": "All", "keyword": businessListSearch.keyword }, businessListSearch, function () { });
          },
          searchDataAdd: function (callback) {
             
              getData(businessListSearch.page, { "condition": "All", "keyword": businessListSearch.keyword }, businessListSearch, callback);
          },
          get: function (chanceId) {
              for (var i = 0; i < businessList.businesss.length; i++) {
                  if (businessList.businesss[i].chanceId === chanceId) {
                      return businessList.businesss[i];
                  }
              }
              if (businessListSearch.businesss != undefined) {
                  for (var i = 0; i < businessListSearch.businesss.length; i++) {
                      if (businessListSearch.businesss[i].chanceId === chanceId) {
                          return businessListSearch.businesss[i];
                      }
                  }
              }
              return null;
          },
          getChancePhases: function () {
              return chancePhases;
          },
          getChanceSource: function () {
              return chanceSource;
          },
          remove: function (business) {
              $hengtexHttp.post({
                  "url": ApiUrl.deleteChanceApi,
                  "data": { "chanceId": business.chanceId },
                  "success": function () {
                      if (businessListSearch.records > 0) {
                          businessListSearch.businesss.splice(businessListSearch.businesss.indexOf(business), 1);
                          businessListSearch.records = businessListSearch.records - 1;
                          for (var i = 0; i < businessList.businesss.length; i++) {
                              if (businessList.businesss[i].chanceId === business.chanceId) {
                                  business = businessList.businesss[i];
                              }
                          }
                      }
                      businessList.businesss.splice(businessList.businesss.indexOf(business), 1);
                      businessList.records = businessList.records - 1;
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "删除失败！" });
                  }
              });
          }
         
      };
  }])
//质检记录
.factory('lrmMesTestList', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
  function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
      //商机列表数据
      var businessList = {
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          businesss: []
      };
      var businessListSearch = {};//搜索列表数据
     
      //方法函数(数据遍历转化)
      function translateData(data, obj) {
          //console.log(data);
          for (var i in data) {
              var item = data[i];
              //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
              //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
             
              obj.push(data[i]);
          }
      };
      //获取数据方法
      function getData(page, queryData, obj, callback) {
          $hengtexHttp.post({
              "url": ApiUrl.getbgSalaryAndTestModuleListApi,
              "data": { "page": page, "rows": 10, "sidx": "CreationDate", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.businesss = [];
                  }
                  translateData(data.result.rows, obj.businesss);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
                 
              },
              "error": function () {
                  $hengtexTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }
      return {
          init: function () {//初始化信息
              $hengtexGetDataItem({
                  "itemName": 'Client_ChancePhase',
                  "callback": function (data) {
                      //console.log(data);
                      chancePhases = data;
                  }
              });
              $hengtexGetDataItem({
                  "itemName": 'Client_ChanceSource',
                  "callback": function (data) {
                      chanceSource = data;
                  }
              });
          },
          getList: function () {
              return businessList;
          },
          update: function (callback) {//刷新数据
              getData(1, {}, businessList, callback);
          },
          add: function (callback) {
              getData(businessList.page, {}, businessList, callback);
          },
          getSearchList: function () {
              businessListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  businesss: [],
                  keyword: "",
                  checktype: ""
              };
              return businessListSearch;
          },
          searchData: function (checktype) {
              
              getData(1, { "condition": "All", "keyword": businessListSearch.keyword, "checktype": checktype }, businessListSearch, function () { });
          },
          searchDataAdd: function (checktype,callback) {
             
              getData(businessListSearch.page, { "condition": "All", "keyword": businessListSearch.keyword, "checktype": checktype }, businessListSearch, callback);
          },
          get: function (chanceId) {
              for (var i = 0; i < businessList.businesss.length; i++) {
                  if (businessList.businesss[i].chanceId === chanceId) {
                      return businessList.businesss[i];
                  }
              }
              if (businessListSearch.businesss != undefined) {
                  for (var i = 0; i < businessListSearch.businesss.length; i++) {
                      if (businessListSearch.businesss[i].chanceId === chanceId) {
                          return businessListSearch.businesss[i];
                      }
                  }
              }
              return null;
          },
       
         
          remove: function (business) {
              $hengtexHttp.post({
                  "url": ApiUrl.deleteChanceApi,
                  "data": { "chanceId": business.chanceId },
                  "success": function () {
                      if (businessListSearch.records > 0) {
                          businessListSearch.businesss.splice(businessListSearch.businesss.indexOf(business), 1);
                          businessListSearch.records = businessListSearch.records - 1;
                          for (var i = 0; i < businessList.businesss.length; i++) {
                              if (businessList.businesss[i].chanceId === business.chanceId) {
                                  business = businessList.businesss[i];
                              }
                          }
                      }
                      businessList.businesss.splice(businessList.businesss.indexOf(business), 1);
                      businessList.records = businessList.records - 1;
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "删除失败！" });
                  }
              });
          },
          searchDataIni: function () {
              var deferred = $q.defer();
              var promise = deferred.promise;

              getData(1, { "condition": "All", "keyword": businessListSearch.keyword }, businessListSearch, function () { });

              $hengtexHttp.post({
                  "url": ApiUrl.getdocflowprocedures,
                  "data": { "Account": UserInfo.Account },
                  "async": false,
                  "success": function (data) {

                      dfpLists.splice(0, dfpLists.length);// cases=[];
                      for (var i = 0; i < data.result.count; i++) {
                          var item = data.result.dfpLists[i];
                          var obj = {};
                          obj.num = item.dfp_num;
                          obj.name = item.dfp_name;
                          obj.account = data.result.account;
                          obj.accountName = data.result.accountName;
                          obj.url = item.dfp_appUrl;

                          dfpLists.push(obj);
                      }
                      deferred.resolve(dfpLists);
                  },
                  "error": function () {
                      $hengtexTopAlert.show({ text: "工序权限取得失败！请联系管理员！" });
                      deferred.reject();
                  }
              });

              return promise;
          }

      };
  }])
