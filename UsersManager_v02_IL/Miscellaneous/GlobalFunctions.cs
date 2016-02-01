using System;
using System.Security.Cryptography;

namespace UserManager_v02_IL.Miscellaneous
{
    public static class GlobalFunctions
    {
       
        public static string EncryptPassword(string password)
        {
            string secret = "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(password);
            string pwdEncript = "";
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                pwdEncript = Convert.ToBase64String(hashmessage);
            }
            return pwdEncript;
        }
    }
}