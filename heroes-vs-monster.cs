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
            // Cooldowns and special ability turns
            int archerCooldown = 0, barbarianCooldown = 0, mageCooldown = 0, druidCooldown = 0;
            int monsterKnockout = 0, barbarianAugmDefenseTurns = 0;

            // Stats for every character
            float archerHealth = 0, ogArcherHealth = 0, archerAttack = 0, archerDefense = 0;
            float barbarianHealth = 0, ogBarbarianHealth = 0, barbarianAttack = 0, barbarianDefense = 0, ogBarbarianDefense;
            float mageHealth = 0, ogMageHealth = 0, mageAttack = 0, mageDefense = 0;
            float druidHealth = 0, ogDruidHealth = 0, druidAttack = 0, druidDefense = 0;
            float monsterHealth = 0, monsterAttack = 0, monsterDefense = 0;
        }
    }
}