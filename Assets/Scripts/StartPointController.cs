using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class StartPointController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
