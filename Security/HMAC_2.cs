using System.Security.Cryptography;
using System.Text;

namespace Task3.Security;

public class HMAC_2
{
    public string Message { get; set; }
    private byte[] HashedMessage { get; set; }
    private byte[] HMACKey { get; set; }

    public HMAC_2(string computerMove)
    {
        using var hmac = new HMACSHA512(); // Has .Key property which has cryptographically strong random key
        Message = computerMove;
        HMACKey = hmac.Key;
        HashedMessage = hmac.ComputeHash(Encoding.UTF8.GetBytes(computerMove));
    }

    public void PrintHashedMessage()
    {
        PrintTheHash("HMAC", HashedMessage);
    }

    public void PrintTheKey()
    {
        PrintTheHash("HMAC Key", HMACKey);
    }

    private static void PrintTheHash(string prefix, byte[] hashByteArray)
    {
        Console.Write($"{prefix}: ");
        for (int i = 0; i < hashByteArray.Length; i++)
        {
            Console.Write($"{hashByteArray[i]:X2}");
        }
        Console.WriteLine();
    }
}
