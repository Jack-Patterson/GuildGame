using System.Linq;
using com.Halkyon.AI.Character;
using com.Halkyon.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.Halkyon.UI
{
    public class GameUiManager : ExtendedMonoBehaviour
    {
        public static GameUiManager Instance { get; private set; }
        private InputActions _inputActions;

        [SerializeField] private CharacterInfoHandlerUI characterInfoHandlerUI;

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

        private void Start()
        {
            InputActions inputActions = FindObjectOfType<InputActions>();
            inputActions.Player.Mouse1Click.performed += Raycast;
        }

        private void Raycast(InputAction.CallbackContext obj)
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
            {
                if (hit.collider.TryGetComponent(out Character character))
                {
                    DisplayCharacterInfo(character);
                }
                else
                {
                    Collider[] colliders = Physics.OverlapSphere(hit.point, 2f);

                    Character closestCharacter = colliders
                        .Where(collider => collider.TryGetComponent(out Character _))
                        .OrderBy(collider => Vector3.Distance(hit.point, collider.transform.position))
                        .Select(collider => collider.GetComponent<Character>())
                        .FirstOrDefault();
                    
                    if (closestCharacter != null)
                    {
                        DisplayCharacterInfo(closestCharacter);
                        return;
                    }

                    characterInfoHandlerUI.gameObject.SetActive(false);
                }
            }
        }
        
        private void DisplayCharacterInfo(Character character)
        {
            characterInfoHandlerUI.gameObject.SetActive(true);
            characterInfoHandlerUI.DisplayCharacter(character);
        }
    }
}