﻿using System;
using DiceyDungeonsAR.MyLevelGraph;
using DiceyDungeonsAR.GameObjects.Players;
using UnityEngine;

namespace DiceyDungeonsAR.GameObjects
{
    public abstract class Item : MonoBehaviour
    {
        [NonSerialized] public Field field;
 
        public void PlaceItem(Field field)
        {
            field.PlacedItem = this;
        }

        public abstract void UseByPlayer(Player player);
    }
}
