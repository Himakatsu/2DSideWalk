using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float uLimit, dLimit, lLimit, rLimit;

    [SerializeField] private float uLimit1, dLimit1, lLimit1, rLimit1;

    [SerializeField] private float uLimit2, dLimit2, lLimit2, rLimit2;

    [SerializeField] private float uLimit3, dLimit3, lLimit3, rLimit3;
    Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        uLimit1 = uLimit;
        dLimit1 = dLimit;
        lLimit1 = lLimit;
        rLimit1 = rLimit;


        rigi = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
    }

    // Update is called once per frame
    void Update()
    {

        if(CameraChanger.cameraNum == 0)
        {
            uLimit = uLimit1;
            dLimit = dLimit1;
            lLimit = lLimit1;
            rLimit = rLimit1;

            if (CameraChanger.check == true)
            {
                Vector2 pPos = player.transform.position;

                CameraChanger.check = false;
                if (pPos.y > uLimit && pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, uLimit, -10f);
                }
                //左下
                else if (pPos.y < dLimit && pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, dLimit, -10f);
                }
                //右上
                else if (pPos.y > uLimit && pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, uLimit, -10f);
                }
                //右下
                else if (pPos.y < dLimit && pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, dLimit, -10f);
                }
                //上
                else if (pPos.y > uLimit)
                {
                    transform.position = new Vector3(pPos.x, uLimit, -10f);
                }
                //下
                else if (pPos.y < dLimit)
                {
                    transform.position = new Vector3(pPos.x, dLimit, -10f);
                }
                //右
                else if (pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, pPos.y, -10f);
                }
                //左
                else if (pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, pPos.y, -10f);
                }
                //その他
                else
                {
                    transform.position = new Vector3(pPos.x, pPos.y, -10f);
                }
            }
        }


        if (CameraChanger.cameraNum == 1)
        {
            uLimit = uLimit2;
            dLimit = dLimit2;
            lLimit = lLimit2;
            rLimit = rLimit2;

            if (CameraChanger.check == true)
            {
                Vector2 pPos = player.transform.position;

                CameraChanger.check = false;
                if (pPos.y > uLimit && pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, uLimit, -10f);
                }
                //左下
                else if (pPos.y < dLimit && pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, dLimit, -10f);
                }
                //右上
                else if (pPos.y > uLimit && pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, uLimit, -10f);
                }
                //右下
                else if (pPos.y < dLimit && pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, dLimit, -10f);
                }
                //上
                else if (pPos.y > uLimit)
                {
                    transform.position = new Vector3(pPos.x, uLimit, -10f);
                }
                //下
                else if (pPos.y < dLimit)
                {
                    transform.position = new Vector3(pPos.x, dLimit, -10f);
                }
                //右
                else if (pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, pPos.y, -10f);
                }
                //左
                else if (pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, pPos.y, -10f);
                }
                //その他
                else
                {
                    transform.position = new Vector3(pPos.x, pPos.y, -10f);
                }
            }
        }

        if (CameraChanger.cameraNum == 2)
        {
            uLimit = uLimit3;
            dLimit = dLimit3;
            lLimit = lLimit3;
            rLimit = rLimit3;

            if (CameraChanger.check == true)
            {
                Vector2 pPos = player.transform.position;

                CameraChanger.check = false;
                if (pPos.y > uLimit && pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, uLimit, -10f);
                }
                //左下
                else if (pPos.y < dLimit && pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, dLimit, -10f);
                }
                //右上
                else if (pPos.y > uLimit && pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, uLimit, -10f);
                }
                //右下
                else if (pPos.y < dLimit && pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, dLimit, -10f);
                }
                //上
                else if (pPos.y > uLimit)
                {
                    transform.position = new Vector3(pPos.x, uLimit, -10f);
                }
                //下
                else if (pPos.y < dLimit)
                {
                    transform.position = new Vector3(pPos.x, dLimit, -10f);
                }
                //右
                else if (pPos.x > rLimit)
                {
                    transform.position = new Vector3(rLimit, pPos.y, -10f);
                }
                //左
                else if (pPos.x < lLimit)
                {
                    transform.position = new Vector3(lLimit, pPos.y, -10f);
                }
                //その他
                else
                {
                    transform.position = new Vector3(pPos.x, pPos.y, -10f);
                }
            }
        }
        Move();
    }
    private void Move()
    {

        Vector2 thisPos = transform.position;
           
            
        if(thisPos.x >lLimit || thisPos.x < rLimit || thisPos.y > dLimit || thisPos.y < uLimit)
        {
            float hori = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");
            rigi.velocity = new Vector3(hori * moveSpeed * Time.deltaTime, ver * moveSpeed * Time.deltaTime, -10f);
        }
        if(thisPos.x < lLimit)
        {
            float hori = 1f;
            float ver = Input.GetAxisRaw("Vertical");
            rigi.velocity = new Vector3(hori * moveSpeed * Time.deltaTime, ver * moveSpeed * Time.deltaTime, -10f);
        }
        if(thisPos.x > rLimit)
        {
            float hori = -1f;
            float ver = Input.GetAxisRaw("Vertical");
            rigi.velocity = new Vector3(hori * moveSpeed * Time.deltaTime, ver * moveSpeed * Time.deltaTime, -10f);
        }
        if(thisPos.y > uLimit)
        {
            float hori = Input.GetAxisRaw("Horizontal");
            float ver = -1f;
            rigi.velocity = new Vector3(hori * moveSpeed * Time.deltaTime, ver * moveSpeed * Time.deltaTime, -10f);
        }
        if(thisPos.y < dLimit)
        {
            float hori = Input.GetAxisRaw("Horizontal");
            float ver = 1f;
            rigi.velocity = new Vector3(hori * moveSpeed * Time.deltaTime, ver * moveSpeed * Time.deltaTime, -10f);
        }
    }
}
