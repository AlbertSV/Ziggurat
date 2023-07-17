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
        private bool _gotParameters = false;

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
            if (_gotParameters == false)
            {
                if (unitAnimator.gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Red)
                {
                    _fastDamage = unitAnimator.gameObject.GetComponent<RedTeamParameters>().RedParameters["FastDamage"];
                    _strongDamage = unitAnimator.gameObject.GetComponent<RedTeamParameters>().RedParameters["StrongDamage"];
                    _gotParameters = true;
                }
                else if (unitAnimator.gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Blue)
                {
                    _fastDamage = unitAnimator.gameObject.GetComponent<BlueTeamParameters>().BlueParameters["FastDamage"];
                    _strongDamage = unitAnimator.gameObject.GetComponent<BlueTeamParameters>().BlueParameters["StrongDamage"];
                    _gotParameters = true;
                }
                else
                {
                    _fastDamage = unitAnimator.gameObject.GetComponent<GreenTeamParameters>().GreenParameters["FastDamage"];
                    _strongDamage = unitAnimator.gameObject.GetComponent<GreenTeamParameters>().GreenParameters["StrongDamage"];
                    _gotParameters = true;
                }
            }

            GameObject unit = unitAnimator.gameObject;

            if (_enemyAnimator == null)
            {
                _enemyAnimator = gameObject.GetComponent<Animator>();
            }

            unitAnimator.gameObject.GetComponent<UnitControl>().AttackCounter += Time.deltaTime;

            if (unitAnimator.gameObject.GetComponent<UnitControl>().AttackCounter >= actionTime)
            {
                if (unitAnimator != null)
                {
                    _actionToPerformUnit = new RandomBehaviour().ActionChose(unit.GetComponent<UnitControl>().Chances);
                    _actionToPerformEnemy = new RandomBehaviour().ActionChose(gameObject.GetComponent<UnitControl>().Chances);

                    if (_actionToPerformUnit == ActionToDo.FastAttack)
                    {
                        unitAnimator.SetTrigger("Fast");

                        if(_actionToPerformEnemy != ActionToDo.Block)
                        {
                            gameObject.GetComponent<UnitControl>().Health -= _fastDamage;
                        }
                        else
                        {
                            gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.Block, gameObject.GetComponent<UnitControl>().Chances);
                            Debug.Log("Enemy blocked attack");
                        }
                        unitAnimator.gameObject.GetComponent<UnitControl>().AttackCounter = 1f;

                        unit.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.FastAttack, unit.GetComponent<UnitControl>().Chances);
                        gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.FastHitted, gameObject.GetComponent<UnitControl>().Chances);
                    }
                    else if(_actionToPerformUnit == ActionToDo.StrongAttack)
                    {
                        unitAnimator.SetTrigger("Strong");

                        if (_actionToPerformEnemy != ActionToDo.Block)
                        {
                            gameObject.GetComponent<UnitControl>().Health -= _strongDamage;
                        }
                        else
                        {
                            Debug.Log("Enemy blocked attack");
                            gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.Block, gameObject.GetComponent<UnitControl>().Chances);
                        }
                        unitAnimator.gameObject.GetComponent<UnitControl>().AttackCounter = 0f;

                        unit.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.StrongAttack, unit.GetComponent<UnitControl>().Chances);
                        gameObject.GetComponent<UnitControl>().Chances = new RatioChange().CalculateRation(ActionType.StrongHitted, gameObject.GetComponent<UnitControl>().Chances);
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

        private void AnimationEventAttackEnd()
        {
         
            
        }
    }
}