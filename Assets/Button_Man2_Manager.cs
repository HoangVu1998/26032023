using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Man2_Manager : MonoBehaviour
{
    public static Button_Man2_Manager Instance;
    public List<Button> buttonList;
    [SerializeField] int numberStartList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Lấy tất cả các button con và gán vào List
        buttonList = new List<Button>(GetComponentsInChildren<Button>());
            Transform child = buttonList[0].transform.GetChild(0);
            child.gameObject.SetActive(true);

        // Gán phương thức OnClick cho mỗi button trong List
        foreach (Button button in buttonList)
        {
            button.onClick.AddListener(() => OnClick(button));
        }
    }
    private void OnClick(Button clickedButton)
    {
        // Tắt tất cả các button khác
        foreach (Button button in buttonList)
        {
            Transform child = button.transform.GetChild(0);
            child.gameObject.SetActive(false);
        }
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList[i] == clickedButton)
            {
                PlayerPrefs.SetInt(buttonList[i].name, i + numberStartList);
                DIYController.instance.buttonseLect = i + numberStartList;
                PlayerPrefs.SetInt(buttonList[i].name + "CharacterType", i );
                Transform child = buttonList[i].transform.GetChild(0);
                child.gameObject.SetActive(true);
            }
        }
    }
    public void resetTichxanh()
    {
        foreach (Button button in buttonList)
        {
            Transform child1 = button.transform.GetChild(0);
            child1.gameObject.SetActive(false);
        }
        Transform child = buttonList[0].transform.GetChild(0);
        child.gameObject.SetActive(true);

    }
}



