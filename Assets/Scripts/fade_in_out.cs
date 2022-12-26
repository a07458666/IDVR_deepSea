using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade_in_out : MonoBehaviour
{
    [SerializeField] 
    public Image fade_image;
    public string next_scenes_name;
    public float delayTime;
    public bool is_invoke_change = false;
    private int start_fade_in = 0;
    private int start_fade_out = 0;

    private float animation_delta_time = 0.0f;
    public const float animation_duration = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        start_fade_in = 1;
        if (is_invoke_change)
        {
            Scene_change_by_time();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(start_fade_in == 1)
        {
            animation_delta_time += Time.deltaTime;
            fade_image.color = new Color(fade_image.color.r, fade_image.color.g, fade_image.color.b, 1 - (animation_delta_time / animation_duration));
        }
        else if (start_fade_out == 1)
        { 
            animation_delta_time += Time.deltaTime;
            fade_image.color = new Color(0, 0, 0, (animation_delta_time / animation_duration));
        }

        if(animation_delta_time >= animation_duration)
        {
            animation_delta_time = 0.0f; 
            if (start_fade_out == 1)
            {
                SceneManager.LoadScene(next_scenes_name, LoadSceneMode.Single);
            }
            start_fade_in = 0;
            start_fade_out = 0; 
            
        }
    }

    public void Scene_change_by_time()
    {
        Invoke("Start_fade_iout", delayTime);
    }

    public void Start_fade_in()
    {
        start_fade_in = 1;
        start_fade_out = 0;
        animation_delta_time = 0.0f;
    }

    public void Start_fade_iout()
    {
        start_fade_out = 1;
        start_fade_in = 0;
        animation_delta_time = 0.0f;
    }

    public void Scene_change()
    {
        SceneManager.LoadScene(next_scenes_name, LoadSceneMode.Single);
    }
}
