using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace TaskDemo.ConsoleApp.chapter1
{
    public static class Print
    {
        /// <summary>
        /// 创建线程
        /// </summary>
        public static void NewThread()
        {
            var t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
        }

        /// <summary>
        /// 休眠线程
        /// </summary>
        public static void NewThreadWithDelay()
        {
            var t = new Thread(PrintNumbersWithDelay);
            t.Start();
            PrintNumbers();
        }

        /// <summary>
        /// 等待线程
        /// </summary>
        public static void NewThreadWithWait()
        {
            var t = new Thread(PrintNumbersWithDelay);
            t.Start();
            t.Join();
            Console.WriteLine($"线程{t.ManagedThreadId}执行完成");
            PrintNumbers();
        }


        /// <summary>
        /// 终止线程
        /// </summary>
        public static void NewThreadWithStop()
        {
            var t = new Thread(PrintNumbersWithDelay);
            t.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t.Abort();
            Console.WriteLine($"线程{t.ManagedThreadId}已被Aborted");
            t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
        }

        /// <summary>
        /// 检查线程
        /// </summary>
        public static void NewThreadWithCheck()
        {
            var t = new Thread(PrintNumbersWithStatus);
            var t2 = new Thread(DoNoThing);
            Console.WriteLine($" 线程{t.ManagedThreadId}的状态是{t.ThreadState.ToString()}");
            t2.Start();
            t.Start();
            for (var i = 1; i < 30; i++)
            {
                Console.WriteLine($" 线程{t.ManagedThreadId}的状态是{t.ThreadState.ToString()}");
            }
            Thread.Sleep(TimeSpan.FromSeconds(6));
            //t.Abort();
            Console.WriteLine($" 线程{t2.ManagedThreadId}的状态是{t2.ThreadState.ToString()}");
            Console.WriteLine($" 线程{t.ManagedThreadId}的状态是{t.ThreadState.ToString()}");
        }
        /// <summary>
        /// 线程优先级
        /// </summary>
        public static void NewThreadWithPriority()
        {
            Console.WriteLine($" 当前线程的优先级是{Thread.CurrentThread.Priority}");
            RunThreads();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine($" 只跑CPU一个核心是{Thread.CurrentThread.Priority}");
            //限制使用一个CPU核心
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();
        }

        /// <summary>
        /// 线程优先级
        /// </summary>
        private static void RunThreads()
        {
            var sample = new ThreadSample();
            var thread1 = new Thread(sample.CountNumbers)
            {
                Name = "线程1",
                Priority = ThreadPriority.Highest
            };
            var thread2 = new Thread(sample.CountNumbers)
            {
                Name = "线程2", 
                Priority = ThreadPriority.Lowest
            };
            thread1.Start();
            thread2.Start();
            //
            Thread.Sleep(TimeSpan.FromSeconds(2));
            sample.Stop();
        }

        private static void DoNoThing()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        private static void PrintNumbersWithStatus()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"PrintNumbersWithStatus 线程{threadId}启动中..."); 
            Console.WriteLine($" 线程{threadId}的状态是{Thread.CurrentThread.ThreadState.ToString()}");
            for (var i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine($"线程{threadId}:{i}");
            }
        }

        private static void PrintNumbersWithDelay()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"PrintNumbersWithDelay 线程{threadId}启动中...");
            for (var i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine($"线程{threadId}:{i}");
            }
        }

        private static void PrintNumbers()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"PrintNumbers 线程{threadId}启动中...");
            for (var i = 1; i < 10; i++)
            {
                Console.WriteLine($"线程{threadId}:{i}");
            }
        }
    }
}
