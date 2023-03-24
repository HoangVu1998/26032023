using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonChooseWater : MonoBehaviour
{
    public List<Button> waterList = new List<Button>();
    Button button;
    private void Start()
    {
        // Lấy tất cả các button con và gán vào List
        waterList = new List<Button>(GetComponentsInChildren<Button>());
        Transform child = waterList[0].transform.GetChild(0);
        child.gameObject.SetActive(true);
        // Gán phương thức OnClick cho mỗi button trong List
        foreach (Button button in waterList)
        {
            button.onClick.AddListener(() => OnClick(button));
            
        }
    }
    private void OnClick(Button clickedButton)
    {
        // Tắt tất cả các button khác
        foreach (Button button in waterList)
        {
            Transform child = button.transform.GetChild(0);
            child.gameObject.SetActive(false);
        }
        for (int i = 0; i < waterList.Count; i++)
        {
            if (waterList[i] == clickedButton)
            {
                Transform child = waterList[i].transform.GetChild(0);
                child.gameObject.SetActive(true);
                UIManager.Instance.numberTypeDIY = i;
            }
        }
    }
}