using UnityEngine;

public class ItemTriggerProbe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == false)
        {
            return;
        }

        Debug.Log("Player entered item area");
    }
}
