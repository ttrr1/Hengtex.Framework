using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Busines.ErpManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.Entity.WebApp;
using Hengtex.Util.WebControl;
using Nancy.Responses.Negotiation;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hengtex.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.05.04 13:57
    /// 描 述:登录接口
    /// </summary>
    public class AmmeModule : BaseModule
    {
        private AmmeDailyBLL ammeDailyBll = new AmmeDailyBLL();
        private AmmeBLL ammeBll = new AmmeBLL();
        private AppAuthorizeBLL appAuthorizeBLL = new AppAuthorizeBLL();
        public AmmeModule()
            : base("/hengtex/api")
        {
            Post["/amme/modifyPassword"] = ModifyPassword;//暂时有问题
            Post["/amme/GetAmmeData"] = GetAmmeData;
            Post["/amme/getAmmeModuleList"] = GetAmmeModuleList;
            Post["/amme/getAmmeDaylilyModuleList"] = GetAmmeDaylilyModuleList;

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
        /// 获取电表档案
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetAmmeData(dynamic _)
        {
            try
            {


                var recdata1 = this.GetModule<ReceiveModule<AmmeEntity>>();
                bool resValidation = this.DataValidation(recdata1.userid, recdata1.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = ammeBll.GetEntity(recdata1.data.a_ammeNo);
                    return this.SendData<AmmeEntity>(data, recdata1.userid, recdata1.token, ResponseType.Success);
                }
            }
            catch (Exception e)
            {
                throw e;
                // return this.SendData(ResponseType.Fail, "异常");
            }
        }

        /// <summary>
        /// 获取电表列表 
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetAmmeModuleList(dynamic _)
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
                    var data = ammeBll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<AmmeEntity>> dataPageList = new DataPageList<IEnumerable<AmmeEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = Util.CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<AmmeEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }

        /// <summary>
        /// 获取电表日报列表 
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetAmmeDaylilyModuleList(dynamic _)
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
                    var data = ammeDailyBll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<AmmeDailyEntity>> dataPageList = new DataPageList<IEnumerable<AmmeDailyEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = Util.CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<AmmeDailyEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }
    }
        //电表档案主键信息
        public class a_ammeNoData
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string a_ammeNo { get; set; }
        
    }
}