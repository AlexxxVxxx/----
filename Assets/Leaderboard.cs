using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject userEntryPrefab;
    [SerializeField] private InputField userNameInput;
    [SerializeField] private InputField userScoreInput;
    [SerializeField] private Button createUserButton;
    [SerializeField] public TextMeshProUGUI errorMessage;

    private List<User> users = new List<User>();

    void Start()
    {

        createUserButton.onClick.AddListener(AddUserToLeaderboard);
        LoadLeaderboard();
        UpdateLeaderboardUI();
    }

    public void AddUserToLeaderboard()
    {
        string name = userNameInput.text;
        string score = "0";
        if (!string.IsNullOrEmpty(name))
        {
            if (UserExists(name))
            {
                errorMessage.text = "User name already exists.";
                errorMessage.gameObject.SetActive(true);
                Debug.LogError("User name already exists.");
                return;
            }

            User newUser = new User(name, int.Parse(score));
            users.Add(newUser);
            UpdateLeaderboardUI();
            SaveLeaderboard();
            ClearInputFields();
            errorMessage.gameObject.SetActive(false);
        }
        else
        {
            errorMessage.text = "User name is empty.";
            errorMessage.gameObject.SetActive(true);
            Debug.LogError("User name is empty or null.");
        }

    }

    private void UpdateLeaderboardUI()
    {
        if (container == null)
        {
            Debug.LogError("Container is not assigned.");
            return;
        }

        if (userEntryPrefab == null)
        {
            Debug.LogError("User Entry Prefab is not assigned.");
            return;
        }

        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        users.Sort((x, y) => y.Score.CompareTo(x.Score));

        foreach (User user in users)
        {
            GameObject userEntry = Instantiate(userEntryPrefab, container);
            UserEntryUI entryUI = userEntry.GetComponent<UserEntryUI>();
            if (entryUI != null)
            {
                entryUI.Setup(user.Name, user.Score);
            }
            else
            {
                Debug.LogError("UserEntryUI component is missing on the userEntryPrefab.");
            }
        }
    }

    private void ClearInputFields()
    {
        if (userNameInput != null)
        {
            userNameInput.text = "";
            userScoreInput.text = "";
        }
        else
        {
            Debug.LogError("User Name Input is not assigned.");
        }
    }


    private void SaveLeaderboard()
    {
        PlayerPrefs.SetInt("UsersCount", users.Count);
        for (int i = 0; i < users.Count; i++)
        {
            PlayerPrefs.SetString($"Username_{i}", users[i].Name);
            PlayerPrefs.SetInt($"{userNameInput.text}_Score", users[i].Score);
        }

        PlayerPrefs.Save();
    }

    private void LoadLeaderboard()
    {
        int usersCount = PlayerPrefs.GetInt("UsersCount", 0);

        for (int i = 0; i < usersCount; i++)
        {
            string name = PlayerPrefs.GetString($"Username_{i}", "");
            int score = PlayerPrefs.GetInt($"{name}_Score", 0);
            if (!string.IsNullOrEmpty(name))
            {
                users.Add(new User(name, score));
            }
        }
    }

    private bool UserExists(string name)
    {
        foreach (User user in users)
        {
            if (user.Name == name)
            {
                return true;
            }
        }
        return false;
    }

}
