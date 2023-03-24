using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ModalBuoyancyEffector : MonoBehaviour
{
    BuoyancyEffector2D effector;
    public float NumbereffectorUp/* = 0.02f*/;
    public float NumbereffectorDown/* = 0.02f*/;

    public float MaxhightSurFace;
    public float MinhightSurFace;

    public float MaxlowMagnitude;
    public float MinlowMagnitude;
    private void Start()
    {
        effector = GetComponent<BuoyancyEffector2D>();
    }
    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        if (acceleration.y < 0 && ModalMove.isFiling == true)
        {
            if (MinhightSurFace < effector.surfaceLevel)
            {
                effector.surfaceLevel -= NumbereffectorDown;
            }
            effector.flowMagnitude = 0;
        }
        if (acceleration.y >= 0 && ModalMove.isFiling == true)
        {
            if(effector.surfaceLevel < MaxhightSurFace)
            {
                effector.surfaceLevel += NumbereffectorUp;
            }
            if ( acceleration.x <= 1f && acceleration.x > 0)
            {
                effector.flowMagnitude = MaxlowMagnitude;
            }
            if (acceleration.x >= -1f && acceleration.x < 0)
            {
                effector.flowMagnitude = MinlowMagnitude;
                Debug.Log(effector.flowMagnitude + " effector.flowMagnitude");
            }
        }
    }
}
