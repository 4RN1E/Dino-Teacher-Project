using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suriyun
{
    public class DinoAnimations : MonoBehaviour
    {
        public AnimatorController animatorController;
        private float timer = 0f;
        public float animationDuration = 2f;

        // Start is called before the first frame update
        void Start()
        {

            animatorController.SetInt("animation,1");

            StartCoroutine(AnimationCycle);

        }

        IEnumerator AnimationCycle()
        {
            while (true)
            {
                yield return new
            WaitForSeconds(animationDuration);
                animatorController.SetInt("animationsState,3");

                yield return new
                    WaitForSeconds(animationDuration);
                animatorController.SetInt("animationState,1");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}