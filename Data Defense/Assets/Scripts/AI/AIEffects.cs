using UnityEngine;
using System.Collections;

public class AIEffects : MonoBehaviour {

	public Material VirusMaterial;
	public Color32 VirusHigh;
	public Color32 VirusLow;
	public float VirusSpeed = 2;

	private float virusProgress = 0;
	private int virusDir = 1;

//	public void Update(){
//		virusProgress += Time.deltaTime * VirusSpeed * virusDir;
//		if(virusProgress > 1 || virusProgress < 0) virusDir *= -1;
//		VirusMaterial.color = Color32.Lerp(VirusHigh, VirusLow, virusProgress);
//	}
}
