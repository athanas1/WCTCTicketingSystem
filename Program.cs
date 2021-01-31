using System;
using System.IO;
using System.Collections.Generic;

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
                Console.WriteLine("1) Read the data from the file");
                Console.WriteLine("2) Add a ticket to data");
                Console.WriteLine("Press any other key to exit the application");

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
                            string str = String.Join(",", arr);
                            Console.WriteLine(str);

                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }

                } else if (choice == "2")
                {
                    //increment each ticket in for loop for unique id's?
                    int id = 0;
                    int x = 0;
                    string answer;
                    //I tried using a normal string array for this but found trying to increase the size of it to be a pain.
                    //Is there a better way to do this without List or was using List correct?
                    //-------------
                    List<string> watchers = new List<string>();
                    string ticketid = "";
                    
                    //To get ID's that increment we need to be able to read the last ID generated
                    StreamReader sr = new StreamReader(file);
                    while(!sr.EndOfStream){
                        //this goes through all strings in the 0 place on the array and grabs the last one entered
                        string line = sr.ReadLine();
                        string[] arr = line.Split(",");
                        //setting the ticketid string to the whatever the latest value is in the array
                        ticketid = arr[0];
                        //checking if ticket id is the string or an int value, had to do this because if I try to parse int "TicketID" shit blew up
                        if(ticketid == "TicketID"){
                            id = 0;
                        } else{
                            id = Int32.Parse(ticketid);
                        }
                    }
                    sr.Close();
                     //Creating a file with the data
                    StreamWriter sw = new StreamWriter(file, true);
                    //Setting up the top end of the ticket
                    //Checks to make sure the file is empty to post header, otherwise skips it
                    if( new FileInfo( file ).Length == 0){
                        sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    }

                    for(int i = 0; i < 10; i++)
                    {
                        //asking a question
                        System.Console.WriteLine("Enter a new ticket?(Y/N)");
                        //gather respong
                        string response = Console.ReadLine().ToUpper();
                        //if answer is anything else besides Y break if chain
                        if( response != "Y"){ break;}
                        //asking entry for all all fields and then saving it to a string 
                        System.Console.WriteLine("Enter a small description of the ticket issue");
                        string summary = Console.ReadLine();
                        
                        System.Console.WriteLine("Enter status of ticket");
                        string status = Console.ReadLine();
                        
                        System.Console.WriteLine("Enter ticket priority");
                        string prio = Console.ReadLine();

                        System.Console.WriteLine("Enter who is submitted the ticket");
                        string submitter = Console.ReadLine();

                        System.Console.WriteLine("Enter who is assigned to the ticket");
                        string assigned = Console.ReadLine();
                        // incrementing each id
                        id++;
                        //-----
                        //This didn't pan out
                        //Asking how many people are watching the ticket then saving it 
                        // System.Console.WriteLine("How many people are watching this ticket?");
                        // int numb = Int32.Parse(Console.ReadLine());
                        // //for loop to enter in watchers name
                        // for (int x = 0; x < numb; x++){
                        //     System.Console.WriteLine(x);
                        // }
                        do
                        {
                            System.Console.WriteLine("Who is watching this ticket?");
                            string output = Console.ReadLine();
                            watchers.Add(output);
                            x++;
                            System.Console.WriteLine("Is there anyone else watching this ticket? (Y/N)");
                            answer = Console.ReadLine().ToUpper();
                        } while (answer == "Y");
                        string watcher = String.Join("|", watchers);
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", id, summary, status, prio, submitter, assigned, watcher);
                        
                    }
                    sw.Close();
                }
            } 
            while (choice == "1"|| choice == "2");
        }
    }
}
