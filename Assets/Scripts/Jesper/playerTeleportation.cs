using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class playerTeleportation : MonoBehaviour
{
    public ActionBasedController leftController;
    public Transform player;
    public List<GameObject> playerPosition = new List<GameObject>();

    private int position = 2;
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
        position = Mathf.Clamp(position, 0, 4);
        ChangePosition();
    }

    private void ChangePosition()
    {
        if(changePos.x == 0)
        {
            canChangePosition = true;
        }

        if (!canChangePosition) return;

        if(changePos.x >= 0.5f)
        {
            player.transform.position = playerPosition[position].transform.position;
            player.transform.rotation = playerPosition[position].transform.rotation;
            position += 1;
            canChangePosition = false;
        }

        if (changePos.x <= -0.5f)
        {
            player.transform.position = playerPosition[position].transform.position;
            player.transform.rotation = playerPosition[position].transform.rotation;
            position -= 1;
            canChangePosition = false;
        }

        AudioManager.instance.PlayOnceLocal("Teleportation", gameObject);

    }
}
