using UnityEngine;

public class RaycasterNormalsDemo : MonoBehaviour
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
                    float[] t = {
                        (-b - Mathf.Sqrt(discriminant)) / (2.0f * a),
                        (-b + Mathf.Sqrt(discriminant)) / (2.0f * a)
                    };

                    foreach (float currentT in t)
                    {
                        Vector3 hitPosition = rayOrigin + rayDir.Multiply(currentT);

                        // Calculate normal
                        Vector3 sphereOrigin = Vector3.zero;
                        Vector3 normal = hitPosition - sphereOrigin;
                        normal.Normalize();
                        
                        Gizmos.color = new Color(normal.x, normal.y, normal.z, 1.0f);
                        Gizmos.DrawSphere(hitPosition - offset, hitPointRadius);
                    }

                    Gizmos.color = sphereColor;
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
