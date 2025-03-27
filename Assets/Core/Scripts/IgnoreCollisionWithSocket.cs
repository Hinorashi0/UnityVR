using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class IgnoreCollisionWithSocket : MonoBehaviour
{


    XRSocketInteractor _socket;

    [SerializeField]
    Collider _ourCollider = null;
    Collider _theirCollider;

    void Awake()
    {
        _socket = GetComponent<XRSocketInteractor>();
        Assert.IsNotNull(_socket);

        if (_ourCollider == null)
        {
            _theirCollider = GetComponent<Collider>();
        }

        _socket.selectEntered.AddListener(OnSelectEntered);
        _socket.selectExited.AddListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.gameObject.name + " entered.");
        GameObject other = args.interactableObject.transform.gameObject;
        _theirCollider = other.GetComponent<Collider>();

        Physics.IgnoreCollision(_ourCollider, _theirCollider, true);
    }


    void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.gameObject.name + " exited.");
        Physics.IgnoreCollision(_ourCollider, _theirCollider, false);
    }
}
