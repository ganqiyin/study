using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TaskDemo.ConsoleApp.chapter1
{
    class MonitorSample
    {
        public static void LockTooMuch(object lock1, object lock2)
        { 
            lock(lock1)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                lock (lock2) {
                }
            }
        }
    }
}
