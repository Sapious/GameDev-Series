using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singing : MonoBehaviour
{
    public static Singing instance;
    public AudioSource src;
    public AudioClip clip;
    bool isSinging = true;
    bool takingAway;
    public int songDuration;

    public GameObject loseScreen;
    public GameObject invWAll;
    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        src.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (songDuration > 0 && takingAway == false)
        {
            StartCoroutine(Timer());
            if (songDuration < 2)
            {
                StartCoroutine(ResueSinging());
            }
        }
    }

    public void StartSinging()
    {
        isSinging = true;
        src.PlayOneShot(clip);
        StartCoroutine(ResueSinging());
    }

    public void StopSinging()
    {
        isSinging = false;
        src.Stop();

        Instantiate(invWAll, player.transform.position + new Vector3(0, 0, 2.5f), Quaternion.identity);

        StartCoroutine(ResueSinging());
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator Timer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        songDuration -= 1;
        takingAway = false;
    }

    IEnumerator ResueSinging()
    {
        if (isSinging == false)
        {
            yield return new WaitForSeconds(10);
            songDuration = 20;
            StartSinging();
        }
        if (isSinging == true)
        {
            yield return new WaitForSeconds(songDuration);
            StopSinging();
        }
    }
}
