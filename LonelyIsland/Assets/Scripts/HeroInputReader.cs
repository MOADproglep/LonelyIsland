using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public void OnMovementAction(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnInteract()
        {
                _hero.Interact();
        }
    }
}
