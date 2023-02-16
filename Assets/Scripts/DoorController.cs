using UnityEditor;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Animator doorAnimator;

    public void OpenDoor()
    {
        audioSource.Play();
        doorAnimator.SetBool("IsActive", true);
    }

    public void CloseDoor()
    {
        audioSource.Play();
        doorAnimator.SetBool("IsActive", false);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(DoorController))]
public class DoorControllerEditor : Editor
{
    private DoorController doorController;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        doorController = (DoorController)target;

        if (GUILayout.Button("Open Door"))
        {
            doorController.OpenDoor();
        }

        if (GUILayout.Button("Close Door"))
        {
            doorController.CloseDoor();
        }
    }
}
#endif