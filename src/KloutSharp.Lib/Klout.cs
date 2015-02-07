// Coded by Alex Danvy
// http://danvy.tv
// http://twitter.com/danvy
// http://github.com/danvy
// Licence Apache 2.0
// Use at your own risk, have fun

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KloutSharp.Lib
{
    public class Klout
    {
        private static string kloutUri = "http://api.klout.com/v2/";
        private static string kloutIdentityUri = kloutUri + "identity.json/";
        private string key;
        public Klout(string key)
        {
            this.key = key;
        }
        private void CheckKey()
        {
            if (string.IsNullOrEmpty(key))
                throw new KloutException("Klout key not set!");
        }
        private string UriAddKey(string uri)
        {
            return string.Format("{0}{2}key={1}", uri, key, uri.Contains("?") ? "&" : "?");
        }
        public async Task<KloutIdentity> IdentityAsync(string id, KloutIdentityKind kind = KloutIdentityKind.TwitterScreenName)
        {
            CheckKey();
            var parmeters = string.Empty;
            switch (kind)
            {
                case KloutIdentityKind.TwitterId:
                    {
                        parmeters = "tw/{0}";
                        break;
                    }
                case KloutIdentityKind.Google:
                    {
                        parmeters = "gp/{0}";
                        break;
                    }
                case KloutIdentityKind.Instagram:
                    {
                        parmeters = "ig/{0}";
                        break;
                    }
                case KloutIdentityKind.TwitterScreenName:
                    {
                        parmeters = "twitter?screenName={0}";
                        break;
                    }
                case KloutIdentityKind.KloutId:
                    {
                        parmeters = "klout/{0}/tw";
                        break;
                    }
            }
            var uri = UriAddKey(string.Format(kloutIdentityUri + parmeters, id));
            var client = new HttpClient();
            var res = await client.GetAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var identity = JsonConvert.DeserializeObject<KloutIdentity>(content);
                return identity;
            }
            else
            {
                throw new KloutException(res.StatusCode);
            }
        }
        public async Task<KloutIdentity> IdentityTwitterIdAsync(string id)
        {
            return await IdentityAsync(id, KloutIdentityKind.TwitterId);
        }
        public async Task<KloutIdentity> IdentityGoogle(string googleId)
        {
            return await IdentityAsync(googleId, KloutIdentityKind.Google);
        }
        public async Task<KloutIdentity> IdentityInstagram(string instagramId)
        {
            return await IdentityAsync(instagramId, KloutIdentityKind.Instagram);
        }
        public async Task<KloutIdentity> IdentityTwitterScreenName(string twitter)
        {
            return await IdentityAsync(twitter, KloutIdentityKind.Instagram);
        }
        public async Task<KloutIdentity> IdentityKlout(string kloutId)
        {
            return await IdentityAsync(kloutId, KloutIdentityKind.KloutId);
        }
        public async Task<KloutUser> UserAsync(string kloutId)
        {
            CheckKey();
            var uri = UriAddKey(string.Format(kloutUri + "user.json/{0}", kloutId));
            var client = new HttpClient();
            var res = await client.GetAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<KloutUser>(content);
                return user;
            }
            else
            {
                throw new KloutException(res.StatusCode);
            }
        }
        public async Task<KloutScore> ScoreAsync(string kloutId)
        {
            CheckKey();
            var uri = UriAddKey(string.Format(kloutUri + "user.json/{0}/score", kloutId));
            var client = new HttpClient();
            var res = await client.GetAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var score = JsonConvert.DeserializeObject<KloutScore>(content);
                return score;
            }
            else
            {
                throw new KloutException(res.StatusCode);
            }
        }
        public async Task<List<KloutTopic>> TopicsAsync(string kloutId)
        {
            CheckKey();
            var uri = UriAddKey(string.Format(kloutUri + "user.json/{0}/topics", kloutId));
            var client = new HttpClient();
            var res = await client.GetAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var topics = JsonConvert.DeserializeObject<List<KloutTopic>>(content);
                return topics;
            }
            else
            {
                throw new KloutException(res.StatusCode);
            }
        }
        public async Task<KloutInfluence> InfluenceAsync(string kloutId)
        {
            CheckKey();
            var uri = UriAddKey(string.Format(kloutUri + "user.json/{0}/influence", kloutId));
            var client = new HttpClient();
            var res = await client.GetAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var influence = JsonConvert.DeserializeObject<KloutInfluence>(content);
                return influence;
            }
            else
            {
                throw new KloutException(res.StatusCode);
            }
        }
    }
}
