using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitBase : MonoBehaviour
{
    private bool isTrigger = false; 

    public void FixedUpdate()
    {
        if (isTrigger && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Room Creator");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
        }
    }
    private void OnGUI()
    {
        if (isTrigger)
        {
            GUI.TextField(new Rect(1000, 1000, 250, 40), "Click E Go To Room ");
        }
    }
}
