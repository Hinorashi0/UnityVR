using UnityEngine;

public class Mine : MonoBehaviour
{

    [SerializeField]
    GameObject item;

    [SerializeField]
    GameObject stone1;

    [SerializeField]
    GameObject stone2;


    int hit = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Mine")
            return;
        stone1.SetActive(false);
        stone2.SetActive(true);
        item.SetActive(true);
    }
}
