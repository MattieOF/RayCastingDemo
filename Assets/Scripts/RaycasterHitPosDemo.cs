using UnityEngine;

public class RaycasterHitPosDemo : MonoBehaviour
{
    [Header("Screen and Demo Settings")]
    public int width = 50;
    public int height = 50;
    public float length = 2.0f;
    public Color clearColor = Color.black;
    public Vector3 offset = Vector3.zero;

    [Header("Sphere Settings")] 
    public float radius = 0.5f;
    public Color sphereColor = Color.magenta;
    public float hitPointRadius = 0.05f;

    private float _aspectRatio;

    private void OnValidate()
    {
        _aspectRatio = (float) width / height;
    }
    
    void OnDrawGizmosSelected()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Get "screen" coordinate (-1 to 1 space)
                Vector2 coord = new(x / (float) width, y / (float) height);
                coord = coord.Multiply(2).Subtract(1); // -1 -> 1

                coord.x *= _aspectRatio;
                
                // Get ray origin and direction
                Vector3 rayOrigin = transform.position + offset;
                Vector3 rayDir = new(coord.x, coord.y, -1.0f);

                float a = Vector3.Dot(rayDir, rayDir);
                float b = 2 * Vector3.Dot(rayOrigin, rayDir);
                float c = Vector3.Dot(rayOrigin, rayOrigin) - radius * radius;
                float discriminant = b * b - 4.0f * a * c;

                if (discriminant >= 0.0f)
                {
                    float t0 = (-b - Mathf.Sqrt(discriminant)) / (2.0f * a);
                    float t1 = (-b + Mathf.Sqrt(discriminant)) / (2.0f * a);

                    Vector3 hitPosition0 = rayOrigin + rayDir.Multiply(t0);
                    Vector3 hitPosition1 = rayOrigin + rayDir.Multiply(t1);

                    Gizmos.color = sphereColor;
                    Gizmos.DrawSphere(hitPosition0 - offset, hitPointRadius);
                    Gizmos.DrawSphere(hitPosition1 - offset, hitPointRadius);
                }
                else
                    Gizmos.color = clearColor;

                if (Gizmos.color.a != 0)
                {
                    var position = transform.position;
                    Gizmos.DrawLine(position, position + rayDir * length);
                }
            }
        }
    }
}
