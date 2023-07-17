using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Airplane
{
    public class AirplaneController : BaseRigidbodyController
    {
        [Header("Air Plane Properties")]
        [SerializeField] private BaseAirplane input;
        [SerializeField] private Transform centerOfGravity;

        [Tooltip("wieght is in LBS")]
        [SerializeField] private float airPlaneWieght = 800f;

        [Header("Engines")]
        [SerializeField] private List<AirplaneEngine> engines = new List<AirplaneEngine>();

        [Header("Wheels")]
        [SerializeField] private List<AirplaneWheel> airplaneWheels = new List<AirplaneWheel>();

        const float POUND_OF_KILES = 0.453592f;

        public override void Start()
        {
            base.Start();

            float finalMass = airPlaneWieght * POUND_OF_KILES;

            if (rb != null)
            {
                rb.mass = finalMass;

                if (centerOfGravity != null)
                {
                    rb.centerOfMass = centerOfGravity.localPosition;
                }
            }

            if (airplaneWheels != null)
            {
                if (airplaneWheels.Count > 0)
                {
                    foreach (AirplaneWheel airPlaneWheel in airplaneWheels)
                    {
                        airPlaneWheel.IntializeWheelColider();
                    }
                }
            }
        }

        protected override void HandelPhysics()
        {
            HandelEngine();
            HandelArrowDynamics();
            HandelStreering();
            HandelBrakes();
            HandelAltetitude();
        }

        private void HandelEngine()
        {
            if (engines != null)
            {
                if (engines.Count > 0)
                {
                    foreach (AirplaneEngine engine in engines)
                    {

                        rb.AddForce(engine.CalculateForce(input.Pitch));
                    }
                }
            }
        }

        private void HandelArrowDynamics()
        {

        }

        private void HandelStreering()
        {

        }

        private void HandelBrakes()
        {

        }

        private void HandelAltetitude()
        {

        }

        public void SetCenterOfGravity(Transform centerOfGravity)
        {
            this.centerOfGravity = centerOfGravity;
        }
    }
}