using UnityEngine;

public class FinishController : MonoBehaviour
{
    void FinishGame()
    {
        Debug.Log("Game over. You win!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            FinishGame();
        }
    }
}
