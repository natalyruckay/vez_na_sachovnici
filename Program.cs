using System;
using System.Collections.Generic;

namespace uloha4_vez
{
    class Program
    {
        public class Position
        {
            public int x;
            public int y;

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        static void Main(string[] args)
        {
            return;
            int minimal = 0;
            char[,] sachovnica = new char[10, 10];

            for (int i = 0; i < 8; i++)
            {
                string line = Console.ReadLine()+".............";
                for (int j = 0; j < 9; j++)
                {
                    sachovnica[i, j] = line[j];
                }
            }
            int start1 = 0;
            int start2 = 0;
            int ciel1 = 0;
            int ciel2 = 0;
            int index1 = 0;
            for (int i = 0; i <= 9; i++)
            {
                int index2 = 0;
                for (int j = 0; j < 9; j++)
                {
                    string pozicia = sachovnica[i, j].ToString();

                    if (pozicia == "v")
                    {
                        start1 = index1;
                        start2 = index2;
                    }

                    if (pozicia == "c")
                    {
                        ciel1 = index1;
                        ciel2 = index2;
                    }
                    index2 += 1;
                }
                index1 += 1;
            }
            Queue<Position> fronta = new Queue<Position>();
            fronta.Enqueue(new Position(start1, start2));
            
            sachovnica[start1, start2] = (char)0;

            while (sachovnica[ciel1, ciel2].ToString() == "c")
            {
                if (fronta.Count == 0)
                {
                    break;
                }
                else
                {
                    Position top = fronta.Dequeue();
                    int i1 = top.x;
                    int i2 = top.y;
                    int krok = sachovnica[i1, i2] + 1;

                    for (int miesto = i1 + 1; miesto < 8; miesto++)      
                    {
                        if (sachovnica[miesto, i2].ToString() == "x")
                        {
                            break;
                        }
                        if (sachovnica[miesto, i2].ToString() == "c")
                        {
                            sachovnica[miesto, i2] = (char)krok;                        
                        }
                        if (sachovnica[miesto, i2].ToString() == ".")
                        {
                            sachovnica[miesto, i2] = (char)krok;
                            fronta.Enqueue(new Position(miesto, i2));
                        }
                    }

                    for (int miesto = i1 - 1; miesto > -1; miesto--)             
                    {
                        if (sachovnica[miesto, i2].ToString() == "x")
                        {
                            break;
                        }
                        if (sachovnica[miesto, i2].ToString() == "c")
                        {
                            sachovnica[miesto, i2] = (char)krok;
                        }
                        if (sachovnica[miesto, i2].ToString() == ".")
                        {
                            sachovnica[miesto, i2] = (char)krok;
                            fronta.Enqueue(new Position(miesto, i2));
                        }
                    }

                    for (int miesto = i2 + 1; miesto < 8; miesto++)         
                    {
                        if (sachovnica[i1, miesto].ToString() == "x")
                        {
                            break;
                        }
                        if (sachovnica[i1, miesto].ToString() == "c")
                        {
                            sachovnica[i1, miesto] = (char)krok;
                        }
                        if (sachovnica[i1, miesto].ToString() == ".")
                        {
                            sachovnica[i1, miesto] = (char)krok;
                            fronta.Enqueue(new Position(i1, miesto));
                        }
                    }
                    
                    for (int miesto = i2 - 1; miesto > -1;  miesto--)                                        
                    {
                        if (sachovnica[i1, miesto].ToString() == "x")
                        {
                            break;
                        }
                        if (sachovnica[i1, miesto].ToString() == "c")
                        {
                            sachovnica[i1, miesto] = (char)krok;
                        }
                        if (sachovnica[i1, miesto].ToString() == ".")
                        {
                            sachovnica[i1, miesto] = (char)krok;
                            fronta.Enqueue(new Position(i1, miesto));
                        }
                    }
                }
            }

            int result = (int)(sachovnica[ciel1, ciel2]);
            if (result == (int)'c')
            {
                result = -1; 
            }
            Console.WriteLine(result);  
        }
    }
}