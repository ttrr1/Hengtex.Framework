using Hengtex.Application.Entity.ErpManage;
using Hengtex.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.IService.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2018 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2018.02.08
    /// 描 述：电表日报管理
    /// </summary>
    public interface IAmmeDailyService
    {
        #region 获取数据
        /// <summary>
        /// 电表日报列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<AmmeDailyEntity> GetList();
        /// <summary>
        /// 电表日报列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<AmmeDailyEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 点半rib实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        AmmeDailyEntity GetEntity(string keyValue);
        #endregion

        #region 验证数据
        /// <summary>
        /// 当天电表日报不能重复
        /// </summary>
        /// <param name="ammeNo">编号</param>
        /// <param name="keyValue">主键</param>
        ///  /// <param name="date">日期</param>
        /// <returns></returns>
        bool ExistAmmeDaily(string ad_ammeNo, string dateNow);
       
        #endregion

        #region 提交数据
      
        /// <summary>
        /// 保存电表日报（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        void SaveAmmeDailyForm(string keyValue, AmmeDailyEntity ammeDailyEntity);
        #endregion
    }
}
