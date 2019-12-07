using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
    public FallChecker FallChecker;

    // Start is called before the first frame update
    void Start()
    {
        FallChecker.Fallen += () => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}