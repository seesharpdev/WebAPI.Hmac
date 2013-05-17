namespace WebApi.Core.Dependency
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>
    /// The customized web api installer.
    /// </summary>
    public class CustomizedWebApiInstaller : IWindsorInstaller
    {
        private readonly Assembly _controllerAssembly;

        private readonly HttpConfiguration _globalConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizedWebApiInstaller"/> class.
        /// </summary>
        /// <param name="globalConfiguration">
        /// The global configuration.
        /// </param>
        /// <param name="controllerAssembly">
        /// The controller assembly.
        /// </param>
        public CustomizedWebApiInstaller(
            HttpConfiguration globalConfiguration, 
            Assembly controllerAssembly)
        {
            _globalConfiguration = globalConfiguration;
            _controllerAssembly = controllerAssembly;
        }

        /// <summary>
        /// The install.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="store">
        /// The store.
        /// </param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<IHttpControllerSelector>()
                    .ImplementedBy<WindsorHttpControllerSelector>()
                    .DependsOn(new { controllerAssembly = _controllerAssembly }))

                .Register(Component.For<HttpConfiguration>().Instance(_globalConfiguration));
        }
    }
}
