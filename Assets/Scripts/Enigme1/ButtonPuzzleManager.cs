using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using Photon.Pun;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonPuzzleManager : MonoBehaviourPun
{
    public List<ButtonMaterial> buttonMaterials = new();

    [System.Serializable]
    public class ButtonMaterial
    {
        public List<Material> materials;
    }

    [System.Serializable]
    public class Button
    {
        public ButtonPuzzleID buttonPuzzleID;
        public MeshRenderer renderer;
    }

    public List<Button> buttonRenderer = new();
    private int lastPush = 0;
    private bool verificationFailed = false;
    public UnityEvent OnWinEvent;
    public UnityEvent OnLoseEvent;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
            SortButtonPuzzle();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SortButtonPuzzle()
    {
        List<int> numberIndex = Enumerable.Range(0, buttonRenderer.Count).ToList();
        List<int> typeIndex = Enumerable.Range(0, buttonMaterials[0].materials.Count).ToList();

        List<int> rpcRandomNumber = new List<int>();
        List<int> rpcRandomType = new List<int>();

        for (int i = 0; i < buttonRenderer.Count; ++i)
        {
            int removeNumberIndex = Random.Range(0, numberIndex.Count);
            int removeTypeIndex = Random.Range(0, typeIndex.Count);
            
            rpcRandomNumber.Add(removeNumberIndex);
            rpcRandomType.Add(removeNumberIndex);

            int randomNumber = numberIndex[removeNumberIndex];
            int randomType = typeIndex[removeTypeIndex];
            buttonRenderer[i].buttonPuzzleID.value = randomNumber;
            buttonRenderer[i].renderer.material = buttonMaterials[randomNumber].materials[randomType];

            numberIndex.RemoveAt(removeNumberIndex);
            typeIndex.RemoveAt(removeTypeIndex);  
        }

        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("SortButtonRPC", RpcTarget.OthersBuffered, rpcRandomNumber.ToArray(),rpcRandomType.ToArray());
        }
    }

    [PunRPC]
    public void SortButtonRPC(int[] removeNumber, int[] removeType)
    {

        List<int> numberIndex = Enumerable.Range(0, buttonRenderer.Count).ToList();
        List<int> typeIndex = Enumerable.Range(0, buttonMaterials[0].materials.Count).ToList();

        for (int i = 0; i < buttonRenderer.Count; ++i)
        {

            int randomNumber = numberIndex[removeNumber[i]];
            int randomType = typeIndex[removeType[i]];
            buttonRenderer[i].buttonPuzzleID.value = randomNumber;
            buttonRenderer[i].renderer.material = buttonMaterials[randomNumber].materials[randomType];

            numberIndex.RemoveAt(removeNumber[i]);
            typeIndex.RemoveAt(removeType[i]);
        }
    }

    public void CheckButton(ButtonPuzzleID buttonPuzzleID)
    {
        if (lastPush != buttonPuzzleID.value) verificationFailed = true;
        if(lastPush >= buttonRenderer.Count - 1)
        {
            if (verificationFailed)
            {
                lastPush = -1;
                foreach (Button b in buttonRenderer)
                {
                    OnLoseEvent.Invoke();
                    b.buttonPuzzleID.leverController.photonView.RPC("NotInteract", Photon.Pun.RpcTarget.All);
                }
                verificationFailed = false;
            }
            else
            {
                OnWinEvent.Invoke();
                Debug.Log("Win Enigme 1 Part 2");
            }
        }
        lastPush++;
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
    }
}
#endif

