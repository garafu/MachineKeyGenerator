namespace KeyGen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Validation
    {
        public static List<Validation> DataSource = new List<Validation>()
        {
            new Validation() {
                DisplayName = "AES",
                TypeName = "AES",
                Bit = 256,
                IsDefault = false
            },
            new Validation() {
                DisplayName = "MD5",
                TypeName = "MD5",
                Bit = 128,
                IsDefault = false
            },
            new Validation() {
                DisplayName = "SHA1",
                TypeName = "SHA1",
                Bit = 160,
                IsDefault = false
            },
            new Validation() {
                DisplayName = "3DES",
                TypeName = "3DES",
                Bit = 192,
                IsDefault = false
            },
            new Validation() {
                DisplayName = "HMACSHA256",
                TypeName = "HMACSHA256",
                Bit = 256,
                IsDefault = true
            },
            new Validation() {
                DisplayName = "HMACSHA384",
                TypeName = "HMACSHA384",
                Bit = 384,
                IsDefault = false
            },
            new Validation() {
                DisplayName = "HMACSHA512",
                TypeName = "HMACSHA512",
                Bit = 512,
                IsDefault = false
            },
        };

        public string DisplayName { get; set; }

        public string TypeName { get; set; }

        public int Bit { get; set; }

        public bool IsDefault { get; set; }
    }
}
