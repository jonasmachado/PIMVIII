using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BpeCentral.API.Tokenizacao
{
    public class Token
    {
        public static string SecretKey { get; protected set; } = "1BF61D24-9862-480D-B27F-3205463E92EB";
        public static int TimeForExpireInMinutes { get; protected set; } = TempoExpirar();
        private static string PrivateKey => "NvsSDFJXRzKRPtt7MU9QWkp9bhkxRmqT";
        private static byte[] IV = { 0x51, 0x32, 0x06, 0x24, 0x03, 0x06, 0x14, 0x16, 0x16, 0x10, 0x18, 0x07, 0x11, 0x22, 0x01, 0x21 };

        public string Generate(int UserId, Claim[] claim)
        {            
            var f = Base64Encode(SecretKey);
            var symmetricKey = Convert.FromBase64String(f);
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim("UserId", UserId.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: claims.Union(claim)),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(TimeForExpireInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(stoken);

            return Encrypt(token);
        }

        public JwtSecurityToken ConvertToken(string rtoken)
        {
            var token = Decrypt(rtoken);
            //var f = Base64Encode(SecretKey);
            //var symmetricKey = Convert.FromBase64String(f);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.ReadJwtToken(token);
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Encrypt(string ctoken)
        {
            try
            {

                if (!string.IsNullOrEmpty(ctoken))
                {

                    byte[] bKey = Convert.FromBase64String(Base64Encode(PrivateKey));
                    byte[] bText = new UTF8Encoding().GetBytes(ctoken);


                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;


                    MemoryStream mStream = new MemoryStream();

                    CryptoStream encryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(bKey, IV),
                        CryptoStreamMode.Write);


                    encryptor.Write(bText, 0, bText.Length);
                    encryptor.FlushFinalBlock();

                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        private static string Decrypt(string ctoken)
        {
            try
            {
                if (!string.IsNullOrEmpty(ctoken))
                {
                    byte[] bKey = Convert.FromBase64String((Base64Encode(PrivateKey)));
                    byte[] bText = Convert.FromBase64String(ctoken);


                    Rijndael rijndael = new RijndaelManaged();
                    rijndael.KeySize = 256;
                    MemoryStream mStream = new MemoryStream();


                    CryptoStream decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(bKey, IV),
                        CryptoStreamMode.Write);


                    decryptor.Write(bText, 0, bText.Length);
                    decryptor.FlushFinalBlock();
                    UTF8Encoding utf8 = new UTF8Encoding();
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {

                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static int TempoExpirar()
        {
            string i = System.Configuration.ConfigurationManager.AppSettings["tokenTempoExpirar"];
            if (int.TryParse(i, out int value))
                return value;
            return -1;
        }
    }
}