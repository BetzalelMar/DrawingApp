using Contracts;
using DrawnigContracts.Interface;
using System;
using System.IO;

namespace ImageService
{
    [Register(Policy.Transient,typeof(IImageService))]
    public class ImageService : IImageService
    {
        public string ConvertToBase64(string url)
        {
            byte[] data = File.ReadAllBytes(url);
            return "data:image/png;base64," + Convert.ToBase64String(data);
        }

        public byte[] ConvertToByte(string base64)
        {
            string convert = base64.Replace("data:image/png;base64,", String.Empty);
            return Convert.FromBase64String(convert);

        }

        public string storeImage(string path, string fileName,string imageBase64)
        {
            var imageBytes = ConvertToByte(imageBase64);
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string imageName = fileName + ".jpg";
            string imagePath = Path.Combine(path, imageName);

            System.IO.File.WriteAllBytes(imagePath, imageBytes);
            return imageName;
        }
    }
}
