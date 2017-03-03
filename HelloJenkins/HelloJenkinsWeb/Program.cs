using System;
using System.Net;
using System.Threading;
using System.Text;

namespace HelloJenkinsWeb
{
    public class WebServer
    {
        private const string server_addr = "http://*:8090/";
        private readonly HttpListener _listener = new HttpListener();

        public WebServer()
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException("Needs Windows XP SP2, Server 2003 or later.");

            _listener.Prefixes.Add(server_addr);
            Console.WriteLine("Actively listening on server: {0}", server_addr);
        }

        public void Start()
        {
            _listener.Start();
            for (;;)
            {
                HttpListenerContext ctx = _listener.GetContext();
                new Thread(new Worker(ctx).ProcessRequest).Start();
            }
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }

        static public void Main()
        {
            WebServer webServer = new WebServer();
            webServer.Start();
        }
    }

    public class Worker
    {
        private HttpListenerContext context;

        public Worker(HttpListenerContext context)
        {
            this.context = context;
        }

        public void ProcessRequest()
        {
            Console.WriteLine("Processing incomming request...");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<html><body><h1>Hello Mohan!!</h1><p>It is now {0} {1} on the server</body></html>", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());

            byte[] b = Encoding.UTF8.GetBytes(sb.ToString());
            context.Response.ContentLength64 = b.Length;
            context.Response.OutputStream.Write(b, 0, b.Length);
            context.Response.OutputStream.Close();
        }
    }
}
