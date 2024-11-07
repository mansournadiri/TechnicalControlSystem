using Common.Interface;
using System.Security.Cryptography;
using System.Text;

namespace Common.Service
{
    public class CommonService : ICommon
    {
        public string GenerateAlphanumericRandom(int? countOfCharacter)
        {
            int index = countOfCharacter ?? 8;
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, index)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GenerateHashKey(string? input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            string hashText = "";
            string hexValue = "";

            byte[] stringData = Encoding.ASCII.GetBytes(input);
            byte[] hashData = SHA1.Create().ComputeHash(stringData);

            foreach (byte b in hashData)
            {
                hexValue = b.ToString("X").ToLower();
                hashText += (hexValue.Length == 1 ? "0" : "") + hexValue;
            }
            return hashText;
        }
    }
}
