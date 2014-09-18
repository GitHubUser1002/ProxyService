using Fiddler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyWindowsService
{
    /// <summary>
    /// To use this, start the service, and then point your browser proxy to 127.0.0.1
    /// The default port is 9999, but a user can pass a value
    /// </summary>
    public partial class ProxyWindowsService : ServiceBase
    {

        #region Global

        List<Session> _allSessions = new List<Session>();

        #endregion Glboal

        public ProxyWindowsService()
        {
            //System.Diagnostics.Debugger.Launch();
            InitializeComponent();
            Fiddler.FiddlerApplication.OnNotification += delegate(object sender, NotificationEventArgs oNEA)
            {
                // do some logging here 
            };

            Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session os)
            {
                //before request
                os.bBufferResponse = true;
                //fow now we're setting it to stream to the client 
                Monitor.Enter(_allSessions);
                _allSessions.Add(os);

                // we need to add some logic here to clear the sessions to ensure memory does not grow

                Monitor.Exit(_allSessions);
                os["X-AutoAuth"] = "(default)";
            };

            Fiddler.FiddlerApplication.AfterSessionComplete += delegate(Fiddler.Session os)
            {
                //after request
            };

            //ignore any errors
            Fiddler.CONFIG.IgnoreServerCertErrors = true;
            
        }

        protected override void OnStart(string[] args)
        {
            int port = 9999;
            if (args.Length > 0)
                int.TryParse(args[0], out port);
            FiddlerCoreStartupFlags defaultFlags = FiddlerCoreStartupFlags.Default;
            Fiddler.FiddlerApplication.Startup(port, defaultFlags);
        }

        protected override void OnStop()
        {
            Fiddler.FiddlerApplication.Shutdown();
        }


    }
}
