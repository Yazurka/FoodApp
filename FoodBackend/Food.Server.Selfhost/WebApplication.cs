using System;
using Food.Server.WebApi;
using Microsoft.Owin.Hosting;


namespace Food.Server.Selfhost
{
    public class WebApplication
    {
        private IDisposable m_application;

        public void Start()
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add("http://localhost:8080"); // 10.0.110.190
            m_application = WebApp.Start<Startup>(startOptions);
        }

        public void Stop()
        {
            m_application.Dispose();
        }
    }
}
