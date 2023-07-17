using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class RatioChange 
    {
        private int lowhChanceChange = 5;
        private int highChanceChange = 10;

        private int minClamp = 0;
        private int maxClamp = 50;



        public Dictionary<string, int> CalculateRation(ActionType actionType, Dictionary<string, int> actionChances)
        {
            if(actionType == ActionType.StrongHitted)
            {
                actionChances["BlockChance"] += highChanceChange;
                actionChances["StrongAttackChance"] -= highChanceChange;
                actionChances["FastAttackChance"] -= lowhChanceChange;

                actionChances = ClampValues(actionChances);

                return actionChances;
            }
            else if(actionType == ActionType.StrongAttack)
            {
                actionChances["BlockChance"] -= highChanceChange;
                actionChances["StrongAttackChance"] -= lowhChanceChange;
                actionChances["FastAttackChance"] += lowhChanceChange;

                actionChances = ClampValues(actionChances);

                return actionChances;
            }
            else if(actionType == ActionType.FastHitted)
            {
                actionChances["BlockChance"] += lowhChanceChange;
                actionChances["StrongAttackChance"] -= lowhChanceChange;
                actionChances["FastAttackChance"] -= lowhChanceChange;

                actionChances = ClampValues(actionChances);

                return actionChances;
            }
            else if (actionType == ActionType.FastAttack)
            {
                actionChances["BlockChance"] -= lowhChanceChange;
                actionChances["StrongAttackChance"] += lowhChanceChange;
                actionChances["FastAttackChance"] -= lowhChanceChange;

                actionChances = ClampValues(actionChances);

                return actionChances;
            }
            else if (actionType == ActionType.Block)
            {
                actionChances["BlockChance"] -= lowhChanceChange;
                actionChances["StrongAttackChance"] += lowhChanceChange;
                actionChances["FastAttackChance"] += highChanceChange;

                actionChances = ClampValues(actionChances);

                return actionChances;
            }

            return actionChances;
        }

        private Dictionary<string, int> ClampValues(Dictionary<string, int> chances)
        {
            chances["BlockChance"] = Mathf.Clamp(chances["BlockChance"], minClamp, maxClamp);
            chances["StrongAttackChance"] = Mathf.Clamp(chances["StrongAttackChance"], minClamp, maxClamp);
            chances["FastAttackChance"] = Mathf.Clamp(chances["FastAttackChance"], minClamp, maxClamp);

            return chances;
        }
    }
}