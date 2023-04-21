namespace GameSuite;
class Program
{
    static void Main(string[] args)
    {
    //Console Info
        Console.Title = "Game Suite";

    //Player Name
        Console.WriteLine("Enter Player Name:");
        string P1Name = Console.ReadLine();

    //Program Loop Start 
        string ProgramLoop = "y";
        while (ProgramLoop== "y"){

        //Menu Loop
            Console.WriteLine("SELECT GAME");
            Console.WriteLine("(1) High Low\n(2) Guess the Number\n(3) Rock Paper Scissors");
            string GameSelect = Console.ReadLine();
            while ((GameSelect != "1") && (GameSelect != "2") && (GameSelect != "3")){
                Console.WriteLine("(1) High Low\n(2) Guess the Number\n(3) Rock Paper Scissors");
                GameSelect = Console.ReadLine();
            }
        
        //High Low
            if (GameSelect == "1"){
                Console.WriteLine ("HIGH LOW");
                double GameNumber = 0;
                double GameWins = 0;

    //GameLoop 
    
            string GameLoop = "y";
            while (GameLoop == "y"){
                Console.WriteLine("High/Low");
    
    //CPU Number Gen
      //First Number
                Random numberGen = new Random();
                int CPUChoice1 = 0;
                CPUChoice1 = numberGen.Next(1,11);
        //Second NUmber
                int CPUChoice2 = 0;
                CPUChoice2 = numberGen.Next(1,11);
                Console.WriteLine ("First Number: " + CPUChoice1);
                Console.WriteLine ("Is Second Number Higher(>) or Lower(<)");

        //Player Choice
                Console.Write (P1Name + ": ");
                string P1Choice = Console.ReadLine();
                while ((P1Choice != ">" && P1Choice != "<")){
                    Console.WriteLine("Enter > or <");
                    Console.Write (P1Name + ": ");
                    P1Choice = Console.ReadLine();
                    }
                Console.WriteLine(P1Choice);

        //Win Condition
                if ((CPUChoice1 < CPUChoice2) && (P1Choice == "<") ||(CPUChoice1 > CPUChoice2) && (P1Choice == ">") ){
                    Console.WriteLine("Win\nSecond Number was: " + CPUChoice2);
                    GameWins ++;
                }
                else if ((CPUChoice1 < CPUChoice2) && (P1Choice == ">") ||(CPUChoice1 > CPUChoice2) && (P1Choice == "<") ){
                    Console.WriteLine ("Lose\nSecond Number was: " + CPUChoice2);
                }
                GameNumber ++;
                double WinPercent = ((GameWins/GameNumber) * 100);
                Console.WriteLine ("Game Number: " + GameNumber + "\nGame Wins: " + GameWins);
                Console.WriteLine ("Win %: " + (Math.Round (WinPercent, 2)) + "%");
                
            
            //Outro
                    Console.WriteLine("Play Guess the Number Again? (y/n)");
                    GameLoop = Console.ReadLine();
                    while ((GameLoop != "y" && GameLoop != "n")){
                        Console.WriteLine("Enter y or n");
                        GameLoop = Console.ReadLine();
                    }            

                }

            }

        //Guess the Number
                
                if (GameSelect == "2"){
                    string GameLoop = "y";
                    while (GameLoop == "y"){
            //Intro
                    Console.WriteLine ("Select game type\n(1) Scored Game\n(2) Free Play");
                
            //Game Type Select   
                    int GameType = Convert.ToInt32 (Console.ReadLine ());
                    while ((GameType != 1) && (GameType != 2)){
                        Console.WriteLine("Select 1 or 2");
                        GameType = Convert.ToInt32 (Console.ReadLine());
                    }
                    if (GameType == 1){
                        Console.WriteLine("SCORED GAME");
                    }
                    else if (GameType == 2){
                        Console.WriteLine("FREE PLAY");
                    }

            //Game Type Loop Start 
                    double GameNumber = 0;
                    double GameWins = 0;
                    string GameTypeLoop = "y";
                    while (GameTypeLoop == "y"){ 

            //Number Generator    
                        Random numberGen = new Random();
                        int P2Choice = 0;
                        P2Choice = numberGen.Next(1,101);

            //P1 Turn  

                        Console.WriteLine("Guess the number\n\nTurn Number: 1");
                        Console.Write (P1Name + ": ");
                        int P1Choice = Convert.ToInt32 (Console.ReadLine());
                        while ((0 >= P1Choice) || (101 <= P1Choice)){
                            Console.WriteLine("Enter Number 1 - 100");
                            Console.Write (P1Name + ": ");
                            P1Choice = Convert.ToInt32 (Console.ReadLine());
                        }

            //Game Code
                        int Turns = 1;

                        for (int i = 2; (P1Choice != P2Choice) && (i <= 10); i++){
                        if (GameType == 1){
                            Turns = i;
                        }
                    
                        else if (GameType == 2){
                            i = 0;
                            Turns ++;
                        }

                        if (P1Choice > P2Choice){
                            Console.WriteLine ("Lower\n\nTurn Number: " + Turns);
                            Console.Write (P1Name + ": ");
                            P1Choice = Convert.ToInt32 (Console.ReadLine());
                        }

                        else if (P1Choice < P2Choice){
                            Console.WriteLine ("Higher\n\nTurn Number: " + Turns);
                            Console.Write (P1Name + ": ");
                            P1Choice = Convert.ToInt32 (Console.ReadLine());
                        } 

                    }

            //Win Condition

                    if (P1Choice == P2Choice){
                        GameNumber ++;
                        GameWins ++;
                        Console.WriteLine("Win");
                    }
                
                    else if (Turns == 10 ){
                        GameNumber ++;
                        Console.WriteLine("\nLose\nMax Turn Limit Reached");
                    }
                    
                    double WinPercent = ((GameWins/GameNumber) * 100);
                    Console.WriteLine ("\nTurns Taken: " + Turns);
                    Console.WriteLine ("Game Number: " + GameNumber + "\nGame Wins: " + GameWins);
                    Console.WriteLine ("Win %: " + (Math.Round (WinPercent, 2)) + "%");
            
            // Game Type Loop End
                    if (GameType == 1){
                        Console.WriteLine ("Play Scored Game Again? (y/n)");
                        GameTypeLoop = Console.ReadLine();
                        while ((GameTypeLoop != "y" && GameTypeLoop != "n")){
                        Console.WriteLine("Enter y or n");
                        GameTypeLoop = Console.ReadLine();
                        }
                    }
            
                    else if (GameType == 2){
                        Console.WriteLine ("Play Free Play Game Again? (y/n)");
                        GameTypeLoop = Console.ReadLine();
                        while ((GameTypeLoop != "y" && GameTypeLoop != "n")){
                            Console.WriteLine("Enter y or n");
                            GameTypeLoop = Console.ReadLine();
                        }
                    }
                }
        //Game Loop End
                Console.WriteLine("Play Guess the Number Again? (y/n)");
                GameLoop = Console.ReadLine();
                while ((GameLoop != "y" && GameLoop != "n")){
                    Console.WriteLine("Enter y or n");
                    GameLoop = Console.ReadLine();
                    }            

                }
        
                }
        // Rock Paper Scissors
                if (GameSelect == "3"){
                    
                    double GameNumber = 0;
                    double GameWins = 0;
    
                //GameLoop 
                    string GameLoop = "y";
                    while (GameLoop == "y"){
                    
                        Console.WriteLine ("ROCK PAPER SCISSORS");

                //Game Number Loop
                        Console.WriteLine ("Best of 3 or 5 games?");
                        Console.Write (P1Name + ": ");
                        int GameCount = Convert.ToInt32(Console.ReadLine());
                        while ((GameCount != 3) && (GameCount!= 5)){
                            Console.WriteLine("Enter 3 or 5");
                            GameCount = Convert.ToInt32(Console.ReadLine());
                        }

                        int P1Wins = 0;
                        int P2Wins = 0;

                        while ((P1Wins != GameCount) && (P2Wins != GameCount)){
                    //P2 Number Gen
                            Random numberGen = new Random();
                            int P2Choice = 0;
                            P2Choice = numberGen.Next(1,4);   


                    //P1 Turn
                            Console.WriteLine ("Select (r)Rock, (p)Paper, or (s)Scissors");
                            Console.Write (P1Name + ": ");
                            string P1Choice = Console.ReadLine();
                            while ((P1Choice != "r") && (P1Choice != "p") && (P1Choice != "s")){
                                    Console.WriteLine("Select (r)Rock, (p)Paper, or (s)Scissors");
                                    P1Choice = Console.ReadLine();
                            }

                    // P2 Turn
                            if (P2Choice == 1){
                                Console.WriteLine ("CPU: Rock");
                            }
                            else if (P2Choice == 2){
                                Console.WriteLine ("CPU: Paper");
                            }
                            else if (P2Choice == 3){
                                Console.WriteLine ("CPU: Scissors");
                            }
                            
                    //Win Condition

                            if ((P1Choice == "r" && P2Choice == 1) || (P1Choice == "p" && P2Choice == 2) || (P1Choice == "s" && P2Choice == 3)){
                                Console.WriteLine ("Draw\n");
                            }

                            else if ((P1Choice == "r" && P2Choice == 2) || (P1Choice == "p" && P2Choice == 3) || (P1Choice == "s" && P2Choice == 1)){
                                Console.WriteLine ("Lose\n");
                                P2Wins ++;
                            }

                            else if ((P1Choice == "r" && P2Choice == 3) || (P1Choice == "p" && P2Choice == 1) || (P1Choice == "s" && P2Choice == 2)){
                                Console.WriteLine ("Win\n");
                                GameWins ++;
                                P1Wins ++;
                            }

                            Console.WriteLine (P1Name + " W/L: " +  P1Wins + "/" + P2Wins);
                            if (P1Wins == GameCount){
                                Console.WriteLine("\n" + P1Name + " Win \n");
                            }
                            else if (P2Wins == GameCount){
                                Console.WriteLine("\nCPU Win \n");
                            }
                            
                            GameNumber ++;
                            double WinPercent = ((GameWins/GameNumber) * 100);
                            Console.WriteLine ("Game Number: " + GameNumber + "\nGame Wins: " + GameWins);
                            Console.WriteLine ("Win %: " + (Math.Round (WinPercent, 2)) + "%");
                                    
                        }      
                //Outro
                        Console.WriteLine("Play Rock Paper Scissors Again? (y/n)");
                        GameLoop = Console.ReadLine();
                        while ((GameLoop != "y" && GameLoop != "n")){
                            Console.WriteLine("Enter y or n");
                            GameLoop = Console.ReadLine();
                        }
                    }
                 } 
                 
        // Program Loop End
                }
                Console.WriteLine("Return to Main Menu? (y/n)");
                ProgramLoop = Console.ReadLine();
                while ((ProgramLoop != "y" && ProgramLoop != "n")){
                    Console.WriteLine("Enter y or n");
                    ProgramLoop = Console.ReadLine();
            
            }
            Console.WriteLine ("Progress Enter to Terminate");
            Console.ReadLine();
        }
    }
