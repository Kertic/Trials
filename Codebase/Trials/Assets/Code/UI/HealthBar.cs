using System.Security.AccessControl;
using Code.Entities.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.RawImage _healthBarFill;
        [SerializeField] private UnityEngine.UI.RawImage _healthBarBackdrop;
        [SerializeField] private Player _followingPlayer;

        private void Awake()
        {
            
        }

        public void SetHealthBarAmount(float ratio)
        {
            _healthBarFill.rectTransform.sizeDelta = new Vector2(
                _healthBarBackdrop.rectTransform.sizeDelta.x * ratio,
                _healthBarBackdrop.rectTransform.sizeDelta.y);
        }

        public void UpdatePlayerPosition()
        {
            transform.position = _followingPlayer.transform.position;
            transform.Translate(0,6,0);
        }
    }
}