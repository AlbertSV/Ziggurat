using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class EnemyManager : MonoBehaviour
    {
        private Animator _animator;
        private Animator _enemyAnimator;
        private bool _isDead = false;
        private float actionTime = 3f;
        private Dictionary<string, int> _chances;
        private ActionToDo _actionToPerformUnit;
        private ActionToDo _actionToPerformEnemy;
        private Dropdown _dropdowns;
        private float _fastDamage;
        private float _strongDamage;
        private float _critical;
        private float _miss;
        private float _criticalProb;
        private float _missProb;
        private bool _gotParameters = false;
        private GameManager _gameManager;

        public bool IsDead
        {
            get { return _isDead; }
            set { _isDead = value; }
        }

        public bool GotParameters
        {
            get { return _gotParameters; }
            set { _gotParameters = value; }
        }

        public bool TakeHit(Animator unitAnimator)
        {

            GameObject unit = unitAnimator.gameObject;

            //get attack and health parameters of the team
            if (_gotParameters == false)
            {
                if (unit.GetComponent<GetColor>().GetTeamColor == TeamColor.Red)
                {
                    _fastDamage = unit.GetComponent<RedTeamParameters>().RedParameters["FastDamage"];
                    _strongDamage = unit.GetComponent<RedTeamParameters>().RedParameters["StrongDamage"];
                    _critical = unit.GetComponent<RedTeamParameters>().RedParameters["Critical"];
                    _miss = unit.GetComponent<RedTeamParameters>().RedParameters["Miss"];
                    _gotParameters = true;
                }
                else if (unit.GetComponent<GetColor>().GetTeamColor == TeamColor.Blue)
                {
                    _fastDamage = unit.GetComponent<BlueTeamParameters>().BlueParameters["FastDamage"];
                    _strongDamage = unit.GetComponent<BlueTeamParameters>().BlueParameters["StrongDamage"];
                    _critical = unit.GetComponent<BlueTeamParameters>().BlueParameters["Critical"];
                    _miss = unit.GetComponent<BlueTeamParameters>().BlueParameters["Miss"];
                    _gotParameters = true;
                }
                else
                {
                    _fastDamage = unit.GetComponent<GreenTeamParameters>().GreenParameters["FastDamage"];
                    _strongDamage = unit.GetComponent<GreenTeamParameters>().GreenParameters["StrongDamage"];
                    _critical = unit.GetComponent<GreenTeamParameters>().GreenParameters["Critical"];
                    _miss = unit.GetComponent<GreenTeamParameters>().GreenParameters["Miss"];
                    _gotParameters = true;
                }
            }
           

            if (_enemyAnimator == null)
            {
                _enemyAnimator = gameObject.GetComponent<Animator>();
            }

            unit.GetComponent<UnitControl>().AttackCounter += Time.deltaTime;

            //possibility to attack
            if (unit.GetComponent<UnitControl>().AttackCounter >= actionTime)
            {
                if (unitAnimator != null)
                {
                    _actionToPerformUnit = new RandomBehaviour().ActionChose(unit.GetComponent<UnitControl>().Chances);
                    _actionToPerformEnemy = new RandomBehaviour().ActionChose(gameObject.GetComponent<UnitControl>().Chances);

                    _missProb = GetRandom(_miss);

                    if (_actionToPerformUnit == ActionToDo.FastAttack)
                    {
                        if(_missProb <= _miss)
                        {
                            Debug.Log("Missed");
                        }
                        else
                        {
                            unitAnimator.SetTrigger("Fast");
                            FastAttack(unit);
                        }

                    }
                    else if(_actionToPerformUnit == ActionToDo.StrongAttack)
                    {

                        if (_missProb <= _miss)
                        {
                            Debug.Log("Missed");
                        }
                        else
                        {
                            unitAnimator.SetTrigger("Strong");
                            StrongAttack(unit);
                        }
                    }
                }
            }

            IsDead = gameObject.GetComponent<UnitControl>().Health <= 0;

            if(IsDead)
            {
                _Die();
            }

            return IsDead;
        }

        private void _Die()
        {
            _enemyAnimator.SetFloat("Movement", 0f);
            _enemyAnimator.SetTrigger("Die");
        }

        private void AnimationEventEnd_UnityEditor()
        {
            Destroy(gameObject);
        }


        private void UpdateKillsStatistic(GameObject unitTeam)
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }

            if (gameObject.GetComponent<UnitControl>().Health <= 0)
            {
                if (unitTeam.GetComponent<GetColor>().GetTeamColor == TeamColor.Red)
                {
                    _gameManager.KillsStatisticRed += 1;
                }
                else if (unitTeam.GetComponent<GetColor>().GetTeamColor == TeamColor.Blue)
                {
                    _gameManager.KillsStatisticBlue += 1;
                }
                else
                {
                    _gameManager.KillsStatisticGreen += 1;
                }
            }
        }

        private void FastAttack(GameObject unitAttack)
        {
            _criticalProb = GetRandom(_critical);

            if (_actionToPerformEnemy != ActionToDo.Block)
            {
                if (_criticalProb <= _critical)
                {
                    gameObject.GetComponent<UnitControl>().Health -= _fastDamage*2;
                    Debug.Log("Critical Attack");
                }
                else
                {
                    gameObject.GetComponent<UnitControl>().Health -= _fastDamage;
                }
                UpdateKillsStatistic(unitAttack);
            }
            else
            {
                gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.Block, gameObject.GetComponent<UnitControl>().Chances);
                Debug.Log("Enemy blocked attack");
            }
            unitAttack.GetComponent<UnitControl>().AttackCounter = 1f;

            unitAttack.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.FastAttack, unitAttack.GetComponent<UnitControl>().Chances);
            gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.FastHitted, gameObject.GetComponent<UnitControl>().Chances);
        }

        private void StrongAttack(GameObject unitAttack)
        {
            _criticalProb = GetRandom(_critical);

            if (_actionToPerformEnemy != ActionToDo.Block)
            {
                if (_criticalProb <= _critical)
                {
                    gameObject.GetComponent<UnitControl>().Health -= _strongDamage * 2;
                    Debug.Log("Critical Attack");
                }
                else
                {
                    gameObject.GetComponent<UnitControl>().Health -= _strongDamage;
                }
                UpdateKillsStatistic(unitAttack);
            }
            else
            {
                Debug.Log("Enemy blocked attack");
                gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.Block, gameObject.GetComponent<UnitControl>().Chances);
            }
            unitAttack.GetComponent<UnitControl>().AttackCounter = 0f;

            unitAttack.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.StrongAttack, unitAttack.GetComponent<UnitControl>().Chances);
            gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.StrongHitted, gameObject.GetComponent<UnitControl>().Chances);
        }

        private float GetRandom(float probability)
        {
            var random = new System.Random();
            probability = random.Next(0, 100);
            return probability;
        }
    }
}