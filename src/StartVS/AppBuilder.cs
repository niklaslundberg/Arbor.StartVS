using Arbor.KVConfiguration.Core;
using Arbor.KVConfiguration.SystemConfiguration;
using Autofac;

namespace StartVS
{
    public class AppBuilder
    {
        private static IContainer _container;

        public static App BuildApp()
        {
            KVConfigurationManager.Initialize(new AppSettingsKeyValueConfiguration());

            var builder = new ContainerBuilder();

            builder.RegisterType<App>().SingleInstance();
            builder.Register(context => VSConfigurationBuilder.Build(KVConfigurationManager.AppSettings))
                .As<VSConfiguration>().SingleInstance();

            _container = builder.Build();

            var buildApp = _container.Resolve<App>();

            return buildApp;
        }
    }
}