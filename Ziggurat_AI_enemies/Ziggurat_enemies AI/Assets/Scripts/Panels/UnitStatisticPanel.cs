using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class UnitStatisticPanel : MonoBehaviour
    {

        [SerializeField] private TMP_Text _redHealthText;
        [SerializeField] private TMP_Text _redFastText;
        [SerializeField] private TMP_Text _redStrongText;
        [SerializeField] private TMP_Text _redMissText;
        [SerializeField] private TMP_Text _redSpeedText;
        [SerializeField] private TMP_Text _redCriticalText;

        [SerializeField] private TMP_Text _blueHealthText;
        [SerializeField] private TMP_Text _blueFastText;
        [SerializeField] private TMP_Text _blueStrongText;
        [SerializeField] private TMP_Text _blueMissText;
        [SerializeField] private TMP_Text _blueSpeedText;
        [SerializeField] private TMP_Text _blueCriticalText;

        [SerializeField] private TMP_Text _greenHealthText;
        [SerializeField] private TMP_Text _greenFastText;
        [SerializeField] private TMP_Text _greenStrongText;
        [SerializeField] private TMP_Text _greenMissText;
        [SerializeField] private TMP_Text _greenSpeedText;
        [SerializeField] private TMP_Text _greenCriticalText;

        private GameObject _unit;

        private void TextUpdate()
        {
            _unit = FindObjectOfType<SelectedTarget>().gameObject;
            
            if(_unit.GetComponentInParent<GetColor>().GetTeamColor == TeamColor.Red)
            {
                _redHealthText.text = "Health: " + _unit.GetComponentInParent<RedTeamParameters>().RedParameters["Health"];
                _redFastText.text = "Fast Damage: " + _unit.GetComponentInParent<RedTeamParameters>().RedParameters["FastDamage"];
                _redStrongText.text = "Strong Damage: " + _unit.GetComponentInParent<RedTeamParameters>().RedParameters["StrongDamage"];
                _redSpeedText.text = "Speed: " + _unit.GetComponentInParent<RedTeamParameters>().RedParameters["Speed"];
                _redCriticalText.text = "Critical %: " + _unit.GetComponentInParent<RedTeamParameters>().RedParameters["Critical"];
                _redMissText.text = "Miss %: " + _unit.GetComponentInParent<RedTeamParameters>().RedParameters["Miss"];
            }
            else if (_unit.GetComponentInParent<GetColor>().GetTeamColor == TeamColor.Blue)
            {
                _blueHealthText.text = "Health: " + _unit.GetComponentInParent<BlueTeamParameters>().BlueParameters["Health"];
                _blueFastText.text = "Fast Damage: " + _unit.GetComponentInParent<BlueTeamParameters>().BlueParameters["FastDamage"];
                _blueStrongText.text = "Strong Damage: " + _unit.GetComponentInParent<BlueTeamParameters>().BlueParameters["StrongDamage"];
                _blueSpeedText.text = "Speed: " + _unit.GetComponentInParent<BlueTeamParameters>().BlueParameters["Speed"];
                _blueCriticalText.text = "Critical %: " + _unit.GetComponentInParent<BlueTeamParameters>().BlueParameters["Critical"];
                _blueMissText.text = "Miss %: " + _unit.GetComponentInParent<BlueTeamParameters>().BlueParameters["Miss"];
            }
            else
            {
                _greenHealthText.text = "Health: " + _unit.GetComponentInParent<GreenTeamParameters>().GreenParameters["Health"];
                _greenFastText.text = "Fast Damage: " + _unit.GetComponentInParent<GreenTeamParameters>().GreenParameters["FastDamage"];
                _greenStrongText.text = "Strong Damage: " + _unit.GetComponentInParent<GreenTeamParameters>().GreenParameters["StrongDamage"];
                _greenSpeedText.text = "Speed: " + _unit.GetComponentInParent<GreenTeamParameters>().GreenParameters["Speed"];
                _greenCriticalText.text = "Critical %: " + _unit.GetComponentInParent<GreenTeamParameters>().GreenParameters["Critical"];
                _greenMissText.text = "Miss %: " + _unit.GetComponentInParent<GreenTeamParameters>().GreenParameters["Miss"];
            }
        }

    }
}