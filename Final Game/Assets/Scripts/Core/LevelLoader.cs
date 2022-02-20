using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            LoadScene();
        }    
    }

    void LoadScene()
    {
        if (useIntegerToLoadLevel)
            SceneManager.LoadScene(iLevelToLoad);
        else
            SceneManager.LoadScene(sLevelToLoad);
    }

}
