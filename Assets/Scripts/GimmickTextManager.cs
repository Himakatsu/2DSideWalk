using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GimmickTextManager : MonoBehaviour
{
    [SerializeField] private GameObject panel1,panel2;

    [SerializeField] private Vector2 p1Distance = Vector2.zero;

    [SerializeField] private Vector2 p2Distance = Vector2.zero;

    [Range(0.1f, 10.0f), SerializeField] private float moveTime;

    Rigidbody2D rigi;

    

    // Start is called before the first frame update
    void Start()
    {
        

        rigi = GetComponent<Rigidbody2D>();

        

        //panel1.transform.DOMove(p1Distance, moveTime);
        panel2.transform.DOMove(p2Distance, moveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
