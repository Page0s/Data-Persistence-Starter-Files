using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject inputField;

    public void SetPlayerName()
    {
        DataManager.Instance.SetPlayerName(inputField.GetComponent<Text>().text);
        Debug.Log(inputField.GetComponent<Text>().text);
    }
}
