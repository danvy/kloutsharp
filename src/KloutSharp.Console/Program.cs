// Coded by Alex Danvy
// http://danvy.tv
// http://twitter.com/danvy
// http://github.com/danvy
// Licence Apache 2.0
// Use at your own risk, have fun

using KloutSharp.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloutSharp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.ReadKey();
        }
        static async Task MainAsync(string[] args)
        {
            var key = "Put your Klout API key here";
            var k = new Klout(key);
            var twitterId = "danvy";
            Console.WriteLine("KloutSharp by @danvy");
            var identity = await k.IdentityAsync(twitterId);
            Console.WriteLine(string.Format("KloutId for TwitterId '{0}'={1}", twitterId, identity.Id));
            var user = await k.UserAsync(identity.Id);
            Console.WriteLine(string.Format("Klout user nick={0} score={1}", user.Nick, user.Score.Score));
            var score = await k.ScoreAsync(identity.Id);
            Console.WriteLine(string.Format("Klout score={0}, bucket={1}", score.Score, score.Bucket));
            var topics = await k.TopicsAsync(identity.Id);
            Console.WriteLine("Topics");
            foreach (var topic in topics)
            {
                Console.WriteLine(string.Format("- {0}", topic.DisplayName));
            }
            var influence = await k.InfluenceAsync(identity.Id);
            Console.WriteLine("Influencers");
            foreach (var influencer in influence.Influencers)
            {
                Console.WriteLine(string.Format("- {0} ({1})", influencer.Entity.Payload.Nick, influencer.Entity.Payload.Score.Score));
            }
            Console.WriteLine("Influencees");
            foreach (var influencee in influence.Influencees)
            {
                Console.WriteLine(string.Format("- {0} ({1})", influencee.Entity.Payload.Nick, influencee.Entity.Payload.Score.Score));
            }
        }
    }
}
