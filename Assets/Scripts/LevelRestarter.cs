using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
    public float CheckEveryXSeconds;
    public float YCoordTreshold;

    WaitForSeconds _updateWait;

    // Start is called before the first frame update
    void Start()
    {
        _updateWait = new WaitForSeconds(CheckEveryXSeconds);
        StartCoroutine(CheckIfFalling());
    }

    IEnumerator CheckIfFalling()
    {
        while (true)
        {
            if(this.transform.position.y < YCoordTreshold)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            yield return _updateWait;
        }
    }
}