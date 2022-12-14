using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }
       
    void Update()
    {
        if(!isPressed && GetValue() + threshold >= 1)
            Pressed();

        if (isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadzone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f); 
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        AudioManager.instance.PlayOnceLocal("Button", gameObject);
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
    }

  
}
