using System;
using System.Collections.Generic;
using System.Linq;

namespace Odev1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Kullanıcı Giriş/Kayıt
            var userList = new List<User>();
            var user1 = new User { TcKimlikNo = "11111111111", Name = "Neslihan", Surname = "Alıcıoğlu", PhoneNumber = 1234567899 };
            userList.Add(user1);
            var user2 = new User { TcKimlikNo = "22222222222", Name = "Ali", Surname = "Yılmaz", PhoneNumber = 1234567899 };
            userList.Add(user2);
            var user3 = new User { TcKimlikNo = "33333333333", Name = "Hilal", Surname = "Durak", PhoneNumber = 1234567899 };
            userList.Add(user3);
            var user4 = new User { TcKimlikNo = "44444444444", Name = "Sinan", Surname = "Çakır", PhoneNumber = 1234567899 };
            userList.Add(user4);
        Ticket:
        //Kullanıcı kaydı
            Console.WriteLine("Giriş yapmak için kayıtlı TC Kimlik Numaranızı giriniz: \n");
        Ticket3:
            string tcNo;
            tcNo= HiddenPassword();//Tc kimlik numarası * şeklinde gözükmesi için gidilen method
            //Console.ReadLine();
            Console.Clear();
            if (string.IsNullOrEmpty(tcNo))
            {
                Console.WriteLine("TC Kimlik Numaranızı giriniz");
                return;
            }
            var IsUser = userList.Any(x => x.TcKimlikNo == tcNo);//Girilen değerde kullanıcı var mı?
            User? user;//hesap kısmında kullanıcı bilgisi alabilmek için nullable olarak tanımladım
            if (IsUser)
            {
                Console.WriteLine("Giriş işlemi başarılı");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                user = userList.Find(x => x.TcKimlikNo == tcNo);//Girilen kullanıcının bilgilerini listeden bul
              
                //Console.WriteLine("TcKimlik No: "+user.TcKimlikNo);
                Console.WriteLine("İsim: " + user.Name);
                Console.WriteLine("Soyisim: " + user.Surname);
                Console.WriteLine("Numara: " + user.PhoneNumber);
                //Kişi bilgileri sayfası
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Kayıtlı kullanıcı bulunamadı.");
                Console.WriteLine("TC Kimlik Numaranızı yanlış giriğinizi düşünüyorsanız 1'i , " +
                    "kayıdınız yoksa yeni kayıt için lütfen 2'ye basınız.");
            Ticket2:
                int desition = Int32.Parse(Console.ReadLine());
                switch (desition)
                {
                    case 1:
                        goto Ticket;
                    case 2: 
                        var newUser=new User();
                Ticket5:
                        Console.WriteLine("TC Kimlik Numaranızı giriniz: ");
                        newUser.TcKimlikNo=Console.ReadLine();
                        if (newUser.TcKimlikNo.Length != 11) {
                            Console.WriteLine("TC Kimlik Numaranızı yanlış girdiniz! ");
                            goto Ticket5;
                        }
                        Console.WriteLine("Adınızı giriniz: ");
                        newUser.Name = Console.ReadLine();
                        Console.WriteLine("Soyadınızı giriniz: ");
                        newUser.Surname = Console.ReadLine();
                        Console.WriteLine("Telefon Numaranızı giriniz: ");
                        newUser.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                        userList.Add(newUser);
                        Console.WriteLine("Giriş yapmak için TC Kimlik Numaranızı giriniz: \n");
                        goto Ticket3;

                    default: 
                        Console.WriteLine("Lütfen geçerli bir değer giriniz: ");
                        goto Ticket2;

                }
            }
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            //Ürünler ve alış-veriş
            double option, number=1, total = 0;
            double totalAmount = 0; //Ödenecek toplam hesap
            string? size="",product="";

            //MENÜ
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("**                         KAHVE EVİNE HOŞGELDİNİZ                      **");
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("**          İÇECEK           **     KÜÇÜK    /   ORTA    /   BÜYÜK      **");
            Console.WriteLine("**                           **                                         **");
            Console.WriteLine("**   1-Very Vanilla Chiller  **     34.25 tl    37.50 tl    41.75 tl    **");
            Console.WriteLine("**   2-Créme Brulée Chiller  **     34.25 tl    37.50 tl    41.75 tl    **");
            Console.WriteLine("**   3-Iced Mocha            **     31.25 tl    34.75 tl    36.25 tl    **");
            Console.WriteLine("**   4-Iced Latte            **     27.50 tl    30.00 tl    33.25 tl    **");
            Console.WriteLine("**   5-Choco Caramel         **     34.75 tl    37.50 tl    42.25 tl    **");
            Console.WriteLine("**   6-Macchiato             **     17.50 tl    19.25 tl    21.00 tl    **");
            Console.WriteLine("**   7-Cappuccino            **     22.75 tl    24.25 tl    26.75 tl    **");
            Console.WriteLine("**   8-Espresso              **       -         17.50 tl       -        **");
            Console.WriteLine("**   9-Çay Poşet             **       -         12.50 tl       -        **");
            Console.WriteLine("**   10-Türk Kahvesi         **       -         19.75 tl       -        **");
            Console.WriteLine("**                           **                                         **");
            Console.WriteLine("**************************************************************************");

            //Sipariş
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hoşgeldiniz :)");
                Console.WriteLine("Lütfen alacağınız ürünün numarasını giriniz: ");
                option = Convert.ToDouble(Console.ReadLine());
                if (option==1)
                {

                Ticket4:
                    Console.WriteLine("Lütfen alacağınız ürünün boyutunu giriniz (Küçük/Orta/Büyük): ");
                    size = Console.ReadLine();
                    if(size=="K"||size=="k" || size== "Küçük" || size=="küçük" || size=="KÜÇÜK" || 
                        size == "Kucuk" || size == "kucuk" || size == "KUCUK")
                    {
                        Console.WriteLine("Kaç adet Very Vanilla Chiller küçük boy istiyorsunuz?");
                        number= Convert.ToDouble(Console.ReadLine());
                        total = number * 34.25;
                        totalAmount += total;
                        size = "küçük boy ";
                    }
                    else if (size == "O" || size == "o" || size == "Orta" || size == "orta" || size == "ORTA")
                    {
                        Console.WriteLine("Kaç adet Very Vanilla Chiller orta boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 37.50;
                        totalAmount += total;
                        size = "orta boy ";
                    }
                    else if (size == "B" || size == "b" || size == "Büyük" || size == "büyük" || size == "BÜYÜK"||
                        size == "Buyuk" || size == "buyuk" || size == "BUYUK")
                    {
                        Console.WriteLine("Kaç adet Very Vanilla Chiller büyük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 41.75;
                        totalAmount += total;
                        size = "büyük boy ";
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                        goto Ticket4;
                    }
                    product = "Very Vanilla Chiller";
                }
                else if (option == 2)
                {

                Ticket4:
                    Console.WriteLine("Lütfen alacağınız ürünün boyutunu giriniz (Küçük/Orta/Büyük): ");
                    size = Console.ReadLine();
                    if (size == "K" || size == "k" || size == "Küçük" || size == "küçük" || size == "KÜÇÜK" ||
                        size == "Kucuk" || size == "kucuk" || size == "KUCUK")
                    {
                        Console.WriteLine("Kaç adet Créme Brulée Chiller küçük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 34.25;
                        totalAmount += total;
                        size = "küçük boy ";
                    }
                    else if (size == "O" || size == "o" || size == "Orta" || size == "orta" || size == "ORTA")
                    {
                        Console.WriteLine("Kaç adet Créme Brulée Chiller orta boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 37.50;
                        totalAmount += total;
                        size = "orta boy ";
                    }
                    else if (size == "B" || size == "b" || size == "Büyük" || size == "büyük" || size == "BÜYÜK" ||
                        size == "Buyuk" || size == "buyuk" || size == "BUYUK")
                    {
                        Console.WriteLine("Kaç adet Créme Brulée Chiller büyük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 41.75;
                        totalAmount += total;
                        size = "büyük boy ";
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                        goto Ticket4;
                    }
                    product = "Créme Brulée Chiller";
                }
                else if (option == 3)
                {

                Ticket4:
                    Console.WriteLine("Lütfen alacağınız ürünün boyutunu giriniz (Küçük/Orta/Büyük): ");
                    size = Console.ReadLine();
                    if (size == "K" || size == "k" || size == "Küçük" || size == "küçük" || size == "KÜÇÜK" ||
                        size == "Kucuk" || size == "kucuk" || size == "KUCUK")
                    {
                        Console.WriteLine("Kaç adet Iced Mocha küçük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 31.25;
                        totalAmount += total;
                        size = "küçük boy ";
                    }
                    else if (size == "O" || size == "o" || size == "Orta" || size == "orta" || size == "ORTA")
                    {
                        Console.WriteLine("Kaç adet Iced Mocha orta boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 34.75;
                        totalAmount += total;
                        size = "orta boy ";
                    }
                    else if (size == "B" || size == "b" || size == "Büyük" || size == "büyük" || size == "BÜYÜK" ||
                        size == "Buyuk" || size == "buyuk" || size == "BUYUK")
                    {
                        Console.WriteLine("Kaç adet Iced Mocha büyük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 36.25;
                        totalAmount += total;
                        size = "büyük boy ";
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                        goto Ticket4;
                    }
                    product = "Iced Mocha";
                }
                else if (option == 4)
                {
                Ticket4:
                    Console.WriteLine("Lütfen alacağınız ürünün boyutunu giriniz (Küçük/Orta/Büyük): ");
                    size = Console.ReadLine();
                    if (size == "K" || size == "k" || size == "Küçük" || size == "küçük" || size == "KÜÇÜK" ||
                        size == "Kucuk" || size == "kucuk" || size == "KUCUK")
                    {
                        Console.WriteLine("Kaç adet Iced Latte küçük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 27.50;
                        totalAmount += total;
                        size = "küçük boy ";
                    }
                    else if (size == "O" || size == "o" || size == "Orta" || size == "orta" || size == "ORTA")
                    {
                        Console.WriteLine("Kaç adet Iced Latte orta boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 30.00;
                        totalAmount += total;
                        size = "orta boy ";
                    }
                    else if (size == "B" || size == "b" || size == "Büyük" || size == "büyük" || size == "BÜYÜK" ||
                        size == "Buyuk" || size == "buyuk" || size == "BUYUK")
                    {
                        Console.WriteLine("Kaç adet Iced Latte büyük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 33.25;
                        totalAmount += total;
                        size = "büyük boy ";
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                        goto Ticket4;
                    }
                    product = "Iced Latte";
                }
                else if (option == 5)
                {
                Ticket4:
                    Console.WriteLine("Lütfen alacağınız ürünün boyutunu giriniz (Küçük/Orta/Büyük): ");
                    size = Console.ReadLine();
                    if (size == "K" || size == "k" || size == "Küçük" || size == "küçük" || size == "KÜÇÜK" ||
                        size == "Kucuk" || size == "kucuk" || size == "KUCUK")
                    {
                        Console.WriteLine("Kaç adet Choco Caramel küçük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 34.75;
                        totalAmount += total;
                        size = "küçük boy ";
                    }
                    else if (size == "O" || size == "o" || size == "Orta" || size == "orta" || size == "ORTA")
                    {
                        Console.WriteLine("Kaç adet Choco Caramel orta boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 37.50;
                        totalAmount += total;
                        size = "orta boy ";
                    }
                    else if (size == "B" || size == "b" || size == "Büyük" || size == "büyük" || size == "BÜYÜK" ||
                        size == "Buyuk" || size == "buyuk" || size == "BUYUK")
                    {
                        Console.WriteLine("Kaç adet Choco Caramel büyük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 42.25;
                        totalAmount += total;
                        size = "büyük boy ";
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                        goto Ticket4;
                    }
                    product = "Choco Caramel";
                }
                else if (option == 6)
                { 
                Ticket4:
                    Console.WriteLine("Lütfen alacağınız ürünün boyutunu giriniz (Küçük/Orta/Büyük): ");
                    size = Console.ReadLine();
                    if (size == "K" || size == "k" || size == "Küçük" || size == "küçük" || size == "KÜÇÜK" ||
                        size == "Kucuk" || size == "kucuk" || size == "KUCUK")
                    {
                        Console.WriteLine("Kaç adet Macchiato küçük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 17.50;
                        totalAmount += total;
                        size = "küçük boy ";
                    }
                    else if (size == "O" || size == "o" || size == "Orta" || size == "orta" || size == "ORTA")
                    {
                        Console.WriteLine("Kaç adet Macchiato orta boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 19.25;
                        totalAmount += total;
                        size = "orta boy ";
                    }
                    else if (size == "B" || size == "b" || size == "Büyük" || size == "büyük" || size == "BÜYÜK" ||
                        size == "Buyuk" || size == "buyuk" || size == "BUYUK")
                    {
                        Console.WriteLine("Kaç adet Macchiato büyük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 21.00;
                        totalAmount += total;
                        size = "büyük boy ";
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                        goto Ticket4;
                    }
                    product = "Macchiato";
                }
                else if (option == 7)
                {
                Ticket4:
                    Console.WriteLine("Lütfen alacağınız ürünün boyutunu giriniz (Küçük/Orta/Büyük): ");
                    size = Console.ReadLine();
                    if (size == "K" || size == "k" || size == "Küçük" || size == "küçük" || size == "KÜÇÜK" ||
                        size == "Kucuk" || size == "kucuk" || size == "KUCUK")
                    {
                        Console.WriteLine("Kaç adet Cappuccino küçük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 22.75;
                        totalAmount += total;
                        size = "küçük boy ";
                    }
                    else if (size == "O" || size == "o" || size == "Orta" || size == "orta" || size == "ORTA")
                    {
                        Console.WriteLine("Kaç adet Cappuccino orta boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 24.25;
                        totalAmount += total;
                        size = "orta boy ";
                    }
                    else if (size == "B" || size == "b" || size == "Büyük" || size == "büyük" || size == "BÜYÜK" ||
                        size == "Buyuk" || size == "buyuk" || size == "BUYUK")
                    {
                        Console.WriteLine("Kaç adet Cappuccino büyük boy istiyorsunuz?");
                        number = Convert.ToDouble(Console.ReadLine());
                        total = number * 26.75;
                        totalAmount += total;
                        size = "büyük boy ";
                    }
                    else
                    {
                        Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                        goto Ticket4;
                    }
                    product = "Cappuccino";
                }
                else if (option == 8)
                {
                    Console.WriteLine("Kaç adet Espresso istiyorsunuz?");
                    number = Convert.ToDouble(Console.ReadLine());
                    total = number * 17.50;
                    totalAmount += total;
                    product = "Espresso";

                }
                else if (option == 9)
                {
                    Console.WriteLine("Kaç adet Çay Poşet istiyorsunuz?");
                    number = Convert.ToDouble(Console.ReadLine());
                    total = number * 12.50;
                    totalAmount += total;
                    product = "Çay Poşet ";

                }
                else if (option == 10)
                {
                    Console.WriteLine("Kaç adet Türk Kahvesi istiyorsunuz?");
                    number = Convert.ToDouble(Console.ReadLine());
                    total = number * 19.75;
                    totalAmount += total;
                    product = "Türk Kahvesi ";
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
                }

                Console.WriteLine();
                Console.WriteLine(number+" adet "+size+product+"sipariş verdiniz.");
                Console.WriteLine("Başka bir şey ister misiniz?");
                string response = Console.ReadLine();
                if (response=="h"|| response == "H" || response == "hayır" || response == "hayir" 
                    || response == "Hayır" || response == "Hayir" || response == "HAYIR" || response == "HAYİR" )
                {
                    break;
                }
            }

            Console.WriteLine("Sayın "+ user.Name+" "+user.Surname);
            Console.WriteLine("Ödeyeceğiniz toplam tutar: " + totalAmount + "tl dir.");      
            Console.Read();
        }
        private static string HiddenPassword()
        { 
            //Girilen değeri dizeye atayıp bu dizeyi * karakterine çeviriyor.
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }

        public sealed class User
        {
            public string TcKimlikNo { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public long PhoneNumber { get; set; }
        }
       
    }

    
}
