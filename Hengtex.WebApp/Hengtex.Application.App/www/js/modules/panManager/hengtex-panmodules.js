 // add by lvh
//盘头列表信息
  app.factory('htPanManage', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert', '$hengtexGetDataDict', 'UserInfo',
  function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert, $hengtexGetDataDict, UserInfo) {
    //盘头列表数据
    var panList = {
      records: 0,
      page: 1,
      total: 1,
      moredata: true,
      pans: []
    };
    var panListSearch = {};//搜索列表数据
    var positions = {};//位置
    var panStatus = {};//盘头状态
    var editDataEx = [
      {
        "name": "盘头编号",
        "id": "dcph_num",
        "isRequire": true
      },
      {
        "name": "名称",
        "id": "dcph_no",
        "isRequire": true
      },
      {
        "name": "状态",
        "id": "dcph_status",
        "isRequire": true
      },
      {
        "name": "位置",
        "id": "dcph_positionName",
        "isRequire": true
      },

      {
        "name": "批次",
        "id": "dcph_batch",
        "isRequire": false
      }
    ];//商家编辑数据字段

    //方法函数(数据遍历转化)
    function translateData(data, obj) {
      //console.log(data);
      for (var i in data) {
        var item = data[i];
        //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
        //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
        data[i].dcph_num = data[i].dcph_num;
        data[i].bgStageColor = 'calm-bg';
        //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
        data[i].dcph_no = data[i].dcph_no;

        data[i].LastUpdateDate = $hengtexFormatDate(new Date(), 'yyyy-MM-dd hh:mm');
        data[i].LastUpdatedBy = UserInfo.get().account;

        //data[i].lastDate =  $hengtexFormatDate(item.modifyDate, 'MM-dd');
        //data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
        //data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
        //data[i].dealDate = $hengtexFormatDate(item.dealDate, 'yyyy-MM-dd');
        obj.push(data[i]);
      }

    };
    //获取数据方法
    function getData(page, queryData, obj, callback) {
      $hengtexHttp.post({
        "url": ApiUrl.panListApi,
        "data": { "page": page, "rows": 10, "sidx": "dcph_num", "sord": "asc", "queryData": JSON.stringify(queryData) },
        "isverify": false,
        "success": function (data) {
          if (page == 1) {
            obj.pans = [];
          }

          translateData(data.result.rows, obj.pans);
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

        $hengtexGetDataDict({
          "itemName": 317,
          "callback": function (data) {
            var bgColorList = ["positive-bg", "royal-bg", "balanced-bg", "energized-bg", "assertive-bg", "calm-bg", "dark-bg"];
            for (var i in data) {
              var item = data[i];

              //alert(JSON.stringify(item))
              panStatus[i] = item;
              panStatus[i].itemName = item.nativeName;
              panStatus[i].itemValue = item.nativeName;
              //lsdata.push(item);
              panStatus[i].bgColor = bgColorList[i];
            }
            //panStatus = data;
          }
        });
        $hengtexHttp.post({
          "url": ApiUrl.positionListApi,
          "data": { "dcpp_type": "整经区域" },
          "isverify": false,
          "success": function (data) {
            //alert(JSON.stringify(data));
            var bgColorList = ["positive-bg", "royal-bg", "balanced-bg", "energized-bg", "assertive-bg", "calm-bg", "dark-bg"];
            for (var i in data.result) {
              var item = data.result[i];

              //alert(JSON.stringify(item))
              positions[i] = item;
              positions[i].itemName = item.dcpp_name;
              positions[i].itemValue = item.dcpp_num;
              //lsdata.push(item);
              positions[i].bgColor = bgColorList[i];
            }
          }
        });

      },
      getList: function () {

        return panList;
      },
      update: function (callback) {//刷新数据
        getData(1, {}, panList, callback);
        // alert(JSON.stringify(panList));
      },
      add: function (callback) {
        getData(panList.page, {}, panList, callback);
      },
      getSearchList: function () {
        panListSearch = {
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          pans: [],
          keyword: ""
        };
        //alert(JSON.stringify(panListSearch));
        return panListSearch;
      },
      searchData: function () {
        if (panListSearch.keyword == "") {
          return false;
        }
        //alert(JSON.stringify(panListSearch));
        getData(1, { "condition": "All", "keyword": panListSearch.keyword }, panListSearch, function () { });
        //alert('**'+JSON.stringify(panListSearch));
      },
      searchDataAdd: function (callback) {
        if (panListSearch.keyword == "") {
          return false;
        }
        getData(panListSearch.page, { "condition": "All", "keyword": panListSearch.keyword }, panListSearch, callback);

      },
      get: function (panNum) {
        for (var i = 0; i < panList.pans.length; i++) {
          if (panList.pans[i].dcph_num === panNum) {
            return panList.pans[i];
          }
        }
        if (panListSearch.pans != undefined) {
          for (var i = 0; i < panListSearch.pans.length; i++) {
            if (panListSearch.pans[i].dcph_num === panNum) {
              return panListSearch.pans[i];
            }
          }
        }
        return null;
      },
      getPositions: function () {
        return positions;
      },
      getPanStatus: function () {
        return panStatus;
      },
      getEditDataEx: function () {
        return editDataEx;
      },
      remove: function (pan) {
        $hengtexHttp.post({
          "url": ApiUrl.deletePanApi,
          "data": { "dcph_num": pan.dcph_num },
          "success": function () {
            if (panListSearch.records > 0) {
              panListSearch.pans.splice(panListSearch.pans.indexOf(pan), 1);
              panListSearch.records = panListSearch.records - 1;
              for (var i = 0; i < panList.pans.length; i++) {
                if (panList.businesss[i].dcph_num === pan.dcph_num) {
                  pan = panList.pans[i];
                }
              }
            }
            panList.pans.splice(panList.pans.indexOf(pan), 1);
            panList.records = panList.records - 1;
          },
          "error": function () {
            $hengtexTopAlert.show({ text: "删除失败！" });
          }
        });
      },
      editSubmit: function (editData, callback) {
        $hengtexHttp.post({
          "url": ApiUrl.savePanApi,
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


  //盘头上织机管理
  .factory('htPanUpManage', ['$hengtexFormatDate', '$hengtexGetDataItem', '$hengtexHttp', 'ApiUrl', '$hengtexTopAlert', '$hengtexGetDataDict', 'UserInfo',
    function ($hengtexFormatDate, $hengtexGetDataItem, $hengtexHttp, ApiUrl, $hengtexTopAlert, $hengtexGetDataDict, UserInfo) {
      //盘头列表数据
      var panList = {
        records: 0,
        page: 1,
        total: 1,
        moredata: true,
        pans: []
      };
      var panListSearch = {};//搜索列表数据
      var positions = {};//位置
      var panStatus = {};//盘头状态
      var editDataEx = [
        {
          "name": "盘头编号",
          "id": "phu_panNum",
          "isRequire": true
        }
        ,
        {
          "name": "名称",
          "id": "phu_panno",
          "isRequire": true
        },
        {
          "name": "位置",
          "id": "phu_no_pos",
          "isRequire": true
        },
        {
          "name": "位置名称",
          "id": "phu_name_pos",
          "isRequire": true
        }
        ,
        {
          "name": "机台",
          "id": "phu_machineID_con",
          "isRequire": true
        },
        {
          "name": "机台名称",
          "id": "phu_machineName_con",
          "isRequire": true
        },
        {
          "name": "任务单号",
          "id": "phu_planDetail",
          "isRequire": true
        },
        {
          "name": "批次",
          "id": "phu_batch",
          "isRequire": true
        },
        {
          "name": "品号",
          "id": "phu_pinhao",
          "isRequire": true
        },
        {
          "name": "颜色",
          "id": "phu_color",
          "isRequire": false
        }
        //  ,
        //    {
        //      "name": "人员编码",
        //      "id": "emps.phe_empNo",
        //"isRequire": false
        //    },
        //{
        //      "name": "人员名称",
        //      "id": "emps.phe_name",
        //  "isRequire": false
        //    }
      ];//商家编辑数据字段

      //方法函数(数据遍历转化)
      function translateData(data, obj) {
        //console.log(data);
        for (var i in data) {
          var item = data[i];
          //data[i].stageName =  chancePhases[data[i].stageId].ItemName;
          //data[i].bgStageColor = chancePhases[data[i].stageId].bgColor;
          data[i].dcph_num = data[i].dcph_num;
          data[i].bgStageColor = 'calm-bg';
          //data[i].sourceName = chanceSource[data[i].sourceId].ItemName;
          data[i].dcph_no = data[i].dcph_no;

          data[i].LastUpdateDate = $hengtexFormatDate(new Date(), 'yyyy-MM-dd hh:mm');
          data[i].LastUpdatedBy = UserInfo.get().account;

          //data[i].lastDate =  $hengtexFormatDate(item.modifyDate, 'MM-dd');
          //data[i].createDate = $hengtexFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
          //data[i].modifyDate = $hengtexFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
          //data[i].dealDate = $hengtexFormatDate(item.dealDate, 'yyyy-MM-dd');
          obj.push(data[i]);
        }

      };
      //获取数据方法
      function getData(page, queryData, obj, callback) {
        $hengtexHttp.post({
          "url": ApiUrl.panListApi,
          "data": { "page": page, "rows": 10, "sidx": "phu_panNum", "sord": "asc", "queryData": JSON.stringify(queryData) },
          "isverify": false,
          "success": function (data) {
            if (page == 1) {
              obj.pans = [];
            }

            translateData(data.result.rows, obj.pans);
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

          $hengtexGetDataDict({
            "itemName": 317,
            "callback": function (data) {
              var bgColorList = ["positive-bg", "royal-bg", "balanced-bg", "energized-bg", "assertive-bg", "calm-bg", "dark-bg"];
              for (var i in data) {
                var item = data[i];

                //alert(JSON.stringify(item))
                panStatus[i] = item;
                panStatus[i].itemName = item.nativeName;
                panStatus[i].itemValue = item.nativeName;
                //lsdata.push(item);
                panStatus[i].bgColor = bgColorList[i];
              }
              //panStatus = data;
            }
          });
          $hengtexHttp.post({
            "url": ApiUrl.positionListApi,
            "data": { "dcpp_type": "整经区域" },
            "isverify": false,
            "success": function (data) {
              //alert(JSON.stringify(data));
              var bgColorList = ["positive-bg", "royal-bg", "balanced-bg", "energized-bg", "assertive-bg", "calm-bg", "dark-bg"];
              for (var i in data.result) {
                var item = data.result[i];

                //alert(JSON.stringify(item))
                positions[i] = item;
                positions[i].itemName = item.dcpp_name;
                positions[i].itemValue = item.dcpp_num;
                //lsdata.push(item);
                positions[i].bgColor = bgColorList[i];
              }
            }
          });
        },
        getList: function () {

          return panList;
        },
        update: function (callback) {//刷新数据
          getData(1, {}, panList, callback);
          // alert(JSON.stringify(panList));
        },
        add: function (callback) {
          getData(panList.page, {}, panList, callback);
        },
        getSearchList: function () {
          panListSearch = {
            records: 0,
            page: 1,
            total: 1,
            moredata: false,
            pans: [],
            keyword: ""
          };
          //alert(JSON.stringify(panListSearch));
          return panListSearch;
        },
        searchData: function () {
          if (panListSearch.keyword == "") {
            return false;
          }
          //alert(JSON.stringify(panListSearch));
          getData(1, { "condition": "All", "keyword": panListSearch.keyword }, panListSearch, function () { });
          //alert('**'+JSON.stringify(panListSearch));
        },
        searchDataAdd: function (callback) {
          if (panListSearch.keyword == "") {
            return false;
          }
          getData(panListSearch.page, { "condition": "All", "keyword": panListSearch.keyword }, panListSearch, callback);

        },
        get: function (panNum) {
          for (var i = 0; i < panList.pans.length; i++) {
            if (panList.pans[i].dcph_num === panNum) {
              return panList.pans[i];
            }
          }
          if (panListSearch.pans != undefined) {
            for (var i = 0; i < panListSearch.pans.length; i++) {
              if (panListSearch.pans[i].dcph_num === panNum) {
                return panListSearch.pans[i];
              }
            }
          }
          return null;
        },
        getPositions: function () {
          return positions;
        },
        getPanStatus: function () {
          return panStatus;
        },
        getEditDataEx: function () {
          return editDataEx;
        },
        remove: function (pan) {
          $hengtexHttp.post({
            "url": ApiUrl.deletePanApi,
            "data": { "dcph_num": pan.dcph_num },
            "success": function () {
              if (panListSearch.records > 0) {
                panListSearch.pans.splice(panListSearch.pans.indexOf(pan), 1);
                panListSearch.records = panListSearch.records - 1;
                for (var i = 0; i < panList.pans.length; i++) {
                  if (panList.businesss[i].dcph_num === pan.dcph_num) {
                    pan = panList.pans[i];
                  }
                }
              }
              panList.pans.splice(panList.pans.indexOf(pan), 1);
              panList.records = panList.records - 1;
            },
            "error": function () {
              $hengtexTopAlert.show({ text: "删除失败！" });
            }
          });
        },
        editSubmit: function (editData, callback) {
          alert(JSON.stringify(editData));
          $hengtexHttp.post({
            "url": ApiUrl.savePanUpApi,
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
