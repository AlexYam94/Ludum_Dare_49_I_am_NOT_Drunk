using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Pickup
{
    public class TrapPickup : Pickup
    {
        [SerializeField]
        [Range(0, 100)]
        float staminaToReduce = 5f;

        protected override void PickupObject(Collider other)
        {
            StaminaManager.GetInstance().ChangeStamina(-1 * staminaToReduce);
        }

    }
}