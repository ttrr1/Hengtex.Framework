using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Busines.ErpManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.Entity.WebApp;
using Nancy.Responses.Negotiation;
using System;
using System.Collections;
using System.Collections.Generic;
using Hengtex.Application.Code;
using Hengtex.Util;
using Hengtex.Util.WebControl;
namespace Hengtex.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2016.05.04 13:57
    /// 描 述:登录接口
    /// </summary>
    public class MesModule : BaseModule
    {
        private doc_flow_proceduresBLL dfpBll = new doc_flow_proceduresBLL();
        private mes_emp_report_setBLL mersBll = new mes_emp_report_setBLL();
        private mes_pro_check_setBLL mpcsBll = new mes_pro_check_setBLL();
        private AppAuthorizeBLL appAuthorizeBLL = new AppAuthorizeBLL();
        private mes_bg_batchBLL mbbBbll = new mes_bg_batchBLL();
        private Fclt_facilitiesBLL fcltbll = new Fclt_facilitiesBLL();
        private Dpt_batch_tasksBLL dptbll = new Dpt_batch_tasksBLL();
        private doc_con_pan_headBLL dcphbll = new doc_con_pan_headBLL();
        private doc_con_pan_positionBLL dcppbll = new doc_con_pan_positionBLL();
        private mes_pro_quality_itemsBLL mpqibll = new mes_pro_quality_itemsBLL();
        private mes_pro_recordsBLL mprbll = new mes_pro_recordsBLL();
        private mes_pro_checkBLL mpcbll = new mes_pro_checkBLL();

        public MesModule()
            : base("/hengtex/api")
        {
            //Get["/Mes/getdocflowprocedures"] = Getdocflowprocedures;

            Post["/Mes/getdocflowprocedures"] = Getdocflowprocedures;
            Post["/Mes/getMesModuleList"] = GetMesModuleList;
            Post["/Mes/getDfpCheck"] = GetDfpCheckAndSalary;
            Post["/Mes/getbg_batchModuleList"] = Getbg_batchModuleList;
            Post["/Mes/getbgFcltModuleList"] = GetbgFcltModuleList;
            Post["/Mes/getBatchTasksData"] = GetBatchTasksData;
            Post["/Mes/getbgConPanHeadModuleList"] = GetbgConPanHeadModuleList;
            Post["/Mes/getbgConPanPosModuleList"] = GetbgConPanPosModuleList;
            Post["/Mes/getbgMesQulityItemsModuleList"] = GetbgMesQulityItemsModuleList;
            Post["/Mes/saveBgAdd"] = SaveBgAdd;
            Post["/Mes/getbgAddModuleList"] = GetbgAddModuleList;
            Post["/Mes/getbgAddModuleListByWhere"] = GetbgAddModuleListByWhere;
            Post["/Mes/saveBgSalaryCheck"] = SaveBgSalaryCheck;
            Post["/Mes/GetbgSalaryAndTestModuleList"] = GetbgSalaryAndTestModuleList;
            Post["/Mes/getbgGroupList"] = GetbgGroupList;

        }
        /// <summary>
        /// 修改密码接口 
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator ModifyPassword(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Leave);
                }
                else
                {
                    this.RomveCache(recdata.userid);
                    return this.SendData(ResponseType.Success, "用户退出成功");
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        /// <summary>
        /// 根据员工获取工序档案
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator Getdocflowprocedures(dynamic _)
        {
            try{

                var t = Request.Query["Account"];


                var recdata1 =  this.GetModule<ReceiveModule<AppUserEntity>>();              
                bool resValidation = this.DataValidation(recdata1.userid, recdata1.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    string account = this.ReadCache<Operator>(recdata1.userid).Account;
                    string accountname = this.ReadCache<Operator>(recdata1.userid).UserName;
                    // string account1 = recdata1.data.Account;
                    IEnumerable<mes_emp_report_setEntity> dataMers = mersBll.GetList(account);
                    IList<doc_flow_proceduresEntity> dfpLists = new List<doc_flow_proceduresEntity>();
                    foreach(var model in dataMers)
                    {
                        string mprs_proIDS = model.mprs_proIDS;//🐖主工序
                        string mprs_proIDsSub = model.mprs_proIDsSub;//辅助工序
                        string[] proIDLists = mprs_proIDS.Split(',');
                        string[] proIDSubLists = mprs_proIDsSub.Split(',');
                        foreach (string id in proIDLists) {
                            doc_flow_proceduresEntity dfpModel = dfpBll.GetEntity(id);
                            dfpLists.Add(dfpModel);
                        }
                        foreach (string id in proIDSubLists)
                        {
                            doc_flow_proceduresEntity dfpModel = dfpBll.GetEntity(id);
                            dfpLists.Add(dfpModel);
                        }
                    }

                    string count = dfpLists.Count.ToString();
                    Doc_flow_proceduresForDisplay modelDisplay = new Doc_flow_proceduresForDisplay();
                    modelDisplay.count = count;
                    modelDisplay.account = account;
                    modelDisplay.accountName = accountname;
                    modelDisplay.dfpLists = dfpLists;
                    
                    return this.SendData<Doc_flow_proceduresForDisplay>(modelDisplay, recdata1.userid, recdata1.token, ResponseType.Success);
                }
            }
            catch (Exception e) { 
                throw e;
               // return this.SendData(ResponseType.Fail, "异常");
            }   
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetMesModuleList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<AppUserEntity>>();
                
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var listModule = new List<dynamic>();
                    string account = recdata.data.Account;
                    IEnumerable<AppModuleEntity> modules = appAuthorizeBLL.GetModuleList(recdata.userid,recdata.data.DomainName);
                    return this.SendData<IEnumerable<AppModuleEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);


                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        /// <summary>
        /// 根据完工工序ID和批次信息获取可把关工序和合格工资工序
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetDfpCheckAndSalary(dynamic _) {
            try
            {
                var recdata = this.GetModule<ReceiveModule<DfpCheckPostData>>();

                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    //var listModule = new List<dynamic>();mecs_proIDEnd mecs_type
                    string dfpID = recdata.data.DfpID;
                    string batch = recdata.data.batch;
                    string type = batch;//后期修改 根据批次查询分类
                    Dictionary<string, string> fields = new Dictionary<string, string>();
                    fields.Add("mpcs_proIDEnd", dfpID);
                    if (!string.IsNullOrEmpty(type))
                    {
                        fields.Add("mpcs_type", type);

                    }

                    IEnumerable<mes_pro_check_setEntity> modules = mpcsBll.GetList(fields);
                   
                    return this.SendData<IEnumerable<mes_pro_check_setEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        /// <summary>
        /// 获取批次列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator Getbg_batchModuleList(dynamic _)
        {
            try
            {
                var watch = Util.CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = mbbBbll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<bg_batchEntity>> dataPageList = new DataPageList<IEnumerable<bg_batchEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = Util.CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<bg_batchEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }


        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgFcltModuleList(dynamic _)
        {
            try
            {



                var watch = Util.CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = fcltbll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<Fclt_facilitiesEntity>> dataPageList = new DataPageList<IEnumerable<Fclt_facilitiesEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = Util.CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<Fclt_facilitiesEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }

        /// 根据机台获取一条任务单
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetBatchTasksData(dynamic _)
        {
            try
            {


                var recdata1 = this.GetModule<ReceiveModule<DfpFcltTaskData>>();
                bool resValidation = this.DataValidation(recdata1.userid, recdata1.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = dptbll.GetEntity(recdata1.data.FcltNo);
                    if (data == null)
                    {
                        data = new Dpt_batch_tasksEntity() { Bpt_taskNum = "",Bpt_batch="" };
                    }else
                    {
                        var dataBatch=mbbBbll.GetEntity(data.Bpt_batch);
                        if(dataBatch != null)
                        {
                            data.Bpt_color = dataBatch.b_color;
                            data.Bpt_attr = dataBatch.b_attr;
                            data.Bpt_pinhao = dataBatch.b_pinhao;

                        }
                    }
                    return this.SendData<Dpt_batch_tasksEntity>(data, recdata1.userid, recdata1.token, ResponseType.Success);
                }
            }
            catch (Exception e)
            {
                throw e;
                // return this.SendData(ResponseType.Fail, "异常");
            }
        }


        /// <summary>
        /// 获取盘头列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgConPanHeadModuleList(dynamic _)
        {
            try
            {



                var watch = Util.CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = dcphbll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<doc_con_pan_headEntity>> dataPageList = new DataPageList<IEnumerable<doc_con_pan_headEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = Util.CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<doc_con_pan_headEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }
        /// <summary>
        /// 获取货位列表
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgConPanPosModuleList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<DataFromWeb>>();

                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var listModule = new List<dynamic>();
                   
                    IEnumerable<doc_con_pan_positionEntity> modules = dcppbll.GetList(recdata.data.filed, recdata.data.value);
                    return this.SendData<IEnumerable<doc_con_pan_positionEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);


                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }

        /// <summary>
        /// 获取班组列表
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgGroupList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<DataFromWeb>>();

                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var listModule = new List<dynamic>();
                    int dataType = ConvertEx.ToInt(recdata.data.value);
                    IEnumerable<tb_CommonDataDictEntity> modules = mprbll.GetList(dataType);
                    return this.SendData<IEnumerable<tb_CommonDataDictEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);


                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }
        /// <summary>
        /// 获取检验项目列表
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgMesQulityItemsModuleList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<DataFromWeb>>();

                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var listModule = new List<dynamic>();

                    Dictionary<string, string> fields = new Dictionary<string, string>();
                    fields.Add(recdata.data.filed, recdata.data.value);
                    IEnumerable<mes_pro_quality_itemsEntity> modules = mpqibll.GetList(fields);
                    return this.SendData<IEnumerable<mes_pro_quality_itemsEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);


                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }

        /// <summary>
        /// 添加/编辑报工登记
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveBgAdd(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<mes_pro_recordsEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    string account = this.ReadCache<Operator>(recdata.userid).Account;
                    string accountname = this.ReadCache<Operator>(recdata.userid).UserName;
                    recdata.data.CreatedByNum = account;
                    recdata.data.CreatedBy = accountname;
                    recdata.data.mpr_num = "";

                    mprbll.SaveForm(recdata.data.mpr_num, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
        /// <summary>
        /// 添加/编辑合格工资记录或把关记录
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveBgSalaryCheck(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<DataFromWeb2>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);

                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    string account = this.ReadCache<Operator>(recdata.userid).Account;
                    string accountname = this.ReadCache<Operator>(recdata.userid).UserName;
                    recdata.data.editDataHgGz.CreatedByNum = account;
                    recdata.data.editDataHgGz.CreatedBy = accountname;

                    // recdata.data.mpr_num = mprbll.GetBillCode(recdata.userid, moduleId);
                    recdata.data.editDataHgGz.mpc_num = "";

                    mpcbll.SaveForm(recdata.data.editDataHgGz.mpc_num, recdata.data.editDataHgGz);

                    Dictionary<string, string> keys = new Dictionary<string, string>();
                    keys.Add("mpr_num", recdata.data.editDataHgGz.mpc_mprNum);

                    Dictionary<string, string> values = new Dictionary<string, string>();
                    values.Add("mpr_checkResult", recdata.data.checkResult);
                    mprbll.UpdateByKey("mes_pro_records", keys,values);

                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        /// <summary>
        /// 获取合格工资或把关记录列表 
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgSalaryAndTestModuleList(dynamic _)
        {
            try
            {



                var watch = Util.CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = mpcbll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<mes_pro_checkEntity>> dataPageList = new DataPageList<IEnumerable<mes_pro_checkEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = Util.CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<mes_pro_checkEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }
        /// <summary>
        /// 获取报工登记列表 
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgAddModuleList(dynamic _)
        {
            try
            {



                var watch = Util.CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = mprbll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<mes_pro_recordsEntity>> dataPageList = new DataPageList<IEnumerable<mes_pro_recordsEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = Util.CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<mes_pro_recordsEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }


        /// <summary>
        /// 获取报工登记列表
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetbgAddModuleListByWhere(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<DataFromWeb>>();

                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var listModule = new List<dynamic>();

                    Dictionary<string, string> fields = new Dictionary<string, string>();
                    fields.Add(recdata.data.filed, recdata.data.value);
                    IEnumerable<mes_pro_recordsEntity> modules = mprbll.GetList(fields);
                    return this.SendData<IEnumerable<mes_pro_recordsEntity>>(modules, recdata.userid, recdata.token, ResponseType.Success);


                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }
    }

    //返回前端工序权限列表
    public class Doc_flow_proceduresForDisplay
    {
        /// <summary>
        /// 数量
        /// </summary>
        public string count { get; set; }
        public string account { get; set; }
        public string accountName { get; set; }
        public IList<doc_flow_proceduresEntity> dfpLists { set; get; }


        
    }






    //从前台传递参数到后台类
    /// <summary>
    /// 传递完工工序ID和批次获取可把关工序和合格工资工序
    /// </summary>
    public class DfpCheckPostData
    {
        /// <summary>
        /// 完工工序ID
        /// </summary>
        public string DfpID { set; get; }
        /// <summary>
        /// 批次
        /// </summary>
        public string batch { set; get; }

    }

    public class DfpFcltTaskData
    {
        public string FcltNo { set; get; }

        
    }

    public class DataFromWeb
    {
        public string filed { set; get; }

        public string value { set; get; }
    }

    public class DataFromWeb2
    {
        public mes_pro_checkEntity editDataHgGz { set; get; }

        public string checkResult { set; get; }
    }
}