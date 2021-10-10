using LD.System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VisualManager : MonoBehaviour
{
    [SerializeField]
    PostProcessVolume volume = null;

    [SerializeField]
    [Range(0.1f,0.8f)]
    float lenDistortionValue = .25f;

    [SerializeField]
    float distortionOscillicateRate = 0.5f;

    [SerializeField]
    float focalLength = 200f;

    private LensDistortion _ld;
    private DepthOfField _dof;
    private Vignette v;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings<LensDistortion>(out _ld);
        volume.profile.TryGetSettings<DepthOfField>(out _dof);
        _dof.focalLength.value = focalLength;
        volume.profile.TryGetSettings<Vignette>(out v);
    }

    // Update is called once per frame
    void Update()
    {
        DistortLens();
        Dof();
        Vignette();
    }

    private void Vignette()
    {
        v.intensity.value = 1 - 1 * StaminaManager.GetInstance().GetStaminaPercentage();
    }

    private void Dof()
    {
        _dof.focalLength.value = focalLength * DrunkLevelManager.GetInstance().GetDrunkFactor();
    }

    private void DistortLens()
    {//TODO: Update centerX Y to initial value on drunk level changed
        float tmpDistortionOscillicateRate = distortionOscillicateRate * DrunkLevelManager.GetInstance().GetDrunkFactor();
        float tmpLenDistortionValue = lenDistortionValue * DrunkLevelManager.GetInstance().GetDrunkFactor();
        _ld.centerX.value = Mathf.PingPong(Time.time * tmpDistortionOscillicateRate, tmpLenDistortionValue * 2) - tmpLenDistortionValue;
        _ld.centerY.value = Mathf.PingPong(Time.time * tmpDistortionOscillicateRate, tmpLenDistortionValue * 2) * -1 + tmpLenDistortionValue;
    }
}
