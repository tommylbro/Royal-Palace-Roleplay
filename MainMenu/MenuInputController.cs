using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuInputController : MonoBehaviour
{
    public GameObject defaultSelected;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelected);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Ensure navigation still works if user unselects UI by accident
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaultSelected);
        }
    }
}