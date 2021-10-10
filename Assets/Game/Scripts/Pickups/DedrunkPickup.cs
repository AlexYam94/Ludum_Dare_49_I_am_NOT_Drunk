using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Pickup
{
    public class DedrunkPickup : Pickup
    {
        [SerializeField]
        [Range(0,100)]
        float _dedrunkNumber = 10f;

        [SerializeField]
        [Range(0, 100)]
        float _staminaReduceAmount = 10f;

        protected override void PickupObject(Collider other)
        {
            DrunkLevelManager.GetInstance().UpdateDrunkLevel(-1 * _dedrunkNumber);
            StaminaManager.GetInstance().ChangeStamina(-1 * _staminaReduceAmount);
            Destroy(gameObject);
        }
    }
}