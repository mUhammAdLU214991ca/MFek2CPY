// 代码生成时间: 2025-08-30 20:48:43
using System;
using System.Security.Cryptography;
using System.Text;

// A utility class for password encryption and decryption using Unity framework.
public class PasswordEncryptionTool
{
    private const string Salt = "YourSaltValue"; // This should be a secure, random value.
    private const int IterationCount = 1000; // Number of iterations for hashing.
    private const int KeySize = 256; // Key size in bits.
    private const string HashAlgorithm = "SHA256"; // Hash algorithm to use.

    // Encrypts a password using PBKDF2 algorithm.
    public static string EncryptPassword(string password)
    {
        // Generate a salt if not already provided.
        byte[] salt = Encoding.UTF8.GetBytes(Salt);

        // Use Rfc2898DeriveBytes to hash the password.
        using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, IterationCount))
        {
            byte[] key = rfc2898DeriveBytes.GetBytes(KeySize / 8);
            return Convert.ToBase64String(key);
        }
    }

    // Decrypts a password from its encrypted form.
    public static string DecryptPassword(string encryptedPassword)
    {
        // Decode the encrypted password from Base64 format.
        byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

        // Use Rfc2898DeriveBytes to hash the password using the same salt and iteration count.
        using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(encryptedPassword, Encoding.UTF8.GetBytes(Salt), IterationCount))
        {
            byte[] decryptedBytes = rfc2898DeriveBytes.GetBytes(KeySize / 8);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }

    // Main method for demonstration purposes.
    public static void Main(string[] args)
    {
        try
        {
            string originalPassword = "MySecretPassword";
            string encryptedPassword = EncryptPassword(originalPassword);
            Console.WriteLine($"Encrypted Password: {encryptedPassword}");

            string decryptedPassword = DecryptPassword(encryptedPassword);
            Console.WriteLine($"Decrypted Password: {decryptedPassword}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
