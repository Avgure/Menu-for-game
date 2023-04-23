using System;
using System.Collections;
using UnityEngine;

namespace Movement
{

    [RequireComponent(typeof(Transform))]
    public class KinematicMovement : MonoBehaviour
    {
        private Action<Vector3, float> _onRotationChanged;
        private Coroutine RotateOnOwnAxisCoroutine;

        public void StartRotation(Vector3 rotationDirection, float speed)
        {
            rotationDirection = rotationDirection.normalized;
            float _xComponentOfRotation = rotationDirection.x;
            float _yComponentOfRotation = rotationDirection.y;
            float _zComponentOfRotation = rotationDirection.z;
            Vector3 rotation = new(_xComponentOfRotation, _yComponentOfRotation, _zComponentOfRotation);
            Transform transform = GetComponent<Transform>();

            RotateOnOwnAxisCoroutine = StartCoroutine(RotateOnOwnAxis(transform, rotation, speed));
        }

        public void StopRotation()
        {
            StopCoroutine(RotateOnOwnAxisCoroutine);
        }

        public void ChangeRotation(Vector3 nerRotationDirection, float newSpeed)
        {
            _onRotationChanged?.Invoke(nerRotationDirection, newSpeed);
        }

        private IEnumerator RotateOnOwnAxis(Transform objectTransform, Vector3 rotationDirection, float speed)
        {
            Vector3 finalRotation = new();
            _onRotationChanged += RefreshParameters;

            while (true)
            {
                yield return null;

                finalRotation = GetRotationChanging(rotationDirection, speed);
                objectTransform.Rotate(finalRotation);
            }

            Vector3 GetRotationChanging(Vector3 newRotationDirection, float newSpeed)
            {
                float x = GetRotationAxixChanging(newRotationDirection.x, newSpeed);
                float y = GetRotationAxixChanging(newRotationDirection.y, newSpeed);
                float z = GetRotationAxixChanging(newRotationDirection.z, newSpeed);

                Vector3 rotationChanging = new(x, y, z);
                return rotationChanging;
            }

            float GetRotationAxixChanging(float valueOfRotationDirectionAxis, float speed)
            {
                return valueOfRotationDirectionAxis * Time.deltaTime * speed;
            }

            void RefreshParameters(Vector3 newRotationDirection, float newSpeed)
            {
                rotationDirection = newRotationDirection.normalized;
                speed = newSpeed;
            }
        }
    }
}