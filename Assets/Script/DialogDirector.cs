using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogDirector : MonoBehaviour
{
    public void TitleButtonDown()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
