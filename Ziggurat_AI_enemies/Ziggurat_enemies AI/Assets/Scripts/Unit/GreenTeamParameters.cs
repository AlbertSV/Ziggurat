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

        public override float Speed
        {
            get { return _speedGreen; }
            set { _speedGreen = value; }
        }

        public override float Health
        {
            get { return _healthGreen; }
            set { _healthGreen = value; }
        }

        public override float FastDamage
        {
            get { return _fastDamageGreen; }
            set { _fastDamageGreen = value; }
        }

        public override float StrongDamage
        {
            get { return _strongDamageGreen; }
            set { _strongDamageGreen = value; }
        }

        public override float Miss
        {
            get { return _missGreen; }
            set { _missGreen = value; }
        }

        public override float Critical
        {
            get { return _criticalGreen; }
            set { _criticalGreen = value; }
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