using Newtonsoft.Json;
using System.Text;

namespace OrderManagementSystem.Common.General
{
    public class ApiService(HttpClient client)
    {
        //private static readonly HttpClient client = new HttpClient();
        public async Task<T> GetDataFromApiAsync<T>(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();

                T data = JsonConvert.DeserializeObject<T>(responseData);

                return data;
            }
            catch (HttpRequestException e)
            {
                return default;
            }
        }

        public async Task<TResponse> PostDataToApiAsync<TRequest, TResponse>(string apiUrl, TRequest data)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                TResponse result = JsonConvert.DeserializeObject<TResponse>(responseData);

                return result;
            }
            catch (HttpRequestException e)
            {
                return default;
            }
        }
    }
}
