using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonPuzzleManager : MonoBehaviour
{
    public List<ButtonMaterial> buttonMaterials = new List<ButtonMaterial>();

    [System.Serializable]
    public class ButtonMaterial
    {
        public List<Material> materials;
    }

    public List<MeshRenderer> buttonRenderer = new List<MeshRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        SortButtonPuzzle();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SortButtonPuzzle()
    {
        List<int> numberIndex = new List<int>();
        List<int> typeIndex = new List<int>();

        for (int i = 0; i < buttonRenderer.Count; ++i)
        {
            numberIndex.Add(i);
        }

        for(int i = 0; i < buttonMaterials[0].materials.Count; ++i)
        {
            typeIndex.Add(i);
        }

        for (int i = 0; i < buttonRenderer.Count; ++i)
        {
            int removeNumberIndex = Random.Range(0, numberIndex.Count);
            int removeTypeIndex = Random.Range(0, typeIndex.Count);

            int randomNumber = numberIndex[removeNumberIndex];
            int randomType = typeIndex[removeTypeIndex];
            buttonRenderer[i].material = buttonMaterials[randomNumber].materials[randomType];
            numberIndex.RemoveAt(removeNumberIndex);
            typeIndex.RemoveAt(removeTypeIndex);  
        }
    }


}

#if UNITY_EDITOR
[CustomEditor(typeof(ButtonPuzzleManager))]
public class ButtonPuzzleEditor : Editor
{
    ButtonPuzzleManager t;
    SerializedObject GetTarget;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        t = (ButtonPuzzleManager)target;
        GetTarget = new SerializedObject(t);

        GetTarget.Update();

        if (GUILayout.Button("Sort Button"))
        {
            t.SortButtonPuzzle();
        }

        //SerializedProperty scenes = serializedObject.FindProperty("scenes");

        //scenes.isExpanded = true;

        //serializedObject.ApplyModifiedProperties();

    }
}
#endif

