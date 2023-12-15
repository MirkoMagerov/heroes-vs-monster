/*
* Author: Miroslav Magerov
* M03. Programació UF2
* v1. dd/mm/aa
* Exercici Modular - Heroes vs Monster.
*/

namespace Proyecto
{
    public static class ConsoleApp
    {
        // CÓDIGO MAIN
        public static void Main()
        {
            // CONSTRAINTS
            // Messages

            // Valid range for every character stats
            const int MinArcherHealthValue = 1500, MaxArcherHealthValue = 2000, MinArcherAttackValue = 180, MaxArcherAttackValue = 300, MinArcherDefenseValue = 25, MaxArcherDefenseValue = 35;
            const int MinBarbarianHealthValue = 3000, MaxBarbarianHealthValue = 3750, MinBarbarianAttackValue = 150, MaxBarbarianAttackValue = 250, MinBarbarianDefenseValue = 35, MaxBarbarianDefenseValue = 45;
            const int MinMageHealthValue = 1100, MaxMageHealthValue = 1500, MinMageAttackValue = 300, MaxMageAttackValue = 400, MinMageDefenseValue = 20, MaxMageDefenseValue = 35;
            const int MinDruidHealthValue = 2000, MaxDruidHealthValue = 2500, MinDruidAttackValue = 70, MaxDruidAttackValue = 120, MinDruidDefenseValue = 25, MaxDruidDefenseValue = 40;
            const int MinMonsterHealthValue = 7000, MaxMonsterHealthValue = 10000, MinMonsterAttackValue = 300, MaxMonsterAttackValue = 400, MinMonsterDefenseValue = 20, MaxMonsterDefenseValue = 30;

            // VARIABLES
            string archerName = "";
            string barbarianName = "";
            string mageName = "";
            string druidName = "";

            // General program flow variables
            bool correctCreation;
            int mainMenuDecision, difficultyDecision;

            // Special characters variables
            int archerCooldown = 0, barbarianCooldown = 0, mageCooldown = 0, druidCooldown = 0, monsterKnockout = 0, barbarianAugmDefenseTurns = 0;

            // Stats
            float archerHealth = 0, ogArcherHealth = 0, archerAttack = 0, archerDefense = 0;
            float barbarianHealth = 0, ogBarbarianHealth = 0, barbarianAttack = 0, barbarianDefense = 0, ogBarbarianDefense;
            float mageHealth = 0, ogMageHealth = 0, mageAttack = 0, mageDefense = 0;
            float druidHealth = 0, ogDruidHealth = 0, druidAttack = 0, druidDefense = 0;
            float monsterHealth = 0, monsterAttack = 0, monsterDefense = 0;

            // ****************************** MAIN PROGRAM ******************************

            //do
            //{
            //    correctCreation = GetCharactersNames(ref archerName, ref barbarianName, ref mageName, ref druidName);

            //} while (!correctCreation);

            mainMenuDecision = GetMainMenuDecision();

            Console.WriteLine();

            if (mainMenuDecision == 0)
            {
                // Salir
            }

            else
            {
                difficultyDecision = GetDifficultyDecision();

                switch (difficultyDecision)
                {
                    case 3:
                        archerHealth = GetCharacterStat(MinArcherHealthValue, MaxArcherHealthValue, 3);
                        archerAttack = GetCharacterStat(MinArcherAttackValue, MaxArcherAttackValue, 3);
                        archerDefense = GetCharacterStat(MinArcherDefenseValue, MaxArcherDefenseValue, 3);
                        break;
                    case 2:
                        archerHealth = GetCharacterStat(MinArcherHealthValue, MaxArcherHealthValue, 2);
                        archerAttack = GetCharacterStat(MinArcherAttackValue, MaxArcherAttackValue, 2);
                        archerDefense = GetCharacterStat(MinArcherDefenseValue, MaxArcherDefenseValue, 2);
                        break;
                    case 1:
                        archerHealth = GetCharacterStat(MinArcherHealthValue, MaxArcherHealthValue, 1);
                        archerAttack = GetCharacterStat(MinArcherAttackValue, MaxArcherAttackValue, 1);
                        archerDefense = GetCharacterStat(MinArcherDefenseValue, MaxArcherDefenseValue, 1);
                        break;
                    case 0:
                        // Personalizada
                        // Arquera
                        archerHealth = GetCharacterStat(MinArcherHealthValue, MaxArcherHealthValue);
                        archerAttack = GetCharacterStat(MinArcherAttackValue, MaxArcherAttackValue);
                        archerDefense = GetCharacterStat(MinArcherDefenseValue, MaxArcherDefenseValue);
                        break;
                }
            }
        }

        public static bool GetCharactersNames(ref string archerName, ref string barbName, ref string mageName, ref string druidName)
        {
            static string CapitalizeFirstLetter(string word)
            {
                return $"{word[0].ToString().ToUpper()}{word.Substring(1).ToLower()}";
            }

            string userInput;
            string[] separatedNames;

            Console.Write("Introduce 4 nombres separados por comas.\nSe asignarán a los personajes en este orden: Arquera, Bárbaro, Maga, Druida.\nEscribe aqui: ");
            userInput = Console.ReadLine() ?? "";

            userInput = userInput.Replace(" ", "");

            separatedNames = userInput.Split(',');

            for (int i = 0; i < separatedNames.Length; i++)
            {
                separatedNames[i] = CapitalizeFirstLetter(separatedNames[i]);

                switch (i)
                {
                    case 0:
                        archerName = separatedNames[i];
                        break;

                    case 1:
                        barbName = separatedNames[i];
                        break;

                    case 2:
                        mageName = separatedNames[i];
                        break;

                    case 3:
                        druidName = separatedNames[i];
                        break;
                }
            }

            if (separatedNames.Length == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetMainMenuDecision()
        {
            string[] mainMenuOptions = { "Salir", "Iniciar nueva batalla" };
            return GetDecision("MENÚ", mainMenuOptions);
        }

        public static int GetDifficultyDecision()
        {
            string[] difficultyOptions = { "Personalizada", "Random", "Difícil", "Fácil" };
            return GetDecision("DIFICULTAD", difficultyOptions);
        }

        public static int GetDecision(string menuTitle, string[] options)
        {
            bool secondEx = false;
            int decision;

            do
            {
                if (secondEx)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                    Console.ResetColor();
                }

                Console.WriteLine(menuTitle);

                for (int i = options.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine($"{i}. {options[i]}");
                }

                Console.Write("Tu elección: ");
                decision = Convert.ToInt16(Console.ReadLine());

                secondEx = true;

            } while (decision < 0 || decision > options.Length - 1);

            return decision;
        }

        public static float GetCharacterStat(int minValue, int maxValue)
        {
            float stat;
            bool secondEx = false;
            do
            {
                if (secondEx)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                    Console.ResetColor();
                }

                Console.Write($"Escoge el valor de la estadística entre los rangos permitidos [{minValue} ... {maxValue}]: ");
                stat = Convert.ToSingle(Console.ReadLine());

                secondEx = true;

            } while (stat < minValue || stat > maxValue);

            return stat;
        }

        public static float GetCharacterStat(int minvalue, int maxValue, int automaticDifficulty)
        {
            if (automaticDifficulty == 3)
            {
                return maxValue;
            }
            else if (automaticDifficulty == 2)
            {
                return minvalue;
            }
            else
            {
                Random random = new Random();

                return Convert.ToSingle(random.NextDouble() * (maxValue - minvalue) + minvalue);
            }
        }
    }
}