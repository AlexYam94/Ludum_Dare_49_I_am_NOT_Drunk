using LD.Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.System
{
    public class DrunkLevelManager : Singleton<DrunkLevelManager>
    {
        [Range(0,100)]
        [SerializeField]
        private float _levelOfDrunk = 50f;

        private float _drunkFactor;

        protected override void Init()
        {
            _drunkFactor = _levelOfDrunk/100;
            DontDestroyOnLoad(this);
        }

        public void UpdateDrunkLevel(float amount)
        {
            _levelOfDrunk = Mathf.Clamp(_levelOfDrunk += amount, 0, 100);
        }

        public float GetDrunkLevelPercentage()
        {
            if (_levelOfDrunk == 0) return .01f;
            return _levelOfDrunk/100;
        }

        public float GetDrunkFactor()
        {
            return GetDrunkLevelPercentage();
        }
    }
}