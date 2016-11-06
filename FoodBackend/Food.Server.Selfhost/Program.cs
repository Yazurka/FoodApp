using Topshelf;

namespace Food.Server.Selfhost
{
    class Program
    {
        private static int Main()
        {

            return (int)HostFactory.Run(
                 host =>
                 {
                     host.Service<WebApplication>(
                         service =>
                         {
                             service.ConstructUsing(() => new WebApplication());
                             service.WhenStarted(s => s.Start());
                             service.WhenStopped(s => s.Stop());
                         });
                     host.RunAsLocalSystem();
                     host.SetServiceName("FoodServer");
                     host.SetDisplayName("FoodServer");
                     host.SetDescription("Food Web Server");
                 });
        }
    }
}
