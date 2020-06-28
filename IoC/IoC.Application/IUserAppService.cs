using System;
using System.Collections.Generic;
using System.Text;
using IoC.Domain;

namespace IoC.Application
{
    public class UserAppService : IUserAppService
    {
        public string Scoped()
        {
            var i = string.Format("Scoped:{0}", Guid.NewGuid());
            Console.WriteLine(i);
            return i;
        }
    }
    public interface IUserAppService: IScopedDenpency
    {
        string Scoped();
    }
}
