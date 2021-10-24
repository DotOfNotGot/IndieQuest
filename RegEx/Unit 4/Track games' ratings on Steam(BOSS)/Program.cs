using System;
using System.Net.Http;
using System.Text.RegularExpressions;
namespace Track_games__ratings_on_Steam_BOSS_
{
    class Program
    {
        static void Main(string[] args)
        {

            var httpClient = new HttpClient();
            string[] links = { @"https://store.steampowered.com/app/367520/Hollow_Knight/", @"https://store.steampowered.com/app/346110/ARK_Survival_Evolved/", @"https://store.steampowered.com/app/1163550/Captain_Tsubasa_Rise_of_New_Champions/" };

            foreach (string link in links)
            {
                ReviewScore(httpClient.GetStringAsync(link).Result);
            }



            static void ReviewScore(string htmlCode)
            {
                string reviewMatch = @"<span class=""(game_review_summary) (positive|negative|mixed)"" itemprop=""description"">((Overwhelmingly|Mostly|Very)? ?(Positive|Negative|Mixed))<\/span>";
                string findName = @"<span itemprop=""name"">(.+)\b<";
                     Match result = Regex.Match(htmlCode, reviewMatch);
                Match name = Regex.Match(htmlCode, findName);
                Console.WriteLine($"The rating for the game {name.Groups[1].Value} is {result.Groups[3].Value}.");
            }

        }
    }
}
