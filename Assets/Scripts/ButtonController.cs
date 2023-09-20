using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons;
    private Button lastClickedButton;
    private bool waitingForSecondClick = false;

    private void Start()
    {
        // Assign the buttons from the Unity Editor.
        buttons = new Button[8];
        for (int i = 0; i < 8; i++)
        {
            buttons[i] = transform.GetChild(i).GetComponent<Button>();
        }

        // Attach click event listeners to each button.
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button button)
    {
        if (waitingForSecondClick)
        {
            if (button != lastClickedButton)
            {
                if (button.GetComponent<Image>().sprite == lastClickedButton.GetComponent<Image>().sprite)
                {
                    // Match found! Disable both buttons.
                    button.interactable = false;
                    lastClickedButton.interactable = false;
                }
            }
            waitingForSecondClick = false;
        }
        else
        {
            lastClickedButton = button;
            waitingForSecondClick = true;
        }
    }
}
