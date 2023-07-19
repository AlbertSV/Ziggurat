using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class Dropdown : MonoBehaviour
    {
        private float _health;
        private float _fastDamage;
        private float _strongDamage;
        private float _speed;
        private float _miss;
        private float _critical;

        private float _startHealth;
        private float _startFastDamage;
        private float _startStrongDamage;
        private float _startSpeed;
        private float _startMiss;
        private float _startCritical;

        private GameManager _gameManager;

        private void Awake()
        {

            _gameManager = FindObjectOfType<GameManager>();

        }

        public List<TMP_Dropdown> AddToList(List<TMP_Dropdown> dropList, TMP_Dropdown unitHealth, TMP_Dropdown fastAttack, TMP_Dropdown strongAttack,
            TMP_Dropdown unitSpeed, TMP_Dropdown missProbabilty, TMP_Dropdown criticalAttack)
        {
            dropList.Add(unitHealth);
            dropList.Add(fastAttack);
            dropList.Add(strongAttack);
            dropList.Add(unitSpeed);
            dropList.Add(missProbabilty);
            dropList.Add(criticalAttack);

            return dropList;
        }

        public Dictionary<string, float> AddToList(Dictionary<string, float> parametersDict, float health, float fastDamage, float strongDamage, float speed, float miss, float critical)
        {
            parametersDict.Add("Health", health);
            parametersDict.Add("FastDamage", fastDamage);
            parametersDict.Add("StrongDamage", strongDamage);
            parametersDict.Add("Speed", speed);
            parametersDict.Add("Miss", miss);
            parametersDict.Add("Critical", critical);

            return parametersDict;
        }

        public Dictionary<string, float> ParameterUpgrade(List<TMP_Dropdown> dropList, TMP_Dropdown unitHealth, TMP_Dropdown fastAttack, TMP_Dropdown strongAttack,
            TMP_Dropdown unitSpeed, TMP_Dropdown missProbabilty, TMP_Dropdown criticalAttack, Dictionary<string, float> parametersDictionary)
        {

            foreach (TMP_Dropdown drop in dropList)
            {
                if (drop.value == 0)
                {
                    if (drop == unitHealth)
                    {
                        parametersDictionary["Health"] = _gameManager.UnitHealth;
                    }
                    else if (drop == fastAttack)
                    {
                        parametersDictionary["FastDamage"] = _gameManager.FastDamage;
                    }
                    else if (drop == strongAttack)
                    {
                        parametersDictionary["StrongDamage"] = _gameManager.StrongDamage;
                    }
                    else if (drop == unitSpeed)
                    {
                        parametersDictionary["Speed"] = _gameManager.UnitSpeed;
                    }
                    else if (drop == missProbabilty)
                    {
                        parametersDictionary["Miss"] = _gameManager.MissProbability;
                    }
                    else
                    {
                        parametersDictionary["Critical"] = _gameManager.CriticalAttack;
                    }

                }
                else if (drop.value == 1)
                {
                    if (drop == unitHealth)
                    {
                        parametersDictionary["Health"] = _gameManager.UnitHealth + _gameManager.HealthIncrease;
                    }
                    else if (drop == fastAttack)
                    {
                        parametersDictionary["FastDamage"] = _gameManager.FastDamage + _gameManager.AttackIncrease;
                    }
                    else if (drop == strongAttack)
                    {
                        parametersDictionary["StrongDamage"] = _gameManager.StrongDamage + _gameManager.AttackIncrease;
                    }
                    else if (drop == unitSpeed)
                    {
                        parametersDictionary["Speed"] = _gameManager.UnitSpeed + _gameManager.SpeedIncrease;
                    }
                    else if (drop == missProbabilty)
                    {
                        parametersDictionary["Miss"] = _gameManager.MissProbability + _gameManager.MissIncrease;
                    }
                    else
                    {
                        parametersDictionary["Critical"] = _gameManager.CriticalAttack + _gameManager.CriticalIncrease;
                    }
                }
                else
                {
                    if (drop == unitHealth)
                    {
                        parametersDictionary["Health"] = _gameManager.UnitHealth + _gameManager.HealthIncrease * 2;
                    }
                    else if (drop == fastAttack)
                    {
                        parametersDictionary["FastDamage"] = _gameManager.FastDamage + _gameManager.AttackIncrease * 2;
                    }
                    else if (drop == strongAttack)
                    {
                        parametersDictionary["StrongDamage"] = _gameManager.StrongDamage + _gameManager.AttackIncrease * 2;
                    }
                    else if (drop == unitSpeed)
                    {
                        parametersDictionary["Speed"] = _gameManager.UnitSpeed + _gameManager.SpeedIncrease * 2;
                    }
                    else if (drop == missProbabilty)
                    {
                        parametersDictionary["Miss"] = _gameManager.MissProbability + _gameManager.MissIncrease * 2;
                    }
                    else
                    {
                        parametersDictionary["Critical"] = _gameManager.CriticalAttack + _gameManager.CriticalIncrease * 2;
                    }
                }
               
            }
            return parametersDictionary;
        }
    }  
}