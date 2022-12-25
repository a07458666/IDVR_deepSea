using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{

    public string scene_name;
    public bool is_invoke_change = false;
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        if (is_invoke_change)
        {
            Scene_change_by_time();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Scene_change(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Scene_change_by_time()
    {
        Invoke("Scene_change_invoke", delayTime);
    }

    public void Scene_change_invoke()
    {
        SceneManager.LoadScene(scene_name);
    }
}
