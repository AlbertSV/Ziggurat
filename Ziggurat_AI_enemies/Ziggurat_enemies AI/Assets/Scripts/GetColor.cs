using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class GetColor : MonoBehaviour
    {
        [SerializeField]
        private TeamColor teamColor;

        public TeamColor GetTeamColor
        {
            get { return teamColor; }
            set {  teamColor = value; }
        }
    }
}