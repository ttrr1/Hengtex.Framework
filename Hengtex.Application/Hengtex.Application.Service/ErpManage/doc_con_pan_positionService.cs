using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using Hengtex.Util;

using Hengtex.Util.Extension;
using System;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：lvh
    /// 日 期：2018-02-10 10:17
    /// 描 述：doc_con_pan_position
    /// </summary>
    public class doc_con_pan_positionService : RepositoryFactory<doc_con_pan_positionEntity>, doc_con_pan_positionIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<doc_con_pan_positionEntity> GetList(string fieldName,string keyword)
        {
            var expression = LinqExtensions.True<doc_con_pan_positionEntity>();
            string sqlCondation = "  ";
            //查询条件

            switch (fieldName)
                {
                    
                    case "All":            //类型
                    sqlCondation = sqlCondation + " and (dcpp_num like '%" + keyword + "%'";
                    
                    sqlCondation = sqlCondation + " or dcpp_type like '%" + keyword + "%')";
                    break;
                    default:
                        break;
                }

            try
            {

                string sql = "select * from  doc_con_pan_position where    FlagDelete=0 ";
                sql += sqlCondation;
                
                return this.ERPRepository().FindList(sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public doc_con_pan_positionEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, doc_con_pan_positionEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
