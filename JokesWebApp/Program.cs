using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace JokesWebApp
{
    public class Program
    {
        static MySqlConnection con;

        public static void Connect(string user, string password)
        {
            con = new MySqlConnection();

            try
            {
                con.ConnectionString = "server = localhost:3306; User Id = " + user + "; " +
                    "Persist Security Info = True; database = initialSetup; Password = " + password;
                con.Open();
                Console.WriteLine("Succesfully connected!");

            }

            catch (Exception e)
            {
                Console.WriteLine("Not Successful! due to " + e.ToString());
            }
        }
       
            public static void Main(string[] args)
            {
                Connect("root", "password");
                con.Close();
                CreateHostBuilder(args).Build().Run();


        }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        }
    }




// OG Files
//namespace JokesWebApp
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}
