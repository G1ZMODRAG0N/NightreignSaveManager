using System.Text;

namespace NightreignSaveManager.Helpers
{
    internal class DataHelpers
    {
        private static byte[] divider = [0x40, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF];

        internal static bool IsValidHeader(string fileIdentifier, byte[] data)
        {
            if (data != null && data.Length >= fileIdentifier.Length && data.Take(fileIdentifier.Length).SequenceEqual(Encoding.ASCII.GetBytes(fileIdentifier)))
            {
                return true;
            } else {  return false; }
        }
        internal static bool IsValidDivider(byte[] data, int position)
        {
            return data.Skip(position).Take(divider.Length).SequenceEqual(divider);
        }
            
    }
}