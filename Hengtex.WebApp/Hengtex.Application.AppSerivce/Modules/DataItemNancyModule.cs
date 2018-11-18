using Hengtex.Application.Busines.SystemManage;
using Hengtex.Application.Cache;
using Hengtex.Application.Entity.SystemManage;
using Hengtex.Application.Entity.SystemManage.ViewModel;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace Hengtex.Application.AppSerivce.Modules
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：陈彬彬
    /// 日 期：2016.05.12 13:57
    /// 描 述:数据字典接口
    /// </summary>
    public class DataItemNancyModule:BaseModule
    {
        private DataItemCache dataItemCache = new DataItemCache();
        private tb_CommonDataDictBLL dictbll = new tb_CommonDataDictBLL();
        public DataItemNancyModule()
            : base("/hengtex/api")
        {
            Post["/dataItem/list"] = List;
            Post["/dataItem/getDataDict"] = DataDict;
        }
        /// <summary>
        /// 获取数据字典列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator List(dynamic _)
        {
            var recdata = this.GetModule<ReceiveModule<DataItemQuery>>();
            bool resValidation = this.DataValidation(recdata.userid, recdata.token);
            if (!resValidation)
            {
                return this.SendData(ResponseType.Fail, "无该用户登录信息");
            }
            else
            {
                var data = dataItemCache.GetDataItemList(recdata.data.enCode);
                return this.SendData<IEnumerable<DataItemModel>>(data, recdata.userid, recdata.token, ResponseType.Success);
            }
         
        }

        /// <summary>
        /// 获取基础档案
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator DataDict(dynamic _)
        {
            var recdata = this.GetModule<ReceiveModule<tb_CommonDataDictEntity>>();
            bool resValidation = this.DataValidation(recdata.userid, recdata.token);
            if (!resValidation)
            {
                return this.SendData(ResponseType.Fail, "无该用户登录信息");
            }
            else
            {
                var data = dictbll.GetList(recdata.data.DataType.ToString());
                return this.SendData<IEnumerable<tb_CommonDataDictEntity>>(data, recdata.userid, recdata.token, ResponseType.Success);
            }

        }
    }
    /// <summary>
    /// 字典列表请求条件
    /// </summary>
    public class DataItemQuery{
        public string enCode { get; set; }
    }
}