using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Pickup{
    public class DrunkPickup : Pickup
    {
        [SerializeField]
        [Range(0, 100)]
        float _drunkNumber = 15f;

        [SerializeField]
        [Range(0, 100)]
        float _drunkRecoverAmount = 5f;

        protected override void PickupObject(Collider other)
        {
            DrunkLevelManager.GetInstance().UpdateDrunkLevel(_drunkNumber);
            StaminaManager.GetInstance().ChangeStamina(_drunkRecoverAmount);
            Destroy(gameObject);
        }
    }
}