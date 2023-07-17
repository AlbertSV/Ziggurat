using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class RedDropdowns : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _redUnitHealth;
        [SerializeField] private TMP_Dropdown _redFastAttack;
        [SerializeField] private TMP_Dropdown _redStrongAttack;
        [SerializeField] private TMP_Dropdown _redUnitSpeed;
        [SerializeField] private TMP_Dropdown _redMissProbability;
        [SerializeField] private TMP_Dropdown _redCriticalAttack;

        public TMP_Dropdown RedUnitHealthDrop
        {
            get { return _redUnitHealth; }
            set { _redUnitHealth = value; }
        }

        public TMP_Dropdown RedFastDrop
        {
            get { return _redFastAttack; }
        }

        public TMP_Dropdown RedStrongDrop
        {
            get { return _redStrongAttack; }
        }

        public TMP_Dropdown RedSpeedDrop
        {
            get { return _redUnitSpeed; }
        }

        public TMP_Dropdown RedMissDrop
        {
            get { return _redMissProbability; }
        }

        public TMP_Dropdown RedCriticalDrop
        {
            get { return _redCriticalAttack; }
        }

    }
}