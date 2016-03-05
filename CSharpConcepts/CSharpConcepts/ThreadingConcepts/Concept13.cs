using System;
using CSharpConcepts.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Instead of blocking thread until the I/O operation finishes , Task object represents the results of asynchronous operation
    /// By setting the continuation on this tasks , we can continue untill taks is done and thread is available for other tasks
    /// When I/O operation finishes Windows notifies the runtime and continuation task is scheduled on thread pool
    /// As writing asynchornous is not easy C# 5.0 introduced async and await
    /// By Applying async keyword we signal compiler that asynchronous is going to happen and it converts code into state machine
    /// </summary>
    internal class Concept13 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Instead of blocking thread until the I/O operation finishes , Task object represents the results of asynchronous operation");
            Console.WriteLine("By setting the continuation on this tasks , we can continue untill taks is done and thread is available for other tasks");
            Console.WriteLine("When I/O operation finishes Windows notifies the runtime and continuation task is scheduled on thread pool");
            Console.WriteLine("As writing asynchornous is not easy C# 5.0 introduced async and await");
            Console.WriteLine("By Applying async keyword we signal compiler that asynchronous is going to happen and it converts code into state machine");
        }

        public void MainMethod()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
        }

        public static async Task<string>  DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}