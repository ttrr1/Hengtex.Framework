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
    public class BatchesManageModule : BaseModule
    {
        private doc_con_pan_headBLL docpanbll = new doc_con_pan_headBLL();
        private doc_con_pan_positionBLL docpositionbll = new doc_con_pan_positionBLL();
        private sale_order_batchesBLL batchBll = new sale_order_batchesBLL();
        //private CustomerBLL customerbll = new CustomerBLL();
        private CodeRuleBLL codeRuleBLL = new CodeRuleBLL();
        //private OrderBLL orderBll = new OrderBLL();
        public BatchesManageModule()
            : base("/hengtex/api")
        {
            Post["/batchesManage/getBatchInfo"] = getBatchInfo;
            //Post["/batchesManage/savePan"] = savePan;
            //Post["/batchesManage/deletePan"] = deletePan;
            //Post["/batchesManage/positionList"] = positionList;
            //Post["/batchesManage/panInfo"] = panInfo;
            //Post["/batchesManage/positionInfo"] = positionInfo;

            
        }
        

        /// <summary>
        /// 获取批次信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator getBatchInfo(dynamic _)
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
                    var data = batchBll.GetList(recdata.data.queryData);
                    DataPageList<IEnumerable<sale_order_batchesEntity>> dataPageList = new DataPageList<IEnumerable<sale_order_batchesEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<sale_order_batchesEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        ///// <summary>
        ///// 添加/编辑商机
        ///// </summary>
        ///// <param name="_"></param>
        ///// <returns></returns>
        //private Negotiator savePan(dynamic _)
        //{
        //    try
        //    {
        //        var recdata = this.GetModule<ReceiveModule<doc_con_pan_headEntity>>();
        //        //var moduleId = "66f6301c-1789-4525-a7d2-2b83272aafa6";
        //        bool resValidation = this.DataValidation(recdata.userid, recdata.token);
        //        if (!resValidation)
        //        {
        //            return this.SendData(ResponseType.Fail, "后台无登录信息");
        //        }
        //        else
        //        {
        //            //recdata.data.dcph_num = codeRuleBLL.GetBillCode(recdata.userid, moduleId);
        //            docpanbll.SaveForm(recdata.data.dcph_num, recdata.data);
        //            return this.SendData(ResponseType.Success);
        //        }
        //    }
        //    catch
        //    {
        //        return this.SendData(ResponseType.Fail, "异常");
        //    }
        //}
        ///// <summary>
        ///// 删除商机
        ///// </summary>
        ///// <param name="_"></param>
        ///// <returns></returns>
        //private Negotiator deletePan(dynamic _)
        //{
        //    var recdata = this.GetModule<ReceiveModule<doc_con_pan_headEntity>>();

        //    try
        //    {
        //        bool resValidation = this.DataValidation(recdata.userid, recdata.token);
        //        if (!resValidation)
        //        {
        //            return this.SendData(ResponseType.Fail, "后台无登录信息");
        //        }
        //        else
        //        {
        //            docpanbll.RemoveForm(recdata.data.dcph_num);
        //            return this.SendData(ResponseType.Success);
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        return this.SendData(ResponseType.Fail, "异常");
        //    }  
        //}



        ///// <summary>
        ///// 获取位置列表
        ///// </summary>
        ///// <param name="_"></param>
        ///// <returns></returns>
        //private Negotiator positionList(dynamic _)
        //{
        //    try
        //    {
        //        var watch = CommonHelper.TimerStart();
        //        var recdata = this.GetModule<ReceiveModule<doc_con_pan_positionEntity>>();
        //        bool resValidation = this.DataValidation(recdata.userid, recdata.token);
        //        if (!resValidation)
        //        {
        //            return this.SendData(ResponseType.Fail, "后台无登录信息");
        //        }
        //        else
        //        {
        //            var data = docpositionbll.GetList("dcpp_type", recdata.data.dcpp_type.ToString());
        //            return this.SendData<IEnumerable<doc_con_pan_positionEntity>>(data, recdata.userid, recdata.token, ResponseType.Success);

        //        }
        //    }
        //    catch
        //    {
        //        return this.SendData(ResponseType.Fail, "异常");
        //    }
        //}

        ///// <summary>
        ///// 获取位置信息
        ///// </summary>
        ///// <param name="_"></param>
        ///// <returns></returns>
        //private Negotiator positionInfo(dynamic _)
        //{
        //    try
        //    {
        //        var watch = CommonHelper.TimerStart();
        //        var recdata = this.GetModule<ReceiveModule<doc_con_pan_positionEntity>>();
        //        bool resValidation = this.DataValidation(recdata.userid, recdata.token);
        //        if (!resValidation)
        //        {
        //            return this.SendData(ResponseType.Fail, "后台无登录信息");
        //        }
        //        else
        //        {
        //            var data = docpositionbll.GetEntity( recdata.data.dcpp_num.ToString());
        //            return this.SendData<doc_con_pan_positionEntity>(data, recdata.userid, recdata.token, ResponseType.Success);
        //        }
        //    }
        //    catch
        //    {
        //        return this.SendData(ResponseType.Fail, "异常");
        //    }
        //}


        ///// <summary>
        ///// 获取盘头信息
        ///// </summary>
        ///// <param name="_"></param>
        ///// <returns></returns>
        //private Negotiator panInfo(dynamic _)
        //{
        //    try
        //    {
        //        var watch = CommonHelper.TimerStart();
        //        var recdata = this.GetModule<ReceiveModule<doc_con_pan_headEntity>>();
        //        bool resValidation = this.DataValidation(recdata.userid, recdata.token);
        //        if (!resValidation)
        //        {
        //            return this.SendData(ResponseType.Fail, "后台无登录信息");
        //        }
        //        else
        //        {
        //            var data = docpanbll.GetEntity( recdata.data.dcph_num.ToString());
        //            return this.SendData<doc_con_pan_headEntity>(data, recdata.userid, recdata.token, ResponseType.Success);

        //            //var data = docpanbll.GetList(pagination, recdata.data.queryData);
        //            //DataPageList<IEnumerable<doc_con_pan_positionEntity>> dataPageList = new DataPageList<IEnumerable<doc_con_pan_positionEntity>>
        //            //{
        //            //    rows = data,
        //            //    total = pagination.total,
        //            //    page = pagination.page,
        //            //    records = pagination.records,
        //            //    costtime = CommonHelper.TimerEnd(watch)
        //            //};
        //            //return this.SendData<DataPageList<IEnumerable<doc_con_pan_positionEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
        //        }
        //    }
        //    catch
        //    {
        //        return this.SendData(ResponseType.Fail, "异常");
        //    }
        //}

    }
}