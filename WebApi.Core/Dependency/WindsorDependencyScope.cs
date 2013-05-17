namespace WebApi.Core.Dependency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    /// <summary>
    /// The windsor dependency scope.
    /// </summary>
    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IDependencyScope _scope;

        private readonly Action<object> _releaseActions;

        private readonly List<object> _objectInstances;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorDependencyScope"/> class.
        /// </summary>
        /// <param name="scope">
        /// The scope.
        /// </param>
        /// <param name="releaseAction">
        /// The release action.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public WindsorDependencyScope(IDependencyScope scope, Action<object> releaseAction)
        {
            if (scope == null)
            {
                throw new ArgumentNullException("scope");
            }

            if (releaseAction == null)
            {
                throw new ArgumentNullException("releaseAction");
            }

            _scope = scope;
            _releaseActions = releaseAction;
            _objectInstances = new List<object>();
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetService(Type type)
        {
            var service = _scope.GetService(type);
            AddToScope(service);

            return service;
        }

        public IEnumerable<object> GetServices(Type type)
        {
            var services = _scope.GetServices(type);
            AddToScope(services);

            return services;
        }

        /// <summary>
        /// The add to scope.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        private void AddToScope(params object[] services)
        {
            if (services.Any())
            {
                _objectInstances.AddRange(services);
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            foreach (object instance in _objectInstances)
            {
                _releaseActions(instance);
            }

            _objectInstances.Clear();
        }
    }
}
