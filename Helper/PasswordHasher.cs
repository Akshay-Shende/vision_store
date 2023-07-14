using System;
using System.Security.Cryptography;

namespace VisionStore.Helper;
public class PasswordHasher
{
    private const int SaltSize = 16; // Size of the salt in bytes
    private const int HashSize = 32; // Size of the hash in bytes
    private const int Iterations = 10000; // Number of iterations for the hashing algorithm

    // Method to generate a random salt
    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    // Method to hash a password using bcrypt with salt
    public static string HashPassword(string password)
    {
        byte[] salt = GenerateSalt();

        using (var bcrypt = new Rfc2898DeriveBytes(password, salt, Iterations))
        {
            byte[] hash = bcrypt.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }
    }

    // Method to verify a password against a hashed password
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        using (var bcrypt = new Rfc2898DeriveBytes(password, salt, Iterations))
        {
            byte[] hash = bcrypt.GetBytes(HashSize);

            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
