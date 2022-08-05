using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action tapped;

    private float uninteractableScreenHeight;
    private void Start()
    {
        uninteractableScreenHeight = Screen.height * GameData.Default.uninteractableAreaPercent; //% of screen, where arrows will not appear
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began && touch.position.y > uninteractableScreenHeight)
            {
                tapped?.Invoke();
            }
        }
    }
}
