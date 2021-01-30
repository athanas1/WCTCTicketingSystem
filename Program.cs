using System;
using System.IO;

namespace WCTCTicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Ticket.csv";
            string choice;
            

            do {

                //Asks the user what to do
                System.Console.WriteLine("1) Read the data from the file");
                System.Console.WriteLine("2) Create a file from data");
                System.Console.WriteLine("Press any other key to exit the application");

                //getting user input
                choice = Console.ReadLine();
                
                if(choice == "1")
                {
                    //checking for file
                    if(File.Exists(file)){
                        //Reading data from file
                        StreamReader sr = new StreamReader(file);
                        while(!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            //converting each string to an array with split with a ,
                            string[] arr = line.Split(',');
                            //output the array?
                            System.Console.WriteLine(arr);

                        }
                    }

                } else if (choice == "2")
                {
                    //Creating a file with the data
                    StreamWriter sw = new StreamWriter(file);
                    //To get ID's that increment we need to be able to read the last ID generated
                    StreamReader sr = new StreamReader(file);
                }
            } 
            while (choice == "1"|| choice == "2");
        }
    }
}
