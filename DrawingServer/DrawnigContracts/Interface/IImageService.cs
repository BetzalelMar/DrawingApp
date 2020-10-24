using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IImageService
    {
        public string ConvertToBase64(string url);
        public byte[] ConvertToByte(string base64);
        public string storeImage(string path, string fileName, string base64);

    }
}
