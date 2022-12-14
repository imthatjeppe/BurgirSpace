using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System;

public class PlayerTeleportation : MonoBehaviour
{
    public ActionBasedController leftController;
    public Transform player;
    public List<GameObject> playerPosition = new List<GameObject>();
    public int position = 4;
    Vector2 changePos;

    bool canChangePosition;
    
    void Start()
    {
        player.transform.position = playerPosition[position].transform.position;
        player.transform.rotation = playerPosition[position].transform.rotation;
        canChangePosition = true;

    }
    void Update()
    {
        changePos = leftController.rotateAnchorAction.action.ReadValue<Vector2>();

        if (Save.instance.walking) {Walking(); return; }
        ChangePosition();
    }

    private void Walking()
    {
        player.gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
        player.gameObject.GetComponent<CharacterController>().enabled = true;

    }

    private void ChangePosition()
    {
        player.gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
        player.gameObject.GetComponent<CharacterController>().enabled = false;

        if (changePos.x == 0)
        {
            canChangePosition = true;
        }

        if (!canChangePosition) return;

        if(changePos.x >= 0.5f)
        {
            player.transform.position = playerPosition[position].transform.position;
            player.transform.rotation = playerPosition[position].transform.rotation;

            if(position !=playerPosition.Count)
                position += 1;

            canChangePosition = false;
        }

        if (changePos.x <= -0.5f)
        {
            player.transform.position = playerPosition[position].transform.position;
            player.transform.rotation = playerPosition[position].transform.rotation;

            if (position != 0)
                position -= 1;

            canChangePosition = false;
        }

        //AudioManager.instance.PlayOnceLocal("Teleportation", gameObject);

    }
}
