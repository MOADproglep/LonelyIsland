using Assets.Scripts.Component;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [Space]
        [Header("OverlapCircle interaction Settings")]
        [SerializeField] private float _interactionRadious;
        [SerializeField] private LayerMask _interactionLayer;


        private Vector2 _direction;
        private Collider2D[] _interactionResult = new Collider2D[1];

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            if (_direction.magnitude > 0)
            {
                var delta = _direction * _speed * Time.deltaTime;
                transform.position = transform.position + new Vector3(delta.x, delta.y, transform.position.z);
            }
        }

        internal void Interact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
            transform.position,
            _interactionRadious,
            _interactionResult,
            _interactionLayer);

            for (int i = 0; i < size; i++)
            {
                var interacteble = _interactionResult[i].GetComponent<InteractableComponent>();
                if (interacteble != null)
                {
                    interacteble.Interact();
                }
            }
        }
    }
}
