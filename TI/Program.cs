using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Coding with noise");
            ElementOfVector[] ev = { new ElementOfVector(0), new ElementOfVector(1), new ElementOfVector(0), new ElementOfVector(1) };
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                Console.Write(ev[i]);
            }
            Console.WriteLine();
            // Кодирование 4_7
            Vector initv = new Vector(ev); // исходный вектор
            Vector rezv = new Vector(7); // результирующий вектор
            Vector noise_rezv = new Vector(7); // код с помехой
            Vector indicator = new Vector(3); // индикатор
            Coding4_7 coding4_7 = new Coding4_7(initv); // Кодирование 4_7

            rezv = coding4_7.MakeRezVector();

            Console.ReadKey();

            noise_rezv = coding4_7.RezNoiseStart(rnd.Next(0, 7));
            Console.WriteLine("Code with noise: " + coding4_7.GetRezVector());

            indicator = coding4_7.CalculateID();
            Console.ReadKey();
            /*
            // кодирование 2_8
            Console.WriteLine("Coding with noise");
            ElementOfVector[] ev2 = { new ElementOfVector(1), new ElementOfVector(1) };
            Random rnd2 = new Random();
            for (int i = 0; i < 2; i++)
            {
                Console.Write(ev2[i]);
            }
            Console.WriteLine();
            Vector initv2 = new Vector(ev2); // исходный вектор
            Vector rezv2 = new Vector(8); // результирующий вектор
            Vector noise_rezv2 = new Vector(8); // код с помехой
            Vector indicator1 = new Vector(5); // индикатор
            Vector indicator2 = new Vector(5);

            Coding2_8 coding2_8 = new Coding2_8(initv2); // Кодирование 2_8

            rezv2 = coding2_8.MakeRezVector();

            Console.ReadKey();

            noise_rezv2 = coding2_8.RezNoiseStart(rnd.Next(0, 8), rnd.Next(0, 8));
            Console.WriteLine("Code with noise: " + coding2_8.GetRezVector());

            indicator1 = coding2_8.CalculateID5();
            indicator2 = coding2_8.CalculateID8();

            initv2 = coding2_8.RecoverRezV(indicator1, indicator2);
            Console.WriteLine(initv2);
            Console.ReadKey();*/
        }
    

        
        
    }
}
