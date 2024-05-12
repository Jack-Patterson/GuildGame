using System.Collections;
using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Interaction.NewInteraction
{
    public class Station : ExtendedMonoBehaviour, IStation
    {
        [SerializeField] public string Type { get; }
        public string Name { get; }
        public float Duration { get; }
        public string AnimationTrigger { get; }

        public void UseStation(AI.OldCharacter.NewInteraction.Character character)
        {
            StartCoroutine(WaitForTime(Duration));
            Log($"Using station {Name} of Type {Type} for {Duration} seconds.");
        }
        
        private IEnumerator WaitForTime(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}