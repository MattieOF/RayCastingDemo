using UnityEngine;

public static class VectorUtil
{
    public static Vector2 Multiply(this Vector2 vec, float other)
    {
        vec.x *= other;
        vec.y *= other;
        return vec;
    }
    
    public static Vector2 Divide(this Vector2 vec, float other)
    {
        vec.x /= other;
        vec.y /= other;
        return vec;
    }
    
    public static Vector2 Add(this Vector2 vec, float other)
    {
        vec.x += other;
        vec.y += other;
        return vec;
    }
    
    public static Vector2 Subtract(this Vector2 vec, float other)
    {
        vec.x -= other;
        vec.y -= other;
        return vec;
    }
    
    public static Vector3 Multiply(this Vector3 vec, float other)
    {
        vec.x *= other;
        vec.y *= other;
        vec.z *= other;
        return vec;
    }
    
    public static Vector3 Divide(this Vector3 vec, float other)
    {
        vec.x /= other;
        vec.y /= other;
        vec.z /= other;
        return vec;
    }
    
    public static Vector3 Add(this Vector3 vec, float other)
    {
        vec.x += other;
        vec.y += other;
        vec.z += other;
        return vec;
    }
    
    public static Vector3 Subtract(this Vector3 vec, float other)
    {
        vec.x -= other;
        vec.y -= other;
        vec.z -= other;
        return vec;
    }
}
