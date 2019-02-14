using Refit;
using System;
using System.Threading.Tasks;

namespace WebApiTester
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = RestService.For<ILabManagement>("http://smartdeploy:5000");

            foreach(var item in await client.GetReportItemsAsync())
            {
                Console.WriteLine($"{item.HostName} @ {item.ReportTime}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now put in a name and we can add it");
            var hostName = Console.ReadLine();

            var newItem = new ReportItem { HostName = hostName };

            Console.WriteLine($"Adding new {newItem.HostName} item...");
            var committedItem = await client.AddReportItemAsync(newItem);

            Console.WriteLine($"ID for new {newItem.HostName} item: {committedItem.Id}");


            Console.WriteLine("Enter an ID of an item you'd like to retrieve");
            var requestedId = int.Parse(Console.ReadLine());
            var requestedItem = await client.GetReportItemAsync(requestedId);

            Console.WriteLine($"You requested {requestedItem.Id} @ {requestedItem.ReportTime} for {requestedItem.HostName}");

            Console.WriteLine("Enter a new value for the image version content");
            var newImageVersionContent = Console.ReadLine();

            requestedItem.ImageVersionContent = newImageVersionContent;
            var success = await client.UpdateReportItemAsync(requestedId, requestedItem);
            Console.WriteLine($"Update success? {success}");


            Console.WriteLine("All done.");
            Console.ReadLine();
        }
    }
}
