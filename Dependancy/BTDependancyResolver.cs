using Microsoft.Practices.Unity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
//using System.Web.Http.Dependencies;

namespace Dependancy
{
    public class BTDependancyResolver : IDependencyResolver
    {
        readonly IUnityContainer _container;

        public BTDependancyResolver(IUnityContainer Container)
        {
            _container = Container;
            _container.RegisterType<IService, Service>();

        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
            
        }
        /////////
        //public IDependencyScope BeginScope()
        //{
        //    var child = _container.CreateChildContainer();
        //    return new BTDependancyResolver(child);
        //}

        //public void Dispose()
        //{
        //    _container.Dispose();
        //}


    }
}
