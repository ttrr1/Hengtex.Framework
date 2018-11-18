using Hengtex.Data.EF;

namespace Hengtex.Data.Repository
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.10.10
    /// 描 述：数据库建立工厂
    /// </summary>
    public class DbContextFactory
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        public static IDatabase Base(string connString)
        {
            return new Database(connString);
        }
        /// <summary>
        /// 连接基础库
        /// </summary>
        /// <returns></returns>
        public static IDatabase Base()
        {
            return new Database("Base");
        }
        /// <summary>
        /// 连接日志库
        /// </summary>
        /// <returns></returns>
        public static IDatabase Log()
        {
            return new Database("Log");
        }
    }



}
