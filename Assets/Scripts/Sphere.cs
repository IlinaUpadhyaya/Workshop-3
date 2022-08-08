// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class Sphere : SceneEntity
{
    [SerializeField] private Vector3 center;
    [SerializeField] private float radius;
    
    public Vector3 Center => this.center;
    public float Radius => this.radius;
    
    public override RaycastHit? Intersect(Ray ray)
    { 
        // By default we use the Unity engine for ray-entity collisions.
        // See the parent 'SceneEntity' class definition for details.
        // Task: Replace with your own intersection computations.
        float b = 2.0f * (Vector3.Dot(ray.direction, ray.origin - this.center));
        float c = (float)(System.Math.Pow(Vector3.Magnitude(ray.origin - this.center), 2.0f) - System.Math.Pow(this.radius, 2.0f));
        float delta = (float)(System.Math.Pow(b, 2.0) - 4.0 * c);
        float t = 0;

        if (delta >= 0)
        {
            float t1 = (float)((-b + System.Math.Sqrt(delta)) / 2.0);
            float t2 = (float)((-b - System.Math.Sqrt(delta)) / 2.0);
            if (t1 > 0 && t2 > 0) t = t1 < t2 ? t1 : t2;
        }
        if (t <= 0) return null;
        Vector3 position = ray.origin + t * ray.direction;
        Vector3 normal = position - this.center;
        RaycastHit hit_data = new RaycastHit(t, position, normal, ray.direction, null);

        // return hit_data;
        return base.Intersect(ray);
    }
}
