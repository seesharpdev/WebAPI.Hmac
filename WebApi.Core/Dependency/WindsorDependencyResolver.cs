namespace WebApi.Core.Dependency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    using Castle.Windsor;

    /// <summary>
    /// The windsor dependency resolver.
    /// </summary>
    public class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">
        /// The windsor container.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container != null)
            {
                _container = container;
            }
            else
            {
                throw new ArgumentNullException("container");
            }
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? 
                _container.Resolve(serviceType) : 
                null;
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? 
                _container.ResolveAll(serviceType).Cast<object>() : 
                Enumerable.Empty<object>();
        }

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyScope"/>.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this, _container.Release);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
