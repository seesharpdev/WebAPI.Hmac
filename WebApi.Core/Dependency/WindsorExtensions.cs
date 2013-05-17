namespace WebApi.Core.Dependency
{
    using System.Reflection;

    using Castle.MicroKernel;

    /// <summary>
    /// The windsor extensions.
    /// </summary>
    public static class WindsorExtensions
    {
        /// <summary>
        /// The inject properties.
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        public static void InjectProperties(this IKernel kernel, object target)
        {
            var type = target.GetType();
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanWrite && kernel.HasComponent(property.PropertyType))
                {
                    var value = kernel.Resolve(property.PropertyType);
                    property.SetValue(target, value, null);
                }
            }
        }
    }
}
