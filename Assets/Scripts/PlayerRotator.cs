using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private RotateTarget[] targets;

    private float targetAngle;

    private readonly Dictionary<Transform, float> velocities = new();

    private void Update()
    {
        foreach (RotateTarget target in targets)
        {
            Transform obj = target.obj;
            
            float currentVelocity = velocities.GetValueOrDefault(obj, 0f);
                
            Vector3 rot = obj.localRotation.eulerAngles;
            rot.z = Mathf.SmoothDampAngle(rot.z, targetAngle, ref currentVelocity, target.smoothTime);
            obj.localRotation = Quaternion.Euler(rot);

            velocities[obj] = currentVelocity;
        }
    }

    public void ApplyDirection(Vector2 direction)
    {
        targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    }

    [System.Serializable]
    public struct RotateTarget
    {
        public Transform obj;
        public float smoothTime;
    }
}
