using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Ziggurat
{
    public class RandomBehaviour 
    {
        private int _chancesTotal;
        private ActionToDo _action;

        public ActionToDo ActionChose(Dictionary<string, int> chances)
        {
            RatioTotalSum(chances);

            System.Random random = new System.Random();
            int x = random.Next(0, _chancesTotal);

            if ((x -= chances["FastAttackChance"]) < 0) // Test for first action
            {
                _action = ActionToDo.FastAttack;
                return _action;
            }
            else if ((x -= chances["StrongAttackChance"]) < 0) // Test for second action
            {
                _action = ActionToDo.StrongAttack;
                return _action;
            }
            else 
            {
                _action = ActionToDo.Block;
                return _action;
            }
        }


        private int RatioTotalSum(Dictionary<string, int> actionChances)
        {
            _chancesTotal = actionChances.SumOfValue();
            return _chancesTotal;
        }
    }
}