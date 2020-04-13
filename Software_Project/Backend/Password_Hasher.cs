using System.Security.Cryptography;
using System;

namespace Software_Project.Hasher{

    /// <summary>
    /// This class is responsible for hashing passwords and verifying them.
    /// </summary>
    public static class Password_Hasher {

        //Constants for the hash and salt size.
        private const int SaltSize = 16;
        private const int HashSize = 20;

        /// <summary>
        /// Hashes the given password for n number of itterations and returns the hashed password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="iterations"></param>
        /// <returns>string</returns>
        public static string Hash(string password, int iterations) {
            
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            return string.Format("$KRASH${0}${1}", iterations, base64Hash);

        }

        /// <summary>
        /// Hashes the given password for 220640 itterations and returns the hashed password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>string</returns>
        public static string Hash(string password) { return Hash(password, 220640); }
        
        /// <summary>
        /// Checks if the hash is supported for this project.
        /// </summary>
        /// <param name="hashString"></param>
        /// <returns>boolean</returns>
        public static bool IsHashSupported(string hashString) { return hashString.Contains("$KRASH$"); }

        /// <summary>
        /// Verifies if the password is valid and the hash is correct.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <returns>boolean</returns>
        public static bool Verify(string password, string hashedPassword) {

            if (!IsHashSupported(hashedPassword))
                throw new NotSupportedException("The hashtype is not supported");

            var splittedHashString = hashedPassword.Replace("$KRASH$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];
            
            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;

            return true;

        }

    }

}