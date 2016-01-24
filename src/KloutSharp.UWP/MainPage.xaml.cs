using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using KloutSharp.Lib;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KloutSharp.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            var key = "Put your Klout API key here";
            var k = new Klout(key);
            var twitterId = "danvy";
            sb.AppendLine("KloutSharp by @danvy");
            var identity = await k.IdentityAsync(twitterId);
            sb.AppendLine(string.Format("KloutId for TwitterId '{0}'={1}", twitterId, identity.Id));
            var user = await k.UserAsync(identity.Id);
            sb.AppendLine(string.Format("Klout user nick={0} score={1}", user.Nick, user.Score.Score));
            var score = await k.ScoreAsync(identity.Id);
            sb.AppendLine(string.Format("Klout score={0}, bucket={1}", score.Score, score.Bucket));
            var topics = await k.TopicsAsync(identity.Id);
            sb.AppendLine("Topics");
            foreach (var topic in topics)
            {
                sb.AppendLine(string.Format("- {0}", topic.DisplayName));
            }
            var influence = await k.InfluenceAsync(identity.Id);
            sb.AppendLine("Influencers");
            foreach (var influencer in influence.Influencers)
            {
                sb.AppendLine(string.Format("- {0} ({1})", influencer.Entity.Payload.Nick, influencer.Entity.Payload.Score.Score));
            }
            sb.AppendLine("Influencees");
            foreach (var influencee in influence.Influencees)
            {
                sb.AppendLine(string.Format("- {0} ({1})", influencee.Entity.Payload.Nick, influencee.Entity.Payload.Score.Score));
            }
            LogBlock.Text = sb.ToString();
        }
    }
}
