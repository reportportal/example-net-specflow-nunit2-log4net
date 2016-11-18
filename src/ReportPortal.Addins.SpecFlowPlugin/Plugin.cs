using BoDi;
using ReportPortal.Addins.SpecFlowPlugin;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;

[assembly: RuntimePlugin(typeof(Plugin))]
namespace ReportPortal.Addins.SpecFlowPlugin
{
    /// <summary>
    /// Registered SpecFlow plugin from configuration file.
    /// </summary>
    public class Plugin: IRuntimePlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {
            if (Configuration.ReportPortal.Enabled)
            {
                container.RegisterTypeAs<ReportPortalAddin, ITestTracer>();
            }
        }

        public void RegisterConfigurationDefaults(RuntimeConfiguration runtimeConfiguration)
        {

        }

        public void RegisterCustomizations(ObjectContainer container, RuntimeConfiguration runtimeConfiguration)
        {

        }
    }
}
