using Hengtex.Application.Entity.CustomerManage;
using Hengtex.Application.IService.CustomerManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Service.CustomerManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：菠萝绒
    /// 日 期：2016-03-16 13:54
    /// 描 述：订单明细
    /// </summary>
    public class OrderEntryService : RepositoryFactory<OrderEntryEntity>, IOrderEntryService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="orderId">订单主键</param>
        /// <returns>返回列表</returns>
        public IEnumerable<OrderEntryEntity> GetList(string orderId)
        {
            return this.BaseRepository().IQueryable(t => t.OrderId.Equals(orderId)).OrderByDescending(t => t.SortCode).ToList();
        }
        #endregion
    }
}