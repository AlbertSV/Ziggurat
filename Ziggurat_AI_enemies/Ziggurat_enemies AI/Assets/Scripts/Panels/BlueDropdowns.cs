using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class BlueDropdowns : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _blueUnitHealth;
        [SerializeField] private TMP_Dropdown _blueFastAttack;
        [SerializeField] private TMP_Dropdown _blueStrongAttack;
        [SerializeField] private TMP_Dropdown _blueUnitSpeed;
        [SerializeField] private TMP_Dropdown _blueMissProbability;
        [SerializeField] private TMP_Dropdown _blueCriticalAttack;

        public TMP_Dropdown BlueUnitHealthDrop
        {
            get { return _blueUnitHealth; }
        }

        public TMP_Dropdown BlueFastDrop
        {
            get { return _blueFastAttack; }
        }

        public TMP_Dropdown BlueStrongDrop
        {
            get { return _blueStrongAttack; }
        }

        public TMP_Dropdown BlueSpeedDrop
        {
            get { return _blueUnitSpeed; }
        }

        public TMP_Dropdown BlueMissDrop
        {
            get { return _blueMissProbability; }
        }

        public TMP_Dropdown BlueCriticalDrop
        {
            get { return _blueCriticalAttack; }
        }
    }
}