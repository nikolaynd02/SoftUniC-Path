using System;

namespace P._02_Wall_Destroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());

            string[,] wall = new string[wallSize, wallSize];

            int[] vankoCordinates = new int[2];

            int maxHoles = 0;
            int holesCount = 0;

            for(int x = 0; x < wallSize; x++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for(int y=0; y < wallSize; y++)
                {
                    wall[x, y] = input[y].ToString();

                    if (input[y] == 'V')
                    {
                        vankoCordinates[0] = x;
                        vankoCordinates[1] = y;
                        wall[x, y] = "*";
                        holesCount++;
                    }
                    if (input[y] == '-')
                    {
                        maxHoles++;
                    }
                }
            }

            int rodsHit = 0;


            string cmd = string.Empty;
            bool dead = false;

            while((cmd = Console.ReadLine())!= "End")
            {
                bool wasHole = false;
                if (cmd == "left")
                {
                    vankoCordinates[1]--;

                    if (ValidateCordanates(vankoCordinates, wallSize))
                    {
                        if (wall[vankoCordinates[0], vankoCordinates[1]] == "R")
                        {
                            rodsHit++;
                            vankoCordinates[1]++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if(wall[vankoCordinates[0], vankoCordinates[1]] == "C")
                        {
                            wall[vankoCordinates[0], vankoCordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++holesCount} hole(s).");
                            dead = true;
                            break;
                        }
                        else
                        {
                            if(wall[vankoCordinates[0], vankoCordinates[1]] == "-")
                            {
                                wall[vankoCordinates[0], vankoCordinates[1]] = "*";
                                holesCount++;
                            }
                            else
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vankoCordinates[0]}, {vankoCordinates[1]}]!");
                            }
                            
                        }
                    }
                    else
                    {
                        vankoCordinates[1]++;
                    }
                }
                else if (cmd == "right")
                {
                    vankoCordinates[1]++;

                    if (ValidateCordanates(vankoCordinates, wallSize))
                    {
                        if (wall[vankoCordinates[0], vankoCordinates[1]] == "R")
                        {
                            rodsHit++;
                            vankoCordinates[1]--;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vankoCordinates[0], vankoCordinates[1]] == "C")
                        {
                            wall[vankoCordinates[0], vankoCordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++holesCount} hole(s).");
                            dead = true;
                            break;
                        }
                        else
                        {
                            if (wall[vankoCordinates[0], vankoCordinates[1]] == "-")
                            {
                                wall[vankoCordinates[0], vankoCordinates[1]] = "*";
                                holesCount++;
                            }
                            else
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vankoCordinates[0]}, {vankoCordinates[1]}]!");
                            }
                        }
                    }
                    else
                    {
                        vankoCordinates[1]--;
                    }
                }
                else if (cmd == "up")
                {
                    vankoCordinates[0]--;

                    if (ValidateCordanates(vankoCordinates, wallSize))
                    {
                        if (wall[vankoCordinates[0], vankoCordinates[1]] == "R")
                        {
                            rodsHit++;
                            vankoCordinates[0]++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vankoCordinates[0], vankoCordinates[1]] == "C")
                        {
                            wall[vankoCordinates[0], vankoCordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++holesCount} hole(s).");
                            dead = true;
                            break;
                        }
                        else
                        {
                            if (wall[vankoCordinates[0], vankoCordinates[1]] == "-")
                            {
                                wall[vankoCordinates[0], vankoCordinates[1]] = "*";
                                holesCount++;
                            }
                            else
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vankoCordinates[0]}, {vankoCordinates[1]}]!");
                            }
                        }
                    }
                    else
                    {
                        vankoCordinates[0]++;
                    }
                }
                else if (cmd == "down")
                {
                    vankoCordinates[0]++;

                    if (ValidateCordanates(vankoCordinates, wallSize))
                    {
                        if (wall[vankoCordinates[0], vankoCordinates[1]] == "R")
                        {
                            rodsHit++;
                            vankoCordinates[0]--;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else if (wall[vankoCordinates[0], vankoCordinates[1]] == "C")
                        {
                            wall[vankoCordinates[0], vankoCordinates[1]] = "E";
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++holesCount} hole(s).");
                            dead = true;
                            break;
                        }
                        else
                        {
                            if (wall[vankoCordinates[0], vankoCordinates[1]] == "-")
                            {
                                wall[vankoCordinates[0], vankoCordinates[1]] = "*";
                                holesCount++;
                            }
                            else
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vankoCordinates[0]}, {vankoCordinates[1]}]!");
                            }
                        }
                    }
                    else
                    {
                        vankoCordinates[0]--;
                    }
                }
            }

            if (!dead)
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsHit} rod(s).");
            }

            for(int x = 0; x < wallSize; x++)
            {
                for(int y = 0; y < wallSize; y++)
                {
                    if(vankoCordinates[0] == x && vankoCordinates[1] == y && !dead)
                    {
                        Console.Write('V');
                    }
                    else
                    {
                        Console.Write(wall[x,y]);
                    }
                }
                Console.WriteLine();
            }
            
        }

        static bool ValidateCordanates(int[] vanko,int size)
        {
            if (vanko[0] >= 0 && vanko[0] < size && vanko[1] >= 0 && vanko[1] < size)
            {
                return true;
            }

            return false;
        }


    }
}
