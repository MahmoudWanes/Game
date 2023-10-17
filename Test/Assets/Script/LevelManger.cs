using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    public static LevelManger instance;
    public Transform Player;
    public int Score;
    public int LevelItem;
    public AudioClip[] LevelSounds;
    public Transform[] Particles;
    public Transform MainCanvas;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void PlaySound(AudioClip sound, Vector3 ownerpos)
    {
        GameObject obj = BulletPooler.current.GetPooledObject();
        AudioSource audio = obj.GetComponent<AudioSource>();
        obj.transform.position = ownerpos;
        obj.SetActive(true);
        audio.PlayOneShot(sound);
        StartCoroutine(DisableSound(audio));
    }

    IEnumerator DisableSound(AudioSource audio)
    {
        while (audio.isPlaying)
            yield return new WaitForSeconds(.5f);
        audio.gameObject.SetActive(false);
    }
}
