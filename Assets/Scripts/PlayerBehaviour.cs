using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerBehaviour : MonoBehaviour
{
    public List<Vector3> Positions;
    public List<int> Times;


    // Start is called before the first frame update
    void Start()
    {
        Positions = new List<Vector3>();
        Times = new List<int>();

        AppendPos(0);
    }



    public void AppendPos(int time)
    {
        if (Times.Contains(time))
        {
            Debug.Log("Already added at: " + time.ToString());
            return;
        }

        Positions.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        Times.Add(time);
    }
}