using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Data;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive;

namespace OfferAPI
{
    public class DefaultActor
    {
        public DefaultActor(string uri)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(uri);
            listener.Start();
            Init(listener);
        }

        private static void Init(HttpListener listener)
        {
            var listenerFactory = Observable.FromAsyncPattern<HttpListenerContext>(listener.BeginGetContext, listener.EndGetContext);

            var observable = listenerFactory();
            
            var disposable = observable.Subscribe(i =>
            {
                i.Response.Close(Encoding.ASCII.GetBytes(DefaultController.Get(i.Request)), false);
                Init(listener);
            });
        }
    }
}
