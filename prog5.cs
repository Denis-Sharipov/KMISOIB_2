using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KMiSOIB
//ЭЦП
//Используя хеш-образ своей Фамилии, вычислите электронную цифровую подпись по схеме RSA. 
{
    class prog5
    {
        private string mes;
        public int p { get; }
        public int q { get; }
        public int n { get; }
        public int h0 { get; }
        public int d { get; }
        public int k { get; }
        public int f { get; }
        public int e { get; }

        private int hash;
        private int s;
        private int h;


        public prog5(string mes, int p, int q, int d, int h0)
        {
            this.mes = mes; //Сообщение
            this.p = p; //Значение p
            this.q = q; //Значение q
            this.h0 = h0; //Начальное значение хеша
            this.d = d; //Значение d (выбираем из условий d < φ(n) и d взаимно просто с φ(n))
            n = p * q; //Значение n
            f = (p - 1) * (q - 1); //Функция Эйлера
            e = FindE(); //Знаение e
            Hash(); //Функция нахождения хеш-образа
        }


        public int Hash() //Функция нахождения хеш-образа
        {
            hash = h0;

            foreach (var ch in mes.Substring(0))
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
                else throw new Exception($"Недопустимое значение!");
                hash = func(hash, charIndex);
                Console.WriteLine(hash);
            }
            return hash; //Хеш
        }
        private int func(int a, int b) //Функция нНахождения значений по формуле (H(i)+M(i-1))^2modn
        {
            return (int)BigInteger.ModPow(a + b, 2, n);
        }

        public int Encrypt() //Шифрование
        {
            s = (int)BigInteger.ModPow(hash, d, n);
            return s; //Зашифрованное сообщение
        }
        public int Decrypt() //Дешифрование
        {
            h = (int)BigInteger.ModPow(s, e, n);
            return h; //Расшифрованное сообщение
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

        public string publicKey() { return e + " " + n; } //Открытый ключ
        public string privateKey() { return d + " " + n; } //Закрытый ключ
    }
}



