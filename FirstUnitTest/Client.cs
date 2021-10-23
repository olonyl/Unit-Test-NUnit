using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Client
    {
        private readonly UpdateableSpin spin;
        private readonly Processor processor;
        private readonly double maxTimeoutToWait;
        private readonly object timeout;

        public Client()
        {
            processor = new Processor();
            processor.ResponseReceived += response =>
            {
                spin.UpdateTimeOut();
                Console.Write(response);
            };
            processor.ProcessingFinished += () => spin.Set();
            spin = new UpdateableSpin(shouldWait: true);
        }
        public void Do()
        {
            processor.StartAsyncExchange(timeout);
            if (!spin.Wait(TimeSpan.FromSeconds(maxTimeoutToWait)))
            {
                Console.WriteLine("Time out!");
            }
            else
            {
                Console.WriteLine("Finished in time.");
            }
        }
    }

    internal class Processor
    {
        internal Action<object> ResponseReceived;
        internal Func<object> ProcessingFinished;

        internal void StartAsyncExchange(object timeout)
        {
            throw new NotImplementedException();
        }
    }

    internal class UpdateableSpin
    {
        private bool shouldWait;

        public UpdateableSpin(bool shouldWait)
        {
            this.shouldWait = shouldWait;
        }

        internal object Set()
        {
            throw new NotImplementedException();
        }

        internal void UpdateTimeOut()
        {
            //throw new NotImplementedException();
        }

        internal bool Wait(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }
    }
}
