using System.Collections.Generic;
using UnityEngine;

namespace com.Halcyon.Core.AI.OldCharacter.Character
{
    public class CharacterManager : API.Core.Character.CharacterManager
    {
        [SerializeField] private GameObject passerbyPrefab;
        [SerializeField] private Transform footPathPointOne;
        [SerializeField] private Transform footPathPointTwo;

        internal Transform FootPathPointOne => footPathPointOne;
        internal Transform FootPathPointTwo => footPathPointTwo;

        private List<GameObject> _passerbys;

        private void Start()
        {
            _passerbys = new List<GameObject>();

            for (int i = 0; i < 10; i++)
            {
                InstantiateAndMovePasserby();
            }
        }

        private void InstantiateAndMovePasserby()
        {
            int random = Random.Range(1f, 2f) < 1.5f ? 1 : 2;
            bool isStartPointOne = random == 1;

            GameObject passerby = Instantiate(passerbyPrefab,
                isStartPointOne ? footPathPointOne.position : footPathPointTwo.position, Quaternion.identity);
            _passerbys.Add(passerby);

            passerby.GetComponent<Character>()
                .SetTarget(isStartPointOne ? footPathPointTwo.position : footPathPointOne.position);
        }
    }
}