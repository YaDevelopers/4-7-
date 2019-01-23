using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI
{
    class Coding2_8
    {
        Vector rezv2 = new Vector(8); // Результирующий вектор(8)
        Vector v = new Vector(2); // Исходный вектор(2)
        Random r = new Random();
        public Coding2_8 (Vector v) // Конструктор
        {
            this.v = v;
        }
        public Vector GetRezVector() { return rezv2; } // Получение результирующего вектора

        public Vector RezNoiseStart(int index, int index2) // Создание помех в определенных индексах
        {
            ElementOfVector ev = new ElementOfVector(1);
            if (index < 0 || index > rezv2.size) { Console.WriteLine("Неправильный индекс!"); return new Vector(0); }
            rezv2.data[index] += ev;
            rezv2.data[index2] += ev;
            return rezv2;
            
        }

        public Vector MakeRezVector() // Создание результирующего вектора
        {
            rezv2.data[4] = v.data[0];
            rezv2.data[7] = v.data[1];

            rezv2.data[2] = rezv2.data[4];
            rezv2.data[3] = rezv2.data[4];
            rezv2.data[5] = rezv2.data[7];
            rezv2.data[6] = rezv2.data[7];
            rezv2.data[0] = rezv2.data[4] + rezv2.data[7];
            rezv2.data[1] = rezv2.data[4] + rezv2.data[7];
            
            Console.WriteLine("Result code:" + rezv2);
            return rezv2;
        }

        public Vector CalculateID5() // Вычисление индикатора для 5
        {
            Vector temp2 = new Vector(6);
            ElementOfVector ev = new ElementOfVector(1);
            temp2.data[0] = rezv2.data[0] + rezv2.data[5];
            temp2.data[1] = rezv2.data[1] + rezv2.data[6];
            temp2.data[2] = rezv2.data[2];
            temp2.data[3] = rezv2.data[3];
            temp2.data[4] = rezv2.data[4];
            
            Console.Write("Indicator5:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(temp2.data[i].EV_Value);
            }
            Console.WriteLine();
            return temp2;
                       
        }
        public Vector CalculateID8() // Вычисление индикатора для 8
        {
            Vector temp2 = new Vector(6);
            ElementOfVector ev = new ElementOfVector(1);
            temp2.data[0] = new ElementOfVector(rezv2.data[0] + rezv2.data[2]);
            temp2.data[1] = new ElementOfVector(rezv2.data[1] + rezv2.data[3]);
            temp2.data[2] = new ElementOfVector(rezv2.data[5]);
            temp2.data[3] = new ElementOfVector(rezv2.data[6]);
            temp2.data[4] = new ElementOfVector(rezv2.data[7]);

            Console.Write("Indicator8:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(temp2.data[i].EV_Value);
            }
            Console.WriteLine();
            return temp2;
        }

        
        
        public Vector RecoverRezV(Vector indicator5, Vector indicator8) // Подсчет 0 или 1
        {
            ElementOfVector ev = new ElementOfVector();
            Vector rezv = new Vector(2);
            int counter0 = 0, counter1 = 0;

            for (int i = 0; i < 5; i++ )
            {
                if (indicator5.data[i] == ev)
                {
                    counter0++;
                }
                else counter1++;
            }
            if (counter0 > counter1) rezv.data[0] = new ElementOfVector(0);
            else rezv.data[0] = new ElementOfVector(1);
            counter0 = 0;
            counter1 = 0;

            for (int i = 0; i < 5; i++)
            {
                if (indicator8.data[i] == ev)
                {
                    counter0++;
                }
                else counter1++;
            }
            if (counter0 > counter1) rezv.data[1] = new ElementOfVector(0);
            else rezv.data[1] = new ElementOfVector(1);

            return rezv;
               
                
        }
    }
}

