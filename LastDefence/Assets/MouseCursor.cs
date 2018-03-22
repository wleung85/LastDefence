using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

	public Texture2D crosshairTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = new Vector2(65f,65f);

	//int cursorSizeX = 16;
	//int cursorSizeY = 16;

	void Start() {
		Cursor.SetCursor(crosshairTexture, hotSpot, cursorMode);
	}

	void OnGUI()
	{
		//crosshairTexture.Resize(30, 30);
		//crosshairTexture.Apply();

		//Rect rect = new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, cursorSizeX, cursorSizeY);
		//GUI.DrawTexture(rect, crosshairTexture);
	}

	//Below code for modifying the cursor when entering particular areas of the screen.

	/*void OnMouseEnter()
	{
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}

	void OnMouseExit()
	{
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}*/
}
