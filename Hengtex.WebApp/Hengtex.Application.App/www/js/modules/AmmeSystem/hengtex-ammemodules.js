app//电表档案
.factory('lrmAmmeList', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
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
             "url": ApiUrl.getAmmeModuleListApi,
             "data": { "page": page, "rows": 10, "sidx": "ad_Dept", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
    //电表日报表
.factory('lrmAmmeDayList', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
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
             "url": ApiUrl.getAmmeDaylilyModuleListApi,
             "data": { "page": page, "rows": 10, "sidx": "ad_date", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
         searchData: function (where) {

             getData(1, { "condition": "All", "keyword": businessListSearch.keyword, "where": where }, businessListSearch, function () { });
         },
         searchDataAdd: function (where,callback) {

             getData(businessListSearch.page, { "condition": "All", "keyword": businessListSearch.keyword, "where": where }, businessListSearch, callback);
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