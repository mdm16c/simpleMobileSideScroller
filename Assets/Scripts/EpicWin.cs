using UnityEngine;
using UnityEngine.SceneManagement;

public class EpicWin : MonoBehaviour
{
    PointCounter pc;

    void Start()
    {
        pc = GameObject.Find("Canvas").GetComponent<PointCounter>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            pc.setDefaultScore();

            // use SceneManager to load the NEXT scene!  Add one to the current scene #
            // the LoadScene function just wants a NUMBER of the scene to load
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
