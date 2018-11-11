using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace stock_libs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new HttpClient();

            var day = DateTime.Now.AddDays(-5);
            var timespan = TimeSpan.FromDays(5);

            var results = QueryTickerResult(client, "msft", day, timespan).Result;

            foreach (var result in results)
            {
                Console.WriteLine($"Timestamp: {result.Timestamp} - # Trades: {result.MarketAverage}");
            }

            Console.ReadLine();
        }

        public static async Task<IList<ChartResponse>> QueryTickerResult(HttpClient client, string ticker, DateTime startDate, TimeSpan? timespan = null)
        {
            var results = new List<ChartResponse>();
            var endDate = startDate.Add(timespan ?? new TimeSpan());

            do
            {
                var dayString = startDate.ToString("yyyyMMdd");
                startDate = startDate.AddDays(1);

                var endpoint = $"https://api.iextrading.com/1.0/stock/{ticker}/chart/date/{dayString}";

                try
                {
                    var response = await client.GetStringAsync(endpoint);

                    results.AddRange(JsonConvert.DeserializeObject<List<ChartResponse>>(response));
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"Exception encountered sending a GET request: {e.StackTrace}");

                    return Enumerable.Empty<ChartResponse>().ToList();
                }
            }
            while (startDate <= endDate);

            return results;
        }
    }
}
