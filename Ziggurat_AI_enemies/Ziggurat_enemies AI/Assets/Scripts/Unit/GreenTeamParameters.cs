using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class GreenTeamParameters : Dropdown
    {
        private List<TMP_Dropdown> _greenDropList;
        private Dictionary<string, float> _greenParameters;
        private GreenDropdowns _green;

        private float _healthGreen;
        private float _fastDamageGreen;
        private float _strongDamageGreen;
        private float _speedGreen;
        private float _missGreen;
        private float _criticalGreen;

        public Dictionary<string, float> GreenParameters
        {
            get { return _greenParameters; }
            set { _greenParameters = value; }
        }

        public void SetParameters()
        {
            _green = FindObjectOfType<GreenDropdowns>();
            _greenDropList = new List<TMP_Dropdown>();
            _greenParameters = new Dictionary<string, float>();

            _greenDropList = AddToList(_greenDropList, _green.GreenUnitHealthDrop, _green.GreenFastDrop, _green.GreenStrongDrop, _green.GreenSpeedDrop, _green.GreenMissDrop, _green.GreenCriticalDrop);
            _greenParameters = AddToList(_greenParameters, _healthGreen, _fastDamageGreen, _strongDamageGreen, _speedGreen, _missGreen, _criticalGreen);

            GreenParameters = ParameterUpgrade(_greenDropList, _green.GreenUnitHealthDrop, _green.GreenFastDrop, _green.GreenStrongDrop, _green.GreenSpeedDrop, _green.GreenMissDrop, _green.GreenCriticalDrop, _greenParameters);
        }
    }
}