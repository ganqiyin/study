using System;
using System.Collections.Generic;
using System.Text;
using IoC.Domain;

namespace IoC.Application
{
    public class TService : ITService
    {
        public string Traint()
        {
            var i = string.Format("T:{0}", Guid.NewGuid());
            Console.WriteLine(i);
            return i;
        }
    }
    public interface ITService: ITraintDenpency
    {
        string Traint();
    }
}
