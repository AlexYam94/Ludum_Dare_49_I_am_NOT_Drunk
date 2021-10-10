using ECM.Controllers;
using LD.Camera;
using LD.Movement;
using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LD.Camera
{
    public class CameraAnimationController : MonoBehaviour
    {
        [SerializeField]
        UnityEvent OnAnimationPlay;

        [SerializeField]
        UnityEvent OnAnimationFinish;

        [SerializeField]
        UnityEvent OnVomiting;

        [SerializeField]
        float vomitLoseStamina = 10f;


        [SerializeField]
        Animator animator = null;

        [SerializeField]
        ParticleSystem vomitParticle = null;

        [SerializeField]
        Rigidbody rigidbody = null;

        [SerializeField]
        DrunkCamera drunkCamera = null;

        [SerializeField]
        DrunkMovement drunkMovement = null;

        private bool _isFinishPlayedAnimation = true;

        private void Start()
        {
            animator.enabled = false;
        }

        private void Update()
        {
            if (DrunkLevelManager.GetInstance().GetDrunkLevelPercentage() >= 1)
            {
                PlayVomitAnimation();
            }
        }

        private void LateUpdate()
        {
            if (_isFinishPlayedAnimation)
            {
                animator.enabled = false;
            }
        }

        public void PlayVomitAnimation()
        {
            animator.enabled = true;
            animator.SetBool("Vomit", true);
        }

        public void Vomit()
        {
            OnVomiting?.Invoke();
            StaminaManager.GetInstance().ChangeStamina(vomitLoseStamina * -1);
            vomitParticle.Play();
        }

        public void StopVomiting()
        {
            vomitParticle.Stop();
        }

        public void DisablePlayerMove()
        {
            OnAnimationPlay?.Invoke();

            rigidbody.isKinematic = true;
            _isFinishPlayedAnimation = false;
            drunkCamera.enabled = false;
            drunkMovement.enabled = false;
            Vector3 angles = transform.rotation.eulerAngles;
            angles.z = 0;
            transform.rotation = Quaternion.Euler(angles);
        }

        public void EnablePlayerMove()
        {
            OnAnimationFinish?.Invoke();

            _isFinishPlayedAnimation = true;

            rigidbody.isKinematic = false;
            drunkCamera.enabled = true;
            drunkMovement.enabled = true;

            DrunkLevelManager.GetInstance().UpdateDrunkLevel(-50);
        }
    }
}