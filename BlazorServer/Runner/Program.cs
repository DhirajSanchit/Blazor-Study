using System;
using System.Diagnostics;
//using GetAllTestData.Classes;

namespace Runner
{
    class Program
    {
        
        // public static IConfigurationRoot _configuration;
        
        
        
        /*
         * Purpose : Code below is only to be used to for Testing, Debugging and Proof of Concept purposes.
         * For Example: Direct printing of date shows how is to be formatted and printed;
         */
         
        
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(DateTime.Now);

            // Initialize();
            // string cns = _configuration.GetConnectionString("SQLServer");
            // GetTestData();
        }

 


        // static void GetTestData()
        // {
        //     //arrange
        //     var repository =  CreateTestRepo();
        //
        //     //act
        //     var data = repository.GetAll();
        //
        //     //assert
        //     Console.WriteLine($"Count: {data.Count}");
        //     Debug.Assert(data.Count == 3);
        //     data.Output();
        //
        // }
        //
        //
        // private static void Initialize()
        // {
        //     var builder = new ConfigurationBuilder()
        //         .AddJsonFile("/Users/graciousmacbook/RiderProjects/HAMmer/Hammer/Hammer/appsettings.json", optional: true, reloadOnChange: true);
        //
        //     var appsettings = _configuration.GetConnectionString("SQLServer");
        //     _configuration = builder.Build();
        // }
 
    }
 

    internal interface IConfigurationRoot
    {
    }
}