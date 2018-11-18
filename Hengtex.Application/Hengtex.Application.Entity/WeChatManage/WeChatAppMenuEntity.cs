
namespace Hengtex.Application.Entity.WeChatManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.12.23 11:31
    /// 描 述：企业号应用自定义菜单
    /// </summary>
    public class WeChatAppMenuEntity
    {
        /// <summary>
        /// 菜单主键
        /// </summary>
        public string MenuId { get; set; }
        /// <summary>
        /// 菜单标题
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 跳转URL
        /// </summary>
        public string MenuUrl { get; set; }
        /// <summary>
        /// 菜单的响应动作类型
        /// </summary>
        public string MenuType { get; set; }
        /// <summary>
        /// 菜单的响应动作类型
        /// </summary>
        public string MenuTypeName { get; set; }
        /// <summary>
        /// 菜单等级
        /// </summary>
        public int? Level { get; set; }
        /// <summary>
        /// 菜单节点
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? SortCode { get; set; }
    }
}
