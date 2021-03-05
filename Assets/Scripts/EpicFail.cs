using UnityEngine;
using UnityEngine.SceneManagement;

public class EpicFail : MonoBehaviour
{
    PointCounter pc;

    void Start()
    {
        pc = GameObject.Find("Canvas").GetComponent<PointCounter>();
    }

    public void doStuff(GameObject other) {
        if (other.tag == "Player" && pc.getLives() == 1 && other.tag != "bullet") {
            // game over screen
            SceneManager.LoadScene("GameOver");
        }
        else if (other.tag == "Player" && pc.getLives() > 1 && other.tag != "bullet") {
            pc.resetScore();
            pc.decrementLives();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Finish" && pc.getLives() > 1 && other.tag != "bullet") {
            pc.resetScore();
            pc.decrementLives();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (gameObject.tag == "Finish" && pc.getLives() == 1 && other.tag != "bullet") {
            // game over
            SceneManager.LoadScene("GameOver");
        }
        else {
            doStuff(other.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        doStuff(other.gameObject);
    }
}
