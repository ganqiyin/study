using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TaskDemo.ConsoleApp.chapter1
{
    class ThreadSample2
    {
        private readonly int _iterations;
        public ThreadSample2(int iterations)
        {
            _iterations = iterations;
        }

        public void CountNumber()
        {
            for (var i = 0; i < _iterations; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                var name = Thread.CurrentThread.Name;
                if (string.IsNullOrEmpty(name))
                    name = Thread.CurrentThread.ManagedThreadId.ToString();
                Console.WriteLine($"线程{name} 打印 {i}");
            }
        }
    }
}
