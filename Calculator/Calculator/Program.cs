using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float number1 = 0;
            float number2 = 0;
            bool isNumber1Valid = false; //True değeri atarsam while döngüsüne girmeden çıkar.
            bool isNumber2Valid = false;
            bool isAnswerValid = false;
            string answer;
            Console.WriteLine("Hello, welcome to my first c# calculator program");

            //girilenin int olup olmadığını kontrol etmenin 4 yolu vardır. Bunlardan ilki net 9.0 sonrası
            //için geçerli olan if (number is not int) ifadesi, ikincisi 8.0 ve öncesi için geçerli olan
            //if(!(number1 is int)) ifadesi; 3.sü if(number1.GetType() != typeof(int)) ifadesi ve sonuncusu ise
            //TryParse yöntemi ile tür doğrulamadır.
            while (!isNumber1Valid)
            {
                Console.WriteLine("Please enter your first Integer number;");
                if (float.TryParse(Console.ReadLine(), out number1))
                {
                    isNumber1Valid = true;
                    Console.WriteLine("Number 1 is; " + number1);
                }
                else
                {
                    // Kullanıcı geçersiz bir sayı girdiğinde bu mesaj gösterilir
                    Console.WriteLine("value is invalid. please enter an valid number next time.");
                }
            }
            while (!isNumber2Valid)
            {
                Console.WriteLine("Please enter your second number;");
                if (float.TryParse(Console.ReadLine(), out number2))
                {
                    isNumber2Valid = true;
                    Console.WriteLine("Number 2 is; " + number2);
                }
                else
                {
                    // Kullanıcı geçersiz bir sayı girdiğinde bu mesaj gösterilir
                    Console.WriteLine("Number is invalid. please enter an Integer number next time.");
                }
            }
            Console.WriteLine("What type of operation would you like to do?");
           

            while (!isAnswerValid)
            {
                Console.WriteLine("Type a for addition, s for subtraction, m for multiplication, d for division");
                answer = Console.ReadLine();
                if (answer == "a")
                {
                    Console.WriteLine("The result of the addition is; " + (number1 + number2));
                    isAnswerValid = true;
                }
                else if (answer == "s")
                {
                    if (number1 < number2)
                    {
                        Console.WriteLine("number1 must be bigger than number2 for this equation.");
                    }
                    else
                    {
                       Console.WriteLine("The result of the subtraction is; " + (number1 - number2));
                       isAnswerValid = true;  
                    }
                    
                }
                else if (answer == "m")
                {
                    Console.WriteLine("The result of the multiplication is; " + (number1 * number2));
                    isAnswerValid = true;
                }
                else if (answer == "d")
                {
                    if (number2 == 0)
                    {
                        Console.WriteLine("You cannot divide by zero. Please enter a valid second number:");
                        if (float.TryParse(Console.ReadLine(), out number2))
                        {
                            // Yeni number2'nin geçerli olup olmadığını kontrol et
                            Console.WriteLine("Number 2 is: " + number2);
                        }
                        else
                        {
                            Console.WriteLine("Number is invalid. Please enter an integer number next time.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The result of the division is; " + (number1 / number2));
                        isAnswerValid = true;
                    }
                
                
                }
                else
                {
                    Console.WriteLine("Invalid operation. Please enter a valid operation.");
                }
            }

            //ReadLine ile ReadKey farkları; Key genelde butona basmak gerektiği durumlarda ve herhangi
            //bir tuşa basılırsa reaksiyon verir. ReadLine ise string döndürür ve konsolu kapatmak
            //için enter tuşuna basma şarttır. Ana amaçları girdi almak olan bu iki değer içleri boş
            //olduğunda açılan programın hemen kapanmasını önleyerek programın kapanması
            //için kullanıcıdan bir girdi alınmasını sağlar.
            Console.ReadLine();
        }
    }
}

//ReadLine string döndürür. Bu yüzden Convert.ToInt32 ile integera çeviriyoruz ki girilen değer okunabilsin.
//ancak bu yöntemde kullanıcı yanlış bir değer girdiğinde program exception fırlatır o yüzden tüm girişler
//için güvenli olması adına while ve if ile birleştirilen TryParse metodunu kullanacağız. eğer kullanıcının
//sayı gireceğinden eminsem TryCatch ile kullanılabilir.
//int number1 = Convert.ToInt32(Console.ReadLine());