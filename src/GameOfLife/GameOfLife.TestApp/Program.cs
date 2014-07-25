using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife.TestApp
{
    public static class Program
    {
        public static void Main()
        {
            var m = 50;
            var n = 50;
            var processor = new Processor(m, n);
            //Console.WriteLine(processor.Field.ToString());
            //Console.ReadKey();
            //Console.WriteLine();
            processor.SetAliveCell(3, 3);
            processor.SetAliveCell(4, 4);
            processor.SetAliveCell(5, 2);
            processor.SetAliveCell(5, 3);
            processor.SetAliveCell(5, 4);
            //processor.SetAliveCell(3, 3);
            //processor.SetAliveCell(4, 2);
            Console.WriteLine(processor.Field.ToString());
            Console.ReadKey();
            //processor.SetAliveCell(1, 1);

            while(true)
            {
                Console.Clear();
                processor.ProcessField();
                Console.WriteLine(processor.Field.ToString());
                Thread.Sleep(200);
            }

            //Console.WriteLine(processor.Field.ToString());
            //Console.ReadKey();
            //Console.WriteLine();
            //processor.ProcessField();
            //Console.WriteLine(processor.Field.ToString());
            //Console.ReadKey();
            //Console.WriteLine();

        }
    }
}
