using Hengtex.Application.Entity.CustomerManage;
using Hengtex.Application.IService.CustomerManage;
using Hengtex.Data.Repository;
using Hengtex.Util.Extension;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hengtex.Application.Service.CustomerManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：菠萝绒
    /// 日 期：2016-03-21 16:10
    /// 描 述：跟进记录
    /// </summary>
    public class TrailRecordService : RepositoryFactory<TrailRecordEntity>, ITrailRecordService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TrailRecordEntity> GetList(string objectId)
        {
            return this.BaseRepository().IQueryable(t => t.ObjectId.Equals(objectId)).OrderByDescending(t => t.CreateDate).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TrailRecordEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TrailRecordEntity entity)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                switch (entity.ObjectSort)
                {
                    case 1:         //商机
                        ChanceEntity chanceEntity = new ChanceEntity();
                        chanceEntity.Modify(entity.ObjectId);
                        db.Update<ChanceEntity>(chanceEntity);
                        break;
                    case 2:         //客户
                        CustomerEntity customerEntity = new CustomerEntity();
                        customerEntity.Modify(entity.ObjectId);
                        db.Update<CustomerEntity>(customerEntity);
                        break;
                    default:
                        break;
                }
                entity.Create();
                db.Insert(entity);

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