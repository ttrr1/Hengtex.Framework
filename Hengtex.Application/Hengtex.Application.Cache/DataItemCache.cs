using Hengtex.Application.Busines;
using Hengtex.Application.Busines.SystemManage;
using Hengtex.Application.Entity.SystemManage.ViewModel;
using Hengtex.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hengtex.Application.Cache
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.29 9:56
    /// 描 述：数据字典缓存
    /// </summary>
    public class DataItemCache
    {
        private DataItemDetailBLL busines = new DataItemDetailBLL();

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<DataItemModel>>(busines.cacheKey);
            if (cacheList == null)
            {
                var data = busines.GetDataItemList();
                CacheFactory.Cache().WriteCache(data, busines.cacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList(string EnCode)
        {
            return this.GetDataItemList().Where(t => t.EnCode == EnCode);
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetSubDataItemList(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == EnCode);
            string ItemDetailId = data.First(t => t.ItemValue == ItemValue).ItemDetailId;
            return data.Where(t => t.ParentId == ItemDetailId);
        }
        /// <summary>
        /// 项目值转换名称
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public string ToItemName(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == EnCode);
            return data.First(t => t.ItemValue == ItemValue).ItemName;
        }
    }
}
