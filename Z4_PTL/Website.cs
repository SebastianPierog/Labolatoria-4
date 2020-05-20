using System.Reflection;
using System.Threading.Tasks;
using RestSharp;

namespace Z4_PTL
{
    public class Website
    {
        public Website(string baseLink)
        {
            _Client = new RestClient(baseLink);
        }
        
        public RestClient _Client { get;private set; }
        public string Download(string path)
        {
            var request = new RestRequest(path, Method.GET);
            var resposne = _Client.Execute(request);
            return resposne.Content;
        }
        
        public  Task<IRestResponse> DownloadAsync(string path)
        {
            var request = new RestRequest(path, Method.GET);
            var res = _Client.ExecuteAsync(request);
            return res;
        }
    }
}