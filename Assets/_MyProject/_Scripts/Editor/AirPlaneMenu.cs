using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

namespace Airplane
{

    public static class AirplaneMenu
    {
        [MenuItem("Airplane Tools/Create New Airplane")]
        public static void CreateNewAirPlane()
        {
            GameObject currentSelection = new GameObject("NewPane");
            AirplaneController airPlaneController = currentSelection.AddComponent<AirplaneController>();

            CreateGameObject(currentSelection.transform, "PlaneVisual");
            CreateGameObject(currentSelection.transform, "CollisionGroup");
            GameObject centreOfGravity = CreateGameObject(currentSelection.transform, "CentreOfGravity");
            airPlaneController.SetCenterOfGravity(centreOfGravity.transform);
        }

        private static GameObject CreateGameObject(Transform parent, string gameObjectName)
        {
            GameObject g_object = new GameObject(gameObjectName);
            g_object.transform.SetParent(parent);

            return g_object;
        }
    }
}
