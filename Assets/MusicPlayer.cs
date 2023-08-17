using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicPlayer : MonoBehaviour
{
    public GameObject ObjectMusic;
    public AudioSource audioSource;
    public Slider MusicSlide;
    
    private float musicVolume = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();
        //set volume
        audioSource.Play();
        musicVolume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = musicVolume;
        MusicSlide.value = musicVolume;
    }

    // Update is called once per frame
    private void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume",musicVolume);
    }
    public void VolumeUpdate(float volume)
    {
        musicVolume = volume;
    }
}
