using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    private IEnumerable<ICheckable> objects;
    private GameObject winningPanel, tryAgain;

    void Awake()
    {
        objects = FindObjectsOfType<DragToBoxObject>().OfType<ICheckable>();

        winningPanel = Finder.FindObjectByTag(PanelTag.Success);
        tryAgain = Finder.FindObjectByTag(PanelTag.TryAgain);
    }

    public void Check()
    {
        if (objects.Any(checkable => !checkable.Check()))
        {
            tryAgain.SetActive(true);
        }
        else
        {
            winningPanel.SetActive(true);
        }
    }
}
