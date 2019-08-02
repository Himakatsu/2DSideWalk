using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float upLimit, downLmit, rightLimit, leftLimit,cameraLLimit,cameraRLimit;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveComera();

    }
    void MoveComera()
    {

        Vector2 pPos = player.transform.position;

        //左上
        if(pPos.y >upLimit && pPos.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, upLimit, -10f);
        }
        //左下
        else if(pPos.y< downLmit && pPos.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, downLmit, -10f);
        }
        //右上
        else if(pPos.y > upLimit && pPos.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, upLimit, -10f);
        }
        //右下
        else if(pPos.y < downLmit && pPos.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, downLmit, -10f);
        }
        //上
        else if(pPos.y > upLimit)
        {
            transform.position = new Vector3(pPos.x, upLimit, -10f);
        }
        //下
        else if(pPos.y < downLmit)
        {
            transform.position = new Vector3(pPos.x, downLmit, -10f);
        }
        //右
        else if(pPos.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, pPos.y, -10f);
        }
        //左
        else if(pPos.x < leftLimit)
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
