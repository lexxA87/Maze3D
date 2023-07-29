using UnityEngine;

public class StartPointsController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    GameObject[] startPoints;


    private void Awake()
    {
        startPoints = GameObject.FindGameObjectsWithTag("Start");
        for (int i = 0; i < startPoints.Length; i++)
        {
            startPoints[i].SetActive(false);
        }
        int random = Random.Range(0, startPoints.Length - 1);
        startPoints[random].SetActive(true);
        player.SetStartPosition(startPoints[random].transform.position);
    }
}
