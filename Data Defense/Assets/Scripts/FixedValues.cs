using UnityEngine;
using System.Collections;

public class FixedValues : MonoBehaviour {

    // Set the FixedValues instance to itself
    private static FixedValues instance;
    private void Awake(){ instance = this; }


    public Transform aiContainer;
    public static Transform AIContainer { get { return instance.aiContainer;  } }

    // Enemy types can be specified by numbers now
    public enum Enemy_Types { Data, Virus, Program }

}
