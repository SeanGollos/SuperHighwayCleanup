using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //public GameObject winScreen;
    //public GameObject loseScreen;
    [SerializeField] int numberOfTrash = 0;
    [SerializeField] GameObject winScreen;

    bool noiseActivated = false;
    LevelLoader levelloader;

    private void Start()
    {
        winScreen.SetActive(false);
        levelloader = GetComponent<LevelLoader>();
    }

    private void Update()
    {
        if(Time.time > 4 && noiseActivated == false)
        {
            GetComponent<AudioSource>().Play();
            noiseActivated = true;
        }
    }

    public void TrashDropped()
    {
        numberOfTrash++;
    }

    public void TrashPickedUp( int piecesOfTrash)
    {
        numberOfTrash -= piecesOfTrash;
        if(numberOfTrash<=0)
        {
            winScreen.SetActive(true);
            StartCoroutine(Win());
            //Time.timeScale = 0;
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(2f);
        levelloader.LoadNextScene();
    }
}
