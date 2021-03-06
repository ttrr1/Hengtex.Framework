﻿
namespace Hengtex.Application.Entity.SystemManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.24 13:32
    /// 描 述：数据库表字段
    /// </summary>
    public class DataBaseTableFieldEntity
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string column { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string datatype { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public int? length { get; set; }
        /// <summary>
        /// 允许空
        /// </summary>
        public string isnullable { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string identity { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string defaults { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string remark { get; set; }
    }
}
