﻿using DiceyDungeonsAR.Battle;

namespace DiceyDungeonsAR.Enemies
{
    public class Boss_1 : Enemy
    {
        public override string Name { get; } = "Кристаллина";
        public override int Level { get; } = 6;
        public override int MaxHealth { get; } = 55;

        public override void FillInventory()
        {
            Cards[0, 0] = new CardDescription()
            {
                action = CardAction.Damage,
                bonus = new Bonus(),
                condition = new Condition() { type = ConditionType.Odd },
            };
        }
    }
}
