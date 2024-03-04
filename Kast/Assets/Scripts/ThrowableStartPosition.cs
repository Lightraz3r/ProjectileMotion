using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableStartPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize;
        float width = Camera.main.aspect * height;

        transform.position = new Vector2(-width + transform.localScale.x / 2, -height + transform.localScale.y / 2);
    }
}
