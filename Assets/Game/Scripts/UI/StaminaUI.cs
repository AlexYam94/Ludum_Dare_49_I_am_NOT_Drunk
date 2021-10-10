using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.UI
{
    public class StaminaUI : UIUpdater
    {
        public override void UpdateUI()
        {
            float xScale = StaminaManager.GetInstance().GetStaminaPercentage();
            _scale.x = xScale;
            _ui.localScale = _scale;
        }

    }
}