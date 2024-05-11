using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Itog_work_2
{



    internal class Program
    {
        public class treug
        {
            public int[] cords = new int[6];
            public int searhzn = 100;

            public void check(int[] points)
            {
                int Inn = 0;
                int Out = 0;
                for (int p = 0; p < points.Length; p += 2)
                {
                    if (cords.Contains(points[p]) && cords.Contains(points[p + 1])) continue;
                    else
                    {

                        int ax;
                        int ay;
                        int bx;
                        int by;
                        int[] ch = new int[3];
                        int[] extcords = new int[8] { cords[0] , cords[1], cords[2], cords[3], cords[4], cords[5], cords[0], cords[1] };
                        for (int i = 0; i < 6; i += 2)//переписать завтра
                        {
                            ax = points[p] - extcords[i];
                            ay = points[p + 1] - extcords[i + 1];

                            bx = extcords[i + 2] - extcords[i];
                            by = extcords[i + 3] - extcords[i + 1];
                            ch[i / 2] = ax * by - ay * bx;
                        }
                        if (((ch[0] > 0) && (ch[1] > 0) && (ch[2] > 0)) || ((ch[0] < 0) && (ch[1] < 0) && (ch[2] < 0))) Inn++;
                        else Out++;


                    }
                }
                searhzn = Out - Inn;
            }

         
        }
        static void Main(string[] args)
        {
            
            
            
            
            int factorial(int fact) // Функция для подсчёта факториала
            {
                int h1 = fact;
                int h2 = 1;
                
                {
                    for (int i = 1; i <= h1; i++)
                    {
                        h2 *= i;
                    }
                }
                return h2;
            }



            Console.WriteLine("Введите количество точек N");
            int N = Convert.ToInt32( Console.ReadLine());

            var rand = new Random();
            int[] points= new int[2*N];

            for (int j = 0; j < 2*N; j++) //Создаём массив злучайных значений
            {
                points[j] = rand.Next(40);
            }

            for (int i = 0;i < 2*N; i += 2)
            {
                Console.WriteLine($"{points[i]} {points[i+1]}");
            }

            int treug_number=0;
            for (int n = 0; n < N-2; n++)
            {
                treug_number += factorial(N - n - 1) * factorial(N - n - 2) * factorial(N - n - 3);
                Console.WriteLine(treug_number);
            }
            var trs = new treug[treug_number].Select(h => new treug()).ToArray(); ;//создаём массив треугольников

            Console.WriteLine($"теперь ждите пока заполнится {treug_number} треугольников \nзаполняем треугольники");
            for (int i = 0; i < trs.Length; i++)//заполняем массив треугольников
            {
                for (int j = 0;j<points.Length-2; j += 2)
                {
                    for (int k = 0; k < points.Length-j-2; k += 2)
                    {
                        trs[i].cords[0] = points[j];
                        trs[i].cords[1] = points[j+1];
                        trs[i].cords[2] = points[k];
                        trs[i].cords[3] = points[k+1];
                        trs[i].cords[4] = points[k+2];
                        trs[i].cords[5] = points[k+3];
                        trs[i].check(points);
                        
                    }
                }

            }

            int minim=100;
            for (int i = 0; i < trs.Length; i++)
            {
                if (trs[i].searhzn<minim)
                {
                    minim = trs[i].searhzn;
                }

            }

            for (int i = 0; i < trs.Length; i++)
            {
                if (trs[i].searhzn == minim)
                {
                    for (int j = 0; j < 6; j++) {
                        Console.Write(trs[i].cords[j]);
                        Console.Write(' ');   
                    }
                    break;
                }
            }

            Console.ReadKey();


        }
    }
}
