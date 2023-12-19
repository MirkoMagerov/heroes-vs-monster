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
            // ****************************** CONSTRAINTS ******************************
            // Messages

            // Difficulty numbers
            const int EasyMode = 3, HardMode = 2, PersonalizedMode = 1;

            // Valid range for every character stats
            const int MinArcherHealthValue = 1500, MaxArcherHealthValue = 2000, MinArcherAttackValue = 180, MaxArcherAttackValue = 300, MinArcherDefenseValue = 25, MaxArcherDefenseValue = 35;
            const int MinBarbarianHealthValue = 3000, MaxBarbarianHealthValue = 3750, MinBarbarianAttackValue = 150, MaxBarbarianAttackValue = 250, MinBarbarianDefenseValue = 35, MaxBarbarianDefenseValue = 45;
            const int MinMageHealthValue = 1100, MaxMageHealthValue = 1500, MinMageAttackValue = 300, MaxMageAttackValue = 400, MinMageDefenseValue = 20, MaxMageDefenseValue = 35;
            const int MinDruidHealthValue = 2000, MaxDruidHealthValue = 2500, MinDruidAttackValue = 70, MaxDruidAttackValue = 120, MinDruidDefenseValue = 25, MaxDruidDefenseValue = 40;
            const int MinMonsterHealthValue = 7000, MaxMonsterHealthValue = 10000, MinMonsterAttackValue = 300, MaxMonsterAttackValue = 400, MinMonsterDefenseValue = 20, MaxMonsterDefenseValue = 30;
            const int IndexArcher = 0, IndexBarbarian = 1, IndexMage = 2, IndexDruid = 3, IndexMonster = 4;

            // ****************************** VARIABLES ******************************
            Random random = new Random();

            string archerName = "";
            string barbarianName = "";
            string mageName = "";
            string druidName = "";

            // General program flow variables
            bool correctNameCreation;
            int mainMenuDecision, difficultyDecision, tries = 3;

            // Special characters variables
            int archerCooldown = 0, barbarianCooldown = 0, mageCooldown = 0, druidCooldown = 0, monsterKnockout = 0, barbarianAugmDefenseTurns = 0;

            // Stats
            float archerHealth = 0, archerAttack = 0, archerDefense = 0;
            float barbarianHealth = 0, barbarianAttack = 0, barbarianDefense = 0;
            float mageHealth = 0, mageAttack = 0, mageDefense = 0;
            float druidHealth = 0, druidAttack = 0, druidDefense = 0;
            float monsterHealth = 0, monsterAttack = 0, monsterDefense = 0;
            // Variables para guardar la vida original de los personajes y stats importantes
            float ogArcherHealth, ogBarbarianHealth, ogMageHealth, ogDruidHealth, ogBarbarianDefense;

            int[] turnOrder = GetTurnOrder(random, IndexArcher, IndexBarbarian, IndexMage, IndexDruid);

            int[,] allStatsRange = new int[,]
            {
                { MinArcherHealthValue, MaxArcherHealthValue, MinArcherAttackValue, MaxArcherAttackValue, MinArcherDefenseValue, MaxArcherDefenseValue },
                { MinBarbarianHealthValue, MaxBarbarianHealthValue, MinBarbarianAttackValue, MaxBarbarianAttackValue, MinBarbarianDefenseValue, MaxBarbarianDefenseValue },
                { MinMageHealthValue, MaxMageHealthValue, MinMageAttackValue, MaxMageAttackValue, MinMageDefenseValue, MaxMageDefenseValue },
                { MinDruidHealthValue, MaxDruidHealthValue, MinDruidAttackValue, MaxDruidAttackValue, MinDruidDefenseValue, MaxDruidDefenseValue },
                { MinMonsterHealthValue, MaxMonsterHealthValue, MinMonsterAttackValue, MaxMonsterAttackValue, MinMonsterDefenseValue, MaxMonsterDefenseValue }
            };

            // ****************************** MAIN PROGRAM ******************************

            // Salir
            if (!GetMainMenuDecision(ref tries))
            {
                // Despedida del juego
            }

            // Jugar
            else if (tries > 0)
            {
                Console.WriteLine();
                difficultyDecision = GetDifficultyDecision(ref tries);

                // ************************** Creación personajes según dificultad **************************
                if (difficultyDecision == PersonalizedMode)
                {
                    CreateCharacterAutomatic(allStatsRange, IndexArcher, ref archerHealth, ref archerAttack, ref archerDefense);
                    CreateCharacterAutomatic(allStatsRange, IndexBarbarian, ref barbarianHealth, ref barbarianAttack, ref barbarianDefense);
                    CreateCharacterAutomatic(allStatsRange, IndexMage, ref mageHealth, ref mageAttack, ref mageDefense);
                    CreateCharacterAutomatic(allStatsRange, IndexDruid, ref druidHealth, ref druidAttack, ref druidDefense);
                    CreateCharacterAutomatic(allStatsRange, IndexMonster, ref monsterHealth, ref monsterAttack, ref monsterDefense);
                }
                else
                {
                    CreateCharacterAutomatic(allStatsRange, IndexArcher, difficultyDecision, random, ref archerHealth, ref archerAttack, ref archerDefense);
                    CreateCharacterAutomatic(allStatsRange, IndexBarbarian, difficultyDecision, random, ref barbarianHealth, ref barbarianAttack, ref barbarianDefense);
                    CreateCharacterAutomatic(allStatsRange, IndexMage, difficultyDecision, random, ref mageHealth, ref mageAttack, ref mageDefense);
                    CreateCharacterAutomatic(allStatsRange, IndexDruid, difficultyDecision, random, ref druidHealth, ref druidAttack, ref druidDefense);

                    // Cambiar dificultad para adaptarla a las stats del monstruo
                    if (difficultyDecision == EasyMode)
                    {
                        difficultyDecision = HardMode;
                    }
                    else if (difficultyDecision == HardMode)
                    {
                        difficultyDecision = EasyMode;
                    }

                    CreateCharacterAutomatic(allStatsRange, IndexMonster, difficultyDecision, random, ref monsterHealth, ref monsterAttack, ref monsterDefense);
                }

                // ************************** Guardar atributos originales en otras variables **************************
                ogArcherHealth = archerHealth;
                ogBarbarianHealth = barbarianHealth;
                ogBarbarianDefense = barbarianDefense;
                ogMageHealth = mageHealth;
                ogDruidHealth = druidHealth;

                // ************************** Nombres de los personajes **************************
                //do
                //{
                //    correctNameCreation = GetCharactersNames(ref archerName, ref barbarianName, ref mageName, ref druidName);

                //} while (!correctNameCreation);

                // ************************** Sistema de turnos **************************
                turnOrder = GetTurnOrder(random, IndexArcher, IndexBarbarian, IndexMage, IndexDruid);

                for (int i = 0; i < turnOrder.Length; i++)
                {
                    Console.Write(turnOrder[i] + " ");
                }
                Console.WriteLine();

                turnOrder = GetTurnOrder(random, IndexArcher, IndexBarbarian, IndexMage, IndexDruid);

                for (int i = 0; i < turnOrder.Length; i++)
                {
                    Console.Write(turnOrder[i] + " ");
                }
                Console.WriteLine();

                turnOrder = GetTurnOrder(random, IndexArcher, IndexBarbarian, IndexMage, IndexDruid);

                for (int i = 0; i < turnOrder.Length; i++)
                {
                    Console.Write(turnOrder[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TE HAS QUEDADO SIN INTENTOS");
                Console.ResetColor();
            }
        }

        // ************************** FIN MAIN **************************

        public static int GetDecision(string menuTitle, string[] options, ref int tries)
        {
            bool validDecision;
            int decision;
            do
            {
                Console.WriteLine(menuTitle);

                for (int i = options.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine($"{i}. {options[i]}");
                }

                Console.Write("Tu elección: ");
                decision = Convert.ToInt16(Console.ReadLine());

                if (decision < 0 || decision > options.Length - 1)
                {
                    validDecision = false;
                }
                else
                {
                    validDecision = true;
                }

                if (!validDecision)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                    Console.ResetColor();
                    Console.WriteLine();
                    tries--;
                }

            } while (!validDecision && tries > 0);

            return decision;
        }

        public static bool GetMainMenuDecision(ref int tries)
        {
            string[] mainMenuOptions = { "Salir", "Iniciar nueva batalla" };
            return GetDecision("MENÚ", mainMenuOptions, ref tries) != 0;
        }

        public static int GetDifficultyDecision(ref int tires)
        {
            string[] difficultyOptions = { "Random", "Personalizada", "Difícil", "Fácil" };
            return GetDecision("DIFICULTAD", difficultyOptions, ref tires);
        }

        // Dificultad personalizada
        public static float CreateCharacterStat(int minValue, int maxValue)
        {
            int tries = 3;
            float stat;
            bool validDecision;
            do
            {
                Console.Write($"Escoge el valor de la estadística entre los rangos permitidos [{minValue} ... {maxValue}]: ");
                stat = Convert.ToSingle(Console.ReadLine());

                if (stat < minValue || stat > maxValue)
                {
                    validDecision = false;
                }
                else
                {
                    validDecision = true;
                }

                if (!validDecision)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                    Console.ResetColor();
                    Console.WriteLine();
                    tries--;
                }

            } while (!validDecision && tries > 0);

            if (tries == 0)
            {
                stat = minValue;
            }

            return stat;
        }

        // Dificultad automática
        public static float CreateCharacterStat(int minvalue, int maxValue, int automaticDifficulty, Random random)
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
                return Convert.ToSingle(random.Next(minvalue, maxValue + 1));
            }
        }

        public static void CreateCharacterAutomatic(int[,] allStatsRange, int characterIndex, ref float health, ref float attack, ref float defense)
        {
            health = CreateCharacterStat(allStatsRange[characterIndex, 0], allStatsRange[characterIndex, 1]);
            attack = CreateCharacterStat(allStatsRange[characterIndex, 2], allStatsRange[characterIndex, 3]);
            defense = CreateCharacterStat(allStatsRange[characterIndex, 4], allStatsRange[characterIndex, 5]);
        }

        public static void CreateCharacterAutomatic(int[,] allStatsRange, int characterIndex, int difficulty, Random random, ref float health, ref float attack, ref float defense)
        {
            health = CreateCharacterStat(allStatsRange[characterIndex, 0], allStatsRange[characterIndex, 1], difficulty, random);
            attack = CreateCharacterStat(allStatsRange[characterIndex, 2], allStatsRange[characterIndex, 3], difficulty, random);
            defense = CreateCharacterStat(allStatsRange[characterIndex, 4], allStatsRange[characterIndex, 5], difficulty, random);
        }

        public static string CapitalizeFirstLetter(string word)
        {
            return $"{word[0].ToString().ToUpper()}{word.Substring(1).ToLower()}";
        }

        public static bool GetCharactersNames(ref string archerName, ref string barbName, ref string mageName, ref string druidName)
        {
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

        public static int[] GetTurnOrder(Random random, int archerIndex, int barbarianIndex, int mageIndex, int druidIndex)
        {
            int[] randomOrder = { archerIndex, barbarianIndex, mageIndex, druidIndex };

            for (int i = randomOrder.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (randomOrder[i], randomOrder[j]) = (randomOrder[j], randomOrder[i]);
            }

            return randomOrder;
        }

        public static int GetTurnDecision(ref int tries)
        {
            string[] difficultyOptions = { "Usar habilidad especial", "Protegerse", "Atacar" };
            return GetDecision("OPCIONES DE TURNO", difficultyOptions, ref tries);
        }

        public static bool IsCriticAttac(Random random)
        {
            return random.Next(0, 10) < 1;
        }

        public static bool IsMissedAttack(Random random)
        {
            return random.Next(0, 20) < 1;
        }
    }
}