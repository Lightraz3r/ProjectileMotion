using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoveringOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool Touching { get; private set; }
    static bool _hovering;
    bool _pressed;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _hovering = false;
    }

    private void Update()
    {
        if (_hovering && !Touching && Input.GetMouseButtonDown(0))
        {
            Touching = true;
        }
        if (!_hovering && Touching && _pressed && Input.GetMouseButtonUp(0))
        {
            Touching = false;
        }
        _pressed = Input.GetMouseButton(0);
    }
}
