using TMPro;

namespace com.Halkyon.UI
{
    public class MoneyHandlerUI : ExtendedMonoBehaviour
    {
        private TMP_Text _moneyText;

        private void Start()
        {
            _moneyText = GetComponentInChildren<TMP_Text>();
            UpdateMoneyText(GameManager.Instance.Money);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnMoneyChanged += UpdateMoneyText;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnMoneyChanged -= UpdateMoneyText;
        }

        private void UpdateMoneyText(int amount)
        {
            _moneyText.text = amount.ToString();
        }
    }
}