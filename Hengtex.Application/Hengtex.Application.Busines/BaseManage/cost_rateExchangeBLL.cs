using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.IService.BaseManage;
using Hengtex.Application.Service.BaseManage;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System;

namespace Hengtex.Application.Busines.BaseManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-01-19 14:56
    /// 描 述：cost_rateExchange
    /// </summary>
    public class cost_rateExchangeBLL
    {
        private cost_rateExchangeIService service = new cost_rateExchangeService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<cost_rateExchangeEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public cost_rateExchangeEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, cost_rateExchangeEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
