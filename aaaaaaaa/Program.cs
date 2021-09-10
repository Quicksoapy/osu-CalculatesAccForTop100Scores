using System;
using System.Net;
using Newtonsoft.Json;

namespace aaaaaaaa
{
    class Program
    {
        static void Main(string[] args)
        {
            float totalAcc = 0;
            float threehundreds = 0;
            float hundreds = 0;
            float fifties = 0;
            float misses = 0;
            Console.WriteLine("give your username: ");
            string username = Console.ReadLine();
            string json = new WebClient().DownloadString("https://osu.ppy.sh/api/get_user_best?u=" + username + "&limit=100&k=");
            
            
            dynamic response = JsonConvert.DeserializeObject(json);
            
            Console.WriteLine(response);
            foreach (var score in response)
            {
                
                threehundreds = score.count300;
                Console.WriteLine(threehundreds);
                hundreds = score.count100;
                Console.WriteLine(hundreds);
                fifties = score.count50;
                Console.WriteLine(fifties);
                misses = score.countmiss;
                Console.WriteLine(misses);
                totalAcc += ((threehundreds * 300 + hundreds * 100 + fifties * 50) /
                             (threehundreds + hundreds + fifties + misses)) / 3;
                Console.WriteLine(totalAcc);
            }
            
            Console.WriteLine("Your pp acc is: " + totalAcc/100);
            Console.WriteLine("Enter any key to continue...");
            Console.ReadLine();
        }
    }
}