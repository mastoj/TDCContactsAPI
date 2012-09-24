using System.Net.Http;

namespace TDCContactsAPI.Providers
{
    public class CustomFileNameStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomFileNameStreamProvider(string rootPath) : base(rootPath)
        {
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return name.Replace("\"", string.Empty); //this is here because Chrome submits files in quotation marks which get treated as part of the filename and get escaped
        }
    }
}