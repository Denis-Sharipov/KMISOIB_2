using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KMiSOIB
{
    //RSA
    //Сгенерируйте открытый и закрытый ключи в алгоритме шифрования RSA, 
    //выбрав простые числа p и q из первой сотни.Зашифруйте сообщение, 
    //состоящее из ваших инициалов: ФИО.

    class prog3
    {
        string message, enMsg, deMsg;
        public int p { get; }
        public int q { get; }
        public int d { get; }
        public int k { get; }
        public int n { get; }
        public int f { get; }
        public int e { get; }
        private int maxCharCode;

        public prog3(string message, int p, int q, int d) 
        {
           
            this.message = message; //Собщение
            this.p = p; //Значение p
            this.q = q; //Значение q
            this.d = d; //Значение d

            n = p * q; //Модуль n
            f = (p - 1) * (q - 1); //Значение по формуле Эйлера
            e = FindE(); //Значение e
        }
        private int FindE() //Нахождение e
        {
            int e = 0;
            while ((d * e - 1) % f != 0)
            {
                e++;
            }

            return e;
        }

        public string publicKey() {return e + " " + n; } //Открытый ключ
        public string privateKey() { return d + " " + n; } //Закрытый ключ

        public string Encrypt() //Шифрование
        {
            foreach(var ch in message) 
            {
                int charIndex;
                if (Alphabet.GetCharCode(ch) >= 192 && Alphabet.GetCharCode(ch) <= 223)
                {
                    charIndex = Alphabet.GetCharCode(ch) - 191;
                }
                else if (Alphabet.GetCharCode(ch) >= 224 && Alphabet.GetCharCode(ch) <= 255)
                {
                    charIndex = Alphabet.GetCharCode(ch) - 223;
                }
                else throw new Exception($"Символ не подходит");
                maxCharCode = charIndex > maxCharCode ? charIndex : maxCharCode;
                if (maxCharCode >= n) throw new Exception($"Индекс выходит за границы");
                var res = BigInteger.ModPow(charIndex, e, n);
                enMsg += res + " ";
            }
            return enMsg; //Зашифрованное сообщение
        }

        public string Decrypt() //Дешифрование
        {
            foreach (var ch in enMsg.Trim().Split(' '))
            {
                var res = BigInteger.ModPow(int.Parse(ch), d, n);
                deMsg += Alphabet.GetChar(((int)res + n) % n + 191);
            }
            return deMsg; //Расшиврованное сообщение
        }

    }
}
