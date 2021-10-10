using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.UI
{
    public abstract class UIUpdater : MonoBehaviour
    {
        [SerializeField]
        protected RectTransform _ui;
        protected Vector3 _scale;

        // Start is called before the first frame update
        void Start()
        {
            if (_ui != null)
            {
                _scale = _ui.localScale;
            }
        }

        // Update is called once per frame
        void Update()
        {
            UpdateUI();
        }

        public abstract void UpdateUI();
    }
}
