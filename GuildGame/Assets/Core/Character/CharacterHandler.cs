using System.Collections.Generic;
using UnityEngine;

namespace com.Halcyon.Core.Character
{
    public class CharacterHandler : MonoBehaviour
    {
        [SerializeField] private GameObject passerbyPrefab;
        [SerializeField] private Transform footPathPointOne;
        [SerializeField] private Transform footPathPointTwo;

        private List<GameObject> _passerbys;

        private void Start()
        {
            _passerbys = new List<GameObject>();

            for (int i = 0; i < 10; i++)
            {
                InstantiateAndMovePasserbys();
            }
        }

        private void InstantiateAndMovePasserbys()
        {
            int random = Random.Range(1f, 2f) >= 1.5f ? 2 : 1;
            bool isStartPointOne = random == 1;

            GameObject passerby = Instantiate(passerbyPrefab,
                isStartPointOne ? footPathPointOne.position : footPathPointTwo.position, Quaternion.identity);
            _passerbys.Add(passerby);

            passerby.GetComponent<PasserbyCharacter>()
                .SetTarget(isStartPointOne ? footPathPointTwo.position : footPathPointOne.position);
        }
    }
}