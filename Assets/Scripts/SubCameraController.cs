using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float uLimit, dLimit, lLimit, rLimit;
    Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraChanger.check == true)
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
