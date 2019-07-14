using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameBehaviour : MonoBehaviour
{
    public enum ACTION
    {
        VIEW,
        ADD_PLAYERS,
        MOVE,
        FINISH
    }
    public ACTION action;
    TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        action = ACTION.VIEW;
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        timeManager.time++;
    }

    // Update is called once per frame
    void Update()
    {

        //See if we change the action
        ChangeAction();

        int time = timeManager.time;

        if (action == ACTION.ADD_PLAYERS)
        {
            AddPlayers(time);
            timeManager.time++;
        }

        if (action == ACTION.MOVE)
        {
            OutputFile();
            MovePlayers();
        }

        if (action == ACTION.FINISH)
        {
            FinishOutputting();
        }

        action = ACTION.VIEW;
    }

    void AddPlayers(int time)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Home"))
        {
            PlayerBehaviour playerBehaviour = go.GetComponent<PlayerBehaviour>();
            playerBehaviour.AppendPos(time);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Away"))
        {
            PlayerBehaviour playerBehaviour = go.GetComponent<PlayerBehaviour>();
            playerBehaviour.AppendPos(time);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ball"))
        {
            PlayerBehaviour playerBehaviour = go.GetComponent<PlayerBehaviour>();
            playerBehaviour.AppendPos(time);
        }
    }

    void MovePlayers()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Home"))
        {
            _MovePlayer(go, "Home");
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Away"))
        {
            _MovePlayer(go, "Away");
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ball"))
        {
            _MovePlayer(go, "Ball");
        }
    }

    void _MovePlayer(GameObject go, string name)
    {
        
        if (go.GetComponent<Mover>() == null)
        {
            Debug.Log("Mover Created for " + name);
            go.AddComponent<Mover>();
        }
    }

    void OutputFile()
    {
        if (gameObject.GetComponent<CSVWriter>() == null)
        {
            gameObject.AddComponent<CSVWriter>();
        }
    }

    void FinishOutputting()
    {
        CSVWriter csvWriter = gameObject.GetComponent<CSVWriter>();
        if (csvWriter != null)
        {
            Destroy(csvWriter);
        }
    }

    void ChangeAction()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            action = ACTION.VIEW;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            action = ACTION.ADD_PLAYERS;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            action = ACTION.MOVE;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            action = ACTION.FINISH;
        }
    }


}
