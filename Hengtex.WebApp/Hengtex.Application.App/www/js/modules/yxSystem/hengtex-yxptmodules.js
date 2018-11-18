    //样品列表信息（营销平台）
 app .factory('lrmSamleStock', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
    function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
        //样品列表数据
        var businessList = {
            records: 0,
            page: 1,
            total: 1,
            moredata: false,
            businesss: []
        };
        //查询条件
        //$scope.searchCondationData = 
        var businessListSearch = {};//搜索列表数据
        var chancePhases = {};//商机阶段
        var chanceSource = {};//查询条件
        var editDataEx = [
          {
              "name": "产品编码",
              "id": "s_code",
              "isRequire": true
          },
          {
              "name": "产品名称",
              "id": "p_name",
              "isRequire": true
          },
          {
              "name": "备注",
              "id": "s_note",
              "isRequire": true
          }

        ];//商家编辑数据字段

        //方法函数(数据遍历转化)
        function translateData(data, obj) {
            //console.log(data);
            for (var i in data) {
                var item = data[i];
                //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
                //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
                // data[i].stageName = data[i].stageId;
                // data[i].bgStageColor = 'calm-bg';
                //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
                //data[i].sourceName = data[i].sourceId;

                //data[i].lastDate = $hengtexFormatDate(item.modifyDate, 'MM-dd');
                // data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
                // data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
                // data[i].dealDate = $hengtexFormatDate(item.dealDate, 'yyyy-MM-dd');
                obj.push(data[i]);
            }
        };
        //获取数据方法
        function getData(page, queryData, obj, callback) {
            $hengtexHttp.post({
                "url": ApiUrl.getSaleSampleApi,
                "data": { "page": page, "rows": 10, "sidx": "s_id", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
                    "itemName": 'cxtj',
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
                if (businessList.page > businessList.total) {
                    return false;
                }
                getData(businessList.page, {}, businessList, callback);
            },
            getSearchList: function () {
                businessListSearch = {
                    records: 0,
                    page: 1,
                    total: 1,
                    moredata: false,
                    businesss: [],
                    condition: "请选择",
                    conditionvalue: "",
                    keyword: ""
                };
                return businessListSearch;
            },
            searchData: function () {

                if (businessListSearch.keyword == "") {
                    return false;
                }
                getData(1, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, function () { });
            },
            searchDataAdd: function (callback) {
                if (businessListSearch.keyword == "") {
                    return false;
                }
                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }
                getData(businessListSearch.page, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, callback);
            },
            get: function (chanceId) {

                for (var i = 0; i < businessList.businesss.length; i++) {
                    if (businessList.businesss[i].s_code === chanceId) {
                        return businessList.businesss[i];
                    }
                }
                if (businessListSearch.businesss != undefined) {
                    for (var i = 0; i < businessListSearch.businesss.length; i++) {
                        if (businessListSearch.businesss[i].s_code === chanceId) {
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
                    "url": ApiUrl.saveChanceApi,
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

     //发货列表信息（营销平台）
   .factory('lrmProDelevery', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
    function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
        //样品列表数据
        var businessList = {
            records: 0,
            page: 1,
            total: 1,
            moredata: false,
            businesss: []
        };
        //查询条件
        //$scope.searchCondationData = 
        var businessListSearch = {};//搜索列表数据
        var chancePhases = {};//商机阶段
        var chanceSource = {};//查询条件
        var editDataEx = [
          {
              "name": "产品编码",
              "id": "s_code",
              "isRequire": true
          },
          {
              "name": "产品名称",
              "id": "p_name",
              "isRequire": true
          },
          {
              "name": "备注",
              "id": "s_note",
              "isRequire": true
          }

        ];//商家编辑数据字段

        //方法函数(数据遍历转化)
        function translateData(data, obj) {
            //console.log(data);
            for (var i in data) {
                var item = data[i];
                //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
                //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
                // data[i].stageName = data[i].stageId;
                // data[i].bgStageColor = 'calm-bg';
                //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
                //data[i].sourceName = data[i].sourceId;

                //data[i].pdd_date = $hengtexFormatDate(item.pdd_date, 'MM-dd');
                // data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
                // data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
                //  data[i].pd_date = $hengtexFormatDate(item.pd_date, 'yyyy-MM-dd');
                obj.push(data[i]);
            }
        };
        //获取数据方法
        function getData(page, queryData, obj, callback) {

            $hengtexHttp.post({
                "url": ApiUrl.getProDeliveryApi,
                "data": { "page": page, "rows": 10, "sidx": "pd_date", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
                    "itemName": 'fhd_cxtj',
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
                if (businessList.page > businessList.total) {
                    return false;
                }
                getData(businessList.page, {}, businessList, callback);
            },
            getSearchList: function () {
                businessListSearch = {
                    records: 0,
                    page: 1,
                    total: 1,
                    moredata: false,
                    businesss: [],
                    condition: "请选择",
                    conditionvalue: "",
                    keyword: ""
                };
                return businessListSearch;
            },
            searchData: function () {

                if (businessListSearch.keyword == "") {
                    return false;
                }
                getData(1, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, function () { });
            },
            searchDataAdd: function (callback) {
                if (businessListSearch.keyword == "") {
                    return false;
                }

                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }
                getData(businessListSearch.page, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, callback);
            },
            get: function (chanceId) {

                for (var i = 0; i < businessList.businesss.length; i++) {
                    if (businessList.businesss[i].pd_num === chanceId) {
                        return businessList.businesss[i];
                    }
                }

                if (businessListSearch.businesss != undefined) {
                    for (var i = 0; i < businessListSearch.businesss.length; i++) {
                        if (businessListSearch.businesss[i].pd_num === chanceId) {
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
                    "url": ApiUrl.saveChanceApi,
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

      //染整库存信息（营销平台）
   .factory('lrmProRzStock', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
    function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
        //样品列表数据
        var businessList = {
            records: 0,
            page: 1,
            total: 1,
            moredata: false,
            businesss: []
        };
        //查询条件
        //$scope.searchCondationData = 
        var businessListSearch = {};//搜索列表数据
        var RzDetails = {};
        var chancePhases = {};//商机阶段
        var chanceSource = {};//查询条件
        var editDataEx = [
          {
              "name": "产品编码",
              "id": "s_code",
              "isRequire": true
          },
          {
              "name": "产品名称",
              "id": "p_name",
              "isRequire": true
          },
          {
              "name": "备注",
              "id": "s_note",
              "isRequire": true
          }

        ];//商家编辑数据字段

        //方法函数(数据遍历转化)
        function translateData(data, obj) {
            //console.log(data);
            for (var i in data) {
                var item = data[i];
                //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
                //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
                // data[i].stageName = data[i].stageId;
                // data[i].bgStageColor = 'calm-bg';
                //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
                //data[i].sourceName = data[i].sourceId;

                //data[i].pdd_date = $hengtexFormatDate(item.pdd_date, 'MM-dd');
                // data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
                // data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
                data[i].p_dateLastIn = $hengtexFormatDate(item.pd_date, 'yyyy-MM-dd');
                obj.push(data[i]);
            }
        };
        //获取数据方法
        function getData(page, queryData, obj, callback) {

            $hengtexHttp.post({
                "url": ApiUrl.getProRzStockApi,
                "data": { "page": page, "rows": 10, "sidx": "p_dateLastIn", "sord": "desc", "queryData": JSON.stringify(queryData) },
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

        //获取染整详情数据方法
        function getDataForDetail(page, queryData, obj, callback) {

            $hengtexHttp.post({
                "url": ApiUrl.getProRzStockDetailsApi,
                "data": { "page": page, "rows": 10, "sidx": "mpp_dateCheck", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
                    "itemName": 'rzkc_cxtj',
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
                if (businessList.page > businessList.total) {
                    return false;
                }

                getData(businessList.page, {}, businessList, callback);
            },
            getSearchList: function () {
                businessListSearch = {
                    records: 0,
                    page: 1,
                    total: 1,
                    moredata: false,
                    businesss: [],
                    condition: "请选择",
                    conditionvalue: "",
                    keyword: ""
                };
                return businessListSearch;
            },
            searchData: function () {

                if (businessListSearch.keyword == "") {
                    return false;
                }
                getData(1, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, function () { });
            },
            searchDataAdd: function (callback) {
                if (businessListSearch.keyword == "") {
                    return false;
                }
                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }
                getData(businessListSearch.page, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, callback);
            },
            detailDataAdd: function (callback) {
                if (businessListSearch.keyworddetail == "") {
                    return false;
                }

                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }

                getDataForDetail(businessListSearch.page, { "condition": "mpp_batch", "keyword": businessListSearch.keyworddetail }, businessListSearch, callback);
            },
            get: function (chanceId) {
                businessListSearch.keyworddetail = chanceId;
                businessListSearch.conditiondetail = "mpp_batch";

                getDataForDetail(1, { "condition": "mpp_batch", "keyword": chanceId }, businessListSearch, function () { });

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
                    "url": ApiUrl.saveChanceApi,
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


       //绒布库存信息（营销平台）
   .factory('lrmProRbStock', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
    function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
        //样品列表数据
        var businessList = {
            records: 0,
            page: 1,
            total: 1,
            moredata: false,
            businesss: []
        };
        //查询条件
        //$scope.searchCondationData = 
        var businessListSearch = {};//搜索列表数据
        var RzDetails = {};
        var chancePhases = {};//商机阶段
        var chanceSource = {};//查询条件
        var editDataEx = [
          {
              "name": "产品编码",
              "id": "s_code",
              "isRequire": true
          },
          {
              "name": "产品名称",
              "id": "p_name",
              "isRequire": true
          },
          {
              "name": "备注",
              "id": "s_note",
              "isRequire": true
          }

        ];//商家编辑数据字段

        //方法函数(数据遍历转化)
        function translateData(data, obj) {
            //console.log(data);
            for (var i in data) {
                var item = data[i];
                //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
                //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
                // data[i].stageName = data[i].stageId;
                // data[i].bgStageColor = 'calm-bg';
                //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
                //data[i].sourceName = data[i].sourceId;

                //data[i].pdd_date = $hengtexFormatDate(item.pdd_date, 'MM-dd');
                // data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
                // data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
                data[i].p_dateLastIn = $hengtexFormatDate(item.pd_date, 'yyyy-MM-dd');
                obj.push(data[i]);
            }
        };
        //获取数据方法
        function getData(page, queryData, obj, callback) {

            $hengtexHttp.post({
                "url": ApiUrl.getProRbStockApi,
                "data": { "page": page, "rows": 10, "sidx": "p_dateLastIn", "sord": "desc", "queryData": JSON.stringify(queryData) },
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

        //获取染整详情数据方法
        function getDataForDetail(page, queryData, obj, callback) {

            $hengtexHttp.post({
                "url": ApiUrl.getProRbStockDetailsApi,
                "data": { "page": page, "rows": 10, "sidx": "mpp_dateCheck", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
                    "itemName": 'rzkc_cxtj',
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
                if (businessList.page > businessList.total) {
                    return false;
                }

                getData(businessList.page, {}, businessList, callback);
            },
            getSearchList: function () {
                businessListSearch = {
                    records: 0,
                    page: 1,
                    total: 1,
                    moredata: false,
                    businesss: [],
                    condition: "请选择",
                    conditionvalue: "",
                    keyword: "",
                    conditiondetail: "",
                    keyworddetail: ""
                };
                return businessListSearch;
            },
            searchData: function () {

                if (businessListSearch.keyword == "") {
                    return false;
                }
                getData(1, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, function () { });
            },
            searchDataAdd: function (callback) {
                if (businessListSearch.keyword == "") {
                    return false;
                }
                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }
                getData(businessListSearch.page, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, callback);
            },
            detailDataAdd: function (callback) {
                if (businessListSearch.keyworddetail == "") {
                    return false;
                }

                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }
                // alert(businessListSearch.keyworddetail);
                getDataForDetail(businessListSearch.page, { "condition": "mpp_batch", "keyword": businessListSearch.keyworddetail }, businessListSearch, callback);
            },
            get: function (chanceId) {
                businessListSearch.keyworddetail = chanceId;
                // businessListSearch.conditiondetail = "mpp_batch";

                getDataForDetail(1, { "condition": "mpp_batch", "keyword": chanceId }, businessListSearch, function () { });

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
                    "url": ApiUrl.saveChanceApi,
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


       //绒布订单列表信息（营销平台）
   .factory('lrmProRbOrder', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
    function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
        //样品列表数据
        var businessList = {
            records: 0,
            page: 1,
            total: 1,
            moredata: false,
            businesss: []
        };
        //查询条件
        //$scope.searchCondationData = 
        var businessListSearch = {};//搜索列表数据
        var chancePhases = {};//商机阶段
        var chanceSource = {};//查询条件
        var editDataEx = [
          {
              "name": "产品编码",
              "id": "s_code",
              "isRequire": true
          },
          {
              "name": "产品名称",
              "id": "p_name",
              "isRequire": true
          },
          {
              "name": "备注",
              "id": "s_note",
              "isRequire": true
          }

        ];//商家编辑数据字段

        //方法函数(数据遍历转化)
        function translateData(data, obj) {
            //console.log(data);
            for (var i in data) {
                var item = data[i];
                //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
                //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
                // data[i].stageName = data[i].stageId;
                // data[i].bgStageColor = 'calm-bg';
                //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
                //data[i].sourceName = data[i].sourceId;

                //data[i].pdd_date = $hengtexFormatDate(item.pdd_date, 'MM-dd');
                // data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
                // data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
                data[i].pd_date = $hengtexFormatDate(item.pd_date, 'yyyy-MM-dd');
                obj.push(data[i]);
            }
        };
        //获取数据方法
        function getData(page, queryData, obj, callback) {

            $hengtexHttp.post({
                "url": ApiUrl.getProRbOrderApi,
                "data": { "page": page, "rows": 10, "sidx": "o_dateOrder", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
                    "itemName": 'rbdd_cxtj',
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
                if (businessList.page > businessList.total) {
                    return false;
                }
                getData(businessList.page, {}, businessList, callback);
            },
            getSearchList: function () {
                businessListSearch = {
                    records: 0,
                    page: 1,
                    total: 1,
                    moredata: false,
                    businesss: [],
                    condition: "请选择",
                    conditionvalue: "",
                    keyword: ""
                };
                return businessListSearch;
            },
            searchData: function () {

                if (businessListSearch.keyword == "") {
                    return false;
                }
                getData(1, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, function () { });
            },
            searchDataAdd: function (callback) {
                if (businessListSearch.keyword == "") {
                    return false;
                }

                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }
                getData(businessListSearch.page, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, callback);
            },
            get: function (chanceId) {

                for (var i = 0; i < businessList.businesss.length; i++) {
                    if (businessList.businesss[i].o_num === chanceId) {
                        return businessList.businesss[i];
                    }
                }
                if (businessListSearch.businesss != undefined) {
                    for (var i = 0; i < businessListSearch.businesss.length; i++) {
                        if (businessListSearch.businesss[i].o_num === chanceId) {
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
                    "url": ApiUrl.saveChanceApi,
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

        //染整订单列表信息（营销平台）
   .factory('lrmProRzOrder', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert',
    function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert) {
        //样品列表数据
        var businessList = {
            records: 0,
            page: 1,
            total: 1,
            moredata: false,
            businesss: []
        };
        //查询条件
        //$scope.searchCondationData = 
        var businessListSearch = {};//搜索列表数据
        var chancePhases = {};//商机阶段
        var chanceSource = {};//查询条件
        var editDataEx = [
          {
              "name": "产品编码",
              "id": "s_code",
              "isRequire": true
          },
          {
              "name": "产品名称",
              "id": "p_name",
              "isRequire": true
          },
          {
              "name": "备注",
              "id": "s_note",
              "isRequire": true
          }

        ];//商家编辑数据字段

        //方法函数(数据遍历转化)
        function translateData(data, obj) {
            //console.log(data);
            for (var i in data) {
                var item = data[i];
                //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
                //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
                // data[i].stageName = data[i].stageId;
                // data[i].bgStageColor = 'calm-bg';
                //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
                //data[i].sourceName = data[i].sourceId;

                //data[i].pdd_date = $hengtexFormatDate(item.pdd_date, 'MM-dd');
                // data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
                // data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
                data[i].pd_date = $hengtexFormatDate(item.pd_date, 'yyyy-MM-dd');
                obj.push(data[i]);
            }
        };
        //获取数据方法
        function getData(page, queryData, obj, callback) {

            $hengtexHttp.post({
                "url": ApiUrl.getProRzOrderApi,
                "data": { "page": page, "rows": 10, "sidx": "o_dateOrder", "sord": "desc", "queryData": JSON.stringify(queryData) },
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
                    "itemName": 'rbdd_cxtj',
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
                if (businessList.page > businessList.total) {
                    return false;
                }
                getData(businessList.page, {}, businessList, callback);
            },
            getSearchList: function () {
                businessListSearch = {
                    records: 0,
                    page: 1,
                    total: 1,
                    moredata: false,
                    businesss: [],
                    condition: "请选择",
                    conditionvalue: "",
                    keyword: ""
                };
                return businessListSearch;
            },
            searchData: function () {

                if (businessListSearch.keyword == "") {
                    return false;
                }
                getData(1, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, function () { });
            },
            searchDataAdd: function (callback) {
                if (businessListSearch.keyword == "") {
                    return false;
                }

                if (businessListSearch.page > businessListSearch.total) {
                    return false;
                }
                getData(businessListSearch.page, { "condition": businessListSearch.conditionvalue, "keyword": businessListSearch.keyword }, businessListSearch, callback);
            },
            get: function (chanceId) {

                for (var i = 0; i < businessList.businesss.length; i++) {
                    if (businessList.businesss[i].o_num === chanceId) {
                        return businessList.businesss[i];
                    }
                }

                if (businessListSearch.businesss != undefined) {
                    for (var i = 0; i < businessListSearch.businesss.length; i++) {
                        if (businessListSearch.businesss[i].o_num === chanceId) {
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
                    "url": ApiUrl.saveChanceApi,
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
    //数据初始化（营销平台）
.factory('lrmyxptini', ['lrmSamleStock', 'lrmProDelevery', 'lrmProRzStock', 'lrmProRbStock', 'lrmProRbOrder', 'lrmProRzOrder'
    , function (lrmSamleStock, lrmProDelevery, lrmProRzStock, lrmProRbStock, lrmProRbOrder, lrmProRzOrder) {

    return {
        init: function () {//初始化信息
            lrmSamleStock.init();
            lrmProDelevery.init();
            lrmProRzStock.init();
            lrmProRbStock.init();
            lrmProRbOrder.init();
            lrmProRzOrder.init();
        }
    };
}])
