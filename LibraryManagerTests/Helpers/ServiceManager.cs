using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace LibraryManagerTests.Helpers
{
    public static class ServiceManager
    {
        private static Process _serviceProcess;

        public static void StartService()
        {
            if (_serviceProcess != null && !_serviceProcess.HasExited)
                return; // already started

            var baseDir = AppContext.BaseDirectory;
            var servicePath = Path.Combine(baseDir, "LibraryManager.exe");

            if (!File.Exists(servicePath))
                throw new FileNotFoundException($"Could not find LibraryManager.exe at {servicePath}");

            _serviceProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = servicePath,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
            _serviceProcess.Start();
            Thread.Sleep(2500); // wait the chosen time for service to starts
        }

        public static void StopService()
        {
            try
            {
                if (_serviceProcess != null && !_serviceProcess.HasExited)
                {
                    _serviceProcess.Kill(true); 
                    _serviceProcess.WaitForExit();
                    _serviceProcess.Dispose();
                    _serviceProcess = null;
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}