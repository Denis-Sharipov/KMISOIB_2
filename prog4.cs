using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KMiSOIB
{
    //Хеш-функция
    //Найти хеш–образ своей Фамилии, используя хеш–функцию Hi = (Hi-1 +Mi)^2modn, 
    //где n = pq, p, q взять из Задания №3. 
    class prog4
    {
        private string message;
        public int p { get; }
        public int q { get; }
        public int n { get; }
        public int h0 { get; }

        private int hash;

        public prog4(string message, int p, int q, int h0) 
        {
            this.message = message; //Сообщение
            this.p = p; //Значение p
            this.q = q; //Значение q
            this.h0 = h0; //Навчальное значение хеша
            n = p * q; //Значение n
        }

        public int Hash() //Функция нахождения хеш-образа
        {
            hash = h0;

            foreach (var ch in message.Substring(0))
            {
                int charIndex; //Индекс по алфавиту
                if (Alphabet.GetCharCode(ch) >= 192 && Alphabet.GetCharCode(ch) <= 223)
                {
                    charIndex = Alphabet.GetCharCode(ch) - 191;
                }
                else if (Alphabet.GetCharCode(ch) >= 224 && Alphabet.GetCharCode(ch) <= 255)
                {
                    charIndex = Alphabet.GetCharCode(ch) - 223;
                }
                else throw new Exception($"Недопустимое значение!"); 

                hash = hashFunc(hash, charIndex);
                Console.WriteLine(hash);
            }
            return hash;
        }
        private int hashFunc(int a, int b) //Хеш-функция
        {
            return (int)BigInteger.ModPow(a + b, 2, n);
        }
    }
}
