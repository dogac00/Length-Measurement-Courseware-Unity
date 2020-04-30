using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    void Start()
    {
        var fields = GameObject.FindObjectsOfType<Text>();

        foreach (var field in fields)
        {
            StartCoroutine(TypeRoutine(field));
        }
    }

    IEnumerator TypeRoutine(Text field)
    {
        yield return new WaitForSeconds(1);

        string content = field.text;
        int counter = 1;

        field.text = "";

        while (field.text != content)
        {
            field.text = content.Substring(0, counter++);

            yield return null;
        }
    }
}
