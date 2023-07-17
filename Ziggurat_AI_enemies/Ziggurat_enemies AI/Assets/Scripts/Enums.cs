using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public enum TeamColor : byte
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }

    public enum ActionType : byte
    {
        //unit hitted by strong attack
        StrongHitted = 0,
        //unit attack with strong attack
        StrongAttack = 1,
        FastHitted = 2,
        FastAttack = 3,
        Block = 4
    }

    public enum ActionToDo : byte
    {
        Block = 0,
        StrongAttack = 1,
        FastAttack = 2
    }

}