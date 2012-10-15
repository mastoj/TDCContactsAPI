using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using TDCContactsAPI.Models;

namespace TDCContactsAPI.Formatters
{
    public class JpgMediaFormatter : BufferedMediaTypeFormatter
    {
        private ContactRepository _contactsRepository;
        private ContentDispositionHeaderValue _contentDispositionHeader;

        public JpgMediaFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpg"));
            MediaTypeMappings.Add(new QueryStringMapping("format", "jpg", "image/jpg"));
            _contactsRepository = new ContactRepository();
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (typeof(Contact) == type)
            {
                return true;
            }
            return false;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            _contentDispositionHeader = new ContentDispositionHeaderValue("attachment") { FileName = "image.jpg" };
            headers.ContentDisposition = _contentDispositionHeader;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            var contact = value as Contact;
            if (contact != null)
            {
                if (contact.HasImage)
                {
                    var imageName = _contactsRepository.GetImage(contact.Id);
                    var path = HttpContext.Current.Server.MapPath(TdcApiConfiguration.ImageFolderPath + imageName);
                    using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        file.CopyTo(writeStream);
                    }
                    writeStream.Flush();
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var writer = new StreamWriter(writeStream);
                    writer.WriteLine("Contact has no image");
                    writer.Flush();
                }
            }
        }
    }
}