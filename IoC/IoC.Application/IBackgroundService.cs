using System;
using IoC.Domain;

namespace IoC.Application
{
    public class BackgroundService : IBackgroundService
    { 
        public string Singletion()
        {
            var i = string.Format("单例:{0}", Guid.NewGuid());
            Console.WriteLine(i);
            return i;
        }
    }

    public interface IBackgroundService: ISingletonDenpency
    {
        string Singletion();
    }
}
