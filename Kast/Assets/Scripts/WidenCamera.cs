using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidenCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scrollDelta = Input.mouseScrollDelta.y;
        if (Camera.main.orthographicSize + scrollDelta > 0)
        {
            Camera.main.orthographicSize += scrollDelta;
            Camera.main.transform.position += new Vector3(2.14f * scrollDelta, scrollDelta);
        }
    }
}
