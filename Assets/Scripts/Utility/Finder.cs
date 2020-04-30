using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Finder
{
    public static GameObject FindObjectByTag(string tag)
    {
        return Resources.FindObjectsOfTypeAll<GameObject>()
                        .FirstOrDefault(go => go.tag == tag);
    }

    public static GameObject FindObjectByName(string name, bool isActive = true)
    {
        if (!isActive)
        {
            var objs = Resources.FindObjectsOfTypeAll<GameObject>();

            foreach (var o in objs)
                if (o != null && o.name == name)
                    return o;

            return null;
        }

        var gameObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (var gameObject in gameObjects)
            if (gameObject != null && gameObject.name == name)
                return gameObject;

        return null;
    }

    public static GameObject FindGameObjectOfType<T>() where T : MonoBehaviour
    {
        return Resources.FindObjectsOfTypeAll<T>().First().gameObject;
    }
}
