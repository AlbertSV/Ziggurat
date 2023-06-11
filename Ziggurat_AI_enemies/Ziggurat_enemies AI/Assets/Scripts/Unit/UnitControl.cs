using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class UnitControl : MonoBehaviour, IPanel
    {
        private GameObject _unitOpenButton;
        private GameObject _unitPanelColor;
        private TeamColor teamColorUnit;

        public GameObject UnitOpenButton
        {
            get { return _unitOpenButton; }
            set { _unitOpenButton = value; }
        }


        private void Start()
        {
            UnitOpenButton = GameManager.Manager._unitButton;
        }

        public void PanelButtonControl(GameObject hitted)
        {
            if (hitted != null)
            {
                UnitOpenButton.SetActive(true);
            }
        }

        public GameObject SetPanelColor()
        {
            teamColorUnit = gameObject.GetComponent<GetColor>().GetTeamColor;

            if (teamColorUnit == TeamColor.Red)
            {
                _unitPanelColor = GameManager.Manager._redUnitPanel;
            }
            else if (teamColorUnit == TeamColor.Blue)
            {
                _unitPanelColor = GameManager.Manager._blueUnitPanel;
            }
            else
            {
                _unitPanelColor = GameManager.Manager._greenUnitPanel;
            }

            return _unitPanelColor;
        }
    }
}