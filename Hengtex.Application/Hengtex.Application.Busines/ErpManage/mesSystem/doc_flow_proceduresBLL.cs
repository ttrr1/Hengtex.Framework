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
    /// 描 述：工序权限管理
    /// </summary>
    public class doc_flow_proceduresBLL
    {
        private Idoc_flow_proceduresService service = new doc_flow_proceduresService();
        

        #region 获取数据
        
        /// <summary>
        /// 根据人员查询条件获取工序权限表
        /// </summary>
        
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<doc_flow_proceduresEntity> GetPageList( string queryJson)
        {
            return service.GetPageList( queryJson);
        }

        /// <summary>
        /// 工序权限实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public doc_flow_proceduresEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

    }
}
