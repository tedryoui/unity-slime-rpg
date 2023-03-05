using System;
using UnityEngine;

namespace SlimeRPG
{
    public class CameraController : MonoBehaviour
    {
        public GameObject target;

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            var transformPosition = transform.position;
            transformPosition.x = target.transform.position.x;

            transform.position = transformPosition;
        }
    }
}