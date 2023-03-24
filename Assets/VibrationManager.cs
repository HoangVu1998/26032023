using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager instance;
    private void Awake()
    {
        instance = this;    
    }
    public void SetVibrationEnabled(bool enabled)
    {
        Vibration.SetVibrationEnabled(enabled);
    }
    public void Vibrate()
    {
        Vibration.Vibrate();    
    }

    public  void Vibrate(long milliseconds)
    {
       Vibration.Vibrate(milliseconds); 
    }

    public  void Vibrate(long[] pattern, int repeat)
    {
        Vibration.Vibrate(pattern, repeat);
    }

    public void Cancel()
    {
        Vibration.Cancel();
    }

}
