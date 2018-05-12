using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{

    GameManager gm;

    [SerializeField]
    HealthBar[] UIHealthBars;
    [SerializeField]
    ResourceBar[] UIResourceBars;
    // Use this for initialization
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        GameManager.playerHudDelegate += UpdateHealthBar;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateHealthBar(int indexToUpdate)
    {
        UIHealthBars[indexToUpdate].SetHealthBarAmount(
           (float)gm.GetPlayer((uint)indexToUpdate).GetHealth() /
           (float)gm.GetPlayer((uint)indexToUpdate).GetMaxHealth());
    }


}
