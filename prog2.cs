using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMiSOIB
//Шифрование ГОСТ 28147-89
//Выполните первый цикл алгоритма шифрования ГОСТ 28147 89 в режиме простой замены. 
//Для получения 64 бит исходного текста используйте 8 первых букв из своих данных: Фамилии Имени Отчества. 
//Для получения ключа (256 бит) используют текст, состоящий из 32 букв. Первый подключ содержит первые 4 буквы.

{
    class prog2
    {
        private string msg;
        private string k;
        public string l0, r0, x0, R0X0sum32, resBlocks, sdvig11, res;
        public prog2(string message, string key)
        {
            this.msg = message;
            this.k = key;
            Init();
        }

        private void Init()
        {
            l0 = Utills.StickedBinaryMsg(msg.Substring(0, msg.Length / 2)); //L0 (32 бит)
            r0 = Utills.StickedBinaryMsg(msg.Substring(msg.Length / 2, msg.Length / 2)); //R0 (32 бит)
            x0 = Utills.StickedBinaryMsg(k); //X0 (32 бит), ключ
            R0X0sum32 = Utills.Modulo2Pow32(r0, x0); //Сумма блоков R0 и X0 по модулю 2 в степени 32
            resBlocks = func(R0X0sum32); //Преобразование с помощью блока подстановки
            sdvig11 = Utills.Shift(resBlocks, -11); // сдвиг на 11 бит влево, f(R0, X0)
            res = Utills.Modulo2(l0, sdvig11); //Результат (R1): сумма по модулю 2 L0 и f(R0, X0)
        }

        //Функция подстановки
        private string func(string c)
        {
            StringBuilder resStr = new StringBuilder();
            string[] blocks = Utills.BinaryFormat(c, 4).Split(' ');
            int col = 0;
            int row;

            foreach (var b in blocks)
            {
                row = Convert.ToInt32(b, 2);
                resStr.Append(Utills.BinaryFormat(Convert.ToString(Table1[row, col], 2), 4));
                col++;
            }

            return resStr.ToString();
        }

    //Таблица подстановки
    private readonly int[,] Table1 = new int[,]
        {
            // Столбцы - номера блоков, строки - десятичноt значение блоков
           // 8   7  6  5  4  3  2   1.
            { 1, 13, 4, 6, 7, 5, 14, 4 },       //0
            { 15, 11, 11, 12, 13, 8, 11, 10 },  //1
            { 13, 4, 10, 7, 10, 1, 4, 9 },      //2
            { 0, 1, 0, 1, 1, 13, 12, 2 },       //3
            { 5, 3, 7, 5, 0, 10, 6, 13 },       //4
            { 7, 15, 2, 15, 8, 3, 13, 8 },      //5
            { 10, 5, 1, 13, 9, 4, 15, 0 },      //6
            { 4, 9, 13, 8, 15, 2, 10, 14 },     //7
            { 9, 0, 3, 4, 14, 14, 2, 6 },       //8
            { 2, 10, 6, 10, 4, 15, 3, 11 },     //9
            { 3, 14, 8, 9, 6, 12, 8, 1 },       //10
            { 14, 7, 5, 14, 12, 7, 1, 12 },     //11
            { 6, 6, 9, 0, 11, 6, 0, 7 },        //12
            { 11, 8, 12, 3, 2, 0, 7, 15 },      //13
            { 8, 2, 15, 11, 5, 9, 5, 5 },       //14
            { 12, 12, 14, 2, 3, 11, 9, 3 }      //15
        };


    }
}
