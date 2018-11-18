/**
 * Created by cbb on 16/6/3.
 */
//接口地址信息ss
app.factory('ApiUrl', function () {
    //var rootUrl = "http://192.168.124.17:9008/hengtex/api";
    var rootUrl = "http://localhost:62831/hengtex/api";
    //var rootUrl = "http://192.168.103.113:9008/hengtex/api";
  //  var rootUrl = "http://localhost:1166/hengtex/api";
  //var rootUrl = "http://hengtex.cn:8011/hengtex/api";
  var apiUrl = {
      loginApi: rootUrl + "/login/checkLogin",
      //退出
      outLoginApi: rootUrl + '/login/outLogin',
      //获取员工模块权限
      getUserModuleListApi: rootUrl + '/user/getUserModuleList',

      //获取公告列表
      getAnnouncesApi: rootUrl + '/common/getAnnounces',

      //获取员工列表
      getUserListApi: rootUrl + '/user/getUserList',


    //获取基础档案
    getDataDict: rootUrl + '/dataItem/getDataDict',

      //商机列表
      chanceListApi: rootUrl + '/customerManage/chanceList',
      //客户列表
      customerListApi: rootUrl + '/customerManage/customerList',
      //数据字典列表接口
      dataItemListApi: rootUrl + '/dataItem/list',
      //商机添加
      saveChanceApi: rootUrl + '/customerManage/saveChance',
      //客户添加
      saveCustomerApi: rootUrl + '/customerManage/saveCustomer',
      //通知公告列表
      noticeListApi: rootUrl + '/publicInfoManage/noticeList',
      //区域列表接口
      areaListApi: rootUrl + '/area/list',
      //商机删除
      deleteChanceApi: rootUrl + '/customerManage/deleteChance',
      //客户删除
      deleteCustomerApi: rootUrl + '/customerManage/deleteCustomer',
      //订单列表
      getOrderListApi: rootUrl + '/customerManage/orderList',


    //盘头列表
    panListApi: rootUrl + '/panManage/panList',
    panInfoApi: rootUrl + '/panManage/panInfo',
    savePanApi: rootUrl + '/panManage/savePan',
    deletePanApi: rootUrl + '/panManage/deletePan',

    panInListApi: rootUrl + '/panManage/panInList',
    panInInfoApi: rootUrl + '/panManage/panInInfo',
    savePanInApi: rootUrl + '/panManage/savePanIn',
    deletePanInApi: rootUrl + '/panManage/deletePanIn',


    panUpListApi: rootUrl + '/panManage/panUpList',
    panUpInfoApi: rootUrl + '/panManage/panUpInfo',
    savePanUpApi: rootUrl + '/panManage/savePanUp',
    deletePanUpApi: rootUrl + '/panManage/deletePanUp',

    //位置信息
    positionListApi: rootUrl + '/panManage/positionList',
    positionInfoApi: rootUrl + '/panManage/positionInfo',

      //发起流程列表接口
      flowDesignListApi: rootUrl + '/customerManage/list',
      //发起流程添加接口
      saveFlowDesignApi: rootUrl + '/customerManage/list',
      //草稿流程列表接口
      flowRoughdraftListApi: rootUrl + '/customerManage/list',
      //草稿流程删除接口
      deleteFlowRoughdraftApi: rootUrl + '/customerManage/list',
      //我的流程列表接口
      flowProcessListApi: rootUrl + '/customerManage/list',
      //待办流程列表接口
      flowBefProcessListApi: rootUrl + '/customerManage/list',
      //代办流程审核接口
      saveFlowBefProcessApi: rootUrl + '/customerManage/list',
      //已办流程列表接口
      flowAftProcessListApi: rootUrl + '/customerManage/list',
      //工作委托列表接口
      flowDelegateListApi: rootUrl + '/customerManage/list',
      //收款管理
      getReceivableListApi: rootUrl + '/customerManage/list',
      //收款报表管理
      getReceivableReportListApi: rootUrl + '/customerManage/list',


      //获取电表档案
      getAmmeApi: rootUrl + '/Amme/GetAmmeData',

      //获取样品
      getSaleSampleApi: rootUrl + '/Sample/GetSampleModuleList',
      //获取发货单
      getProDeliveryApi: rootUrl + '/Sample/getProDeliveryModuleList',
      //获取染整库存单
      getProRzStockApi: rootUrl + '/Sample/getProRzStockModuleList',
      //获取染整库存详情单
      getProRzStockDetailsApi: rootUrl + '/Sample/getProRzStockDetailsModuleList',
      //获取绒布库存单
      getProRbStockApi: rootUrl + '/Sample/getProRbStockModuleList',
      //获取绒布库存详情单
      getProRbStockDetailsApi: rootUrl + '/Sample/getProRbStockDetailsModuleList',
      //获取绒布订单
      getProRbOrderApi: rootUrl + '/Sample/getProRbOrderModuleList',
      //获取染整订单
      getProRzOrderApi: rootUrl + '/Sample/getProRzOrderModuleList',



      //mesSystem报工管理
      //获取报工权限
      getdocflowprocedures: rootUrl + '/Mes/getdocflowprocedures',
      //报工登记基本信息
      getBgAddCommenDetailApi: rootUrl + '/Mes/getBgAddCommenDetail',
      //根据完工工序ID和批次获取可把关工序
      getDfpCheckApi: rootUrl + '/Mes/getDfpCheck',
      //获取批次
      getbgbatchModuleList: rootUrl + '/Mes/getbg_batchModuleList',
      //获取报工机台
      getbgFcltModuleListApi: rootUrl + '/Mes/getbgFcltModuleList',
      //根据机台获取任务单
      getBatchTasksDataApi: rootUrl + '/Mes/getBatchTasksData',
      //获取盘头数据
      getbgConPanHeadModuleListApi: rootUrl + '/Mes/getbgConPanHeadModuleList',
      //获取货位
      getbgConPanPositionModuleListApi: rootUrl + '/Mes/getbgConPanPosModuleList',
      //获取检验项目
      getMesProCheckItemsApi: rootUrl + '/Mes/getbgMesQulityItemsModuleList',
      //保存报工登记
      saveBgAddApi: rootUrl + '/Mes/saveBgAdd',
      //查询报工登记
      getbgAddModuleListApi: rootUrl + '/Mes/getbgAddModuleList',
      //查询报工登记
      getbgAddModuleListByWhereApi: rootUrl + '/Mes/getbgAddModuleListByWhere',
      //保存合格工资
      saveBgSalaryCheckApi: rootUrl + '/Mes/SaveBgSalaryCheck',
      //查询合格工资
      getbgSalaryAndTestModuleListApi: rootUrl + '/Mes/GetbgSalaryAndTestModuleList',
      //获取班组
      getbgGroupListApi: rootUrl + '/Mes/getbgGroupList',



      //获取电表
      getAmmeModuleListApi: rootUrl + '/amme/getAmmeModuleList',
      //获取电表日报列表
      getAmmeDaylilyModuleListApi: rootUrl + '/amme/getAmmeDaylilyModuleList'
  };
  return apiUrl;
})
.factory('SignalrUrl',function(){
    return "http://localhost:8081/signalr";
    //return "http://localhost:8081/signalr";
})
;
