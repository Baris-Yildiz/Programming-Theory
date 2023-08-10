using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip plasmaShotSound;
    public AudioClip enemyExplosion;
    public AudioClip worldExplosion;

    public GameObject plasmaShot;

    public static MusicManager Instance;
   
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayAudio(Audio.PlasmaShot);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Instantiate(plasmaShot, mousePos, Quaternion.identity);
        }
    }

    public void PlayAudio(Audio audio)
    {
        AudioClip clipToPlay = null;

        switch(audio)
        {
            case Audio.EnemyExplosion:
                clipToPlay = enemyExplosion;
                break;
            case Audio.PlasmaShot:
                clipToPlay = plasmaShotSound;
                break;
            case Audio.WorldExplosion:
                clipToPlay = worldExplosion;
                break;
        }

        audioSource.PlayOneShot(clipToPlay);
    }
}
