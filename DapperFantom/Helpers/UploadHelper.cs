using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace DapperFantom.Helpers
{
    public class UploadHelper
    {
        private IWebHostEnvironment _environment;

        public UploadHelper(IWebHostEnvironment hosting)
        {
            this._environment = hosting;
        }

        //public async Task<string> Upload(IFormFile file)
        public Task<string> Upload(IFormFile file)
        {
            
            string result = "";
            if(file.Length > 0)
            {
                try
                {
                    string fileName = string.Empty;
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var fileExtension = Path.GetExtension(fileName);
                    var folderPath = Path.Combine($"{this._environment.WebRootPath}/img/articles/");
                    var newFilename = myUniqueFileName + fileExtension;
                    fileName = Path.Combine(folderPath + newFilename);
                    using (FileStream fileStream = File.Create(fileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Dispose();
                    }
                    result = newFilename;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //return result;
            return Task.FromResult(result);

        }

        public bool Delete(string filename)
        {
            bool result = false;

            try
            {
                var filePath = Path.Combine($"{this._environment.WebRootPath}/img/articles/{filename}");
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
