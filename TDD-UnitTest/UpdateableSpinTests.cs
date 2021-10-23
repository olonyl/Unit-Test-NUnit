using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD_UnitTest
{
    public class UpdateableSpinTests
    {
        [Test]
        public void Wait_NoPulse_ReturnsFalse()
        {
            UpdateableSpin spin = new UpdateableSpin();
            bool wasPulsed = spin.Wait(TimeSpan.FromMilliseconds(10));
            Assert.IsFalse(wasPulsed);
        }

        [Test]
        public void Wait_Pulse_ReturnsTrue()
        {
            UpdateableSpin spin = new UpdateableSpin();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                spin.Set();
            });
            bool wasPulsed = spin.Wait(TimeSpan.FromSeconds(10));
            Assert.IsTrue(wasPulsed);
        }

        [Test]
        public void Wait_50Millisec_ActuallyWaitingFor50Millisec()
        {
            var spin = new UpdateableSpin();
            
            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            spin.Wait(TimeSpan.FromMilliseconds(50));

            watcher.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            TimeSpan leftEpsilon = TimeSpan.FromMilliseconds(50 - (100 * 0.1));
            TimeSpan rightEpsilon = TimeSpan.FromMilliseconds(50 + (100 * 0.1));

            Assert.IsTrue(actual > leftEpsilon && actual < rightEpsilon);

        }
        [Test]
        public void Wait500Mililisec_UpdateAfter300Millisec_totalWaitingIsApprox800Millisec()
        {
            var spin = new UpdateableSpin();

            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            const int timeout = 500;
            const int spanBeforeUpdate = 300;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(timeout);
                spin.UpdateTimeout();
            });

            spin.Wait(TimeSpan.FromMilliseconds(timeout));
            watcher.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            const int expected = timeout + spanBeforeUpdate;
            
            TimeSpan left = TimeSpan.FromMilliseconds(expected - (expected+100 * 0.1));
            TimeSpan right = TimeSpan.FromMilliseconds(expected + (expected+100 * 0.1));

            Assert.IsTrue(actual > left && actual < right);
        }
    }

  

    internal class UpdateableSpin
    {
        private readonly Object lockObj = new Object();
        private bool shouldWait = true;
        private long executionStartingTime;

        internal bool Wait(TimeSpan timeout, int spintDuration = 0)
        {
            UpdateTimeout();
            while (true)
            {
                lock (lockObj)
                {
                    if (!shouldWait)
                        return true;
                    if (DateTime.UtcNow.Ticks - executionStartingTime > timeout.Ticks)
                        return false;
                }
                Thread.Sleep(spintDuration);
            }
        }

        internal void Set()
        {
            lock (lockObj)
            {
                shouldWait = false;
            }
        }

        internal void UpdateTimeout()
        {
            lock (lockObj)
            {
                executionStartingTime = DateTime.UtcNow.Ticks;
            }
        }              
    }
}
