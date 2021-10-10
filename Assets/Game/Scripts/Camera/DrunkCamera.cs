using LD.Movement;
using LD.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Camera
{
    public class DrunkCamera : MonoBehaviour
    {
        [SerializeField]
        Transform cameraToTilt = null;

        [SerializeField]
        float tiltSpeed = .3f;

        [SerializeField]
        DrunkMovement drunkMovement = null;

        // Start is called before the first frame update
        void Start()
        {
            IEnumerator coroutine = TiltCamera();
            StartCoroutine(coroutine);
            DrunkLevelManager.GetInstance().UpdateDrunkLevel(100);
            StaminaManager.GetInstance().ChangeStamina(100);
        }

        IEnumerator TiltCamera()
        {
            yield return new WaitForSeconds(5f);
            while (true)
            {
                float drunkLevelPercentage = DrunkLevelManager.GetInstance().GetDrunkLevelPercentage();
                if (drunkLevelPercentage < .2f) {
                    yield return null;
                    continue; 
                }
                Vector3 angles = cameraToTilt.rotation.eulerAngles;
                int leftRight = Random.Range(0, 100);
                float tiltAngle = GetTiltAngle(drunkLevelPercentage);
                if (leftRight < 50)
                {
                    tiltAngle *= -1;
                }
                angles.z = tiltAngle;
                
                //Tilt left or right
                while(Mathf.Floor(tiltAngle) > 5 || Mathf.Floor(tiltAngle) < -5)
                {
                    //Tilt left
                    if (leftRight >= 50)
                    {
                        //tiltAngle = Mathf.Clamp(tiltAngle - tiltSpeed, 0, GetTiltAngle(drunkLevelPercentage));
                        tiltAngle -= tiltSpeed;
                        transform.Rotate(Vector3.forward, tiltSpeed);
                        drunkMovement.StrafeLeft();
                    }
                    else //Tile Right
                    {
                        //tiltAngle = Mathf.Clamp(tiltAngle + tiltSpeed, GetTiltAngle(drunkLevelPercentage), 0);
                        tiltAngle += tiltSpeed;
                        transform.Rotate(Vector3.forward, tiltSpeed * -1);
                        drunkMovement.StrafeRight();
                    }
                    

                    yield return new WaitForSeconds(Time.deltaTime);
                }

                yield return new WaitForSeconds(.5f);

                //Tilt back to 0
                //while (Mathf.Abs(Mathf.Floor(transform.rotation.eulerAngles.z)) != 0)
                float tiltBackAngle = Mathf.Floor(transform.rotation.eulerAngles.z);
                if(tiltBackAngle > 180)
                {
                    tiltBackAngle -= 360;
                }
                while (tiltBackAngle!=0)
                {
                    if (leftRight < 50)
                    {
                        transform.Rotate(Vector3.forward, tiltSpeed);
                        tiltBackAngle += tiltSpeed;
                    }
                    else
                    {
                        transform.Rotate(Vector3.forward, tiltSpeed * -1);
                        tiltBackAngle -= tiltSpeed;
                    }
                    yield return new WaitForSeconds(Time.deltaTime);
                }
                transform.Rotate(Vector3.zero);
                yield return new WaitForSeconds(.1f);
            }
        }

        float GetTiltAngle(float drunkLevelPercentage)
        {
            if(drunkLevelPercentage >= .2f && drunkLevelPercentage < .4f)
            {
                return Random.Range(20,30);
            }
            else if (drunkLevelPercentage >= .4f && drunkLevelPercentage < .6f)
            {
                return Random.Range(30, 40);
            }
            else if (drunkLevelPercentage >= .6f && drunkLevelPercentage < .8f)
            {
                return Random.Range(40, 50);
            }
            else if (drunkLevelPercentage >= .8f && drunkLevelPercentage <= 1f)
            {
                return Random.Range(50, 55);
            }
            return 0f;
        }

    }
}