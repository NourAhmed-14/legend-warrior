using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform player;
    public int score;
    public int levelItems;
    public AudioClip[] LevelSounds;


   private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(AudioClip sound, Vector3 ownerpos)
    {
        GameObject obj = SoundFXPooler.current.GetpooledObject();
        AudioSource audio = obj.GetComponent<AudioSource>();

        obj.transform.position = ownerpos;
        obj.SetActive(true);
        audio.PlayOneShot(sound);
        StartCoroutine(DisableSound(audio));
    }
    IEnumerator DisableSound(AudioSource audio)
    {
        while (audio.isPlaying)
              yield return new WaitForSeconds(0.5f);
        audio.gameObject.SetActive(false);      
    }
}
