using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDemo.ConsoleApp.chapter1
{
    static class LockSample
    {
        public static void TestCounter(CounterBase c)
        { 
           for(var i=0;i<10000;i++)
            {
                c.Increment();
                c.Decrement();
            }
        }
    }

    class Counter : CounterBase
    {


        public int Count { get; private set; }

        public override void Decrement()
        {
            Count--;
        }

        public override void Increment()
        {
            Count++;
        }
    }
    class CounterWithLock : CounterBase
    {
        private readonly object _syncRoot = new object();

        public int Count { get; private set; }

        public override void Decrement()
        {
            lock (_syncRoot)
            {
                Count--;
            }
        }

        public override void Increment()
        {
            lock (_syncRoot)
            {
                Count++;
            }
        }
    }

    abstract class CounterBase
    {
        public abstract void Increment();

        public abstract void Decrement();
    }
}
