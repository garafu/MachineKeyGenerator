namespace KeyGen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Decription
    {
        public static List<Decription> DataSouce = new List<Decription>()
        {
            new Decription() {
                DisplayName = "Auto",
                TypeName  ="Auto",
                Bit = 256,
                IsDefault = true
            },
            new Decription() {
                DisplayName = "AES(128)",
                TypeName  ="AES",
                Bit = 128,
                IsDefault = false
            },
            new Decription() {
                DisplayName = "AES(192)",
                TypeName  ="AES",
                Bit = 192,
                IsDefault = false
            },
            new Decription() {
                DisplayName = "AES(256)",
                TypeName  ="AES",
                Bit = 256,
                IsDefault = false
            },
            new Decription() {
                DisplayName = "DES",
                TypeName  ="DES",
                Bit = 64,
                IsDefault = false
            },
            new Decription() {
                DisplayName = "3DES",
                TypeName  ="3DES",
                Bit = 192,
                IsDefault = false
            }
        };

        public int ID { get; set; }

        public string DisplayName { get; set; }

        public string TypeName { get; set; }

        public int Bit { get; set; }

        public bool IsDefault { get; set; }
    }
}
