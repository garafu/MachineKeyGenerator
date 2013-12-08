namespace KeyGen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security;
    using System.Security.Cryptography;

    public class Key
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">バイト数</param>
        /// <returns></returns>
        public static string Generate(int length = 128)
        {            
            byte[] buff = new byte[length];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            rng.GetBytes(buff);

            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < buff.Length; i++)
            {
                sb.Append(string.Format("{0:X2}", buff[i]));
            }

            return sb.ToString();
        }
    }
}
