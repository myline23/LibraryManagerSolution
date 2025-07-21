using Reqnroll;
using LibraryManagerTests.Helpers;

namespace LibraryManagerTests.Steps
{
    [Binding]
    public sealed class ServiceStepDefinitions
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ServiceManager.StartService();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ServiceManager.StopService();
        }

        [Given("the service is started")]
        public void GivenTheServiceIsStarted()
        {            
            ServiceManager.StartService();
        }
    }
}