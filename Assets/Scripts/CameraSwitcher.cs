using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    Camera mainCamera;
    public Camera behindGoal;
    public Camera ball;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        behindGoal.enabled = false;
        ball.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            mainCamera.enabled = true;
            behindGoal.enabled = false;
            ball.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainCamera.enabled = false;
            behindGoal.enabled = true;
            ball.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mainCamera.enabled = false;
            behindGoal.enabled = false;
            ball.enabled = true;
        }
    }
}
