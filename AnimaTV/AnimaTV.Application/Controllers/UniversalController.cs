using AnimaTV.Application.CoreSingleton;
using AnimaTV.Persistance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnimaTV.Application.Controllers
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
                using(HttpClient client = new HttpClient())
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

        public async Task<bool> Post()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Put()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create()
        {
            throw new NotImplementedException();
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}
