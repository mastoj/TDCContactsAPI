using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TDCContactsAPI.Models;
using TDCContactsAPI.Providers;

namespace TDCContactsAPI.Controllers
{
    public class ImageController : ApiController
    {
        private ContactRepository _contactRepository;

        public ImageController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public HttpResponseMessage Post([FromUri] int id)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var folder = HttpContext.Current.Server.MapPath(TDCApiConfiguration.ImageFolderPath);
            var streamProvider = new CustomFileNameStreamProvider(folder);
            string fileName = null;
            var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
                {
                    if(t.IsFaulted || t.IsCanceled)
                    {
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    }
                    fileName = streamProvider.FileData.Select(fileData => fileData.LocalFileName).First();
                });
            task.Wait();
            _contactRepository.InsertImage(id, fileName);
            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
    }
}