using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Airplane
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class BaseRigidbodyController : MonoBehaviour
    {
        protected Rigidbody rb;
        protected AudioSource audioSource;

        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.playOnAwake = false;
            }
        }

        void FixedUpdate()
        {
            if (rb != null)
            {
                HandelPhysics();
            }
        }

        //This method its used to be overrided by the child classes
        protected virtual void HandelPhysics() {}
    }
}
