using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using Hengtex.Util.Ioc;

namespace Hengtex.Data.Repository
{
    public class IocHelper
    {
        private readonly TinyIoCContainer _container;
        private static readonly IocHelper instance = new IocHelper();

        public IocHelper()
        {
            //接口dll路径
            string assembleFileName1 = Assembly.GetExecutingAssembly().CodeBase.Replace("Hengtex.Data.Repository.DLL", "Hengtex.Data.dll").Replace("file:///", "");
            //实现dll路径
            string assembleFileName2 = Assembly.GetExecutingAssembly().CodeBase.Replace("Hengtex.Data.Repository.DLL", "Hengtex.Data.EF.dll").Replace("file:///", "");
            
            _container = new TinyIoCContainer();
            _container.AutoRegister(new[] { Assembly.LoadFrom(assembleFileName1) },
            DuplicateImplementationActions.RegisterSingle);
            _container.AutoRegister(new[] { Assembly.LoadFrom(assembleFileName2) },
            DuplicateImplementationActions.RegisterSingle);
        }
        public static IocHelper Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// Ioc容器
        /// </summary>
        public TinyIoCContainer Container
        {
            get { return _container; }
        }
    }
}
