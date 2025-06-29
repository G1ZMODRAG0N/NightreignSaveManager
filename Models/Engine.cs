//Credit to EonaCat for aes dycryptor
using System.Security.Cryptography;

namespace NightreignSaveManager.Models
{
    public class Transform
    {
        public static byte[] DecryptEngine(byte[] data, byte[] DS2_KEY, byte[] iv, byte[] encryptedPayload)
        {
            //engine setting
            using var aes = Aes.Create();
            aes.Key = DS2_KEY;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;

            //decrypt using engine
            using var transform = aes.CreateDecryptor();
            data = transform.TransformFinalBlock(encryptedPayload, 0, encryptedPayload.Length);

            return data;
        }
    }
}