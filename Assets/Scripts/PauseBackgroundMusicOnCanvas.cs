using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBackgroundMusicOnCanvas : MonoBehaviour
{
    //�x�s�I�����֪�AudioSource Component
    private AudioSource bgMusicAudioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //�b�Ҧ�Game Object����MBackground Music
        bgMusicAudioSource = GameObject.FindGameObjectWithTag("Background Music").GetComponent<AudioSource>();

        //�Ȱ�����
        bgMusicAudioSource.Pause();
    }

    void OnDisable()
    {
        //�~�򭵼�
        bgMusicAudioSource.UnPause();
    }
}
