using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokeMon
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Battle battleInstance = new Battle();
            

            //Initialize your player objects
            InitializePlayer(player1);
            InitializePlayer(player2);


            //Blahblahblah
            Console.WriteLine("{0}'s {1} will battle {2}'s {3} to the death! Hit ENTER to continue...", player1.Name, player1.ActivePokemon, player2.Name, player2.ActivePokemon);
            Console.ReadLine();

            battleInstance.CurrentlyInBattle = false;
            Console.WriteLine("A trainer catches your eye. Do you want to battle? Y/N");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'Y' || choice == 'y')
            {
                battleInstance.CurrentlyInBattle = true;
                BattleInit(player1, player2);
            }


            
            
        }



        




        private static void ProcessPlayerTurn(Player player, bool battle)
        {
            Console.Clear();
            int choice = 0;
            Console.WriteLine("{0}'s Turn!", player);
            Console.WriteLine("{0} uses a {1}! Get pumped!", player, player.ActivePokemon);
            Console.WriteLine("What will you do?\n1. Fight!\t2. Item\n3. PokeMon\t4. Run!");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    InitiateFightSequence(player, battle);
                    break;
                case 2:
                    OpenBackpack(player);
                    break;
                case 3:
                    SwitchPokemon(player);
                    break;
                case 4:
                    RunFromBattle(player, battle);
                    battle = false;
                    break;
                default:
                    break;
            }
            Console.ReadLine();
            Console.WriteLine("Turn Over. Hit Any Key To Continue...");
            Console.ReadKey();
        }



        private static void SwitchPokemon(Player player)
        {
            
        }



        private static void OpenBackpack(Player player)
        {
            
        }



        private static bool RunFromBattle(Player player, bool battle)
        {
            Console.WriteLine("{0} ran from the battle! Point and laugh!", player);
            
            return false;
        }



        private static void InitiateFightSequence(Player player, bool battle)
        {
            Console.WriteLine("Which attack will you use?");
            
        }






        #region COMMIT




        /// <summary>
        /// Check the victory conditions of each battle
        /// </summary>
        /// <param name="player"></param>
        /// <param name="opponent"></param>
        /// <returns>true or false<returns>
        private static bool CheckVictoryConditions(Player player, Player opponent)
        {
            IPokemon player1 = player.ActivePokemon;
            IPokemon player2 = opponent.ActivePokemon;
            Player victor = new Player();
            int player1HP = player1.MaxHP;
            int player2HP = player2.MaxHP;
            Random random = new Random();



            if (player1HP == 0 || player2HP == 0)
            {
                if (player1HP == 0)
                {
                    victor = player;
                }
                else
                {
                    victor = opponent;
                }

                int xp = victor.ActivePokemon.GainXP(random.Next(20, 56));
                Console.WriteLine("{0}'s {1} gains {2} xp! Nooice!", victor.ToString(), victor.ActivePokemon.ToString(), xp.ToString()); 
                return true;
            }
            return false;
        }



        /// <summary>
        /// Prompts the player for their name. Basic level of name control
        /// </summary>
        /// <param name="player"></param>
        static void Introduction(Player player)
        {
            Console.WriteLine("Hello, Mortal...What are you called?");
            player.Name = Console.ReadLine();
            bool correct = false;
            while (!correct)
            {
                sbyte choice;
                Console.WriteLine("{0}...eh? Is that so?\n1. Yes\t2. No", player.Name);
                choice = Convert.ToSByte(Console.ReadLine());                                   //Santize input to prevent possible error when adding NaN
                if (choice == 1)
                {
                    correct = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Well, then...what is it, now...?");
                    Console.WriteLine("C'mon...out with it!");
                    player.Name = Console.ReadLine();
                }
            }
        }



        /// <summary>
        /// Prompts the user to select a pokemon
        /// </summary>
        /// <param name="player"></param>
        static void SelectAPokemon(Player player)
        {
            Console.Clear();
            Console.WriteLine("And whom do you choice as your companion...? Select wisely, Mortal");
            Console.WriteLine("1. Bulbasaur\t2. Charmander\t3. Squirtle");
            sbyte choice = Convert.ToSByte(Console.ReadLine());
            IPokemon bulbasaur = new Bulbasaur();
            bulbasaur.MaxHP = 50;
            IPokemon charmander = new Charmander();
            charmander.MaxHP = 50;
            IPokemon squirtle = new Squirtle();
            squirtle.MaxHP = 50;
            switch (choice)
            {
                case 1:
                    player.ActivePokemon = bulbasaur;
                    break;
                case 2:
                    player.ActivePokemon = charmander;
                    break;
                case 3:
                    player.ActivePokemon = squirtle;
                    break;
                default:
                    Console.WriteLine("I don't understand you damned kids...");
                    break;
            }
        }



        /// <summary>
        /// Loads the player party into an active 6 celled array
        /// </summary>
        /// <param name="player"></param>
        static void LoadParty(Player player)
        {
            //The battleParty will be used for the main 6 pokemon. The player Party property will hold all of the pokemon the user catches
            
            player.Party.Add(player.ActivePokemon);
            player.BattleParty[0] = player.Party[0];
            player.BattleParty[1] = null;
            player.BattleParty[2] = null;
            player.BattleParty[3] = null;
            player.BattleParty[4] = null;
            player.BattleParty[5] = null;
        }



        /// <summary>
        /// Initializ the the player and have the select their starter/active pokemon. Prints a list and count of the current party
        /// </summary>
        /// <param name="player"></param>
        static void InitializePlayer(Player player)
        {
            Console.Clear();
            //Get the players name and basic information
            
            Introduction(player);

            //Have the player select an ActivePokemon
            SelectAPokemon(player);

            //Output the player's name and ActivePokemon and Load it into the player's party
            Console.WriteLine("{0} has a {1} as his main PokeMon", player.Name, player.ActivePokemon);
            LoadParty(player);

            //Print the Player's party and BattlePokemon Roster in an ordered list
            Console.Clear();
            Console.WriteLine("+++++{0}'s Party+++++\t Count: {1}", player.Name, player.Party.Count);
            sbyte slotNum = 1;
            foreach (var pokemon in player.BattleParty)
            {
                Console.WriteLine("Slot {0} [{1}]", slotNum++, pokemon);
            }

            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadLine();
        }



        /// <summary>
        /// Initial a battle between two players. Eventually will be triggered by random walking events and expanded to 2v2 and 3v3
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        private static void BattleInit(Player player1, Player player2)
        {
            bool inBattle = true;
            while (inBattle)
            {
                Player currentTurn = player1;
                bool victory = CheckVictoryConditions(player1, player2);

                while (!victory)
                {
                    if (currentTurn == player2)
                    {
                        currentTurn = player1;
                        ProcessPlayerTurn(currentTurn, inBattle);
                    }
                    else
                    {
                        currentTurn = player2;
                        ProcessPlayerTurn(currentTurn, inBattle);
                    }
                }
            }
        }



        #endregion

        public static bool battle { get; set; }
    }
}
