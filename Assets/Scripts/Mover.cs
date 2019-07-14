using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mover : MonoBehaviour
{

    float startTime;
    List<Vector3> Positions;
    List<int> Times;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBehaviour playerBehaviour = gameObject.GetComponent<PlayerBehaviour>();

        startTime = Time.time;
        Positions = playerBehaviour.Positions;
        Times = playerBehaviour.Times;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time - startTime;
        Vector3 pos = PickupLerpedPos(currentTime, Positions, Times);
        gameObject.transform.position = pos;

    }

    Vector3 PickupLerpedPos(float t, List<Vector3> vector3s, List<int> vs)
    {
        /*
         * t has to increase by one for now.
         */

        int tStart = -2;
        int tEnd = -2;
        int startIndex = -2;

        if (t >= vs.Last())
        {
            return vector3s.Last();
        }

        foreach(int sec in vs)
        {
            if((t - sec>=0) && (t-sec <= 1))
            {
                startIndex = vs.IndexOf(sec);
                tStart = vs[startIndex];
                tEnd = vs[startIndex + 1];
                break;
            }
        }
        if (startIndex < 0) { Debug.Log("tStart not found");}
        if (tEnd < 0) { Debug.Log("tEnd not found"); }

        int tDiff = tEnd - tStart;
        

        return Vector3.Lerp(Positions[startIndex], Positions[startIndex + 1], (t - tStart) / tDiff);
    }
 
}
