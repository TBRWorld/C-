using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace administrationConsole
{
    internal class Menu
    {
        public void menu()
        {
            Console.Write("\r\n░██████╗██╗░░░██╗░██████╗░██████╗██╗░░░██╗  ░█████╗░███╗░░░███╗░█████╗░███╗░░██╗░██████╗░  ██╗░░░██╗░██████╗\r\n██╔════╝██║░░░██║██╔════╝██╔════╝╚██╗░██╔╝  ██╔══██╗████╗░████║██╔══██╗████╗░██║██╔════╝░  ██║░░░██║██╔════╝\r\n╚█████╗░██║░░░██║╚█████╗░╚█████╗░░╚████╔╝░  ███████║██╔████╔██║██║░░██║██╔██╗██║██║░░██╗░  ██║░░░██║╚█████╗░\r\n░╚═══██╗██║░░░██║░╚═══██╗░╚═══██╗░░╚██╔╝░░  ██╔══██║██║╚██╔╝██║██║░░██║██║╚████║██║░░╚██╗  ██║░░░██║░╚═══██╗\r\n██████╔╝╚██████╔╝██████╔╝██████╔╝░░░██║░░░  ██║░░██║██║░╚═╝░██║╚█████╔╝██║░╚███║╚██████╔╝  ╚██████╔╝██████╔╝\r\n╚═════╝░░╚═════╝░╚═════╝░╚═════╝░░░░╚═╝░░░  ╚═╝░░╚═╝╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚══╝░╚═════╝░  ░╚═════╝░╚═════╝░\r\n\r\n██╗░░██╗  ██╗███╗░░██╗░█████╗░░░░\r\n██║░░██║  ██║████╗░██║██╔══██╗░░░\r\n███████║  ██║██╔██╗██║██║░░╚═╝░░░\r\n██╔══██║  ██║██║╚████║██║░░██╗░░░\r\n██║░░██║  ██║██║░╚███║╚█████╔╝██╗\r\n╚═╝░░╚═╝  ╚═╝╚═╝░░╚══╝░╚════╝░╚═╝\n\n\n");

            Console.Write("map path: ");
            Globals.folderPath = Console.ReadLine() + "\\";

            //check alle bestanden en of path bestaat

            Console.Clear();
            cmdNav();
        }

        //navigatie van de administratieprogramma
        public void cmdNav()
        {
            while (true)
            {
                Console.Write(Globals.folderPath + ": ");
                string input = Console.ReadLine();

                if (input == "h" || input == "-h" || input == "help") cmdHelp();
                else if (input == "dir" || input == "ls") cmdDir();
                else if (input.Contains("add"))
                {
                    input = input.Replace("add ", "");
                    cmdCreate(input);
                }
                else if (input.Contains("rmv"))
                {
                    input = input.Replace("rmv ", "");
                    cmdRemove(input);
                }
                else if (input.Contains("edit"))
                {
                    input = input.Replace("edit ", "");
                    cmdEdit(input);
                }
                else if (input.Contains("open"))
                {
                    input = input.Replace("open ", "");
                    cmdOpen(input);
                }
                else if (input == "clr" || input == "clear") Console.Clear();
                else if (input == "ext" || input == "exit") Environment.Exit(0);
                else if (input == "bop") Console.Beep(500, 500);
                else if (input == "beepbop") { Console.Beep(1000, 500); Console.Beep(500, 500); }
                else if (input == "bopbeep") { Console.Beep(500, 500); Console.Beep(1000, 500); }
                else if (input[0] == 'b' && input[input.Length - 1] == 'p')
                {
                    bool killSwitch = false;
                    int length = 0;
                    int pitchSelector = 0;
                    for(int i = 1; i < input.Length - 1; i++)
                    {
                        if (input[i] == 'e')
                        {
                            pitchSelector = 1000;
                            if (input[i] == 'e') length += 250;
                            else
                            {
                                killSwitch = true;
                                break;
                            }
                        }
                        else if (input[i] == 'o')
                        {
                            pitchSelector = 500;
                            if (input[i] == 'o') length += 250;
                            else
                            {
                                killSwitch = true;
                                break;
                            }
                        }
                        else
                        {
                            killSwitch = true;
                            break;
                        }
                    }
                    if(length >= 500 && !killSwitch) Console.Beep(pitchSelector, length);
                }
                //add edit+
                //add search
                //change path
            }
        }
        //help command
        public void cmdHelp()
        {
            Console.Write("Welcome to the SUSSY AMONG US H INC. admin panel.\n" +
                "We have a variety of commands for you to navigate this shithole of a system!\n" +
                "h - help\ndir - check your current directionary\n" +
                "clr - clear the console of all your jibberish\n" +
                "add \"name\" - add a new entry\n" +
                "rmv \"name\" - remove a entry\n" +
                "edit - edit a existing entry\n");
        }

        public void cmdOpen(string fileName)
        {
            //check if file exists, and alow multiple ways to check
            string filePath = Globals.folderPath + fileName;
            do
            {
                if (File.Exists(filePath) == false)
                {
                    if (fileName == "null") break;
                    Console.Write(filePath + " does not exist!\n");
                    return;
                }
            } while (false);


            FileStream fsRead = File.Open(filePath, FileMode.Open, FileAccess.Read);
            byte[] readArr = new byte[new FileInfo(filePath).Length];

            fsRead.Read(readArr, 0, readArr.Length);
            fsRead.Close();

            string output = Encoding.UTF8.GetString(readArr);
            Console.WriteLine(output);
            fsRead.Close();
        }

        //directory command
        public void cmdDir()
        {
                string[] files = Directory.GetFiles(Globals.folderPath);
                foreach (string file in files)
                {
                    Console.WriteLine(file.Replace(Globals.folderPath, ""));
                }          
        }
        
        //create entry command
        public void cmdCreate(string fileName)
        {
            Console.Title= "AMONG US H INC. Create file:";

            //error handling (file exists?)
            string filePath = Globals.folderPath + fileName;
            if (File.Exists(filePath))
            {
                Console.Write("File already exists! Do you wish to overwrite?\nY/N:");
                string input = Console.ReadLine();
                if (input == "Y")
                {
                    File.Delete(filePath);
                }
                else return;
            }

            Boolean extra = false;
            string extraContent = "";

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Phone Number: ");
            string number = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Date Of Birth: ");
            string DoB = Console.ReadLine();


            //additional lines if user pleases to do so
            Console.Write("Would you like to add additional info?\nY/N: ");
            while (true) 
            {
                string choice = Console.ReadLine();
                if (choice == "Y")
                {
                    extra = true;
                    break;
                }
                else if (choice == "N") break;
            }
            
            if (extra == true)
            {
                bool loop = true;
                Console.Write("Exit by writing \"exit\" at a new line\n");
                while (loop == true)
                {
                    string text = Console.ReadLine();
                    if (text == "exit")
                    {
                        loop = false;
                    }
                    else extraContent += text + "\n";
                }
            }

            //write when done
            FileStream fs = File.Create(filePath);

            string output = "Email: " + email + "\nName: " + name + "\nPhone Number: " + number + "\nAddress: " + address + "\nDate Of Birth: " + DoB + "\n";
            if (extra == true) output += "Additional:\n" + extraContent + "\n";

            fs.Write(Encoding.UTF8.GetBytes(output), 0, Encoding.UTF8.GetByteCount(output));
            fs.Close();

            Console.Clear();
            Console.Write(filePath + " Succesfully Created!\n" + output);
        }

        //remove command
        public void cmdRemove(string fileName)
        {
            Console.Title = "AMONG US H INC. Remove File:";

            //check if file exists
            string filePath = Globals.folderPath + fileName;
            if (File.Exists(filePath) == false)
            {
                Console.Write(filePath + " does not exist!\n");
                return;
            }
            else
            {
                File.Delete(filePath);
                Console.Write(filePath + " has been removed!\n");
            }
        }

        //edit entry command
        public void cmdEdit(string fileName)
        {
            Console.Title = "AMONG US H INC. Edit File:";

            //check if file exists, and alow multiple ways to check
            string filePath = Globals.folderPath + fileName;
            do
            {
                if (File.Exists(filePath) == false)
                {
                    if (fileName == "null") break;
                    Console.Write(filePath + " does not exist!\n");
                    return;
                }
            } while (false);

            Console.Clear();

            //read file
            FileStream fsRead = File.Open(filePath, FileMode.Open, FileAccess.Read);
            byte[] readArr = new byte[new FileInfo(filePath).Length];

            fsRead.Read(readArr, 0, readArr.Length);
            fsRead.Close();

            string output = Encoding.UTF8.GetString(readArr);

            //output = Regex.Replace(output, @"[^\x20-\x7E]", "");

            fsRead.Close();


            //make tag (expand later) also copied from chatgpt
            string[] lines = output.Split(new[] { "\r\n", "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries); 
            string[] tag = lines.Select(line =>
            {
                string cleanTag = line.Split(':')[0] + ":"; // Re-add colon
                cleanTag = Regex.Replace(cleanTag, @"[^\x20-\x7E]", ""); // Remove non-printable ASCII characters
                return cleanTag.Trim();
            }).ToArray();


            //Select the first tag display and select
            int tagInt = 0;
            string selectedTag = tag[tagInt];

            //confirmation of selection
            bool killSwitchConfirm = false;
            while (killSwitchConfirm == false)
            {
                //select tag
                bool killSwitchChoose = false;
                while (!killSwitchChoose)
                {
                    Console.Clear();

                    //background color to indicate selection
                    //fix lines without tags being displayed
                    foreach (string line in lines)
                    {
                        if (line.TrimStart().StartsWith(selectedTag))
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(line.Trim());
                    }

                    //Tag selection
                    Console.Write("\nSelect what tag to edit (arrows or text): ");

                    ConsoleKeyInfo keyPressed = Console.ReadKey(intercept: true);

                    if (keyPressed.Key == ConsoleKey.DownArrow) tagInt++;
                    else if (keyPressed.Key == ConsoleKey.UpArrow) tagInt--;
                    else if (keyPressed.Key == ConsoleKey.Enter) killSwitchChoose = true;
                    else
                    {
                        string tagString = Console.ReadLine().Trim();
                        bool tagHasBeenWritten = false;

                        for (int i = 0; i < tag.Length; i++)
                        {
                            string trimmedTag = tag[i].Trim();

                            if (tagString.Equals(trimmedTag, StringComparison.OrdinalIgnoreCase))
                            {
                                tagInt = i;
                                killSwitchChoose = true;
                                tagHasBeenWritten = true;
                                //instead of writeline reset and select the tag with background
                                Console.WriteLine("Tag found!");
                                break;
                            }
                        }
                    }


                    if (tagInt >= tag.Length) tagInt = 0;
                    else if (tagInt < 0) tagInt = tag.Length - 1;

                    selectedTag = tag[tagInt];
                }

                Console.WriteLine("Confirm selection? Y/N: ");
                string confirm = Console.ReadLine();
                if (confirm == "Y") killSwitchConfirm = true;
                else if (confirm == "N") killSwitchConfirm = false;
            }

            Console.Clear();

            //edit tag
            Console.Write(tag[tagInt] + " ");

            lines[tagInt] = tag[tagInt] + " " + Console.ReadLine();
            Console.WriteLine(lines[tagInt]);

            using (FileStream fsWrite = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                    string lineWithNewline = line + Environment.NewLine;
                    fsWrite.Write(Encoding.UTF8.GetBytes(lineWithNewline), 0, Encoding.UTF8.GetByteCount(lineWithNewline));
                }
            }

        }
    }
}
