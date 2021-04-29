using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 target;
    private float lastClickTime;
    private float timeDashing;
    private float timeDashStarted;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            lastClickTime = Time.time;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            if (timeSinceLastClick <= .2)
            {
                timeDashStarted = Time.time;
                Debug.Log("double click");
                speed = 4f;
            }
        }
        timeDashing = Time.time - timeDashStarted;
        if (timeDashing >= 1.5)
        {
            speed = 2f;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}