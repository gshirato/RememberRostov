using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    public StreamWriter streamWriter;
    FileInfo fileInfo;
    // Start is called before the first frame update
    void Start()
    {
        fileInfo = new FileInfo(Application.dataPath + "/Resources/Rostov.csv");
        streamWriter = fileInfo.CreateText();

        streamWriter.WriteLine("Time,Side,Number,X,Y");

        CreateWriters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Home"))
        {
            _DestroyWriter(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Away"))
        {
            _DestroyWriter(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ball"))
        {
            _DestroyWriter(go);
        }

        streamWriter.Flush();
        streamWriter.Close();
        Debug.Log("Save Done.");
    }

    void CreateWriters()
    {

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Home"))
        {
            _CreateWriter(go, streamWriter);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Away"))
        {
            _CreateWriter(go, streamWriter);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ball"))
        {
            _CreateWriter(go, streamWriter);
        }

    }

    void _CreateWriter(GameObject go, StreamWriter streamWriter)
    {
        if (go.GetComponent<PosWriter>() == null)
        {
            Debug.Log("Created");
            go.AddComponent<PosWriter>();
        }
        

    }

    void _DestroyWriter(GameObject go)
    {
        PosWriter writer = go.GetComponent<PosWriter>();
        Destroy(writer);
    }
}
