using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using Hengtex.Util;
using Hengtex.Util.Extension;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-05-24 17:23
    /// 描 述：con_pan_head_out
    /// </summary>
    public class con_pan_head_outService : RepositoryFactory, con_pan_head_outIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<con_pan_head_outEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.ERPRepository().FindList<con_pan_head_outEntity>(pagination);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public con_pan_head_outEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity<con_pan_head_outEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<con_pan_head_empsEntity> GetDetails(string keyValue)
        {
            return this.ERPRepository().FindList<con_pan_head_empsEntity>("select * from con_pan_head_emps where phe_num='" + keyValue + "'");
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
                db.Delete<con_pan_head_outEntity>(keyValue);
                db.Delete<con_pan_head_empsEntity>(t => t.phe_id.Equals(keyValue));
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
        public void SaveForm(string keyValue, con_pan_head_outEntity entity,List<con_pan_head_empsEntity> entryList)
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
                db.Delete<con_pan_head_empsEntity>(t => t.phe_num.Equals(keyValue));
                foreach (con_pan_head_empsEntity item in entryList)
                {
                    item.Create();
                    item.phe_num = entity.pho_Num;
                    db.Insert(item);
                }
            }
            else
            {
                //主表
                entity.Create();
                db.Insert(entity);
                //明细
                foreach (con_pan_head_empsEntity item in entryList)
                {
                    item.Create();
                    item.phe_num = entity.pho_Num;
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
