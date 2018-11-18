using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Service.ErpManage;
using Hengtex.Cache.Factory;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Busines.AppManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：工序定义管理
    /// </summary>
    public class Fclt_facilitiesBLL
    {
        private IFclt_facilitiesService service = new Fclt_facilitiesService();
        

        #region 获取数据
        /// <summary>
        /// 根据条件查询工序设定表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Fclt_facilitiesEntity> GetList(Dictionary<string, string> fields)
        {
            return service.GetList(fields);
        }
        /// <summary>
        ///根据条件查询工序设定表

        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Fclt_facilitiesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 工序设定实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Fclt_facilitiesEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

    }
}
