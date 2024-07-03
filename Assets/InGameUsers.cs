using TMPro;
using UnityEngine;

public class InGameUsers : MonoBehaviour
{

    public TextMeshProUGUI firstUserText;
    public TextMeshProUGUI secondUserText;

    void Start()
    {
        SetUsers();
    }

    void Update()
    {

    }

    private void SetUsers()
    {
        string firstName = PlayerPrefs.GetString("FirstPlayerName", "");
        string secondName = PlayerPrefs.GetString("SecondPlayerName", "");

        firstUserText.text = firstName;
        secondUserText.text = secondName;
    }

}
