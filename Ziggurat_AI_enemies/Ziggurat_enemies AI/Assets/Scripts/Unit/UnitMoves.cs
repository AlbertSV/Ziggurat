using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class UnitMoves : MonoBehaviour
    {
        private GameObject unit;

        private Vector3 target = new Vector3(0f, 5f, 0f);
        private UnitEnvironment unitEnvironment;

        private void Awake()
        {
            unitEnvironment = this.gameObject.GetComponent<UnitEnvironment>();
            unit = this.gameObject;
            
        }

        private void Update()
        {
            //UnitMove();
            //AnimationControl();
        }

        private void AnimationControl()
        {
            if(Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > Mathf.Epsilon || Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > Mathf.Epsilon)
            {
                unitEnvironment.Moving(1f);
            }
            else
            {
                unitEnvironment.Moving(0f);
            }
        }

        private void UnitMove()
        {
            //if (Mathf.Abs(unit.transform.position.x - target.x) >= GameManager.Manager.targetRange || Mathf.Abs(unit.transform.position.z - target.z) >= GameManager.Manager.targetRange)
            //{
            //    unit.transform.position = Vector3.MoveTowards(unit.transform.position, target, GameManager.Manager.unitSpeed);
            //}

        }

       
    }
}