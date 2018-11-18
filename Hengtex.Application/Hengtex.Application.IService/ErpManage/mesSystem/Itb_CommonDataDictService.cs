using Hengtex.Application.Entity.ErpManage;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.IService.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2018 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2018.02.08
    /// 描 述：工序档案管理
    /// </summary>
    public interface Itb_CommonDataDictService
    {
        #region 获取数据

        /// <summary>
        /// <mes_pro_records
        /// </summary>
        /// <param name="fields">查询</param>
        /// <returns></returns>
        IEnumerable<tb_CommonDataDictEntity> GetList(int dataType);


        #endregion
    }
}