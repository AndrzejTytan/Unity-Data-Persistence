using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://docs.unity3d.com/6000.1/Documentation/ScriptReference/MonoBehaviour.html
public class StartButton : MonoBehaviour {
    public TMP_InputField playerNameInput;

    public void LoadGame() {
        PersistenceManager.playerName = GetPlayerName();
        Debug.Log("Player name: " + GetPlayerName());
        SceneManager.LoadScene("main");
    }

    private string GetPlayerName() {
        string playerName = playerNameInput.text;
        if (playerName == "") {
            return "Anonymous";
        }

        return playerName;
    }
}