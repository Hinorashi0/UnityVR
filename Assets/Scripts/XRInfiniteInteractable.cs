using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInfiniteInteractable : MonoBehaviour
{

    [SerializeField]
    XRBaseInteractable m_InteractablePrefab;

    XRBaseInteractor m_Socket;

    void Awake()
    {
        m_Socket = GetComponent<XRBaseInteractor>();
        Assert.IsNotNull(m_InteractablePrefab);
    }

    void OnEnable()
    {
        m_Socket.selectExited.AddListener(OnSelectExited);
    }

    void OnDisable()
    {
        m_Socket.selectExited.RemoveListener(OnSelectExited);
    }

    void OnSelectExited(SelectExitEventArgs selectExitEventArgs)
    {
        Transform socketTransform = m_Socket.transform;
        XRBaseInteractable interactable = Instantiate(m_InteractablePrefab, socketTransform.position, socketTransform.rotation);

        m_Socket.interactionManager.SelectEnter((IXRSelectInteractor)m_Socket, interactable);
    }
}
