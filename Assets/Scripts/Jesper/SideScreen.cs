using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScreen : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        transform.position = target.position + Vector3.up * offset.y
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;

        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
    }
}
