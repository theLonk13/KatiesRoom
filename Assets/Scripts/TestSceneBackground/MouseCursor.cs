using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    void Start()
    {
        if (cursorTexture != null)
        Cursor.SetCursor(cursorTexture, new Vector2(0, 0), CursorMode.Auto);
        // Vector2 is the offset for the texture
    }

    // Update is called once per frame
    void Update()
    {

    }
}
