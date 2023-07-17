using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class BlueTeamParameters : Dropdown
    {
        private List<TMP_Dropdown> _blueDropList;
        private Dictionary<string, float> _blueParameters;
        private BlueDropdowns _blue;

        private float _healthBlue;
        private float _fastDamageBlue;
        private float _strongDamageBlue;
        private float _speedBlue;
        private float _missBlue;
        private float _criticalBlue;

        public Dictionary<string, float> BlueParameters
        {
            get { return _blueParameters; }
            set { _blueParameters = value; }
        }

        public override float Speed
        {
            get { return _speedBlue; }
            set { _speedBlue = value; }
        }

        public override float Health
        {
            get { return _healthBlue; }
            set { _healthBlue = value; }
        }

        public override float FastDamage
        {
            get { return _fastDamageBlue; }
            set { _fastDamageBlue = value; }
        }

        public override float StrongDamage
        {
            get { return _strongDamageBlue; }
            set { _strongDamageBlue = value; }
        }

        public override float Miss
        {
            get { return _missBlue; }
            set { _missBlue = value; }
        }

        public override float Critical
        {
            get { return _criticalBlue; }
            set { _criticalBlue = value; }
        }

        public void SetParameters()
        {
            _blue = FindObjectOfType<BlueDropdowns>();
            _blueDropList = new List<TMP_Dropdown>();
            _blueParameters = new Dictionary<string, float>();

            _blueDropList = AddToList(_blueDropList, _blue.BlueUnitHealthDrop, _blue.BlueFastDrop, _blue.BlueStrongDrop, _blue.BlueSpeedDrop, _blue.BlueMissDrop, _blue.BlueCriticalDrop);
            _blueParameters = AddToList(_blueParameters, _healthBlue, _fastDamageBlue, _strongDamageBlue, _speedBlue, _missBlue, _criticalBlue);

            BlueParameters = ParameterUpgrade(_blueDropList, _blue.BlueUnitHealthDrop, _blue.BlueFastDrop, _blue.BlueStrongDrop, _blue.BlueSpeedDrop, _blue.BlueMissDrop, _blue.BlueCriticalDrop, _blueParameters);
        }
    }
}