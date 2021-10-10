using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Movement {
    public class DrunkMovement : MonoBehaviour
    {
        [SerializeField]
        Rigidbody rb = null;

        [SerializeField]
        float maxForceToStrafe = 100f;

        [SerializeField]
        float strafeForceMultiplierForLowDrunkLevel = 1.5f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        [ContextMenu("Strafe Left")]
        public void StrafeLeft()
        {
            float drunkFactor = DrunkLevelManager.GetInstance().GetDrunkFactor();
            float tmp = drunkFactor < .7f ? maxForceToStrafe * strafeForceMultiplierForLowDrunkLevel : maxForceToStrafe;
            Strafe(Vector3.left * tmp * drunkFactor);
        }

        [ContextMenu("Strafe Right")]
        public void StrafeRight()
        {
            float drunkFactor = DrunkLevelManager.GetInstance().GetDrunkFactor();
            float tmp = drunkFactor < .7f ? maxForceToStrafe * strafeForceMultiplierForLowDrunkLevel : maxForceToStrafe;
            Strafe(Vector3.right* tmp * drunkFactor);
        }

        private void Strafe(Vector3 force)
        {
            rb.AddRelativeForce(force, ForceMode.Force);
        }
    }
}