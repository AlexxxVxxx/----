using TMPro;
using UnityEngine;

public class UserEntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userNameText;
    [SerializeField] private TextMeshProUGUI userScoreText;

    public void Setup(string name, int score)
    {
        userNameText.text = name;
        userScoreText.text = score.ToString();
    }
}
