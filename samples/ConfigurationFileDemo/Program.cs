using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
namespace ConfigurationFileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configurationRoot = builder.Build();
            //Console.WriteLine($"Key1:{configurationRoot["KEY1"]}");
            //Console.WriteLine($"Key2:{configurationRoot["KEY2"]}");
            //Console.WriteLine($"Key3:{configurationRoot["KEY3"]}");

            //Console.ReadKey();
            //Console.WriteLine($"Key1:{configurationRoot["KEY1"]}");
            //Console.WriteLine($"Key2:{configurationRoot["KEY2"]}");
            //Console.WriteLine($"Key3:{configurationRoot["KEY3"]}");


            #region 代码监视变更


            // IChangeToken token = configurationRoot.GetReloadToken();

            // token.RegisterChangeCallback(state =>
            //{
            //    Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            //    Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            //    Console.WriteLine($"Key3:{configurationRoot["Key3"]}");
            //}, configurationRoot);
            // Console.WriteLine("开始了");


            //ChangeToken.OnChange(() => configurationRoot.GetReloadToken(), () =>
            //{
            //    Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            //    Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            //    Console.WriteLine($"Key3:{configurationRoot["Key3"]}");
            //});
            //Console.WriteLine("开始了");

            //Console.ReadKey();

            #endregion

            #region 绑定到强类型对象
            var config = new Config()
            {
                Key1 = "config key1",
                Key5 = false,
            };
            configurationRoot.GetSection("OrderService").Bind(config,
                binderOptions => { binderOptions.BindNonPublicProperties = true; });

            Console.WriteLine($"Key1:{config.Key1}");
            Console.WriteLine($"Key5:{config.Key5}");
            Console.WriteLine($"Key6:{config.Key6}");

           
            #endregion
            Console.ReadKey();
        }

        class Config
        {
            public string Key1 { get; set; }
            public bool Key5 { get; set; }
            public int Key6 { get; private set; } = 100;
        }


    }
}
