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

    enum States
    {
        Disengaged,
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
        Fallen

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

    enum AttackType
    {
        none,
        Strength,
        Grab,
        Speed
    }


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
        public Ability[] activeAbilities { get; set; }
        public Ability[] inactiveAbilities { get; set; }
        public Ability[] activeAttacks { get; set; }
        public Ability[] inactiveAttacks { get; set; }
        //Any time you use an ability
        public int battleXp { get; set; }
        //anytime you move
        public int moveXP { get; set; }
        //anytime you hold or use defense
        public int defenseXP { get; set; }

        public Meb() {}


        //For New Meb
        public Meb(string name, string abbreviation, int endurance, int speed, int strength, Attack[] activeAttacks)
            :base(name, abbreviation)
        {
            this.endurance = endurance;
            this.speed = speed;
            this.strength = strength;
            this.activeAttacks = activeAttacks;


            this.enduranceModifier = 0;
            this.speedModifier = 0;
            this.strengthModifier = 0;
            this.totalHitPoints = endurance*4;
            this.currentHitPoints = endurance * 4;
            this.currentState = States.Disengaged;
            this.startingPosition = Positions.frontline;
            this.currentPosition = Positions.frontline;
            this.slotsAvailable = 1;
            this.battleXp = 0;
            this.moveXP = 0;
            this.defenseXP = 0;
            this.activeAttacks = activeAttacks;

        }
    }

    class Ability: Entity
    {
        public Types type { get; set; }
        public Types[] advantage { get; set; }
        public Types[] disadvantage { get; set; }
                    public Ability()
                        {
                        }

            public Ability(string entityName, Types abilityType, string entityAbbreviation, Types[] abilityAdvantage, Types[] abilityDisadvantage)
            : base(entityName, entityAbbreviation)
        {
            type = abilityType;
            advantage = abilityAdvantage;
            disadvantage = abilityDisadvantage;
        }

    }

    class Attack : Ability
    {
        public int damageModifier { get; set; }

        public int damageOutput { get; set; }

        public AttackType attackType { get; set; }

        public Attack(string entityName, Types abilityType, string entityAbbreviation, Types[] abilityAdvantage, Types[] abilityDisadvantage, int attackDamage, AttackType attackAttackType)
            :base(entityName, abilityType, entityAbbreviation, abilityAdvantage, abilityDisadvantage)
        {
            damageModifier = attackDamage;
            attackType = attackAttackType;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            //Create all options in game
            rockPaperScissors.Attack rockAttack = new Attack("rock", Types.Rock, "r", new Types[] { Types.Scissor }, new Types[] { Types.Paper }, 1, AttackType.none);
            rockPaperScissors.Attack paperAttack = new Attack("paper", Types.Paper, "p", new Types[] { Types.Rock }, new Types[] { Types.Scissor }, 1, AttackType.none);
            rockPaperScissors.Attack scissorsAttack = new Attack("scissors", Types.Scissor, "s", new Types[] { Types.Paper }, new Types[] { Types.Rock },1, AttackType.none);

            //create array with all abilities
            rockPaperScissors.Attack[] abilities = { rockAttack, paperAttack, scissorsAttack };


            //create player meb
            Meb[] player1Mebs = { 
                new Meb("rock Meb", "r", 1, 1, 1, new Attack[] { rockAttack }),
                new Meb("paper Meb", "p", 1, 1, 1, new Attack[] { paperAttack }),
                new Meb("scissors Meb", "s", 1, 1, 1, new Attack[] { scissorsAttack })
            };

            Random numberGen = new Random();
            int p2Choice = 0;

            p2Choice = numberGen.Next(0, abilities.Length);
            Meb player2Meb1 = new Meb("black Meb", "r", 1, 1, 1, new Attack[] { abilities[p2Choice] });
            



            


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
                rockPaperScissors.Attack p1ability = abilities[0];

                //Ask for input until a correct input is given.
                do {
                    //Start sentance (use write instead of writeline so not make a new line.
                    Console.Write(username + " choose ");

                    //Use the quantity of plays to go through each to write the possible options.
                    for (int j = 0; j < abilities.Length; j++)
                    {
                        //Print Play
                        Console.Write(abilities[j].type + "(" + abilities[j].abbreviation + ")");

                        //If second to last play write or
                        if (j == (abilities.Length - 2))
                        {
                            Console.Write(" or ");
                        }
                        //Otherwise put a , with a space
                        else if (j != (abilities.Length - 1))
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine(".");
                    string abilityChosen = (Console.ReadLine());
                    

                    for (int j = 0; j < abilities.Length; j++)
                    {

                        if (abilities[j].abbreviation == abilityChosen)
                        {
                            Console.WriteLine(username + " chose: " + abilities[j].type);
                            p1ability = abilities[j];
                            correctAbbreviation = true;
                        }

                    }

                    if(correctAbbreviation == false)
                    {
                        Console.WriteLine("incorrect input.");
                    }


                } while (correctAbbreviation == false);
                
                   

                    p2Choice = numberGen.Next(0, abilities.Length);

                    rockPaperScissors.Ability p2ability = abilities[p2Choice];

                    Console.WriteLine(computerplayer + " chose: " + p2ability.type);

                    for (int j = 0; j < p1ability.advantage.Length; j++)
                    {
                        if (p1ability.advantage[j] == p2ability.type)
                        {
                            Console.WriteLine(username + " wins! ");
                            p1wins++;

                        }
                        else if (p1ability.disadvantage[j] == p2ability.type)
                        {
                            Console.WriteLine(username + " loses! ");
                            p1loses++;

                        }
                        else if (p1ability.type == p2ability.type)
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


