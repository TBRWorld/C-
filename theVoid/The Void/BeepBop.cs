using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Void
{
    internal class BeepBop
    {
        public void beep()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input[0] == 'b' && input[input.Length - 1] == 'p')
                {
                    bool crashHandler = false;
                    int length = 0;
                    int pitchSelector = 0;
                    for (int i = 1; i < input.Length - 1; i++)
                    {
                        if (input[i] == 'e')
                        {
                            pitchSelector = 1000;
                            length += 250;
                        }
                        else if (input[i] == 'o')
                        {
                            pitchSelector = 500;
                            length += 250;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    internal class StationPuzzle
    {
        public void solve()
        {
            string input = Console.ReadLine().Replace(" ", "");
            char[] inputArray = input.ToCharArray(); //do this in UTF-8

            //int totalCombo = inputArray.length * smth to calculate the total combo amount

            char[] scrambleArray = inputArray;
            //string[] outputArray = new string[totalCombo];

            bool killSwitch = false;
            while(!killSwitch) 
            {
                if (scrambleArray[0] == inputArray[inputArray.Length-1] && scrambleArray[scrambleArray.Length-1] == inputArray[0])
                {
                    killSwitch = true;
                    break;
                }



            }

            
        }
    }
}
