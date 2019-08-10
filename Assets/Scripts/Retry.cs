using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{

    [SerializeField]
    private enum SceneType
    {
        title, stage1a,stage1b, stage2
    }

    [SerializeField] SceneType _sceneType = SceneType.title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_sceneType == SceneType.stage1a)
            {
                SceneManager.LoadScene("1-1");
            }

            if(_sceneType == SceneType.stage1b)
            {
                SceneManager.LoadScene("1-2");
            }

            if (_sceneType == SceneType.stage2)
            {
                SceneManager.LoadScene("2-1");
            }

            if (_sceneType == SceneType.title)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

}
