using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Ziggurat
{
    public class RedTeamParameters : Dropdown
    {
        private List<TMP_Dropdown> _redDropList;
        private Dictionary<string, float> _redParameters;
        private RedDropdowns _red;

        private float _healthRed;
        private float _fastDamageRed;
        private float _strongDamageRed;
        private float _speedRed;
        private float _missRed;
        private float _criticalRed;

        public Dictionary<string, float> RedParameters
        {
            get { return _redParameters; }
            set { _redParameters = value; }
        }

        public void SetParameters()
        {
            _red = FindObjectOfType<RedDropdowns>();

            _redDropList = new List<TMP_Dropdown>();
            _redParameters = new Dictionary<string, float>();

            _redDropList = AddToList(_redDropList, _red.RedUnitHealthDrop, _red.RedFastDrop, _red.RedStrongDrop, _red.RedSpeedDrop, _red.RedMissDrop, _red.RedCriticalDrop);
            _redParameters = AddToList(_redParameters, _healthRed, _fastDamageRed, _strongDamageRed, _speedRed, _missRed, _criticalRed);

            RedParameters = ParameterUpgrade(_redDropList, _red.RedUnitHealthDrop, _red.RedFastDrop, _red.RedStrongDrop, _red.RedSpeedDrop, _red.RedMissDrop, _red.RedCriticalDrop, _redParameters);
        }
    }
}