using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Pickup
{
    public abstract class Pickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PickupObject(other);
            }
        }

        protected abstract void PickupObject(Collider other);
    }
}