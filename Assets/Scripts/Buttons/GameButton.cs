using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameButton : MonoBehaviour
{
    private Button button;

    protected virtual void Awake()
    {
        button = this.GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
