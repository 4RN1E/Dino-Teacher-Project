using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suriyun
{
    public class DinoAnimation : MonoBehaviour
    {
        public AnimatorController animatorController;


        // Start is called before the first frame update
        void Start()
        {

            animatorController.SetInt("animation,1");

        }

        // Update is called once per frame
        void Update()
        {


        }
    }
}