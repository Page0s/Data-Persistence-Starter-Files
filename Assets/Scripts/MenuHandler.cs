using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] Text bestScoreText;

    private void Start()
    {
        bestScoreText.text = $"Best Score : {DataManager.Instance.GetBestPlayerName()} : {DataManager.Instance.GetBestScore()}";
    }

    public void SetPlayerName()
    {
        DataManager.Instance.SetPlayerName(inputField.GetComponent<Text>().text);
    }
}
