using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    UnityEngine.UI.RawImage HealthBarFill;
    [SerializeField]
    UnityEngine.UI.RawImage HealthBarBackdrop;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHealthBarAmount(float ratio)
    {
        HealthBarFill.rectTransform.sizeDelta = new Vector2(HealthBarBackdrop.rectTransform.sizeDelta.x * ratio, HealthBarBackdrop.rectTransform.sizeDelta.y);
    }
}
