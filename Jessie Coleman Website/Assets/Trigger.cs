using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger_Handler.ChangeMenu(menu);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger_Handler.ChangeMenu(null);
        }
    }
}
