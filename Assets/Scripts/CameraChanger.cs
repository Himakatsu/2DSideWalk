using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    //MainCameraを格納
    [SerializeField] private GameObject mainCamera;
    //SubCameraを格納
    [SerializeField] private GameObject subCamera;
    //CanMoveがtrueの時のみ、Playerが移動可能となる
    public static bool canMove = true;

    public static bool check = false;

    public static int cameraNum = 0;
        // Start is called before the first frame update
    void Start()
    {
        mainCamera.SetActive(true);
        subCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            ViewChange();
        }
    }
    public void ViewChange()
    {



            if (mainCamera.activeSelf)
            {


                mainCamera.SetActive(false);
                canMove = false;
                subCamera.SetActive(true);
                check = true;


            }
            else
            {
                mainCamera.SetActive(true);
                canMove = true;
                subCamera.SetActive(false);
                check = false;


            }
       

        

    }
}
