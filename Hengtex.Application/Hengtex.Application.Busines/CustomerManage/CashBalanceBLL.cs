using Hengtex.Application.Entity.CustomerManage;
using Hengtex.Application.IService.CustomerManage;
using Hengtex.Application.Service.CustomerManage;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Hengtex.Application.Busines.CustomerManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：菠萝绒
    /// 日 期：2016-04-28 16:48
    /// 描 述：现金余额
    /// </summary>
    public class CashBalanceBLL
    {
        private ICashBalanceService service = new CashBalanceService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CashBalanceEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        #endregion

        #region 提交数据
        #endregion
    }
}
