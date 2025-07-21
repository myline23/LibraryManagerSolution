using RestSharp;

namespace LibraryManagerTests.Helpers
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient()
        {
            _client = new RestClient("http://localhost:9000/api");
        }

        public RestClient Client => _client;
    }
}