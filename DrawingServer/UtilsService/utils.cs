using System;
using System.IO;

namespace UtilsService
{
    public class utils
    {
        public string getBase64FrooUrl(string url)
        {
           byte[] data = File.ReadAllBytes(url);
           return "data:image/png;base64,"+Convert.ToBase64String(data);
        }

        public string createId()
        {
            return "1333BM@GMAIL.COM";
        }

        public string storImageFromBase64(string path,string fileName,string dataBase64)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string imageName = fileName + ".jpg";
            string imgPath = Path.Combine(path, imageName);
            string convert = dataBase64.Replace("data:image/png;base64,", String.Empty);
            byte[] imageBytes = Convert.FromBase64String(convert);

            System.IO.File.WriteAllBytes(imgPath, imageBytes);


            return imgPath;
        }
    }
}
