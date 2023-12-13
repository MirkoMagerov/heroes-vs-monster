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

            bool correctCreation;

            // Special Variables
            int archerCooldown = 0, barbarianCooldown = 0, mageCooldown = 0, druidCooldown = 0, monsterKnockout = 0, barbarianAugmDefenseTurns = 0;

            // Stats
            float archerHealth = 0, ogArcherHealth = 0, archerAttack = 0, archerDefense = 0;
            float barbarianHealth = 0, ogBarbarianHealth = 0, barbarianAttack = 0, barbarianDefense = 0, ogBarbarianDefense;
            float mageHealth = 0, ogMageHealth = 0, mageAttack = 0, mageDefense = 0;
            float druidHealth = 0, ogDruidHealth = 0, druidAttack = 0, druidDefense = 0;
            float monsterHealth = 0, monsterAttack = 0, monsterDefense = 0;

            // Bucle para creación de nombres de los personajes
            do
            {
                correctCreation = GetCharactersNames(ref archerName, ref barbarianName, ref mageName, ref druidName);
            } while (!correctCreation);
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
    }
}