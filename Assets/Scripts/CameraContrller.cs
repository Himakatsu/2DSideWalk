using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float upLimit, downLmit, rightLimit, leftLimit;

    [SerializeField] private float upLimit1, downLmit1, rightLimit1, leftLimit1;

    [SerializeField] private float upLimit2, downLmit2, rightLimit2, leftLimit2;

    [SerializeField] private float upLimit3, downLmit3, rightLimit3, leftLimit3;
    // Start is called before the first frame update
    void Start()
    {
        upLimit1 = upLimit;
        downLmit1 = downLmit;
        leftLimit1 = leftLimit;
        rightLimit1 = rightLimit;

        transform.position = new Vector3(0, 0, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveComera();

    }
    void MoveComera()
    {

        if(CameraChanger.cameraNum == 0)
        {
            Vector2 pPos = player.transform.position;

            upLimit = upLimit1;
            downLmit = downLmit1;
            leftLimit = leftLimit1;
            rightLimit = rightLimit1;

            //左上
            if (pPos.y > upLimit && pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, upLimit, -10f);
            }
            //左下
            else if (pPos.y < downLmit && pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, downLmit, -10f);
            }
            //右上
            else if (pPos.y > upLimit && pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, upLimit, -10f);
            }
            //右下
            else if (pPos.y < downLmit && pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, downLmit, -10f);
            }
            //上
            else if (pPos.y > upLimit)
            {
                transform.position = new Vector3(pPos.x, upLimit, -10f);
            }
            //下
            else if (pPos.y < downLmit)
            {
                transform.position = new Vector3(pPos.x, downLmit, -10f);
            }
            //右
            else if (pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, pPos.y, -10f);
            }
            //左
            else if (pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, pPos.y, -10f);
            }
            //その他
            else
            {
                transform.position = new Vector3(pPos.x, pPos.y, -10f);
            }

        }

        else if (CameraChanger.cameraNum == 1)
        {
            Vector2 pPos = player.transform.position;

            upLimit = upLimit2;
            downLmit = downLmit2;
            leftLimit = leftLimit2;
            rightLimit = rightLimit2;

            //左上
            if (pPos.y > upLimit && pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, upLimit, -10f);
            }
            //左下
            else if (pPos.y < downLmit && pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, downLmit, -10f);
            }
            //右上
            else if (pPos.y > upLimit && pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, upLimit, -10f);
            }
            //右下
            else if (pPos.y < downLmit && pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, downLmit, -10f);
            }
            //上
            else if (pPos.y > upLimit)
            {
                transform.position = new Vector3(pPos.x, upLimit, -10f);
            }
            //下
            else if (pPos.y < downLmit)
            {
                transform.position = new Vector3(pPos.x, downLmit, -10f);
            }
            //右
            else if (pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, pPos.y, -10f);
            }
            //左
            else if (pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, pPos.y, -10f);
            }
            //その他
            else
            {
                transform.position = new Vector3(pPos.x, pPos.y, -10f);
            }


        }

        else if (CameraChanger.cameraNum == 2)
        {
            Vector2 pPos = player.transform.position;

            upLimit = upLimit3;
            downLmit = downLmit3;
            leftLimit = leftLimit3;
            rightLimit = rightLimit3;

            //左上
            if (pPos.y > upLimit && pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, upLimit, -10f);
            }
            //左下
            else if (pPos.y < downLmit && pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, downLmit, -10f);
            }
            //右上
            else if (pPos.y > upLimit && pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, upLimit, -10f);
            }
            //右下
            else if (pPos.y < downLmit && pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, downLmit, -10f);
            }
            //上
            else if (pPos.y > upLimit)
            {
                transform.position = new Vector3(pPos.x, upLimit, -10f);
            }
            //下
            else if (pPos.y < downLmit)
            {
                transform.position = new Vector3(pPos.x, downLmit, -10f);
            }
            //右
            else if (pPos.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, pPos.y, -10f);
            }
            //左
            else if (pPos.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, pPos.y, -10f);
            }
            //その他
            else
            {
                transform.position = new Vector3(pPos.x, pPos.y, -10f);
            }


        }
    }
}
