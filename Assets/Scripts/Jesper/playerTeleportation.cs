using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playerTeleportation : MonoBehaviour
{
    public Transform player;
    public List<GameObject> playerPosition = new List<GameObject>();

    private XRController lefthand;
    
    private int position = 2;
    bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        lefthand = FindObjectOfType<XRController>();

        lefthand.inputDevice.IsPressed(InputHelpers.Button.PrimaryAxis2DLeft, out pressed);
        player.transform.position = playerPosition[position].transform.position;

    }

    void Update()
    {
     
    }

    private void ArrayPosition()
    {
        player.transform.position = playerPosition[position].transform.position;
    }

    private void ChangePosition()
    {
        if (lefthand.inputDevice.IsPressed(InputHelpers.Button.PrimaryAxis2DLeft, out pressed))
        {
            position -= 1;
        }

        if (lefthand.inputDevice.IsPressed(InputHelpers.Button.PrimaryAxis2DRight, out pressed))
        {
            position += 1;
        }
    }
}
