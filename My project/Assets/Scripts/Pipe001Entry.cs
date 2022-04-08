using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe001Entry : MonoBehaviour
{
    public GameObject PipeEntry;
    public int StoodOn;

    public GameObject MainCam;
    public GameObject SecondCam;
    public GameObject MainPlayer;

    void OnTriggerEnter(Collider col)
    {
        StoodOn = 1;
    }

    void OnTriggerExit(Collider col)
    {
        StoodOn = 0;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GoDown"))
        {
            if (StoodOn == 1)
            {
                transform.position = new Vector3(0, -1000, 0);
                StartCoroutine(WaitingForPipe());
            }
        }
    }

    IEnumerator WaitingForPipe()
    {
        PipeEntry.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2F);
        PipeEntry.GetComponent<Animator>().enabled = false;
        SecondCam.SetActive(true);
        MainCam.SetActive(false);
        MainPlayer.transform.position = new Vector3(16, -18, 0.5F);
    }
}
