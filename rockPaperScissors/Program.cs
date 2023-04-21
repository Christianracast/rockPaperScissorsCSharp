/*

Summary:A two player game of rock, paper, Scissors where a user will play against the computer.
Description:Input your name, then choose the winning terms (2 out 3 or 3 out of 5). Then you'll be prompted to choose rock paper or scissors, after your choice the computer chooses one of the three options also. Then the two options are evaluated. Rock beats Scissors,Scissors beats Paper, Paper beats rock. If thier is a tie no point is counted. A point will be added to the player with the winning option. The current score will be shown Username: 0, Computer: 0. Then the options will come up again until the winning conditions are made
Purpose: practice C# for use in other games. 
Date Started: 4/12/2023
Date Modified: 4/13/2023
Authors: Daniel Wiley & Christian Castillo

*/

using System;

namespace rockPaperScissors
{

    class Action
    {
        public string actionName { get; }
        public string abbreviation { get; }
        public string[] actionBeats { get; set; }
        public string[] actionLosesto { get; set; }

        public Action(string name, string abbrv, string[] beats, string[] losesto)
        {
            actionName = name;
            abbreviation = abbrv;
            actionBeats = beats;
            actionLosesto = losesto;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            //Create all options in game
            rockPaperScissors.Action rock = new Action("rock", "r", new string[] { "scissors" }, new string[] { "paper" });
            rockPaperScissors.Action paper = new Action("paper", "p", new string[] { "rock" }, new string[] { "scissors" });
            rockPaperScissors.Action scissors = new Action("scissors", "s", new string[] { "paper" }, new string[] { "rock" });

            //create array with all actions
            rockPaperScissors.Action[] actions = { rock, paper, scissors };


            //introductions
            Console.WriteLine("Welcome to rock paper scissors C# Practice!");

            //ask for and store users name.
            Console.WriteLine("Enter your User name:");
            string username = Console.ReadLine();
            string computerplayer = "CPU1";

            //Greet User
            Console.WriteLine("Hello " + username + "!");

            int p1wins = 0;
            int p1loses = 0;



            for (int j = 0; j < 10; j++)
            {

                Console.WriteLine(username + ": " + p1wins + " vs " + computerplayer + ": " + p1loses);

                if (p1wins == 3 || p1loses == 3)
                {
                    Console.WriteLine(username + ": " + p1wins + " vs " + computerplayer + ": " + p1loses);

                    if (p1wins == 3)
                    {
                        Console.WriteLine(username + " Wins!");
                    }
                    else
                    {
                        Console.WriteLine(username + " Loses!");
                    }

                    break;
                }

                
                    //Start sentance (use write instead of writeline so not make a new line.
                    Console.Write(username + " choose ");

                    //Use the quantity of plays to go through each to write the possible options.
                    for (int i = 0; i < actions.Length; i++)
                    {
                        //Print Play
                        Console.Write(actions[i].actionName + "(" + actions[i].abbreviation + ")");

                        //If second to last play write or
                        if (i == (actions.Length - 2))
                        {
                            Console.Write(" or ");
                        }
                        //Otherwise put a , with a space
                        else if (i != (actions.Length - 1))
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.Write(".");
                    string actionChosen = (Console.ReadLine());
                    rockPaperScissors.Action p1action = actions[0];

                    for (int i = 0; i < actions.Length; i++)
                    {

                        if (actions[i].abbreviation == actionChosen)
                        {
                            Console.WriteLine(username + " chose: " + actions[i].actionName);
                            p1action = actions[i];
                        }

                    }

                    Random numberGen = new Random();
                    int p2Choice = 0;
                    p2Choice = numberGen.Next(0, actions.Length);

                    rockPaperScissors.Action p2action = actions[p2Choice];

                    Console.WriteLine(computerplayer + " chose: " + p2action.actionName);

                    for (int i = 0; i < p1action.actionBeats.Length; i++)
                    {
                        if (p1action.actionBeats[i] == p2action.actionName)
                        {
                            Console.WriteLine(username + " wins! ");
                            p1wins++;

                        }
                        else if (p1action.actionLosesto[i] == p2action.actionName)
                        {
                            Console.WriteLine(username + " loses! ");
                            p1loses++;

                        }
                        else if (p1action.actionName == p2action.actionName)
                        {
                            Console.WriteLine(" DRAW ");
                        }
                    }

                
                //Console.WriteLine("Will you play 2 out of 3 or 3 out of 5?");
                //Console.WriteLine("Write 1 for play 2 out of 3 or 2 for 3 out of 5?");
                //get game type 1 or 2 as a int
                //int gameType = Convert.ToInt32(Console.ReadLine());
                //scoreToWin will be the used to figure out how many wins are necessary to win
                //int scoreToWin;
                //if (gameType == 1) { scoreToWin = 2; } else { scoreToWin = 3; }

                //Intro


                Console.ReadLine();
            }
        }
    }
}


