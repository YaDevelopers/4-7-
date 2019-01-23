using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI
{
    class Coding4_7
    {
        Vector rezv = new Vector(7); // Результирующий вектор(7)
        Vector v; // Исходный вектор(4)

        public Coding4_7(Vector v) // Конструктор
        {
            this.v = v;
        }
        public Vector GetRezVector() { return rezv; } // Получение результирующего вектора

        public Vector RezNoiseStart(int index) // Создание помех в определенном индексе
        {
            ElementOfVector ev = new ElementOfVector(1);
            if (index < 0 || index > rezv.size) { Console.WriteLine("Неправильный индекс!"); return new Vector(0); }
            rezv.data[index] += ev;
            return rezv;
        }

        public Vector MakeRezVector() // Создание результирующего вектора
        {
            rezv.data[0] = v.data[0] + v.data[1] + v.data[3];
            rezv.data[1] = v.data[0] + v.data[2] + v.data[3];
            rezv.data[3] = v.data[1] + v.data[2] + v.data[3];

            rezv.data[2] = v.data[0];
            rezv.data[4] = v.data[1];
            rezv.data[5] = v.data[2];
            rezv.data[6] = v.data[3];
            Console.WriteLine("Result code:" + rezv);
            return rezv;
        }
        public int inTen(ElementOfVector[] data)
        {
            string s = "";
            int itog = 0;
            int p = 1;

            foreach (var e in data)
            {
                s += Convert.ToString(e.EV_Value);
            }

           
            if (s == "000")
                return -1;
            else
            {
                for (int i = s.Length - 1; i > -1; i--)
                {
                    itog += (Convert.ToInt32(s[i])-48) * p;
                    p *= 2;
                }
                return itog;
            }
        }

        public Vector CalculateID() // Вычисление индикатора, нахождение позиции с ошибкой и пишем исправленный результирующий код
        {

            Vector temp = new Vector(3);
            ElementOfVector ev = new ElementOfVector(1);
            temp.data[0] = new ElementOfVector(rezv.data[3] + rezv.data[4] + rezv.data[5] + rezv.data[6]);
            temp.data[1] = new ElementOfVector(rezv.data[1] + rezv.data[2] + rezv.data[5] + rezv.data[6]);
            temp.data[2] = new ElementOfVector(rezv.data[0] + rezv.data[2] + rezv.data[4] + rezv.data[6]);
            Console.Write("Indicator:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(temp.data[i].EV_Value);
            }

            if (inTen(temp.data) == -1)
            {
                Console.WriteLine("No Error");
                rezv.data[0] += ev;
            }

            else
            {
                Console.WriteLine($"Error in {inTen(temp.data)} position");

                Console.WriteLine(inTen(temp.data)); 
                rezv.data[inTen(temp.data)-1] += ev;
            }

            Console.WriteLine(($"Исправленный код : {rezv}"));

            return rezv;


        }
           
            
        

        
    }
}