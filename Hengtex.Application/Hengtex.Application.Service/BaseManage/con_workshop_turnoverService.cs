using Hengtex.Application.Entity.BaseManage;
using Hengtex.Application.IService.BaseManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System;
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
    /// 日 期：2018-01-19 15:26
    /// 描 述：con_workshop_turnover
    /// </summary>
    public class con_workshop_turnoverService : RepositoryFactory, con_workshop_turnoverIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<con_workshop_turnoverEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.ERPRepository().FindList<con_workshop_turnoverEntity>(pagination);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public con_workshop_turnoverEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity<con_workshop_turnoverEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<con_workshop_turnover_detailEntity> GetDetails(string keyValue)
        {
            return this.ERPRepository().FindList<con_workshop_turnover_detailEntity>("select * from con_workshop_turnover_detail where wtd_num='" + keyValue + "'");
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IRepository db = new RepositoryFactory().ERPRepository().BeginTrans();
            try
            {
                db.Delete<con_workshop_turnoverEntity>(keyValue);
                db.Delete<con_workshop_turnover_detailEntity>(t => t.wtd_id.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, con_workshop_turnoverEntity entity,List<con_workshop_turnover_detailEntity> entryList)
        {
        IRepository db = this.ERPRepository().BeginTrans();
        try
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                //主表
                entity.Modify(keyValue);
                db.Update(entity);
                //明细
                db.Delete<con_workshop_turnover_detailEntity>(t => t.wtd_num.Equals(keyValue));
                foreach (con_workshop_turnover_detailEntity item in entryList)
                {
                    item.Create();
                    item.wtd_num = entity.wt_num;
                    db.Insert(item);
                }
            }
            else
            {
                //主表
                entity.Create();
                db.Insert(entity);
                //明细
                foreach (con_workshop_turnover_detailEntity item in entryList)
                {
                    item.Create();
                    item.wtd_num = entity.wt_num;
                    db.Insert(item);
                }
            }
            db.Commit();
        }
        catch (Exception)
        {
            db.Rollback();
            throw;
        }
        }
        #endregion
    }
}
