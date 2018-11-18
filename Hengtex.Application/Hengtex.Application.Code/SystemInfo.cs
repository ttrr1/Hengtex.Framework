using Hengtex.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hengtex.Application.Code
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11159 10:45
    /// 描 述：系统信息
    /// </summary>
    public class SystemInfo
    {
        /// <summary>
        /// 当前Tab页面模块Id
        /// </summary>
        public static string CurrentModuleId
        {
            get
            {
                return WebHelper.GetCookie("currentmoduleId");
            }
        }
        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public static string CurrentUserId
        {
            get
            {
                return OperatorProvider.Provider.Current().UserId;
            }
        }
    }
}
