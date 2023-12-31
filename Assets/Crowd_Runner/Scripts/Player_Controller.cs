using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Crowd_System Crowd_System;

    [Header(" Settings ")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float roadWidth;

    [Header(" Control ")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();

        ManageControl();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
    
    private void ManageControl()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 position = transform.position; 
            position.x = clickedPlayerPosition.x + xScreenDifference;

            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + Crowd_System.GetCrowdRadius(), 
                roadWidth / 2 - Crowd_System.GetCrowdRadius());
            transform.position = position; 

            //transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;


        }
    }
}
