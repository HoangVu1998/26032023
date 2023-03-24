using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMusic : MonoBehaviour
{
    public void ToggleMusic(string name)
    {
       musicManager.instance.ToggleMusic();
    }
    public void ToggleSFXc()
    {
        musicManager.instance.ToggleSFXc();
    }
}
