using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgShow : MonoBehaviour
{
    List<Button> buttonList = new List<Button>();
    public List<Sprite> imageList;
    public GameObject BgDefult;
    Image imageBG;
    private void Awake()
    {
        imageBG = BgDefult.GetComponent<Image>();
        foreach (Button button in gameObject.transform.GetComponentsInChildren<Button>())
        {
            buttonList.Add(button);
            button.onClick.AddListener(() => OnClick(button));
        }
    }
    private void OnClick(Button clickedButton)
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            TestMusic.Instance.Play("TapSound");
            VibrationManager.instance.Vibrate(80);
            if (buttonList[i] == clickedButton)
            {
                imageBG.sprite = imageList[i];
                if (!DIYController.instance.isBG)
                {
                    PlayerPrefs.SetInt(DIYController.instance.buttonname + "BG", i);
                    PlayerPrefs.Save();
                }
            }
        }
    }
    public void BacktoUI()
    {
      //  imageBG.sprite = imageList[8];
    }
}

