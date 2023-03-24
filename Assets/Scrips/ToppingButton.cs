using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class ToppingButton : MonoBehaviour
{
    protected FuritsManager furitsManager;
    Button button;
    
    private void Awake()
    {
        // Tìm đối tượng FuritsController trên cảnh
        GameObject GameOBJ = GameObject.Find("FuritsManager");
        // Lấy thành phần "FuritsManager" từ đối tượng
        furitsManager = GameOBJ.GetComponent<FuritsManager>();
       // button = gameObject.GetComponent<Button>();
    }
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => onPlaySFC());
    }

    void onPlaySFC()
    {
        
        VibrationManager.instance.Vibrate(80);
        Invoke("musicFuritsThrow", 0.5f);
    }
    public virtual void chooseToppingBeer(int Index)
    {
        
        // Lấy ra một vị trí ngẫu nhiên trong khoảng giữa hai điểm PointThrowFruits
        var position = new Vector2(Random.Range(furitsManager.FutirsPointThrow[0].position.x, furitsManager.FutirsPointThrow[1].position.x), furitsManager.FutirsPointThrow[0].position.y);
        // Tạo ra một đối tượng mới từ mảng FruitsPrefabsBeer ở vị trí position
        var a = Instantiate(furitsManager.characterUIList[UIManager.Instance.CharacterType].FrutisList[ReturnOneOfTwoNumbers(2 * Index, 2 * Index + 1)], position, Quaternion.identity, furitsManager.Save);
        a.transform.SetParent(MainGameController.instance.saveMainGame);
        VibrationManager.instance.Vibrate(80);    

        if (DetectShake.instance.uonghet == true)
        {
            Destroy(a);
        }
    }
   protected int ReturnOneOfTwoNumbers(int number1, int number2)
    {
        int randomNumber = UnityEngine.Random.Range(0, 2);

        if (randomNumber == 0)
        {
            return number1;
        }
        else
        {
            return number2;
        }
    }
    void musicFuritsThrow()
    {
        TestMusic.Instance.Play("FuritsDrop");
    }
}