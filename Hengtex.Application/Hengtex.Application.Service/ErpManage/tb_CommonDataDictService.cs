using Hengtex.Application.Entity.SystemManage;
using Hengtex.Application.IService.SystemManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using Hengtex.Util;

using Hengtex.Util.Extension;

namespace Hengtex.Application.Service.SystemManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-02-03 17:07
    /// 描 述：tb_CommonDataDict
    /// </summary>
    public class tb_CommonDataDictService : RepositoryFactory<tb_CommonDataDictEntity>, tb_CommonDataDictIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<tb_CommonDataDictEntity> GetList(string queryJson)
        {
            int dataType = 0;
            dataType = int.Parse(queryJson);
            return this.ERPRepository().IQueryable(t => t.DataType == dataType).OrderBy(t => t.DataCode).ToList();
           // return this.ERPRepository().FindList<tb_CommonDataDictEntity>("select * from tb_CommonDataDictEntity where DataType='" + queryJson + "'");
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public tb_CommonDataDictEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.ERPRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, tb_CommonDataDictEntity entity)
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
