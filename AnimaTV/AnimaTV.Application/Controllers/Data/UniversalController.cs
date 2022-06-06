using AnimaTV.Application.CoreSingleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnimaTV.Application.Controllers.Data
{
    public class UniversalController<T> where T: class
    {
        private protected string _url;

        public UniversalController()
        {
            _url = ServerSingleton.GetServerLink();
        }

        public async Task<T> Get()
        {
            if(await CheckServerAvailable())
            {
                using(HttpClient client = new())
                {
                    var stringTask = await client.GetAsync(_url);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result = await JsonSerializer.DeserializeAsync<T>(await stringTask.Content.ReadAsStreamAsync());

                        return result;
                    }

                    throw new NullReferenceException();
                }
            }

            throw new OperationCanceledException();
        }

        public async Task<bool> Post(T target)
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new())
                {
                    var jsonObject = JsonSerializer.Serialize<T>(target);

                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var stringTask = await client.PostAsync(_url, content);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result =
                            await JsonSerializer.DeserializeAsync<T>(await stringTask.Content.ReadAsStreamAsync());

                        return true;
                    }

                    return false;
                }
            }

            throw new OperationCanceledException();
        }

        public async Task<bool> Put(T target)
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new())
                {
                    var jsonObject = JsonSerializer.Serialize<T>(target);

                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var stringTask = await client.PostAsync(_url, content);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result =
                            await JsonSerializer.DeserializeAsync<T>(await stringTask.Content.ReadAsStreamAsync());

                        return true;
                    }

                    return false;
                }
            }

            throw new OperationCanceledException();
        }

        public async Task<bool> Delete(string id)
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new())
                {
                    var stringTask = await client.GetAsync(_url + "?id=" + id);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result = await JsonSerializer.DeserializeAsync<T>(await stringTask.Content.ReadAsStreamAsync());

                        return true;
                    }

                    return false;
                }
            }

            throw new OperationCanceledException();
        }

        private protected async Task<bool> CheckServerAvailable()
        {
            var request = WebRequest.Create(_url);
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)await request.GetResponseAsync();
                response.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
