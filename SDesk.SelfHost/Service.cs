using Topshelf;

namespace SDesk.SelfHost
{
    internal class Service
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<OwinService>(s =>
                {
                    s.ConstructUsing(() => new OwinService());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });
            });
        }
    }
}
