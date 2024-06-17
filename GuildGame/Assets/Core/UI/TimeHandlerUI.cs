using com.Halkyon.Time;
using TMPro;
using UnityEngine;

namespace com.Halkyon.UI
{
    public class TimeHandlerUI : ExtendedMonoBehaviour
    {
        private TimeHandler _timeHandler;
        private TMP_Text _timeText;

        private void Start()
        {
            _timeText = GetComponentInChildren<TMP_Text>();
            _timeHandler = FindObjectOfType<TimeHandler>();
            
            UpdateTimeText(_timeHandler.Time);
        }

        private void OnEnable()
        {
            if (_timeHandler == null)
                _timeHandler = FindObjectOfType<TimeHandler>();

            _timeHandler.OnTimeChanged += UpdateTimeText;
        }

        private void OnDisable()
        {
            _timeHandler.OnTimeChanged -= UpdateTimeText;
        }

        private void UpdateTimeText(Time.Time time)
        {
            _timeText.text = time.ToString();
        }
    }
}