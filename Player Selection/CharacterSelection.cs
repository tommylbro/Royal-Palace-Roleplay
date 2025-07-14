using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] characters; // Assign your character prefabs in the inspector
    private int selectedIndex = 0;

    private void Start()
    {
        ShowSelectedCharacter();
    }

    public void NextCharacter()
    {
        characters[selectedIndex].SetActive(false);
        selectedIndex = (selectedIndex + 1) % characters.Length;
        ShowSelectedCharacter();
    }

    public void PreviousCharacter()
    {
        characters[selectedIndex].SetActive(false);
        selectedIndex = (selectedIndex - 1 + characters.Length) % characters.Length;
        ShowSelectedCharacter();
    }

    void ShowSelectedCharacter()
    {
        characters[selectedIndex].SetActive(true);
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
        // Load the game scene or proceed to gameplay
    }
}
