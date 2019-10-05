using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
    class GeneratePassword
    {

        /// <summary>
        /// This will generate a password based on the first name(s), last name and bank ID
        /// of a person.
        /// </summary>
        /// <param name="first">The first name(s) of the person, space seperated</param>
        /// <param name="second">The Person's last name</param>
        /// <param name="third">The person's bank ID</param>
        /// <returns>The password as a string, except if an exception is thrown</returns>

        public static string generatePassword(string firstNames, string lastName, string bankID)
        {
            if (System.String.IsNullOrWhiteSpace(firstNames))
            {
                throw new System.ArgumentNullException(nameof(firstNames));
            }
            if (System.String.IsNullOrWhiteSpace(lastName))
            {
                throw new System.ArgumentNullException(nameof(lastName));
            }
            if (System.String.IsNullOrWhiteSpace(bankID))
            {
                throw new System.ArgumentNullException(nameof(bankID));
            }

            try
            {
                // the strings here are used to diverisfy the hash generated
                var workString = "1207." + firstNames.ToLower() + " " + lastName.ToUpper() + "." + bankID.ToLower() + ".0105";
                var workBytes = System.Text.Encoding.UTF8.GetBytes(workString);
                using (var sha = System.Security.Cryptography.SHA256.Create())
                {
                    // use only a 3rd of the hash for the password
                    var passwordLength = (sha.HashSize / 8) / 3;
                    var hashPart = new byte[passwordLength];
                    System.Array.Copy(sha.ComputeHash(workBytes), 2, hashPart, 0, passwordLength);
                    // remove the dashes
                    return BitConverter.ToString(hashPart).Replace("-", "");
                }
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
