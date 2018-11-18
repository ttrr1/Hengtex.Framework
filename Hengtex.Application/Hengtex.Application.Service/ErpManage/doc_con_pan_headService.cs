using Hengtex.Application.Entity.ErpManage;
using Hengtex.Application.IService.ErpManage;
using Hengtex.Data.Repository;
using Hengtex.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using Hengtex.Util;

using Hengtex.Util.Extension;
using Hengtex.Application.IService.AuthorizeManage;
using Hengtex.Application.IService.SystemManage;
using Hengtex.Application.Service.AuthorizeManage;
using Hengtex.Application.Service.SystemManage;
using System;

namespace Hengtex.Application.Service.ErpManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创 建：超级管理员
    /// 日 期：2018-02-05 18:06
    /// 描 述：doc_con_pan_head
    /// </summary>
    public class doc_con_pan_headService : RepositoryFactory<doc_con_pan_headEntity>, doc_con_pan_headIService
    {
        private IAuthorizeService<doc_con_pan_headEntity> iauthorizeservice = new AuthorizeService<doc_con_pan_headEntity>();
        private ICodeRuleService coderuleService = new CodeRuleService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<doc_con_pan_headEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<doc_con_pan_headEntity>();
            var queryParam = queryJson.ToJObject();
            //expression.And(t => t.FlagDelete == false);
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "dcph_num":              //编号
                        expression = expression.And(t => t.dcph_num.Contains(keyword));
                        break;
                    case "dcph_no":            //名称
                        expression = expression.And(t => t.dcph_no.Contains(keyword));
                        break;
                    case "dcph_symbol":             //助记符
                        expression = expression.And(t => t.dcph_symbol.Contains(keyword));
                        break;
                    case "dcph_status":       //状态
                        expression = expression.And(t => t.dcph_status.Contains(keyword));
                        break;
                    case "dcph_positionName":       //位置
                        expression = expression.And(t => t.dcph_positionName.Contains(keyword));
                        break;
                    case "dcph_fcltNameNext":       //机台
                        expression = expression.And(t => t.dcph_fcltNameNext.Contains(keyword));
                        break;
                    case "dcph_batch":       //批次
                        expression = expression.And(t => t.dcph_batch.Contains(keyword));
                        break;
                    case "All":
                        expression = expression.And(t => t.dcph_num.Contains(keyword)
                            || t.dcph_no.Contains(keyword)
                            || t.dcph_symbol.Contains(keyword)
                            || t.dcph_status.Contains(keyword)
                            || t.dcph_positionName.Contains(keyword)
                             || t.dcph_fcltNameNext.Contains(keyword)
                              || t.dcph_batch.Contains(keyword)
                            );
                        break;
                    default:
                        break;
                }
            }
            return this.ERPRepository().FindList(expression, pagination);
            //return iauthorizeservice.FindList(expression, pagination);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<doc_con_pan_headEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<doc_con_pan_headEntity>();
            var queryParam = queryJson.ToJObject();
            //expression.And(t => t.FlagDelete == false);
            string sqlCondation = "  ";
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "dcph_num":              //编号
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_no":            //名称
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_symbol":             //助记符
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_status":       //状态
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_positionName":       //位置
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_fcltNameNext":       //机台
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "dcph_batch":       //批次
                        sqlCondation = sqlCondation + " and " + condition + " like '%" + keyword + "%'";
                        break;
                    case "All":
                        sqlCondation = sqlCondation + " and (dcph_num like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_no like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_symbol like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_status like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_positionName like '%" + keyword + "%'";
                        sqlCondation = sqlCondation + " or dcph_fcltNameNext like '%" + keyword + "%'";
                    
                        sqlCondation = sqlCondation + " or dcph_batch like '%" + keyword + "%')";
                        break;
                    default:
                        break;
                }
            }
            try
            {
                string sql = "select  * from  doc_con_pan_head where    FlagDelete=0 ";
                sql += sqlCondation;
               
                return this.ERPRepository().FindList(sql, pagination);

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
        public doc_con_pan_headEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, doc_con_pan_headEntity entity)
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
