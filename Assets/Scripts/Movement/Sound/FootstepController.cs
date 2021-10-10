using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RPG.Movement
{
    public class FootstepController : SerializedMonoBehaviour
    {
        [SerializeField] Dictionary<FootstepType, AudioClip[]> footstepTable = new Dictionary<FootstepType, AudioClip[]>();
        [SerializeField] AudioSource leftFootstepSource;
        [SerializeField] AudioSource rightFootstepSource;
        [SerializeField] Rigidbody rigidbody;

        private FootstepType currentFootStepType = FootstepType.defaultFootstep;

        private bool _shouldDelay = false;

        private void Update()
        {
            if (rigidbody.velocity.magnitude != 0)
            {
                PlayFootStep(leftFootstepSource);
                PlayFootStep(rightFootstepSource);
            }
        }

        private void PlayFootStep(AudioSource footstepSource)
        {
            if (footstepSource.isPlaying) return;
            if (!footstepTable.ContainsKey(currentFootStepType))
            {
                currentFootStepType = FootstepType.defaultFootstep;
            }
                AudioClip[] sources = footstepTable[currentFootStepType];
                System.Random rnd = new System.Random();
            if (!_shouldDelay)
            {
                footstepSource.PlayOneShot(sources[rnd.Next(0, sources.Length - 1)]);
                _shouldDelay = true;
            }
            else
            {
                _shouldDelay = false;
                footstepSource.clip = sources[rnd.Next(0, sources.Length - 1)];
                footstepSource.PlayDelayed(1f);
            }
        }

    }
}
