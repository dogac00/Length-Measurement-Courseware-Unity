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
}
