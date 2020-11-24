using System.Net;
using System.Threading.Tasks;

namespace TrainingApp
{
    class HeadersConnector 
    {
        private readonly string _url;

        public HeadersConnector(string url) => _url = url;

        private string FormateAction(string action) => 
                action.
                Replace("+", "%2B").
                Replace("*", "%2A").
                Replace("/", "%2F");

        private string CreateUrl(double first, double second, string action)
        {
            var formatedAction = FormateAction(action);
            var url = _url + string.Format("first={0}&second={1}&action={2}",
                first, second, formatedAction);
            return url;
        }

        private WebRequest CreateRequest(double first, double second, string action) =>
                WebRequest.Create(CreateUrl(first, second, action));
 
        private async Task<WebResponse> GetResponseAsync(WebRequest _request)
        {
            if (_request != null)
                return await _request.GetResponseAsync();
            else return null;
        }

        private string GetAnswer(WebResponse response)
        {
            switch (response.Headers["result"])
            {
                case "Fail":
                    return string.Empty;
                default:
                    return response.Headers["result"];
            }
        }

        public async Task<string> Solve(double first, string action, double second)
        {
            WebRequest request = CreateRequest(first, second, action);
            WebResponse responce = await GetResponseAsync(request);
            string result = GetAnswer(responce);
            return await Task.FromResult(result);
        }
    }
}
