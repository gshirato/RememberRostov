using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Time
        ChangeTime();
        ShowTime();
    }

    public int Accesible
    {
        get; set;
    }


    void ChangeTime()
    {
        if (Input.GetKeyDown("up"))
        {
            time++;
        }
        if (Input.GetKeyDown("down"))
        {

            time = Mathf.Max(time - 1, 0);
        }
    }

    void ShowTime()
    {
        GetComponent<Text>().text = "Time: " + time.ToString();
    }
}
