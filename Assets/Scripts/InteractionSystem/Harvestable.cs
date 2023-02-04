using UnityEngine;

namespace InteractionSystem
{
    public class Harvestable : MonoBehaviour, IInteractable
    {
        [SerializeField] 
        private InteractionType _requiredInteractionType;

        [SerializeField]
        private GameObject _droppedGameObject;
        
        public bool Interact(InteractionType attemptWithType)
        {
            if (_requiredInteractionType != attemptWithType) return false;

            //do Something with the actual spline

            Instantiate(_droppedGameObject, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            return true;
        }
    }
}