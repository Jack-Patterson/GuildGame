using System;
using System.Collections;
using UnityEngine;

namespace com.Halkyon.Time
{
    public class TimeHandler : MonoBehaviour
    {
        public Action<Time> OnTimeChanged;
        private Time _time;

        public Time Time => _time;

        private void Awake()
        {
            _time = new Time(0, 23, 40);
        }
        
        private void Start()
        {
            StartCoroutine(TimeSimulation());
        }

        private IEnumerator TimeSimulation()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                IncrementTime();
            }
        }
        
        private void IncrementTime()
        {
            _time.Increment();
            OnTimeChanged?.Invoke(_time);
        }
    }
}