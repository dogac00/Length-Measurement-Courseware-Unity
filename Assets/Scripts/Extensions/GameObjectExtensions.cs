using UnityEngine;

public static class GameObjectExtensions
{
    public static void RemoveComponent<T>(this GameObject go) where T : Component
    {
        var component = go.GetComponent<T>();

        if (component != null)
            Object.Destroy(component);
    }

    public static bool HasComponent<T>(this GameObject go) where T : Component
    {
        var component = go.GetComponent<T>();
        
        return component != null;
    }

    public static GameObject GetChildNamed(this GameObject go, string name)
    {
        int count = go.transform.childCount;

        for (int i = 0; i < count; i++)
        {
            var child = go.transform.GetChild(i);

            if (child != null && child.name == name)
                return child.gameObject;
        }

        return null;
    }
}

