using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MacAddressService1
{
    public class MacAddressService
    {
        private HttpListener _listener;

        public void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:5000/");
            Task.Run(() => StartHttpListener());
        }

        public void Stop()
        {
            _listener.Stop();
            Console.WriteLine("HTTP listener stopped.");
        }

        private void StartHttpListener()
        {
            try
            {
                _listener.Start();
                Console.WriteLine("Listening for requests on http://localhost:5000/");
                while (_listener.IsListening)
                {
                    var context = _listener.GetContext();
                    ProcessRequest(context);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting HTTP listener: " + ex.Message);
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            try
            {
                HttpListenerResponse response = context.Response;

                // Add CORS headers
                response.AddHeader("Access-Control-Allow-Origin", "*");
                response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

                // Handle preflight requests
                if (context.Request.HttpMethod == "OPTIONS")
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Close();
                    return;
                }

                var details = new
                {
                    PCName = GetPCName(),
                    MacAddress = GetFormattedMacAddress(),
                    IPAddress = GetIPAddress()
                };

                string jsonResponse = JsonSerializer.Serialize(details);
                byte[] buffer = Encoding.UTF8.GetBytes(jsonResponse);

                response.ContentType = "application/json";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing request: " + ex.Message);
            }
        }

        private string GetPCName()
        {
            return Environment.MachineName;
        }

        private string GetFormattedMacAddress()
        {
            var macAddressBytes = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up)
                .Select(nic => nic.GetPhysicalAddress()?.GetAddressBytes())
                .FirstOrDefault();

            if (macAddressBytes != null && macAddressBytes.Length == 6)
            {
                return string.Join(":", macAddressBytes.Select(b => b.ToString("X2")));
            }
            else
            {
                return "Unknown";
            }
        }

        private string GetIPAddress()
        {
            var ipAddress = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            return ipAddress?.ToString() ?? "Unknown";
        }
    }
}
