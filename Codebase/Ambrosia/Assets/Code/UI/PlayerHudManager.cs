using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHudManager : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.UI.RawImage BuffIcon;

    [SerializeField]
    UnityEngine.UI.RawImage HealthBarFill;
    [SerializeField]
    UnityEngine.UI.RawImage HealthBar;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSkillIcon(UnityEngine.UI.RawImage imageToUpdateTo)
    {
        BuffIcon.texture = imageToUpdateTo.texture;


    }

    public void SetHealthBarAmount(float ratio)
    {
        HealthBarFill.rectTransform.sizeDelta = new Vector2(HealthBar.rectTransform.sizeDelta.x * ratio, HealthBar.rectTransform.sizeDelta.y);
    }
}
