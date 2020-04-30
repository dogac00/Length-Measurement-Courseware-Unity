using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string HelpText;

    private static GameObject _descrPanel;

    void Start()
    {
        _descrPanel = Finder.FindObjectByName("DescrPanel", false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var pos = this.transform.position;

        OpenPanel(new Vector3(pos.x + 2, pos.y - 2));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _descrPanel.SetActive(false);
    }

    private void OpenPanel(Vector3 position)
    {
        _descrPanel.transform.position = position;

        var textChild = _descrPanel.GetChildNamed("Text");

        textChild.GetComponent<Text>().text = HelpText;
        
        _descrPanel.SetActive(true);
    }
}
