using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Airplane
{
    [RequireComponent(typeof(WheelCollider))]
    public class AirplaneWheel : MonoBehaviour
    {
        private WheelCollider wheelCollider;

        const float MORTOR_TORQUE = 0.0000000000001f;

        private void Start()
        {
            wheelCollider = GetComponent<WheelCollider>();
        }

        public void IntializeWheelColider()
        {
            wheelCollider.motorTorque = MORTOR_TORQUE;
        }
    }
}
