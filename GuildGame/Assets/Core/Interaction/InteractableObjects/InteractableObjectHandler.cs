using System.Collections.Generic;
using System.Linq;
using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Interaction.InteractableObjects
{
    public class InteractableObjectHandler : ExtendedMonoBehaviour
    {
        public static InteractableObjectHandler Instance;

        private List<IInteractableObject> _interactableObjects = new();

        private void Awake()
        {
            Singleton(ref Instance, true);
        }

        public void Register(IInteractableObject interactableObject) => _interactableObjects.Add(interactableObject);
        
        public void Deregister(IInteractableObject interactableObject) => _interactableObjects.Remove(interactableObject);
        
        public T GetInteractableObject<T>(Vector3 characterPosition) where T : InteractableObject
        {
            return _interactableObjects
                .OfType<T>()
                .Select(obj => new { obj, distance = Vector3.Distance(characterPosition, obj.transform.position) })
                .OrderBy(item => item.distance)
                .FirstOrDefault()?.obj;
        }
    }
}