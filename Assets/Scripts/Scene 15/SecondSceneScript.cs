using UnityEngine;
using UnityEngine.UI;

public class SecondSceneScript : MonoBehaviour
{
    public InputField mInput, dmInput, cmInput, mmInput;
    public GameObject success, tryAgain;

    public void Check()
    {
        string m = mInput.text;
        string cm = cmInput.text;
        string dm = dmInput.text;
        string mm = mmInput.text;

        if (m.Trim() == "8" && dm.Trim() == "80" &&
            cm.Trim() == "800" && mm.Trim() == "8000")
            success.SetActive(true);
        else
            tryAgain.SetActive(true);
    }
}
