using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    GameObject gameBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        gameBehaviour = GameObject.Find("GameManager");
    }

    public void OnClick()
    {
        Debug.Log(gameBehaviour);
        //gameBehaviour.mode = gameBehaviour.MODE.ADD_PLAYERS;
    }
}
