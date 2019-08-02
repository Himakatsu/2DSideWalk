using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gimmick : MonoBehaviour
{
    [SerializeField] private GameObject _breakableWall, _stone,_gimmick1Text;

    public static    int nStone1, nStone2, nStone3;
     
    [SerializeField] enum gimmickType{
        MoveArea,BreakWall,BurnWall,Stone1,Stone2,Stone3,gimmick1Text,
    }

    [SerializeField] gimmickType _gimmickType = gimmickType.MoveArea;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
        _gimmick1Text.SetActive(false);
        
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && _gimmickType == gimmickType.gimmick1Text)
        {
            _gimmick1Text.SetActive(true);
        }
    }

}
