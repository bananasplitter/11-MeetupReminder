using CSharp.Meetup.Connect;
using MeetupRemind.core.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spring.Social.OAuth1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupRemind.core.Service
{
    public class MeetupService
    {
        private const string MeetupApiKey = "kkp4ido5o45g43hch7i1357cki";
        private const string MeetupSecKey = "5v5vfik6ceefakiano4n8j2s31";

        private static async Task<OAuthToken> aunthenticate()
        {
            var meetupServiceProvider = new MeetupServiceProvider(MeetupApiKey, MeetupSecKey);

            var oauthToken = meetupServiceProvider.OAuthOperations.FetchRequestTokenAsync("oob", null).Result;

            var authenticateUrl = meetupServiceProvider.OAuthOperations.BuildAuthenticateUrl(oauthToken.Value, null);

            Process.Start(authenticateUrl);

            Console.WriteLine("Enter the pin from the meetup.com");
            string pin = Console.ReadLine();

            var requestToken = new AuthorizedRequestToken(oauthToken, pin);
            var oauthAccessToken = meetupServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;

            return oauthAccessToken;

        }


        public static async Task<List<MeetUpList>> GetMeetupsFor(string meetupGroupName)
        {

            List<MeetUpList> list = new List<MeetUpList>();

            var token = await aunthenticate();

            var meetupServiceProvider = new MeetupServiceProvider(MeetupApiKey, MeetupSecKey);


            var meetup = meetupServiceProvider.GetApi(token.Value, token.Secret);


            string json = await meetup.RestOperations.GetForObjectAsync<string>($"https://api.meetup.com/2/events?group_urlname={meetupGroupName}");

            var oEvents = JObject.Parse(json)["results"];

            foreach (var oEvent in oEvents)
            {
                var mappedObject = JsonConvert.DeserializeObject<MeetUpList>(oEvent.ToString());

                list.Add(mappedObject);
            }

            return list;

        }
    }
}

