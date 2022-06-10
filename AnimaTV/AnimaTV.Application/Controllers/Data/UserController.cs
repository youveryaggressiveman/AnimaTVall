using AnimaTV.Application.CoreSingleton;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AnimaTV.Application.Model;

namespace AnimaTV.Application.Controllers.Data
{
    public class UserController : UniversalController<User>
    {
        public async Task<User> GetUserByTokenAsync()
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new())
                {
                    var stringTask = await client.GetAsync(_url + "/Users/getUserByToken?token=" + TokenSingleton.Token);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result = await JsonSerializer.DeserializeAsync<User>(await stringTask.Content.ReadAsStreamAsync());

                        return result;
                    }

                    throw new NullReferenceException();
                }
            }

            throw new OperationCanceledException();
        }

        public async Task<bool> Authorize(User user)
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new())
                {
                    var jsonObject = JsonSerializer.Serialize<User>(user);
                    var url = "https://localhost:44367/api/Users/auth?login=" + user.NickName + "&password=" + user.Password;

                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    var stringTask = await client.PostAsync(url, content);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result =
                            await JsonSerializer.DeserializeAsync<string>(await stringTask.Content.ReadAsStreamAsync());

                       TokenSingleton.Token = result;

                       return true;
                    }

                    return false;
                }
            }

            throw new OperationCanceledException();
        }

        public async Task<bool> Registration(User user)
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new())
                {
                    var jsonObject = JsonSerializer.Serialize<User>(user);

                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var stringTask = await client.PostAsync(_url, content);

                    if (stringTask.IsSuccessStatusCode)
                    {
                        var result =
                            await JsonSerializer.DeserializeAsync<string>(await stringTask.Content.ReadAsStreamAsync());

                        TokenSingleton.Token = result;

                        return true;
                    }

                    return false;
                }
            }

            throw new OperationCanceledException();
        }

        public async Task<bool> UpdateInfoAboutUser(User user, Address address)
        {
            if (await CheckServerAvailable())
            {
                using (HttpClient client = new())
                {
                    using (MultipartFormDataContent arrayObject = new())
                    {
                        arrayObject.Add(new StringContent(JsonSerializer.Serialize<User>(user), Encoding.UTF8, "application/json"));
                        arrayObject.Add(new StringContent(JsonSerializer.Serialize<Address>(address), Encoding.UTF8, "application/json"));

                        arrayObject.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var stringTask = await client.PutAsync(_url, arrayObject);

                        if (stringTask.IsSuccessStatusCode)
                        {
                            var result =
                                await JsonSerializer.DeserializeAsync<string>(
                                    await stringTask.Content.ReadAsStreamAsync());

                            TokenSingleton.Token = result;

                            return true;
                        }

                        return false;
                    }
                }
            }

            throw new OperationCanceledException();
        }
    }
}
