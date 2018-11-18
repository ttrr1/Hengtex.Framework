using Hengtex.Application.Entity.AppManage;
using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.AppManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Application.Service.AppManage;
using Hengtex.Application.Service.ErpManage;
using Hengtex.Cache.Factory;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Busines.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.4 14:31
    /// 描 述：电表日报管理
    /// </summary>
    public class AmmeDailyBLL
    {
        private IAmmeDailyService service = new AmmeDailyService();
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "AmmeDailyCache";

        #region 获取数据
        /// <summary>
        /// 电表日报列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AmmeDailyEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 电表日报列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AmmeDailyEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
       
        /// <summary>
        /// 电表日报实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AmmeDailyEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 电表日报编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAmmeDaily(string enCode, string date)
        {
            return service.ExistAmmeDaily(enCode, date);
        }
       
        #endregion

        #region 提交数据
      
        /// <summary>
        /// 保存电表日报表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="ammeDailyEntity">电表日报实体</param>
        /// <returns></returns>
        public void SaveAmmeDailyForm(string keyValue, AmmeDailyEntity ammeDailyEntity)
        {
            try
            {
                service.SaveAmmeDailyForm(keyValue, ammeDailyEntity);
                CacheFactory.Cache().RemoveCache(cacheKey);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
