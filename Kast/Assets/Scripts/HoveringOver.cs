using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoveringOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool Hovering { get; private set; }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hovering = false;
    }
}
