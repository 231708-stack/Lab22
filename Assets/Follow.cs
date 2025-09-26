using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // The car to follow
    public Vector3 offset = new Vector3(0, 5, -10); // Position offset relative to car
    public float smoothSpeed = 0.125f;              // Smooth follow speed

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position with offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Optional: Make camera look at the car
        transform.LookAt(target);
    }
}
