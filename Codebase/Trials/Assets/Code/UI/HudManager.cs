using UnityEngine;

namespace Code.UI
{
    public class HudManager : MonoBehaviour
    {

        GameManager.GameManager _gm;

        [SerializeField]
        HealthBar[] UIHealthBars;
        [SerializeField]
        ResourceBar[] UIResourceBars;
        // Use this for initialization
        private void Start()
        {
            _gm = FindObjectOfType<GameManager.GameManager>();
            GameManager.GameManager.PlayerHealthDelegate += UpdateHealthBarHealth;
            GameManager.GameManager.PlayerMoveDelegate += UpdateHealthBarPosition;

        }



        /// <summary>
        /// Used to update our health bar when the hud updates
        /// </summary>
        /// <param name="indexToUpdate"></param>
        private void UpdateHealthBarHealth(int indexToUpdate)
        {
            UIHealthBars[indexToUpdate].SetHealthBarAmount(
                (float)_gm.GetPlayer(indexToUpdate).GetHealth() /
                (float)_gm.GetPlayer(indexToUpdate).GetMaxHealth());
        }

        private void UpdateHealthBarPosition(int indexToUpdate)
        {
            UIHealthBars[indexToUpdate].UpdatePlayerPosition();
        }


    }
}
