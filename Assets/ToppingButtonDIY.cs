using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingButtonDIY : ToppingButton
{
    private int countPress;
    public string nameDrink;
    Button button;
    public int Index;
    

    private void Start()
    {
        countPress = 0;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => chooseToppingBeer(Index));

    }

    public override void chooseToppingBeer(int index)
    {
        
        VibrationManager.instance.Vibrate(80);
        onclickButton(index);
        //countPresButton();
        var position = new Vector2(Random.Range(furitsManager.FutirsPointThrow[0].position.x, furitsManager.FutirsPointThrow[1].position.x), furitsManager.FutirsPointThrow[0].position.y);
        var a = Instantiate(furitsManager.characterUIList[UIManager.Instance.CharacterType].FrutisList[ReturnOneOfTwoNumbers(2 * Index, 2 * Index + 1)], position, Quaternion.identity);
        a.transform.SetParent(DIYController.instance.Save);
        Invoke("musicFuritsThrow", 0.5f);
    }
    void onclickButton(int index)
    {
        if (DIYController.instance.isStep)
        {
            DIYController.instance.countPressButtonFurits++;
            countPress++;
            PlayerPrefs.SetInt(nameDrink + Index,countPress); // Lưu số lần nhấn của nút button có vị trí numberIndex vào PlayerPrefs
            if (DIYController.instance.countPressButtonFurits > 14)
            {
                countPress = 0;
                DIYController.instance.isStep=false;
            }
        }
        else
        {
            Debug.Log("hello");
        }
    }
    void musicFuritsThrow()
    {
        TestMusic.Instance.Play("FuritsDrop");
    }
}
