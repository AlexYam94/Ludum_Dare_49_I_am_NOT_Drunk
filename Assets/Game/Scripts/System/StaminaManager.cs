using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD.System {
    public class StaminaManager : Singleton<StaminaManager>
    {
        [SerializeField]
        float stamina = 100f;
        [SerializeField]
        float staminaDecayPerSecond = 10f;
        [SerializeField]
        float staminaDecayValue = .01f;

        private void Start()
        {
            IEnumerator coroutine = DecayStamina();
            StartCoroutine(coroutine);
        }

        private void Update()
        {
            if(stamina <= 0)
            {
                SceneManager.LoadScene(5);
            }
        }

        IEnumerator DecayStamina()
        {
            while (stamina > 0)
            {
                ChangeStamina(-1 * staminaDecayValue);
                yield return new WaitForSeconds(1/staminaDecayPerSecond);
            }
        }
    
        public void ChangeStamina(float amount)
        {
            stamina = Mathf.Clamp(stamina + amount, 0, 100);
        }

        public float GetStaminaPercentage()
        {
            return stamina / 100;
        }
    }
}