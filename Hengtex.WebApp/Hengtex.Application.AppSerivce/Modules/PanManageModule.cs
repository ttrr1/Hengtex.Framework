using Hengtex.Application.Busines.ErpManage;
using Hengtex.Application.Busines.SystemManage;
using Hengtex.Application.Entity.ErpManage;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace Hengtex.Application.AppSerivce
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：lvhui
    /// 日 期：2017.05.12 13:57
    /// 描 述:盘头管理接口
    /// </summary>
    public class PanManageModule : BaseModule
    {
        private doc_con_pan_headBLL docpanbll = new doc_con_pan_headBLL();
        private doc_con_pan_positionBLL docpositionbll = new doc_con_pan_positionBLL();
        //private CustomerBLL customerbll = new CustomerBLL();
        private CodeRuleBLL codeRuleBLL = new CodeRuleBLL();
        private con_pan_head_upBLL panupbll = new con_pan_head_upBLL();
        //private OrderBLL orderBll = new OrderBLL();
        public PanManageModule()
            : base("/hengtex/api")
        {
            //盘头管理
            Post["/panManage/panList"] = panList;
            Post["/panManage/savePan"] = savePan;
            Post["/panManage/deletePan"] = deletePan;
            Post["/panManage/positionList"] = positionList;
            Post["/panManage/panInfo"] = panInfo;
            Post["/panManage/positionInfo"] = positionInfo;

            //盘头下整经机管理
            Post["/panManage/panInList"] = panList;
            Post["/panManage/savePanIn"] = savePan;
            Post["/panManage/deletePanIn"] = deletePan;
            Post["/panManage/panInInfo"] = panInfo;

            //盘头上织机管理
            Post["/panManage/panUpList"] = panList;
            Post["/panManage/savePanUp"] = savePanUp;
            Post["/panManage/deletePanUp"] = deletePan;
            Post["/panManage/panInInfo"] = panInfo;
        }
        

        /// <summary>
        /// 获取盘头列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator panList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
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
                    var data = docpanbll.GetList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<doc_con_pan_headEntity>> dataPageList = new DataPageList<IEnumerable<doc_con_pan_headEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
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
        /// 添加/编辑商机
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator savePan(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<doc_con_pan_headEntity>>();
                //var moduleId = "66f6301c-1789-4525-a7d2-2b83272aafa6";
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    //recdata.data.dcph_num = codeRuleBLL.GetBillCode(recdata.userid, moduleId);
                    docpanbll.SaveForm(recdata.data.dcph_num, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
        /// <summary>
        /// 删除商机
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator deletePan(dynamic _)
        {
            var recdata = this.GetModule<ReceiveModule<doc_con_pan_headEntity>>();

            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    docpanbll.RemoveForm(recdata.data.dcph_num);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch (System.Exception)
            {
                return this.SendData(ResponseType.Fail, "异常");
            }  
        }



        /// <summary>
        /// 获取位置列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator positionList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<doc_con_pan_positionEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = docpositionbll.GetList("dcpp_type", recdata.data.dcpp_type.ToString());
                    return this.SendData<IEnumerable<doc_con_pan_positionEntity>>(data, recdata.userid, recdata.token, ResponseType.Success);

                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        /// <summary>
        /// 获取位置信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator positionInfo(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<doc_con_pan_positionEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = docpositionbll.GetEntity( recdata.data.dcpp_num.ToString());
                    return this.SendData<doc_con_pan_positionEntity>(data, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        /// <summary>
        /// 获取盘头信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator panInfo(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<doc_con_pan_headEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = docpanbll.GetEntity( recdata.data.dcph_num.ToString());
                    return this.SendData<doc_con_pan_headEntity>(data, recdata.userid, recdata.token, ResponseType.Success);

                    //var data = docpanbll.GetList(pagination, recdata.data.queryData);
                    //DataPageList<IEnumerable<doc_con_pan_positionEntity>> dataPageList = new DataPageList<IEnumerable<doc_con_pan_positionEntity>>
                    //{
                    //    rows = data,
                    //    total = pagination.total,
                    //    page = pagination.page,
                    //    records = pagination.records,
                    //    costtime = CommonHelper.TimerEnd(watch)
                    //};
                    //return this.SendData<DataPageList<IEnumerable<doc_con_pan_positionEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        /// <summary>
        /// 添加/盘头上织机登记
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator savePanUp(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<con_pan_head_upEntity>>();
                var recdataEmps = this.GetModule<ReceiveModule<con_pan_head_empsEntity>>();
                //var entity = strEntity.ToObject<OfficeRkEntity>();
                //List<OfficeRkEntryEntity> childEntitys = strChildEntitys.ToList<OfficeRkEntryEntity>();
                //officerkbll.SaveForm(keyValue, entity, childEntitys);

                var empsData = recdata.data.emps;// recdata.data.emps;
                //recdata.data.Remove("emps");
                var saveData = recdata.data;
                //saveData.phu_num = "2222";

                saveData.phu_datetime = null;
                saveData.phu_panNum = "";
                saveData.phu_panno = "102";
                saveData.phu_type = "地经";
                saveData.phu_planDetail = "";

                saveData.phu_procedureID = "";
                saveData.phu_procedureName = "";
                saveData.phu_pinhao = "";
                saveData.phu_batch = "11";
                saveData.phu_pinhao = "";
                saveData.phu_color = "";
                saveData.phu_lengthWarp = 3325;
                saveData.phu_custNum = "";
                saveData.phu_custName = "";
                saveData.phu_count = 3000;

                saveData.phu_count_pan = 1;
                saveData.phu_classId = "";
                saveData.phu_class = "";
                saveData.phu_empNo = "";
                saveData.phu_name = "";
                saveData.phu_weight = decimal.Parse("1.1");
                saveData.phu_weight_remain = decimal.Parse("1.1");
                saveData.phu_machineID_con = "0";
                saveData.phu_machineName_con = "0";
                saveData.phu_no_pos = "";
                saveData.phu_name_pos = "";

                saveData.phu_remarks = "";
                saveData.phu_status = "织造中";
                saveData.CreationDate = null;
                saveData.CreatedBy = null;
                saveData.CreatedByNum = null;
                saveData.LastUpdateDate = null;
                saveData.LastUpdatedBy = null;
                saveData.AppUser = null;
                saveData.AppDate = null;

                saveData.FlagApp = "0";
                saveData.DelDate = null;
                saveData.FlagApp = "0";
                saveData.FlagDelete = "0";

                panupbll.SaveForm(recdata.data.phu_num, saveData, empsData);
                //var moduleId = "66f6301c-1789-4525-a7d2-2b83272aafa6";
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    //recdata.data.dcph_num = codeRuleBLL.GetBillCode(recdata.userid, moduleId);
                    //panupbll.SaveForm(recdata.data.phu_num, recdata.data,recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

    }
}