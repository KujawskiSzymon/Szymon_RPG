using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Szymon_RPG.Models;

namespace Szymon_RPG.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password"; 
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded'"));


        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Login));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var weburl = Constants.LoginUrl;
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponse<Token>(weburl,content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.ExpireDate = dt.AddSeconds(response.expire_in);
            return response;
        }

        public async Task<T> PostResponse<T>(string weburl,FormUrlEncodedContent content) where T : class
        {
            try
            {
                var response = await client.PostAsync(weburl, content);
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
                return responseObject;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
            return null;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonString) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
            try
            {
                var result = await client.PostAsync(weburl, new StringContent(jsonString, Encoding.UTF8, ContentType));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   
                    var jsonResult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
                
            }catch { return null; }
            return null;
            


        }

        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
            
            try
            {
                var response = await client.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }

            }
            catch { return null; }
            return null;
        }
    }
}
