using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    private static int counter;

    public string HelpText;

    private static GameObject _descrPanel;

    void Start()
    {
        _descrPanel = Finder.FindObjectByName("DescrPanel", false);
    }

    void OnMouseOver()
    {
        var pos = this.transform.position;

        OpenPanel(new Vector3(pos.x + 2, pos.y - 2));
    }

    void OnMouseExit()
    {
        _descrPanel.SetActive(false);
    }

    private void OpenPanel(Vector3 position)
    {
        if (_descrPanel.activeSelf)
            return;

        _descrPanel.transform.position = position;

        var textChild = _descrPanel.GetChildNamed("Text");

        textChild.GetComponent<Text>().text = HelpText;
        
        _descrPanel.SetActive(true);
    }
}
