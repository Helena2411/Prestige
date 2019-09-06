using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prestige.RoyalRent.Client.Business.Models;

namespace Prestige.RoyalRent.Client.Console
{
    public class RoyalRentHttpClient
    {
        private readonly HttpClient _httpClient; 

        public RoyalRentHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAllCustomers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44325/api/customers");
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }
        public async Task<string> GetAllCars()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44325/api/cars");
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCustomerById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44325/api/customers/" + id);
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAvailableCars(int customerId, bool book)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44325/api/cars/?customerId={customerId}&book={book}");
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }

        public async Task<string> RefundCar(int carId)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:44325/api/cars/" + carId);
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }

        public async Task<string> OccupyCar(int carId, int customerId)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:44325/api/cars/?carId={carId}&customerId={customerId}");
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCar(Car car)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44325/api/cars/")
            {
                Content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json")
            };
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }
        public async Task<string> GetCustomer(Customer customer)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44325/api/customers/")
            {
                Content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json")
            };
            return await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
        }
    }
}
