using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.IService.BaseManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using Hengtex.Util;

using Hengtex.Util.Extension;

namespace Hengtex.Application.Service.BaseManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-01-19 14:56
    /// 描 述：cost_rateExchange
    /// </summary>
    public class cost_rateExchangeService : RepositoryFactory<cost_rateExchangeEntity>, cost_rateExchangeIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<cost_rateExchangeEntity> GetList(string queryJson)
        {
            return this.ERPRepository().IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public cost_rateExchangeEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(int.Parse(keyValue));
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.ERPRepository().Delete(int.Parse(keyValue));
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, cost_rateExchangeEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.ERPRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.ERPRepository().Insert(entity);
            }
        }
        #endregion
    }
}
