using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UsersSelectionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown firstPlayerDrodown;
    [SerializeField] private TMP_Dropdown secondPlayerDrodown;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button startGuestGameButton;
    [SerializeField] public TextMeshProUGUI errorMessage;

    private List<User> users = new List<User>();

    private void Start()
    {
        LoadUsers();
        PopulateDropdowns();

        startGameButton.onClick.AddListener(StartGame);
        startGuestGameButton.onClick.AddListener(StartGuestGame);
    }

    private void LoadUsers()
    {
        int usersCount = PlayerPrefs.GetInt("UsersCount", 0);

        for (int i = 0; i < usersCount; i++)
        {
            string name = PlayerPrefs.GetString($"Username_{i}", "");
            int score = PlayerPrefs.GetInt($"${name}_Score", 0);
            if (!string.IsNullOrEmpty(name))
            {
                users.Add(new User(name, score));
            }
        }
    }

    private void PopulateDropdowns()
    {
        List<string> userNames = new List<string>();
        foreach (User user in users)
        {
            userNames.Add(user.Name);
        }


        firstPlayerDrodown.ClearOptions();
        secondPlayerDrodown.ClearOptions();

        firstPlayerDrodown.AddOptions(userNames);
        secondPlayerDrodown.AddOptions(userNames);
    }

    private void StartGuestGame()
    {
        PlayerPrefs.SetString("FirstPlayerName", "Guest 1");
        PlayerPrefs.SetString("SecondPlayerName", "Guest 2");

        SceneManager.LoadScene("Game");
    }

    private void StartGame()
    {
        string firstPlayer = firstPlayerDrodown.options[firstPlayerDrodown.value].text;
        string secondPlayer = secondPlayerDrodown.options[secondPlayerDrodown.value].text;

        if (firstPlayer == secondPlayer)
        {
            errorMessage.text = "Chose different players";
            errorMessage.gameObject.SetActive(true);
            Debug.LogError("Chose different players");
            return;
        }

        errorMessage.gameObject.SetActive(false);
        PlayerPrefs.SetString("FirstPlayerName", firstPlayer);
        PlayerPrefs.SetString("SecondPlayerName", secondPlayer);

        SceneManager.LoadScene("Game");
    }

}
