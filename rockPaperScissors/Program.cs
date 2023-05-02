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

    class Entity
    {
        public string name { get; set; }

        //this will be for use in key board games later I will remove this
        public string abbreviation { get; set; }

        //For some reason withouth a contruct with no values I get an error >.> not sure why
        public Entity()
        {
        }

        public Entity(string entityName, string entityAbbreviation)
        {
            name = entityName;
            abbreviation = entityAbbreviation;
        }
    }

    enum States
    {
        Standing,
        Cooldown,
        Charging,
        Waiting,
        Attacking,
        Blocking,
        Defensive,
        Grabbed,
        Prone,
        Moving,
        Jumping,
        Flying,
        Crouching,
        GettingHit,

    }

    enum Positions
    {
        frontline,
        rearguard
    }
    enum Types
    {
        Rock,
        Paper,
        Scissor
    }


    class Meb : Entity
    {
        public int endurance { get; set; }
        public int enduranceModifier { get; set; }
        public int speed { get; set; }
        public int speedModifier { get; set; }
        public int strength { get; set; }
        public int strengthModifier { get; set; }
        public int totalHitPoints { get; set; }
        public int currentHitPoints { get; set; }
        public States currentState { get; set; }
        public Positions startingPosition { get; set; }
        public Positions currentPosition { get; set; }
        public int slotsAvailable { get; set; }
        public Action[] activeAbilities { get; set; }
        public Action[] inactiveAbilities { get; set; }
        
        //Any time you use an ability
        public int battleXp { get; set; }
        //anytime you move
        public int moveXP { get; set; }
        //anytime you hold or use defense
        public int defenseXP { get; set; }

        public Meb() { }

    }

    class Action: Entity
    {
        public Types type { get; set; }
        public Types[] advantage { get; set; }
        public Types[] disadvantage { get; set; }
                    public Action()
            {
            }

            public Action(string entityName, Types actionType, string entityAbbreviation, Types[] actionAdvantage, Types[] actionDisadvantage)
        {
            name = entityName;
            type = actionType;
            abbreviation = entityAbbreviation;
            advantage = actionAdvantage;
            disadvantage = actionDisadvantage;
        }

    }

    class Attack : Action
    {
        public int damage { get; set; }

        public Attack(string entityName, Types actionType, string entityAbbreviation, Types[] actionAdvantage, Types[] actionDisadvantage, int attackDamage)
        {
            name = entityName;
            type = actionType;
            abbreviation = entityAbbreviation;
            advantage = actionAdvantage;
            disadvantage = actionDisadvantage;
            damage = attackDamage;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            //Create all options in game
            rockPaperScissors.Attack rockAttack = new Attack("rock", Types.Rock, "r", new Types[] { Types.Scissor }, new Types[] { Types.Paper }, 1);
            rockPaperScissors.Attack paperAttack = new Attack("paper", Types.Paper, "p", new Types[] { Types.Rock }, new Types[] { Types.Scissor }, 1 );
            rockPaperScissors.Attack scissorsAttack = new Attack("scissors", Types.Scissor, "s", new Types[] { Types.Paper }, new Types[] { Types.Rock },1);

            //create array with all actions
            rockPaperScissors.Attack[] actions = { rockAttack, paperAttack, scissorsAttack };


            //introductions
            Console.WriteLine("Welcome to rock paper scissors C# Practice!");

            //ask for and store users name.
            Console.WriteLine("Enter your user name:");
            string username = Console.ReadLine();
            string computerplayer = "CPU1";

            //Greet User
            Console.WriteLine("Hello " + username + "! Lets play rock paper scissors 3 out of 5.");

            //Vars for tracking player wins and loses
            int p1wins = 0;
            int p1loses = 0;

            //Who many wins you need to win a game
            int scoreToWin = 3;

            
            //Do while loop until a player has wins equal to the score to win.
            do
            {

                Console.WriteLine(username + ": " + p1wins + " vs " + computerplayer + ": " + p1loses);

                if (p1wins == scoreToWin || p1loses == scoreToWin)
                {
                    Console.WriteLine(username + ": " + p1wins + " vs " + computerplayer + ": " + p1loses);

                    if (p1wins == scoreToWin)
                    {
                        Console.WriteLine(@" __     __          __          ___       ");
                        Console.WriteLine(@" \ \   / /          \ \        / (_)      ");
                        Console.WriteLine(@"  \ \_/ /__  _   _   \ \  /\  / / _ _ __  ");
                        Console.WriteLine(@"   \   / _ \| | | |   \ \/  \/ / | | '_ \ ");
                        Console.WriteLine(@"    | | (_) | |_| |    \  /\  /  | | | | |");
                        Console.WriteLine(@"    |_|\___/ \__,_|     \/  \/   |_|_| |_|");
                        Console.WriteLine(username + " Wins!");
                    }
                    else
                    {
                    Console.WriteLine(@" __     __           _                    ");
                    Console.WriteLine(@" \ \   / /          | |                   ");
                    Console.WriteLine(@"  \ \_/ /__  _   _  | |     ___  ___  ___ ");
                    Console.WriteLine(@"   \   / _ \| | | | | |    / _ \/ __|/ _ \");
                    Console.WriteLine(@"    | | (_) | |_| | | |___| (_) \__ \  __/");
                    Console.WriteLine(@"    |_|\___/ \__,_| |______\___/|___/\___|");
                    Console.WriteLine(username + " Loses!");
                    }
                    Console.ReadLine();
                    break;
                }

                bool correctAbbreviation = false;
                rockPaperScissors.Attack p1action = actions[0];

                //Ask for input until a correct input is given.
                do {
                    //Start sentance (use write instead of writeline so not make a new line.
                    Console.Write(username + " choose ");

                    //Use the quantity of plays to go through each to write the possible options.
                    for (int j = 0; j < actions.Length; j++)
                    {
                        //Print Play
                        Console.Write(actions[j].type + "(" + actions[j].abbreviation + ")");

                        //If second to last play write or
                        if (j == (actions.Length - 2))
                        {
                            Console.Write(" or ");
                        }
                        //Otherwise put a , with a space
                        else if (j != (actions.Length - 1))
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine(".");
                    string actionChosen = (Console.ReadLine());
                    

                    for (int j = 0; j < actions.Length; j++)
                    {

                        if (actions[j].abbreviation == actionChosen)
                        {
                            Console.WriteLine(username + " chose: " + actions[j].type);
                            p1action = actions[j];
                            correctAbbreviation = true;
                        }

                    }

                    if(correctAbbreviation == false)
                    {
                        Console.WriteLine("incorrect input.");
                    }


                } while (correctAbbreviation == false);
                
                    Random numberGen = new Random();
                    int p2Choice = 0;
                    p2Choice = numberGen.Next(0, actions.Length);

                    rockPaperScissors.Action p2action = actions[p2Choice];

                    Console.WriteLine(computerplayer + " chose: " + p2action.type);

                    for (int j = 0; j < p1action.advantage.Length; j++)
                    {
                        if (p1action.advantage[j] == p2action.type)
                        {
                            Console.WriteLine(username + " wins! ");
                            p1wins++;

                        }
                        else if (p1action.disadvantage[j] == p2action.type)
                        {
                            Console.WriteLine(username + " loses! ");
                            p1loses++;

                        }
                        else if (p1action.type == p2action.type)
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


                
            } while (p1wins != scoreToWin || p1loses != scoreToWin) ;
        }
    }
}


