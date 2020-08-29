using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Models.DBEntities;
using Newtonsoft.Json;

namespace FurryFit.Services
{
    public class RemoteServices
    {
        private static string _apiBaseUrl = "http://127.0.0.1:5000/api/v1/";
        public async Task<User> CreateUser(User user)
        {
            string apiPath = _apiBaseUrl + $"users";
            try
            {
                user.IsActive = true;
                user.IsVerified = true;
                user.RegisteredDateTime = DateTime.Now;
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Authorization()
                //httpClient.DefaultRequestHeaders.Authorization =
                //    new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkdCI6IjIwMjAtMDgtMDlUMTc6NDg6MjJaIiwibmJmIjoxNTk2OTk1MzAyLCJleHAiOjE1OTk2NzM3MDIsImlhdCI6MTU5Njk5NTMwMn0.ZYiTAR7cCzmTF9Rhw8x7GV5sxplwdvWHXqPYqTmmKJw");
                //var response = await httpClient.GetStringAsync(apiPath);
                string jsonInString = JsonConvert.SerializeObject(user);
                httpClient.DefaultRequestHeaders.Add("accept","application/json");
                var response =await httpClient.PostAsync(apiPath, new StringContent(jsonInString, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Created)
                {

                    var result = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    return result;
                }
                else
                {
                    return new User();
                }

                //Barrel.Current.Add(apiUrl, result, TimeSpan.FromDays(25));

                //if (result.match_details.Count > 0)
                //    return result.match_details[0];
                //else
                //    return new MatchDetail();
            }
            catch (Exception ex)
            {
                return new User();
                //MatchDetails retObj = Barrel.Current.Get<MatchDetails>(apiUrl);
                //if (retObj != null)
                //    return retObj.match_details[0];
                //else
                //    return null;
            }
        }
    }
}
