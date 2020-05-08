using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TaskDemo.ConsoleApp.chapter1
{
    class ThreadSample
    {
        private bool _isStopped = false;
        public void Stop() {
            _isStopped = true;
        }

        public void CountNumbers()
        {
            long counter = 0;
            while(!_isStopped)
            {
                counter++;
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} with {Thread.CurrentThread.Priority,11} priority has a count={counter,13:N0)}");
        }
    }
}
