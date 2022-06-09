using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lightmapping = UnityEditor.Lightmapping;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
        Lightmapping.Bake();
    }


}
