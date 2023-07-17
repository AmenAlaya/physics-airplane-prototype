using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Airplane
{
    public class AirplaneEngine : MonoBehaviour
    {
        [Header("Propeeties")]
        [SerializeField] private float maxForce = 200f;
        [SerializeField] private float maxRPM = 255f;
        [SerializeField] private AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Propellers")]
        [SerializeField] private Propeller propeller;

        public Vector3 CalculateForce(float thorttle)
        {
            //Calculate power
            float finalThrottle = Mathf.Clamp01(thorttle);
            finalThrottle = powerCurve.Evaluate(finalThrottle);

            //Calculate RPM
            float currentRPM = finalThrottle * maxRPM;
            if (propeller != null )
            {
                propeller.HandelPropeller(currentRPM);
            }


            //Create force
            float finalPower = finalThrottle * maxForce;

            return Vector3.forward * finalPower;
        }
    }
}
