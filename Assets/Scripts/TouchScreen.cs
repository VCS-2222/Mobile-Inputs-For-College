using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    [SerializeField] Vector2 inputPosition;
    [SerializeField] GameObject followCursor;
    RaycastHit hit;
    string nameOfUIHit;

    public void Update()
    {
        inputPosition = Input.mousePosition;

        CheckForUI();

        followCursor.transform.position = inputPosition;
    }

    void CheckForUI()
    {
        Physics.Raycast(new Vector3(inputPosition.x, inputPosition.y, 0), Vector3.forward, out hit, 1);

        if(hit.transform != null)
        {
            nameOfUIHit = hit.transform.name;
        }
        else
        {
            nameOfUIHit = "Nothing";
        }
    }

    private void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(200, 200, 2000, 2000), inputPosition.ToString());
        GUI.Label(new Rect(500, 200, 2000, 2000), nameOfUIHit.ToString() + " Hit");
    }
}