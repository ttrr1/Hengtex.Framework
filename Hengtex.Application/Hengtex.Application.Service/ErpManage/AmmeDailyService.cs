using Hengtex.Data.Repository;
using Hengtex.Util;
using Hengtex.Util.WebControl;
using Hengtex.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Hengtex.Data;
using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using System;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：熊斌
    /// 日 期：2015.11.4 14:31
    /// 描 述：电表日报管理
    /// </summary>
    public class AmmeDailyService : RepositoryFactory<AmmeDailyEntity>, IAmmeDailyService
    {
       

        #region 获取数据
        /// <summary>
        /// 电表列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AmmeDailyEntity> GetList()
        {
            var expression = LinqExtensions.True<AmmeDailyEntity>();
           // expression = expression.And(t => t.FlagDelete == "0").And(t => t.a_Dept != "废表");
            return this.ERPRepository().IQueryable(expression).OrderByDescending(t => t.CreationDate).ToList();
        }

        /// <summary>
        /// 电表日报列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AmmeDailyEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<AmmeDailyEntity>();
            var queryParam = queryJson.ToJObject();

            string sqlCondation = "  ";
            string where = queryParam["where"].ToString();
            sqlCondation = sqlCondation + where;
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {

                    case "All":

                        sqlCondation = sqlCondation + " and (a_ammeName like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or a_ammeNo like '%" + keyword + "%'";                        
                        break;
                    default:
                        break;
                }
            }
            try
            {
                string sql = "select a.ad_date,a.ad_ammeNo,a.ad_readingStart,a.ad_readingEnd,a.ad_realDegree,a.ad_registrant,a.ad_registTime,b.* from  fclt_ammeters_daliy a inner join  fclt_ammeters  b on a.ad_ammeNo=b.a_ammeNo  where    1=1    AND b.FlagDelete = 0  AND b.a_Dept <> '废表'  ";
                sql += sqlCondation;
                return this.ERPRepository().FindList(sql, pagination).OrderBy(t => t.ad_ammeNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
      
        /// <summary>
        /// 电表日报实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AmmeDailyEntity GetEntity(string keyValue)
        {
            return this.ERPRepository().FindEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        ///当前日期不能重复
        /// </summary>
        /// <param name="ad_ammeNo">编号</param>
        /// <param name="dateNow">当前日期</param>
        /// <returns></returns>
        public bool ExistAmmeDaily(string ad_ammeNo,string dateNow)
        {
            var expression = LinqExtensions.True<AmmeDailyEntity>();
            expression = expression.And(t => t.ad_ammeNo == ad_ammeNo).And(t => t.ad_date == dateNow);
           
            return this.ERPRepository().IQueryable(expression).Count() == 0 ? true : false;
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存电表日报表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="ammeDailyEntity">电表日报实体</param>
        /// <returns></returns>
        public  void SaveAmmeDailyForm(string keyValue, AmmeDailyEntity ammeDailyEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ammeDailyEntity.Modify(keyValue);
                this.ERPRepository().Update(ammeDailyEntity);
            }
            else
            {
                ammeDailyEntity.Create();
               
                this.ERPRepository().Insert(ammeDailyEntity);
            }
        }






        #endregion
    }
}
