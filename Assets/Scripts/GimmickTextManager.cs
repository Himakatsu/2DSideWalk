using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GimmickTextManager : MonoBehaviour
{

    Animator[] animators;

    [SerializeField] private gimmickNumber _gimmickNumber = gimmickNumber.gimmick1;

    [SerializeField]
    private enum gimmickNumber
    {
        gimmick1,gimmick2,nextToStage1,gimmick3,gimmick4,nextToStage2,
    }

    [SerializeField] private GameObject textWindow;

    [SerializeField] private TypefaceAnimator script;

    [SerializeField] private Text gimmickText;

    [SerializeField] private int textCount = 0;

    [SerializeField] private GameObject camera;

    [SerializeField] private Vector3 distance1, distance2,distance3,distance4 = Vector3.zero;

    [Range(0.1f, 10.0f), SerializeField] private float moveTime;

    [SerializeField] private GameObject cameraChanger;

    [SerializeField] private CameraChanger changer;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject stageClear;

    [SerializeField] private GameObject textPanel;




    // Start is called before the first frame update
    void Start()
    {




        animators = GetComponentsInChildren<Animator>();

        gimmickText = GetComponentInChildren<Text>();



        script = textWindow.GetComponent<TypefaceAnimator>();

        changer = cameraChanger.GetComponent<CameraChanger>();

        stageClear.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
       
        if (_gimmickNumber == gimmickNumber.gimmick1 && Gimmick.textAwake == true)
        {
            Gimmick1Text();
        }

        else if(_gimmickNumber == gimmickNumber.gimmick2 && Gimmick.textAwake == true)
        {
            Gimmick2Text();
        }

        else if(_gimmickNumber == gimmickNumber.nextToStage1 && Gimmick.textAwake == true)
        {
            NexttoStage();
        }

        else if(_gimmickNumber == gimmickNumber.gimmick3 && Gimmick.textAwake == true)
        {
            Gimmick3Text();
        }

        else if(_gimmickNumber == gimmickNumber.gimmick4 && Gimmick.textAwake == true)
        {
            Gimmick4Text();
        }

        else if(_gimmickNumber == gimmickNumber.nextToStage2 && Gimmick.textAwake == true)
        {
            NextToStage2();
        }
    }


    public void Gimmick1Text()
    {


        if (textCount == 0 )
        {

            changer.ViewChange();
            gimmickText.text = "やっとついた！";
            textCount = 1;
        }

        if (textCount == 1 && Input.GetKeyDown(KeyCode.Space))
        {
             
            gimmickText.text = "この先にきっと遺跡があるんだけど・・・";
            textCount = 2;
            script.Play();
        }

        else if (textCount == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            camera.transform.DOMove(distance1, moveTime);



        }

        if (textCount == 2 && camera.transform.position == distance1)
        {
            textCount = 3;
        }

        else if (textCount == 3)
        {
            gimmickText.text = "この先道がふさがっているね・・・\nどうにかしてすすめないかなあ？";
            textCount = 4;
            script.Play();
        }

        else if (textCount == 4 && Input.GetKeyDown(KeyCode.Space))
        {
            camera.transform.DOMove(distance2, moveTime);


        }

        if (textCount == 4 && camera.transform.position == distance2)
        {
            textCount = 5;
        }

        else if (textCount == 5)
        {
            gimmickText.text = "この隙間なんだろう？\n何かはまりそうだな";
            textCount = 6;
            script.Play();
        }

        else if (textCount == 6 && Input.GetKeyDown(KeyCode.Space))
        {
            camera.transform.DOMove(distance3, moveTime);


        }

        if (textCount == 6 && camera.transform.position == distance3)
        {
            textCount = 7;
        }

        else if (textCount == 7)
        {
            gimmickText.text = "近くにちょうどいい物ないかな？探してみよう！";
            textCount = 8;
            script.Play();
        }

        else if (textCount ==　8 && Input.GetKeyDown(KeyCode.Space))
        {

            foreach (Animator anim in animators)
            {
                anim.SetBool("TextFin", true);
            }

            changer.ViewChange();
            textCount = 9;
        }
        else if(textCount == 9)
        {
            textWindow.SetActive(false);
            textCount = 0;
            Gimmick.textAwake = false;
        }

    }

    public void Gimmick2Text()
    {
        if(textCount == 0 && Gimmick.textAwake == true)
        {

            changer.ViewChange();
            textCount = 1;
            gimmickText.text = "待って！！あそこに敵がいるよ！！！\n上の道は通れそうにないからどこか迂回できる所を探そう！！";
            script.Play();
            camera.transform.DOMove(distance1, moveTime);
        }






        else if(textCount == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            camera.transform.DOMove(distance2, moveTime);

            textCount = 2;
        }

        if (textCount == 2 && camera.transform.position == distance2)
        {
            textCount = 3;
        }

        else if (textCount == 3)
        {
            gimmickText.text = "こっちの方から迂回できそうだね・・・\n行ってみよう！";
            textCount = 4;
            script.Play();
        }

        else if (textCount == 4 && Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 pPos = player.transform.position;

            distance3 = new Vector3(pPos.x, pPos.y, -10f);

            camera.transform.DOMove(distance3, moveTime);


        }

        if (textCount == 4 && camera.transform.position == distance3)
        {
            textCount = 5;
            changer.ViewChange();
        }

        else if(textCount == 5)
        {
            foreach (Animator anim in animators)
            {
                anim.SetBool("TextFin", true);
            }


            textCount = 6;
            
        }
        else if (textCount == 6)
        {
            textWindow.SetActive(false);
            textCount = 0;
            Gimmick.textAwake = false;
        }
    }

    public void NexttoStage()
    {
         if(textCount == 0 && Gimmick.textAwake == true)
        {
            changer.ViewChange();
            textCount = 1;
            gimmickText.text = "この先に遺跡はあるのかな・・・？行ってみよう！";
            script.Play();
        }

         else if(textCount == 1 && Input.GetKeyDown(KeyCode.Space) && _gimmickNumber == gimmickNumber.nextToStage1)
        {
            foreach (Animator anim in animators)
            {
                anim.SetBool("TextFin", true);
            }

            textCount = 2;

        }
         else if(textCount == 2 && _gimmickNumber == gimmickNumber.nextToStage1)
        {
            changer.ViewChange();
            textWindow.SetActive(false);
            textCount = 0;
            Gimmick.textAwake = false;
        }

    }


    public void Gimmick3Text()
    {
         if(textCount == 0 && Gimmick.textAwake == true)
        {
            changer.ViewChange();
            textCount = 1;
            gimmickText.text = "まだ遺跡は見えないみたいね・・・\nこの先にあるのかしら？";
            script.Play();

        }

         else if(textCount == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            camera.transform.DOMove(distance1, moveTime);
            textCount = 2;
        }

         if(textCount == 2 && camera.transform.position == distance1)
        {
            textCount = 3;

        }

        else if(textCount == 3)
        {
            textCount = 4;
            gimmickText.text = "また道がふさがっているね・・・どうにかして進めないかな？";
            script.Play();
        }

         else if(textCount == 4 && Input.GetKeyDown(KeyCode.Space))
        {
            camera.transform.DOMove(distance2, moveTime);
            textCount = 5; 
        }

        if (textCount == 5 && camera.transform.position == distance2)
        {
            textCount = 6;

        }

        else if(textCount == 6)
        {
            textCount = 7;
            gimmickText.text = "あそこにある石はなんだろう？\n何か模様が描かれているけど・・・";
            script.Play();
        }

        else if(textCount == 7 && Input.GetKeyDown(KeyCode.Space))
        {
            camera.transform.DOMove(distance3, moveTime);
            textCount = 8;
        }
        if (textCount == 8 && camera.transform.position == distance3)
        {
            textCount = 9;

        }

        else if (textCount == 9)
        {
            textCount = 10;
            gimmickText.text = "よく見るとそこにも同じものがあるね・・・";
            script.Play();
        }

        else if (textCount == 10 && Input.GetKeyDown(KeyCode.Space))
        {
            textCount = 11;



            distance4 = new Vector3(-1.801701f, 0.0f, -10.0f);

            camera.transform.DOMove(distance4, moveTime);
        }

        if(textCount == 11 && camera.transform.position == distance4)
        {
            textCount = 12;
        }

        else if(textCount ==12)
        {
            textCount = 13;
            gimmickText.text = "何か関係があるかもしれない！！";
            script.Play();
        }

        else if (textCount == 13 && Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Animator anim in animators)
            {
                anim.SetBool("TextFin", true);
            }

            textCount = 14;

        }
        else if (textCount == 14 && _gimmickNumber == gimmickNumber.gimmick3)
        {
            changer.ViewChange();
            textWindow.SetActive(false);
            textCount = 0;
            Gimmick.textAwake = false;
        }



    }

    public void Gimmick4Text()
    {
        if (textCount == 0 && Gimmick.textAwake == true)
        {

            changer.ViewChange();
            textCount = 1;
            gimmickText.text = "待って！！あそこに敵がいるよ！！！";
            script.Play();
            camera.transform.DOMove(distance1, moveTime);
        }

        else if(textCount == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            textCount = 2;
            gimmickText.text = "どうしよう・・・あれじゃあ上に行けないや";
            script.Play();
        }

        else if(textCount == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            textCount = 3;
            camera.transform.DOMove(distance2, moveTime);
        }

        if(textCount == 3 && camera.transform.position == distance2)
        {
            textCount = 4;
        }

        else if(textCount == 4)
        {
            textCount = 5;
            gimmickText.text = "あの壺はなんだろう・・・？壊れたら大きな音がしそうだね・・・";
            script.Play();
        }

        else if(textCount == 5 && Input.GetKeyDown(KeyCode.Space))
        {
            textCount = 6;

            Vector3 pPos = player.transform.position;

            distance3 = new Vector3(pPos.x,0.0f, -10);

            camera.transform.DOMove(distance3, moveTime);
        }

        if(textCount == 6 && camera.transform.position == distance3)
        {
            textCount = 7;

        }
        else if(textCount == 7)
        {
            textCount = 8;
            foreach (Animator anim in animators)
            {
                anim.SetBool("TextFin", true);
            }


        }
        else if (textCount == 8 && _gimmickNumber == gimmickNumber.gimmick4)
        {
            changer.ViewChange();
            textWindow.SetActive(false);
            textCount = 0;
            Gimmick.textAwake = false;
        }
    }

    public void NextToStage2()
    {
        if (textCount == 0 && Gimmick.textAwake == true)
        {
            changer.ViewChange();
            textCount = 1;
            gimmickText.text = "やったね！！この調子で先に進もう！！";
            script.Play();
        }

        else if (textCount == 1 && Input.GetKeyDown(KeyCode.Space) && _gimmickNumber == gimmickNumber.nextToStage2)
        {

            textPanel.SetActive(false);
            textCount = 0;
            Gimmick.textAwake = false;
            stageClear.SetActive(true);

        }

    }



}
