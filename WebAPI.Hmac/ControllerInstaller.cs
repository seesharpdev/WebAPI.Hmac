namespace WebAPI.Hmac
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using WebApi.Core;

    using WebAPI.Hmac.Controllers;

    /// <summary>
    /// The controller installer.
    /// </summary>
    public class ControllerInstaller : IWindsorInstaller
    {
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
                .Register(Component.For<ValuesController>().LifestylePerWebRequest())
                .Register(Component.For<IAccountRepository>().ImplementedBy<AccountRepository>())
                .Register(Component.For<IValueService>().ImplementedBy<ValueService>());
        }
    }
}