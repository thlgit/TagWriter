using System;
using System.Security.Cryptography;
using System.Text;

namespace TagWriter.UI.Services;

public class EncryptionService
{
    // 使用32字节的密钥和16字节的IV
    private static readonly byte[] Key = new byte[32] 
    { 
        0x54, 0x61, 0x67, 0x57, 0x72, 0x69, 0x74, 0x65,  // "TagWrite"
        0x72, 0x32, 0x30, 0x32, 0x34, 0x4B, 0x65, 0x79,  // "r2024Key"
        0x21, 0x40, 0x23, 0x24, 0x25, 0x5E, 0x26, 0x2A,  // "!@#$%^&*"
        0x28, 0x29, 0x2D, 0x5F, 0x3D, 0x2B, 0x7E, 0x60   // "()-_=+~`"
    };
    
    private static readonly byte[] IV = new byte[16]
    {
        0x54, 0x61, 0x67, 0x57, 0x72, 0x69, 0x74, 0x65,  // "TagWrite"
        0x72, 0x49, 0x6E, 0x69, 0x74, 0x56, 0x65, 0x63   // "rInitVec"
    };

    public string Encrypt(string plainText)
    {
        try
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            return Convert.ToBase64String(cipherBytes);
        }
        catch (Exception ex)
        {
            throw new Exception($"加密失败: {ex.Message}");
        }
    }

    public string Decrypt(string cipherText)
    {
        try
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }
        catch (Exception ex)
        {
            throw new Exception($"解密失败: {ex.Message}");
        }
    }
} 