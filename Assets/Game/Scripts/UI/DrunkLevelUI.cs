using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.UI {
    public class DrunkLevelUI : UIUpdater
    {
        // Update is called once per frame
        public override void UpdateUI()
        {        
            _scale.y = DrunkLevelManager.GetInstance().GetDrunkLevelPercentage(); 
            _ui.localScale = _scale;
        }

    }
}