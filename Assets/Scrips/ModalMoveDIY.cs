using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ModalMoveDIY : ModalMove
{
    public bool isTutorialMove;
    private bool isTarGet;
    private float timeSinceLastCall = 0.0f;

    private void Start()
    {
        isTutorialMove = true;
        isFiling = false;
        isTarGet = false;
    }
    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        if(Vector2.Distance(transform.position, TargetOriganal.position) >= 0.01f)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                modalMoveBefore();
                TestMusic.Instance.playUpdate("WaterUp");
            }
            else
            
            {
                TestMusic.Instance.stop("WaterUp");
                TestMusic.Instance.isPlaying = false;
            }
        }

        if (Vector2.Distance(transform.position, TargetOriganal.position) < 0.01f && !isTarGet)
        {
            TestMusic.Instance.stop("WaterUp");
            isTarGet = true;
            DIYController.instance.isMan4 = true;
        }

        if (Input.GetMouseButton(1) && Vector2.Distance(transform.position, TargetOriganal.position) >= 0.01f)
        {
            modalMoveBefore();
        }
    }
    public override void moveToWards(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
    }
}
