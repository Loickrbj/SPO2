using UnityEditor;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;

    public void OpenDoor()
    {
        GetComponent<Animator>().SetBool("IsOpen", true);
    }

    public void CloseDoor()
    {
        GetComponent<Animator>().SetBool("IsOpen", false);
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