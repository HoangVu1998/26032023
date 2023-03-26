using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Man2_MorePages : MonoBehaviour
{
    public List<Button> buttonList;
    public static Panel_Man2_MorePages instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
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
                VibrationManager.instance.Vibrate(80);
                TestMusic.Instance.Play("TapSound");
                DIYController.instance.buttonname= buttonList[i].name;  
                PlayerPrefs.SetInt(buttonList[i].name, i);
                DIYController.instance.buttonseLect = i;
                PlayerPrefs.SetInt(buttonList[i].name + "CharacterType", i);
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
