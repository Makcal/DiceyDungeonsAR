﻿namespace DiceyDungeonsAR.Battle
{
    public class CardDescription
    {
        public CardAction action;
        public bool size = true, slotsCount = false;
        public byte uses = 1;
        public Condition condition = Condition.TrueCond;
        public Bonus bonus = Bonus.NoneBonus;
    }
}
