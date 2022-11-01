using UnityEngine;

public class RaycasterScreenCoordDemo : MonoBehaviour
{
    [Header("Screen and Demo Settings")]
    public int width = 50;
    public int height = 50;
    public float length = 2.0f;

    void OnDrawGizmosSelected()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Get "screen" coordinate (-1 to 1 space)
                Vector2 coord = new(x / (float) width, y / (float) height);
                coord = coord.Multiply(2).Subtract(1); // -1 -> 1

                // Get ray origin and direction
                Vector3 rayOrigin = transform.position;
                Vector3 rayDir = new(coord.x, coord.y, -1.0f);

                // Calculate color
                Color rayColor = new(coord.x * 0.5f + 0.5f, coord.y * 0.5f + 0.5f, 0.0f, 1.0f);

                // Draw using gizmos
                Gizmos.color = rayColor;
                Gizmos.DrawLine(rayOrigin, rayOrigin + rayDir * length);
            }
        }
    }
}
