namespace Utilities
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HttpRequestHandler
    {
        public TResult HandleHttpRequest<TResult>(Task<HttpResponseMessage> response)
        {
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"{response.Result.RequestMessage.Method} {response.Result.RequestMessage.RequestUri} {(int)response.Result.StatusCode} ({response.Result.ReasonPhrase}) - {response.Result.Content.ReadAsAsync<TResult>().Result}");
            }

            var resultTask = response.Result.Content.ReadAsStringAsync();
            resultTask.Wait();
            Task<TResult> content = response.Result.Content.ReadAsAsync<TResult>();
            content.Wait();

            if (content.IsFaulted)
            {
                throw new HttpRequestException($"Status: '{content.Status}'; Result: '{content.Result}'", content.Exception);
            }

            return content.Result;
        }

        public string GetHttpRequestMsgAsString(Task<HttpResponseMessage> response)
        {
            var resultTask = response.Result.Content.ReadAsStringAsync();
            resultTask.Wait();
            string resultString = resultTask.Result;

            return resultString;
        }
    }
}
