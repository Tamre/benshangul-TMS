using Topshelf;

namespace MacAddressService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MacAddressService>(s =>
                {
                    s.ConstructUsing(name => new MacAddressService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("MacAddressService using Topshelf");
                x.SetDisplayName("MacAddressService");
                x.SetServiceName("MacAddressService");
            });
        }
    }
}
