using System.Security.Cryptography;
using System.Text;

namespace FakeBank.Services
{
    public class HashService : IHashService
    {
        public string ComputeSha256(byte[] data)
        {
            using var sha = SHA256.Create();
            var hashBytes = sha.ComputeHash(data);

            var sb = new StringBuilder(hashBytes.Length * 2);
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
