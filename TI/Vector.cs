using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI
{
    class Vector
    {
        public int size;// Размер вектора
        public ElementOfVector[] data; // Массив элементов вектора

        public Vector(int size) // Конструктор
        {
            this.size = size;
            data = new ElementOfVector[size];
            for (int i = 0; i < this.size; i++)
            {
                data[i] = new ElementOfVector();
            }
        }
        public Vector(ElementOfVector[] ev) // Конструктор
        {
            size = ev.Length;
            data = new ElementOfVector[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = ev[i];
            }
        }
        public Vector(Vector v) // Конструктор
        {
            size = v.size;
            data = new ElementOfVector[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = new ElementOfVector(v.data[i]);
            }
        }
        public Vector Copy() // Метод копирует данный вектор
        {
            return new Vector(this);
        }

        public bool SetElement(ElementOfVector elementOfVector, int index) // Задание элемента вектора
        {
            if (index < 0 || index > size) return false;
            data[index] = elementOfVector;
            return true;
        }
        public ElementOfVector GetElement(int index) // Получение элемента
        {
            if (index < 0 || index > size)
            {
                Console.WriteLine("Error");
                return default(ElementOfVector);
            }
            return data[index];
        }

        public override string ToString()
        {
            string s = "(";
            for (int i = 0; i < size - 1; i++)
            {
                s = s + data[i].ToString() + ",";
            }
            s = s + data[size - 1].ToString() + ")";
            return s;
        }
        public ElementOfVector this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        public static Vector operator +(Vector v1, Vector v2) // Override operator +
        {
            if (v1.size == v2.size)
            {
                Vector temp = new Vector(v2.size);
                for (int i = 0; i < temp.size; i++) temp.data[i] = v1.data[i] + v2.data[i];
                return temp;
            }
            return null;
        }
        public static Vector operator -(Vector v1, Vector v2) // Override operator -
        {
            if (v1.size == v2.size)
            {
                Vector temp = new Vector(v2.size);
                for (int i = 0; i < temp.size; i++) temp.data[i] = v1.data[i] - v2.data[i];
                return temp;
            }
            return null;
        }

    } 
}
























/*public Vector Add(Vector c)
        {
            Vector rez = new Vector(size);
            for(int i = 0; i < size; i++)
            {
                rez.data[i] = data[i] + c.data[i];
                return rez;
            }
        }
        public int Value { get; set; }

        public bool VectorsCheck()
        {
            if(Value!=0 || Value!= 1){
                return false;
            }
            return true;
        }
        public int SumWithModule2(Vector b, Vector c)
        {
            if(b.Value==0 && c.Value == 0)
            {
                return 0;
            }else if((b.Value == 1 && c.Value == 0) || (b.Value == 0 && c.Value == 1))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }*/
