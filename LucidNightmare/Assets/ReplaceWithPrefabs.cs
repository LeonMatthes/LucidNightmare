using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*
public class ReplaceWithPrefabs : MonoBehaviour
{
    public GameObject Corridor_I;
    public GameObject Corridor_T;
    public GameObject Corridor_L;
    public GameObject Corridor_X;

    public void swap()
    {
        HashSet<GameObject> children = new HashSet<GameObject>();
        foreach(Transform child in transform)
        {
            children.Add(child.gameObject);
        }
        foreach(GameObject oldObject in children)
        {
            SwapPrefabs(oldObject);
        }
    }

    void SwapPrefabs(GameObject oldGameObject)
    {
        // Determine the rotation and position values of the old game object.
        // Replace rotation with Quaternion.identity if you do not wish to keep rotation.
        Quaternion rotation = oldGameObject.transform.rotation;
        Vector3 position = oldGameObject.transform.position;

        GameObject newPrefab = null;
        if(oldGameObject.name.StartsWith("Corridor_I"))
        {
            newPrefab = Corridor_I;
        }
        if (oldGameObject.name.StartsWith("Corridor_L"))
        {
            newPrefab = Corridor_L;
        }
        if (oldGameObject.name.StartsWith("Corridor_T"))
        {
            newPrefab = Corridor_T;
        }
        if (oldGameObject.name.StartsWith("Corridor_X"))
        {
            newPrefab = Corridor_X;
        }

        // Instantiate the new game object at the old game objects position and rotation.
        GameObject newGameObject = PrefabUtility.InstantiatePrefab(newPrefab) as GameObject;
        newGameObject.transform.position = oldGameObject.transform.position;
        newGameObject.transform.rotation = oldGameObject.transform.rotation;

        // If the old game object has a valid parent transform,
        // (You can remove this entire if statement if you do not wish to ensure your
        // new game object does not keep the parent of the old game object.
        if (oldGameObject.transform.parent != null)
        {
            // Set the new game object parent as the old game objects parent.
            newGameObject.transform.SetParent(oldGameObject.transform.parent);
        }

        // Destroy the old game object, immediately, so it takes effect in the editor.
        DestroyImmediate(oldGameObject);
    }

}


/// <summary>Custom Editor for our PrefabSwitch script, to allow us to perform actions
/// from the editor.</summary>
[CustomEditor(typeof(ReplaceWithPrefabs))]
public class PrefabSwitchEditor : Editor
{
    /// <summary>Calls on drawing the GUI for the inspector.</summary>
    public override void OnInspectorGUI()
    {
        // Draw the default inspector.
        DrawDefaultInspector();

        // Grab a reference to the target script, so we can identify it as a 
        // PrefabSwitch, instead of a simple Object.
        ReplaceWithPrefabs prefabSwitch = (ReplaceWithPrefabs)target;

        // Create a Button for "Swap By Tag",
        if (GUILayout.Button("Swap"))
        {
            // if it is clicked, call the SwapAllByTag method from prefabSwitch.
            prefabSwitch.swap();
        }
    }
}*/