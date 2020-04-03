using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建对象：一个document相当于一行记录
            var firstDoc = new BsonDocument {
                {"DepartmentName" ,"研发部门"},
                {"People",new BsonArray{
                  new BsonDocument
                  {
                      {"name","小周" },
                      {"age",30 }
                  },
                   new BsonDocument
                  {
                      {"name","老张" },
                      {"age",40 }
                  }, new BsonDocument
                  {
                      {"name","小王" },
                      {"age",20 }
                  }
                } }
            };
            var secondDoc = new BsonDocument {
                {"DepartmentName" ,"人事部门"},
                {"People",new BsonArray{
                  new BsonDocument
                  {
                      {"name","小周" },
                      {"age",30 }
                  },
                   new BsonDocument
                  {
                      {"name","老张" },
                      {"age",40 }
                  }, new BsonDocument
                  {
                      {"name","小王" },
                      {"age",20 }
                  }
                } }
            };
            var threeDco = new BsonDocument
            {
                {  "time",DateTime.Now.ToString()},
                {"name","花无缺" },
                {"age",100 },
                {"class","高一(2)班" },
                {"语文",100 },
                {"数学",30 }
            }; 
            //连接数据库
            var client = new MongoClient("mongodb://192.168.1.193:27017");
            var database = client.GetDatabase("demo");
            //得到集合，没有则自动创建（相当于表）
            var collection = database.GetCollection<BsonDocument>("test");
            //添加数据
            collection.InsertOne(firstDoc);
            collection.InsertOne(secondDoc);
            collection.InsertOne(threeDco);
            Console.Read();
        }


    }
}
