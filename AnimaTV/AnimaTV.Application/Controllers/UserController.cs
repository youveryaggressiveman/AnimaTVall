using AnimaTV.Application.CoreSingleton;
using AnimaTV.Persistance.Entity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnimaTV.Application.Controllers
{
    public class UserController : UniversalController<User>
    {
        public async Task<bool> GetUserByTokenAsync()
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new HttpClient())
                {
                    var stringTask = await client.GetAsync(_url + "/Users/getUserByToken?token=" + TokenSingleton.Token);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result = await JsonSerializer.DeserializeAsync<User>(await stringTask.Content.ReadAsStreamAsync());

                        try
                        {
                            
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                    throw new NullReferenceException();
                }
            }

            throw new OperationCanceledException();
        }
    }
}
