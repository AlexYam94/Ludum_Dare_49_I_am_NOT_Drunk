using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingScript : MonoBehaviour
{
    [SerializeField]
    PlayableDirector notSoDrunk;


    [SerializeField]
    PlayableDirector Drunk;

    // Start is called before the first frame update
    void Start()
    {
        if (DrunkLevelManager.GetInstance().GetDrunkLevelPercentage() > .7f)
        {
            Drunk.enabled = true;
        }
        else
        {
            notSoDrunk.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
