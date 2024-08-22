namespace HttpClientApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHttpClientHandler client = new HttpClientHandler();
            await client.ExecuteRequestsAsync();
        }
    }
}
