using Contracts;
using DrawnigContracts.Interface;
using System;
using System.Text;

namespace GenerateIdService
{
    [Register(Policy.Transient,typeof(IGenerateIdService))]
    public class GenerateId : IGenerateIdService
    {
        string IGenerateIdService.GenerateId()
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var ticks = DateTime.Now.Ticks;
            var bytes = System.Text.Encoding.ASCII.GetBytes(ticks.ToString());
            var hashBytes = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
