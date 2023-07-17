using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Airplane
{
    public class Propeller : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float minQuedsRPMs = 300f;
        [SerializeField] private float minTextureSwap = 600f;

        [SerializeField] private GameObject minDrop;
        [SerializeField] private GameObject blurredProp;

        [Header("Material Properties")]
        [SerializeField] private Material blurPropMat;
        [SerializeField] private Texture2D blurLevelOne;
        [SerializeField] private Texture2D blurLevelTwo;

        private void Start()
        {
            HandelSwaping(0f);
        }

        public void HandelPropeller(float currentRPM)
        {
            float dps = ((currentRPM * 360f) / 60f) * Time.deltaTime;

            transform.Rotate(Vector3.forward, dps);

            HandelSwaping(currentRPM);
        }

        private void HandelSwaping(float currentRPM)
        {
            if (currentRPM > minQuedsRPMs)
            {
                blurredProp.SetActive(true);
                minDrop.SetActive(false);

                if (blurPropMat != null && blurLevelOne != null && blurLevelTwo != null)
                {
                    if (currentRPM > minTextureSwap)
                    {
                        blurPropMat.SetTexture(Constant.MAIN_TEX, blurLevelTwo);
                    }
                    else
                    {
                        blurPropMat.SetTexture(Constant.MAIN_TEX, blurLevelOne);
                    }
                }
            }
            else
            {
                blurredProp.SetActive(false);
                minDrop.SetActive(true);
            }
        }
    }
}