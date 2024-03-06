using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableStartPosition : MonoBehaviour
{
    public static Vector2 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize;
        float width = Camera.main.aspect * height;

        GetComponent<TrailRenderer>().enabled = false;

        StartPos = new Vector2(-width + transform.localScale.x / 2, -height + transform.localScale.y / 2);
        transform.position = StartPos;

        GetComponent<TrailRenderer>().enabled = true;
    }
}
