using UnityEngine;

public class FPSWallContactProbe : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Wall") == false)
        {
            return;
        }

        Debug.Log("Wall Contact:" + hit.collider.name);
    }
}
