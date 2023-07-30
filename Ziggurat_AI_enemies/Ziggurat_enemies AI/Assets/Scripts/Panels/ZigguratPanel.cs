using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Ziggurat
{
    public class ZigguratPanel : MonoBehaviour
    {

        private bool _isPanelOpen = false;


        public void PanelActivate(GameObject zigguratPanel)
        {
            if (zigguratPanel != null && !_isPanelOpen)
            {
                zigguratPanel.SetActive(true);
                _isPanelOpen = true;
            }
            else if (zigguratPanel != null && _isPanelOpen)
            {
                zigguratPanel.SetActive(false);
                _isPanelOpen = false;
            }

        }
    }
}