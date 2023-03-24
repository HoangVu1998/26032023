using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFuritsManager : MonoBehaviour
{
    public List<GameObject> scrollFurits  = new List<GameObject>();
    private void Start()
    {
        // Lấy tất cả các button con và gán vào List
        for(int i = 0; i<transform.childCount ; i++)
        {
            scrollFurits.Add(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < scrollFurits.Count; i++)
        {
            if (i == DIYController.instance.buttonseLect)
            {
                scrollFurits[i].gameObject.SetActive(true);
            }
        }
    }
    private void OnEnable()
    {
       
        for (int i = 0; i < scrollFurits.Count; i++)
        {
            if (i == DIYController.instance.buttonseLect)
            {
                scrollFurits[i].gameObject.SetActive(true);
            }
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < scrollFurits.Count; i++)
        {
            scrollFurits[i].gameObject.SetActive(false);
        }
    }
}
