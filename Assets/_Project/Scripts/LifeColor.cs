using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    [Serializable]
    public struct LifeColor
    {
        public Color color;
        public Name name;
        public enum Name
        {
            Low,
            Mid,
            High
        }
    }
}