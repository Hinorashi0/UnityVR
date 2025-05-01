using UnityEngine;

public class DiggableArea : MonoBehaviour
{
    [SerializeField]
    GameObject dugAsset;
    [SerializeField]
    GameObject item;


    void OnTriggerExit(Collider other)
    {
        if(other.tag != "Dig")
            return;
        dugAsset.SetActive(true);
    }

}
