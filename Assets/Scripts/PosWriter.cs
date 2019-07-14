using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PosWriter : MonoBehaviour
{
    string number;
    string side;
    StreamWriter streamWriter;

    // Start is called before the first frame update
    void Start()
    {
        CSVWriter csvWriter = GameObject.Find("GameManager").GetComponent<CSVWriter>();

        number = GetNumber();
        side = GetSide();
        streamWriter = csvWriter.streamWriter;
    }

    // Update is called once per frame
    void Update()
    {
        string pos = Time.time + "," + side + "," + number + "," + transform.position.x.ToString() + "," + transform.position.z.ToString();
        streamWriter.WriteLine(pos);
    }


    string GetNumber()
    {
        if (gameObject.tag == "Ball")
        {
            return "-1";
        }

        name = gameObject.name;
        number = name.Split('_')[0];

        return number;
    }

    string GetSide()
    {
        string tag = gameObject.tag;
        if (tag == "Home")
        {
            return "1";
        }
        if (tag == "Away")
        {
            return "2";
        }
        if (tag == "Ball")
        {
            return "0";
        }

        Debug.Log("Tag has to be either Home, Away or Ball.");
        return "-1";
    }
}
