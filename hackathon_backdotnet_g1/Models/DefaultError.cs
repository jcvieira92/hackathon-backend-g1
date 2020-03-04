using System.Net;

namespace hackathon_backdotnet_g1.Models
{
    public class DefaultError
    {
        public HttpStatusCode code { get; set; }
        public string message { get; set; }

        public DefaultError(HttpStatusCode _code, string _message)
        {
            code = _code;
            message = _message;
        }
    }
}