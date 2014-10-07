using UnityEngine;
using System.Collections;

public class FixedValues : MonoBehaviour {

    private static FixedValues instance;
    private void Awake(){ instance = this; }

    public Transform aiContainer;
    public static Transform AIContainer { get { return instance.aiContainer;  } }

}
