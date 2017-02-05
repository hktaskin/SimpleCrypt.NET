using System;
using LibSimpleCrypt;
using System.IO;

namespace ConsoleExample
{
    class Program
    {
        const string TEST_PUBLIC_KEY = "BgIAAACkAABSU0ExAAgAAAEAAQAtcdWnSG4LnaOB0aNXXbj2riv6y74ws6wUu9+M916OCa559SkKrcHeMtI9/L7H9DeBjKosYFR7EnNYOtrR4U++DrQKVBHv7oMiyuWDxJMYMnLRx5v3EyvV8wkeFWKMkHDxhcQjEhK9SsExDmB6zb1O6Yj8wwE/4wm4Pj/e8y2UJ7GzmDRkDQc24nkDHJxdrQ0A4cCJoqMCT+sB+441HCbTLbQHkxwKwDie4qDQnXcBMbBR2Q2WKuvWvZ00iYaOQ75a7ddw+8AKCXgEWWpVoy1nWxJhrWACrBZgkspEvzAfcLEdPuGQE5+lzNh2y7YLKg8NUPi3a/4URoXbJ/GygIe5";
        const string TEST_PRIVATE_KEY = "BwIAAACkAABSU0EyAAgAAAEAAQAtcdWnSG4LnaOB0aNXXbj2riv6y74ws6wUu9+M916OCa559SkKrcHeMtI9/L7H9DeBjKosYFR7EnNYOtrR4U++DrQKVBHv7oMiyuWDxJMYMnLRx5v3EyvV8wkeFWKMkHDxhcQjEhK9SsExDmB6zb1O6Yj8wwE/4wm4Pj/e8y2UJ7GzmDRkDQc24nkDHJxdrQ0A4cCJoqMCT+sB+441HCbTLbQHkxwKwDie4qDQnXcBMbBR2Q2WKuvWvZ00iYaOQ75a7ddw+8AKCXgEWWpVoy1nWxJhrWACrBZgkspEvzAfcLEdPuGQE5+lzNh2y7YLKg8NUPi3a/4URoXbJ/GygIe50f8quIbSQaFhezmYqq1BDWKUTT139iV47gXO6STlSxX2df86HW1+d8pqliaUv7xRaSab/uB5kitC8jUTWjDQvD9EdLhkeflaepULAqJSF3jn1CdlA7/Jz/aMyWwXuolnVWdI8EiPOoxQAFnmIuq92J3C8PnaJa6cd3JMjX/fYdidLk/q+HfN15VQOOK2Pr43Ip+kkJ8vVZ/7E+x/eOVrFn0iCza4T3pMK/nN7x+0n+TTxExLXpaHOdu25Ppz1VHhilA435bYVp9iPTUj9bVoLHXRI6fSdwqbFLcd+O7AKbGliQ65CbD/Bt88T87cJiLupdGXjGHbtRPxPPJnFIJ/26GYon6ChFrZSvCkoG7UlR94MSC7jwkiTR6+KbUT/usI8UMlG5nFOS126u7JZ09oltHbQEU/QZ9as3noz+ESKpL4ZppbqvGrYPb5iz5yIo948ga10dEHoeCSU15c8mPB/yfFFLsDOr2M6HsdpU8OdKQwZ27p6We3SL84VEXtC9YKMRwZqRxUX6l75qfF0NhLqkNzrQAK4uoz3IB8mencVfbQKco7KPn341kIaO7sYLuseRb3yRtg2pmCgBLF/Y4XB8RjXQwFVxESwvxjKaPuFP2+QvbKI7YUcs/hRE7ccBWOdo+OvFjqApLHvkzZPlAD9nXTWM+7YVKtXCt3Q27i7ypUK3ZnMaiANJI5eu1HxAvmLfxhPixRLfuvXqdi/N00w7eA+tZ5rrSZuxGX2uDXVafLbtA7s9PUEIYkZSg9nzbd0tSKUtJRjWpXiJWwgtWldcrFa67Q5OpsrBL8zL9inZNbMEmeaftxTtUIbB/rKB1+Y7lboOwNA+qXEDjc1teMiTEYlc4TjDE1bNyjD58j5kCFSOZxWVU6CocMHSukX4rXeAIp1geQPxkBQT15i8itRe47lSe1CwSKgvAzap9QXRcqHQ8/CqCEJrELnNy2ZeJQXlKMtuSWEVrEusdajOESK3cEWdNvqMQXnobRPUUL3dYDFmCM+01GcEl5uk2JYQuJt2F1/s1lqVnergEICaCpw+dRnQQqoHzdBhKtoXG7C2bK7GIEp/B84/qqZvAOzE+V37Zx1sueIZ+ihzbITyqiNADcn8F8bZoa5azQCXOlibxSiFPBE+eiFDWzAypC6L5k2h/1AzPUGa7+nHKIUnCTjG/SKe7vPlVGDkNynk6qAS0=";
        static void Main(string[] args)
        {
            //TestStringCrypto();
            //Console.WriteLine(HybridCrypto.GenerateKeyPair());

            string inputFilePath = @"C:\Test\dosya1.pdf";
            string outputFilePath = @"C:\Test\dosya1.pdf.enc";
            string decryptedFilePath = @"C:\Test\dosya1_decrypted.pdf";

            // Dosya şifreleme örneği
            using (FileStream fe = new FileStream(inputFilePath, FileMode.Open))
            {
                HybridCrypto.Encrypt(fe, outputFilePath, TEST_PUBLIC_KEY);
                fe.Close();
            }

            // Şifreli dosya çözme örneği
            using (FileStream fd = new FileStream(outputFilePath, FileMode.Open))
            {
                HybridCrypto.Decrypt(fd, decryptedFilePath, TEST_PRIVATE_KEY);
                fd.Close();
            }

            Console.WriteLine("Bitti.");
            Console.ReadLine();
        }

        static void TestStringCrypto()
        {
            string P = "thisisaplaintext";
            string K = "thisisakey";
            Console.WriteLine("P: " + P);
            Console.WriteLine("K: " + K);
            Console.WriteLine();
            // Ayni string'i ayni anahtar ile 20 kere sifrele
            // Hepsinin sifrelenmis hali farklı ama cozunce ayni string degerini veriyor
            for (int i = 0; i < 20; i++)
            {
                string C1 = P.Encrypt(K);
                string P1 = C1.Decrypt(K);
                Console.WriteLine("C{0}: " + C1, i + 1);
                Console.WriteLine("P{0}: " + P1, i + 1);
                Console.WriteLine();
            }

            // Empty string icin test
            string CBos = StringCrypto.Encrypt(string.Empty, string.Empty);
            string PBos = StringCrypto.Decrypt(CBos, string.Empty);
            Console.WriteLine("CBos: " + CBos);
            Console.WriteLine("PBos: " + PBos);
            Console.WriteLine();

            Console.WriteLine("Internal Test: " + StringCrypto.Test().ToString());
        }
    }
}
