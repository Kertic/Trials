using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHudManager : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.RawImage SkillIcon;
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
        SkillIcon.texture = imageToUpdateTo.texture;
        
    }
}
