using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;

public class Gimmick : MonoBehaviour
{
    [SerializeField] private GameObject _breakableWall, _stone,_gimmick1Text,_gimmick2Text,_nextToStage1,_fall,_moveGround,_iWall1,_iWall2,_bGround1,_bGround2, _stageClear;

    public static    int nStone1, nStone2, nStone3;
     
    [SerializeField] enum gimmickType{
        MoveArea,BreakWall,BurnWall,Stone1,Stone2,Stone3,gimmick1Text,gimmick2Text,nextToStage1,fall,moveGround,balanceGround,balanceGround1,balanceGround2,
    }

    [SerializeField] gimmickType _gimmickType = gimmickType.MoveArea;

    public static bool textAwake = false;

    //[SerializeField] private GameObject iWall1,iWall2;

    [SerializeField] private Vector2 direction1, direction2,direction3,direction4,direction5,direction6 = Vector2.zero;

    [SerializeField, Range(0.1f, 10.0f)] private float moveTime;

    //[SerializeField] private int upDown = 0;

    [SerializeField] private int upDown = 0;

    public static List<GameObject> bGround1 = new List<GameObject>();

    public static List<GameObject> bGround2 = new List<GameObject>();

    public static int a, b = 0;

    [SerializeField] private int c = 0;


    // Start is called before the first frame update
    void Start()
    {
        Reset();
        _gimmick1Text.SetActive(false);
        _gimmick2Text.SetActive(false);
        _nextToStage1.SetActive(false);
        _fall.SetActive(false);
        _stageClear.SetActive(false);
        
    }

    private void Reset()
    {
        nStone1 = 0;
        nStone2 = 3;
        nStone3 = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(_gimmickType == gimmickType.BurnWall)
        {
            if (nStone1 == 1 && nStone2 == 1 && nStone3 == 1)
            {
                Destroy(_breakableWall);
            }
        }

        if(_gimmickType == gimmickType.balanceGround)
        {
            BalanceGround();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(_gimmickType == gimmickType.MoveArea && collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("1-2");
            }
        }
        else if (_gimmickType == gimmickType.BreakWall && collision.gameObject.tag == "TargetObject")
        {
            Destroy(_breakableWall);
        }

        else if(_gimmickType == gimmickType.Stone1 && collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _stone.transform.Rotate(0, 90, 0);
                nStone1++;
                if(nStone1 >= 4)
                {
                    nStone1 = 0;
                }
            }

        }

        else if (_gimmickType == gimmickType.Stone2 && collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _stone.transform.Rotate(0, 90, 0);
                nStone2++;
                if (nStone2 >= 4)
                {
                    nStone2 = 0;
                }
            }

        }

        else if (_gimmickType == gimmickType.Stone3 && collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _stone.transform.Rotate(0, 90, 0);
                nStone3++;
                if (nStone3 >= 4)
                {
                    nStone3 = 0;
                }
            }

        }

        else if (_gimmickType == gimmickType.moveGround && collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            //upDown++;

            if (upDown == 0 &&Input.GetKeyDown(KeyCode.E))
            {
                _moveGround.transform.DOMove(direction1, moveTime);
                _iWall1.transform.DOMove(direction2, moveTime);
                _iWall2.transform.DOMove(direction3, moveTime);
                //upDown = true;
                upDown++;
                Debug.Log(upDown);
                  
            }

            else if (upDown == 1 && Input.GetKeyDown(KeyCode.E) )
            {
                _moveGround.transform.DOMove(direction4, moveTime);
                _iWall1.transform.DOMove(direction5, moveTime);
                _iWall2.transform.DOMove(direction6, moveTime);
                upDown++;

                Debug.Log(upDown);
            }

            else if(upDown <= 2)
            {
                upDown = 0;
            }


        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && _gimmickType == gimmickType.gimmick1Text)
        {
            _gimmick1Text.SetActive(true);
            textAwake = true;
        }

        else if(collision.gameObject.tag == "Player" && _gimmickType == gimmickType.gimmick2Text)
        {
            _gimmick2Text.SetActive(true);
            textAwake = true;
        }

        else if (collision.gameObject.tag == "Player" && _gimmickType == gimmickType.nextToStage1)
        {
            _nextToStage1.SetActive(true);
            textAwake = true;
        }
        else if (collision.gameObject.tag == "Player" && _gimmickType == gimmickType.fall)
        {
            _fall.SetActive(true);

        }

        else if (collision.gameObject.tag == "TargetObject" && _gimmickType == gimmickType.balanceGround1)
        {
            GameObject obj = collision.gameObject;
            bGround1.Add(obj);
            a = bGround1.Count;


            
        }

        else if (collision.gameObject.tag == "TargetObject" && _gimmickType == gimmickType.balanceGround2)
        {


            GameObject obj = collision.gameObject;
            bGround2.Add(obj);
            b = bGround2.Count;


        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _gimmickType == gimmickType.gimmick1Text)
        {
            _gimmick1Text.SetActive(false);
            textAwake = false;
        }

        else if (collision.gameObject.tag == "Player" && _gimmickType == gimmickType.gimmick2Text)
        {
            _gimmick2Text.SetActive(false);
            textAwake = false;
        }

        else if (collision.gameObject.tag == "Player" && _gimmickType == gimmickType.nextToStage1)
        {
            _nextToStage1.SetActive(false);
            textAwake = false;
        }

        else if (collision.gameObject.tag == "TargetObject" && _gimmickType == gimmickType.balanceGround1)
        {
            GameObject obj = collision.gameObject;
            bGround1.Remove(obj);
            a = bGround1.Count;
           


        }

        else if (collision.gameObject.tag == "TargetObject" && _gimmickType == gimmickType.balanceGround2)
        {


            GameObject obj = collision.gameObject;
            bGround2.Remove(obj);
            b = bGround2.Count;


        }

    }



    public void BalanceGround()
    {
         
         
         c = a - b;

        if(c < 0)
        {
            _bGround1.transform.DOMove(direction1, moveTime);
            _bGround2.transform.DOMove(direction2, moveTime);
        }

        else if(c == 0)
        {
            _bGround1.transform.DOMove(direction3, moveTime);
            _bGround2.transform.DOMove(direction4, moveTime);
        }

        else if(c > 0)
        {
            _bGround1.transform.DOMove(direction5, moveTime);
            _bGround2.transform.DOMove(direction6, moveTime);
        }

    }



}
