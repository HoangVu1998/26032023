using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager00 : MonoBehaviour
{
    // Dictionary to store the number of clicks for each button
    private Dictionary<string, int> clickCount = new Dictionary<string, int>();

    // Text to display the click count
    public Text clickCountText;

    // Button prefab to clone
    public Button buttonPrefab;

    // Parent object to hold the cloned buttons
    public Transform buttonParent;

    // List of button names
    private List<string> buttonNames = new List<string> { "Button A", "Button B", "Button C", "Button D", "Button E" };

    private void Start()
    {
        // Initialize the click count for each button
        foreach (string buttonName in buttonNames)
        {
            clickCount[buttonName] = 0;
        }

        // Clone the buttons
        foreach (string buttonName in buttonNames)
        {
            Button newButton = Instantiate(buttonPrefab, buttonParent);
            newButton.GetComponentInChildren<Text>().text = buttonName;

            // Add click event listener to the button
            newButton.onClick.AddListener(() =>
            {
                // Increase the click count for the button
                clickCount[buttonName]++;

                // Update the click count text
                UpdateClickCountText();
            });
        }
    }

    // Update the click count text
    private void UpdateClickCountText()
    {
        string clickCountString = "";

        foreach (string buttonName in buttonNames)
        {
            clickCountString += buttonName + ": " + clickCount[buttonName] + "\n";
        }

        clickCountText.text = clickCountString;
    }
}
