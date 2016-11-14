using System;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace SDesk.SelfHost
{
    public class OwinService
    {
        private IDisposable _webApp;

        public void Start()
        {
            _webApp = WebApp.Start<StartOwin>(ConfigurationManager.AppSettings["HostAddress"]);
        }

        public void Stop()
        {
            _webApp.Dispose();
        }
    }
}
