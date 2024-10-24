using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraFitBounds : MonoBehaviour
    {
        public BoxCollider2D levelBounds;  // Collider o límites del nivel

        void Start()
        {
            FitCameraToBounds(levelBounds);
        }

        void Update()
        {
            FitCameraToBounds(levelBounds);
        }

        void FitCameraToBounds(BoxCollider2D bounds)
        {
            Camera cam = Camera.main;

            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = bounds.bounds.size.x / bounds.bounds.size.y;

            if (screenRatio >= targetRatio)
            {
                cam.orthographicSize = bounds.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                cam.orthographicSize = bounds.bounds.size.y / 2 * differenceInSize;
            }
        }
    }


 
  

