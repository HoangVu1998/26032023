using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIY2_Object_Clone1 : MonoBehaviour
{
    public GameObject objectToClone;
    public Transform Panel_Man1_1_Beer;
    public Transform Panel_Man1_1_Coctail;
    public Transform Panel_Man1_1_Alcohol;
    public static DIY2_Object_Clone1 instance;

    List<string> NameBeer = new List<string>() { "Apple Strongbow", "Black Beer", "Cherry Strongbow", "Corona Beer" , "Draft Beer" };
    List<string> NameCoctail = new List<string>() { "Cocktail Bloody Mary", "Cocktail Blue Lagoon", "Cocktail Cosmopolitan", "Cocktail Dark Stormy", "Cocktail Mojito", "Cocktail Old Fashioned" , "Cocktail Penicillin", "Malibu Bay Breeze", "Pimm’s", "Pina Colada", "Rainbow Cocktail" , "Sake Fizz Cocktail" };
    List<string> NameAlcohol = new List<string>() { "Alabama Slammer shot", "B52 shot png", "Caramel Apple shot", "Johnnie Walker Black Label", "Lemon Drop Martini shot", "Liquid Marijuana Shot", "Red, White and Blue shot", "Tequila & lemon" };
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < NameBeer.Count; i++)
        {
            if (PlayerPrefs.HasKey(NameBeer[i] + "position"))
            {
                Vector3 clonePosition = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString(NameBeer[i] + "position"));
                GameObject cloneObject = Instantiate(objectToClone, clonePosition, Quaternion.identity, Panel_Man1_1_Beer);
                cloneObject.name= NameBeer[i];  
                // Lấy đối tượng Button trong cloneObject
                Button myButton = cloneObject.GetComponent<Button>();
                // Gán sprite của ảnh vào nút button
                myButton.image.sprite = DIYController.instance.characterDIY[PlayerPrefs.GetInt(NameBeer[i] + "IndexerCharacterType")].CharacterUI[i];
                cloneObject.transform.SetParent(Panel_Man1_1_Beer);
            }
        }
        for (int i = 0; i < NameCoctail.Count; i++)
        {
            if (PlayerPrefs.HasKey(NameCoctail[i] + "position"))
            {
                Vector3 clonePosition = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString(NameCoctail[i] + "position"));
                GameObject cloneObject = Instantiate(objectToClone, clonePosition, Quaternion.identity, Panel_Man1_1_Coctail);
                cloneObject.name = NameCoctail[i];
                // Lấy đối tượng Button trong cloneObject
                Button myButton = cloneObject.GetComponent<Button>();
                // Gán sprite của ảnh vào nút button
                myButton.image.sprite = DIYController.instance.characterDIY[PlayerPrefs.GetInt(NameCoctail[i] + "IndexerCharacterType")].CharacterUI[i];
                cloneObject.transform.SetParent(Panel_Man1_1_Coctail);
            }
        }
        for (int i = 0; i < NameAlcohol.Count; i++)
        {
            if (PlayerPrefs.HasKey(NameAlcohol[i] + "position"))
            {
                Vector3 clonePosition = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString(NameAlcohol[i] + "position"));
                GameObject cloneObject = Instantiate(objectToClone, clonePosition, Quaternion.identity, Panel_Man1_1_Alcohol);
                cloneObject.name = NameAlcohol[i];
                // Lấy đối tượng Button trong cloneObject
                Button myButton = cloneObject.GetComponent<Button>();
                // Gán sprite của ảnh vào nút button
                myButton.image.sprite = DIYController.instance.characterDIY[PlayerPrefs.GetInt(NameAlcohol[i] + "IndexerCharacterType")].CharacterUI[i];
                cloneObject.transform.SetParent(Panel_Man1_1_Alcohol);
            }
        }
    }
}


