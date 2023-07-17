using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class GreenDropdowns : MonoBehaviour
    {

        [SerializeField] private TMP_Dropdown _greenUnitHealth;
        [SerializeField] private TMP_Dropdown _greenFastAttack;
        [SerializeField] private TMP_Dropdown _greenStrongAttack;
        [SerializeField] private TMP_Dropdown _greenUnitSpeed;
        [SerializeField] private TMP_Dropdown _greenMissProbability;
        [SerializeField] private TMP_Dropdown _greenCriticalAttack;

        public TMP_Dropdown GreenUnitHealthDrop
        {
            get { return _greenUnitHealth; }
        }

        public TMP_Dropdown GreenFastDrop
        {
            get { return _greenFastAttack; }
        }

        public TMP_Dropdown GreenStrongDrop
        {
            get { return _greenStrongAttack; }
        }

        public TMP_Dropdown GreenSpeedDrop
        {
            get { return _greenUnitSpeed; }
        }

        public TMP_Dropdown GreenMissDrop
        {
            get { return _greenMissProbability; }
        }

        public TMP_Dropdown GreenCriticalDrop
        {
            get { return _greenCriticalAttack; }
        }
    }
}