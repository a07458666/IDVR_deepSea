using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject map;
    public GameObject bottle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRun(InputValue value)
    {
        Debug.Log("OnMove" + value.ToString());
    }

    void OnGUI()
    {
        if (Input.anyKeyDown)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                Debug.Log("OnMove" + e.keyCode.ToString());
                if (e.keyCode.ToString() == "Q")
                {
                    //Get script attached to it
                    MapManager _mapManager = map.GetComponent<MapManager>();

                    //Call the function
                    _mapManager.unlock();
                }
                else if (e.keyCode.ToString() == "W")
                {
                    //Get script attached to it
                    BottleSetManager _bottleSetManager = bottle.GetComponent<BottleSetManager>();

                    //Call the function
                    _bottleSetManager.unlock();
                }
            }
        }
    }
}
