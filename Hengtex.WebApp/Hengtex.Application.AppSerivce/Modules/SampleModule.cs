using Hengtex.Application.Busines.AppManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Code;
using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.Entity.Sale;
using Hengtex.Application.Entity.WebApp;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using Nancy.Responses.Negotiation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Hengtex.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.05.04 13:57
    /// 描 述:登录接口
    /// </summary>
    public class SampleModule : BaseModule
    {
        private UserCache userCache = new UserCache();
        private AppAuthorizeBLL appAuthorizeBLL = new AppAuthorizeBLL();
        private SaleBLL salebll = new SaleBLL();
        private ProdeliverySaleBLL proDeliverybll = new ProdeliverySaleBLL();

        private ProRzStockDetailsBLL proRzStockDetailbll = new ProRzStockDetailsBLL();
        private ProRzStockBLL proRzStockbll   = new ProRzStockBLL();
        private ProRbStockBLL proRbStockbll = new ProRbStockBLL();
        private ProRbStockDetailsBLL proRbStockDetailbll = new ProRbStockDetailsBLL();

        private ProRbOrderBLL proRbOrderbll = new ProRbOrderBLL();
        private ProRzOrderBLL proRzOrderbll = new ProRzOrderBLL();

        public SampleModule()
            : base("/hengtex/api")
        {
            Post["/user/modifyPassword"] = ModifyPassword;//暂时有问题
            Post["/Sample/GetSampleData"] = GetUserList;
            Post["/Sample/getSampleModuleList"] = GetSampleModuleList;//获取样品
            Post["/Sample/getProDeliveryModuleList"] = GetProDeliveryModuleList;//获取发货
            Post["/Sample/getProRzStockModuleList"] = GetProRzStockModuleList;//获取染整库存
            Post["/Sample/getProRzStockDetailsModuleList"] = GetProRzStockDetailsModuleList;//获取染整库存详情
            Post["/Sample/getProRbStockModuleList"] = GetProRbStockModuleList;//获取绒布库存
            Post["/Sample/getProRbStockDetailsModuleList"] = GetProRbStockDetailsModuleList;//获取绒布库存详情

            Post["/Sample/getProRbOrderModuleList"] = GetProRbOrderModuleList;//获取绒布订单列表
            Post["/Sample/getProRzOrderModuleList"] = GetProRzOrderModuleList;//获取染整订单列表

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
        /// 获取样品列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetUserList(dynamic _)
        {
            try{
                var recdata = this.GetModule<ReceiveModule>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = userCache.GetListToApp();
                    return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch { 
                return this.SendData(ResponseType.Fail, "异常");
            }   
        }


        /// <summary>
        /// 获取样品列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetSampleModuleList(dynamic _)
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
                    var data = salebll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<SampleEntity>> dataPageList = new DataPageList<IEnumerable<SampleEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<SampleEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

            //var data = userCache.GetListToApp();
            //return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
        }



        /// <summary>
        /// 获取发货单列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetProDeliveryModuleList(dynamic _)
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
                    var data = proDeliverybll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<ProDeliveryEntity>> dataPageList = new DataPageList<IEnumerable<ProDeliveryEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<ProDeliveryEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

            //var data = userCache.GetListToApp();
            //return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
        }



        /// <summary>
        /// 获取染整库存列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetProRzStockModuleList(dynamic _)
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
                    DataTable data = proRzStockbll.GetPageListByDt(pagination, recdata.data.queryData);
                    IList<ProRzStockEntity> proRzList = new List<ProRzStockEntity>();
                    
                    
                    foreach(DataRow row in data.Rows)
                    {
                        ProRzStockEntity proRz = new ProRzStockEntity
                        {
                            b_num = row["b_num"].ToString().Trim(),
                            p_code=row["p_code"].ToString().Trim(),
                            p_name = row["p_name"].ToString().Trim(),
                            o_custName = row["o_custName"].ToString().Trim(),
                            c_region = row["c_region"].ToString().Trim(),
                            p_count = row["p_count"].ToString().Trim(),
                            p_zhishu = row["p_zhishu"].ToString().Trim(),
                            b_pinhao = row["b_pinhao"].ToString().Trim(),
                            p_color = row["p_color"].ToString().Trim(),
                            p_unit = row["p_unit"].ToString().Trim(),
                            p_grade = row["p_grade"].ToString().Trim(),
                            p_dateLastIn = row["p_dateLastIn"].ToString().Trim(),
                            o_departName = row["o_departName"].ToString().Trim(),
                            p_overstockDes = row["p_overstockDes"].ToString().Trim(),

                        };
                        proRzList.Add(proRz);
                    }
                   
                    
                    DataPageList<IList<ProRzStockEntity>> dataPageList = new DataPageList<IList<ProRzStockEntity>>
                    {
                        rows = proRzList,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IList<ProRzStockEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

            //var data = userCache.GetListToApp();
            //return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
        }


        /// <summary>
        /// 获取染整库存详情
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetProRzStockDetailsModuleList(dynamic _)
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
                    var data = proRzStockDetailbll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<ProRzStockDetailsEntity>> dataPageList = new DataPageList<IEnumerable<ProRzStockDetailsEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<ProRzStockDetailsEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

            //var data = userCache.GetListToApp();
            //return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
        }



        /// <summary>
        /// 获取绒布库存列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetProRbStockModuleList(dynamic _)
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
                    DataTable data = proRbStockbll.GetPageListByDt(pagination, recdata.data.queryData);
                    IList<ProRzStockEntity> proRzList = new List<ProRzStockEntity>();


                    foreach (DataRow row in data.Rows)
                    {
                        ProRzStockEntity proRz = new ProRzStockEntity
                        {
                            b_num = row["b_num"].ToString().Trim(),
                            p_code = row["p_code"].ToString().Trim(),
                            p_name = row["p_name"].ToString().Trim(),
                            o_custName = row["o_custName"].ToString().Trim(),
                            c_region = row["c_region"].ToString().Trim(),
                            p_count = row["p_count"].ToString().Trim(),
                            p_zhishu = row["p_zhishu"].ToString().Trim(),
                            b_pinhao = row["b_pinhao"].ToString().Trim(),
                            p_color = row["p_color"].ToString().Trim(),
                            p_unit = row["p_unit"].ToString().Trim(),
                            p_grade = row["p_grade"].ToString().Trim(),
                            p_dateLastIn = row["p_dateLastIn"].ToString().Trim(),
                            o_departName = row["o_departName"].ToString().Trim(),
                            p_overstockDes = row["p_overstockDes"].ToString().Trim(),

                        };
                        proRzList.Add(proRz);
                    }


                    DataPageList<IList<ProRzStockEntity>> dataPageList = new DataPageList<IList<ProRzStockEntity>>
                    {
                        rows = proRzList,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IList<ProRzStockEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

            //var data = userCache.GetListToApp();
            //return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
        }


        /// <summary>
        /// 获取绒布库存详情
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetProRbStockDetailsModuleList(dynamic _)
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
                    var data = proRbStockDetailbll.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<ProRbStockDetailsEntity>> dataPageList = new DataPageList<IEnumerable<ProRbStockDetailsEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<ProRbStockDetailsEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

            //var data = userCache.GetListToApp();
            //return this.SendData<Dictionary<string, appUserInfoModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
        }


        /// <summary>
        /// 获取绒布订单列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetProRbOrderModuleList(dynamic _)
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

                    
                    Operator operator_ = this.ReadCache<Operator>(recdata.userid);
                    var data = proRbOrderbll.GetDataListByDt(pagination, recdata.data.queryData, operator_.Account);
                    IList<ProRbOrderEntity> listOrder = new List<ProRbOrderEntity>();
                   
                    foreach(DataRow row in data.Rows)
                    {
                        ProRbOrderEntity proOrder = new ProRbOrderEntity();
                        Type t = proOrder.GetType();
                        PropertyInfo[] pro2 = t.GetProperties();
                        foreach (PropertyInfo item in pro2)
                        {                            
                            item.SetValue(proOrder,  ConvertEx.ToString(row[item.Name]));                            
                        }
                        listOrder.Add(proOrder);
                    }

                    DataPageList<IList<ProRbOrderEntity>> dataPageList = new DataPageList<IList<ProRbOrderEntity>>
                    {
                        rows = listOrder,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IList<ProRbOrderEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }


        /// <summary>
        /// 获取染整订单列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator GetProRzOrderModuleList(dynamic _)
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


                    Operator operator_ = this.ReadCache<Operator>(recdata.userid);
                    var data = proRzOrderbll.GetDataListByDt(pagination, recdata.data.queryData, operator_.Account);
                    IList<ProRzOrderEntity> listOrder = new List<ProRzOrderEntity>();

                    foreach (DataRow row in data.Rows)
                    {
                        ProRzOrderEntity proOrder = new ProRzOrderEntity();
                        Type t = proOrder.GetType();
                        PropertyInfo[] pro2 = t.GetProperties();
                        foreach (PropertyInfo item in pro2)
                        {
                            item.SetValue(proOrder, ConvertEx.ToString(row[item.Name]));
                        }
                        listOrder.Add(proOrder);
                    }

                    DataPageList<IList<ProRzOrderEntity>> dataPageList = new DataPageList<IList<ProRzOrderEntity>>
                    {
                        rows = listOrder,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IList<ProRzOrderEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }

        }

    }
}