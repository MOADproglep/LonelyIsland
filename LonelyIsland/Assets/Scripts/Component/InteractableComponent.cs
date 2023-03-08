using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Component
{
    public class InteractableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        public void Interact()
        {
            _action.Invoke();
        }
    }
}
