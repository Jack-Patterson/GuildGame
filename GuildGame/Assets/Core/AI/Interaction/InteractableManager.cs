﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.Halkyon.AI.Interaction
{
    public class InteractableManager : ExtendedMonoBehaviour
    {
        public static InteractableManager Instance;
        public List<IInteractable> Interactables { get; } = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Register(IInteractable interactable)
        {
            Interactables.Add(interactable);
        }

        public void Unregister(IInteractable interactable)
        {
            Interactables.Remove(interactable);
        }

        public T GetClosestInteractableOfType<T>(Vector3 currentPosition) where T : IInteractable
        {
            try
            {
                return Interactables
                    .OfType<T>()
                    .Select(interactable => new
                    {
                        Interactable = interactable,
                        Distance = Vector3.Distance(currentPosition, interactable.Position)
                    })
                    .OrderBy(result => result.Distance)
                    .FirstOrDefault()!
                    .Interactable;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}