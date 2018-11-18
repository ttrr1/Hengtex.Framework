namespace Hengtex.Cache.Factory
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2012-2017 恒泰纺织
    /// 创建人：菠萝绒
    /// 日 期：2015.11.9 10:45
    /// 描 述：缓存工厂类
    /// </summary>
    public class CacheFactory
    {
        /// <summary>
        /// 定义通用的Repository
        /// </summary>
        /// <returns></returns>
        public static ICache Cache()
        {
            //修改为支持Redis
            string cacheType = Hengtex.Util.Config.GetValue("CacheType");
            switch (cacheType)
            {
                case "Redis":
                    return new Redis.Cache();
                    break;
                case "WebCache":
                    return new Cache();
                    break;
                default:
                    return new Cache();
                    break;
            }
        }
    }
}
