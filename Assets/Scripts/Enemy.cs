using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    Animator anim;
    //移動速度
    [SerializeField] private float moveSeed;
    //プレイヤーを格納
    [SerializeField] private GameObject player;
    //左右を振り向く
    [SerializeField] private bool stopRotate = false;
    [SerializeField] private float span = 1f;
    [SerializeField] private float currentTime = 0f;
    //プレイヤーに接近
    [SerializeField] private bool canMove = false;
    //ゲームオーバー画面
    [SerializeField] private GameObject gameoverCanvas;
    //音（collider）による状態変化
    public static bool searchTrigger = false;
    [SerializeField] private GameObject target;
    [Range(0.5f, 10.0f), SerializeField] private float moveTime;
    //音がした方向への移動距離
    [SerializeField] private Vector3 distance;
    //音がした方向への振り向き
    [SerializeField] private Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        gameoverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //その場に停止して左右を見続ける挙動を示す
        if(stopRotate == false)
        {
            Rotate();
        }
        //視界内にプレイヤーが入った場合、プレイヤーに向かって移動を開始する
        if(canMove == true)
        {
            Move();
        }
        //オブジェクトが破壊されたとき、その方向に移動する
        if(searchTrigger == true)
        {
            Search();
            stopRotate = true;
        }
    }

    //Enemyを中心として左右を監視するスクリプト
    void Rotate()
    {
        //経過時間
        currentTime += Time.deltaTime;
        //一定時間で起動
        if (currentTime > span)
        {
            transform.Rotate(0, 180, 0);
            //リセット
            currentTime = 0f;
        }
    }
    //Enemyの視界内にPlayerが侵入して来た場合起動
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            stopRotate = true;
            canMove = true;
        }
        
    }
    //Playerに移動
    private void Move()
    {
        //Playerの現在の座標を取得
        Vector2 pPos = player.transform.position;
        //Playerの座標に移動
        transform.position = Vector2.MoveTowards(transform.position, pPos, moveSeed * Time.deltaTime);
        anim.SetInteger("Run", 1);
    }
    //Playerと衝突したとき、ゲームオーバー画面を表示する
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            moveSeed = 0f;
            anim.SetInteger("Run", 0);
            canMove = false;
            gameoverCanvas.SetActive(true);
        }
        

    }
    //大きな音がなった方向へ移動する
    private void Search()
    {

        
        transform.DOMove(distance, moveTime);
        transform.Rotate(rotate);
        searchTrigger = false;
        
        
    }
}
