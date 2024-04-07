using System.Collections;
using System.Collections.Generic;
using System.Linq;
using com.Halcyon.API.Core;
using UnityEngine;

namespace com.Halcyon.Core.Interaction.NewInteraction
{
    public class Character : ExtendedMonoBehaviour
    {
        private readonly List<INeed> _needs = new();
        private readonly List<ISkill> _skills = new();
        private IStation _currentStation = null;
        private bool _isBusy = false;

        private void Awake()
        {
            _needs.Add(new Hunger());
            _needs.Add(new Thirst());
            _needs.Add(new Energy());
            _skills.Add(new Swordsmanship());
            _skills.Add(new Archery());
        }

        private void Update()
        {
            print(
                $"Character Update: {_needs[0].Name} {_needs[0].Level} " +
                $"{_needs[1].Name} {_needs[1].Level} " +
                $"{_needs[2].Name} {_needs[2].Level} " +
                $"{_skills[0].Name} {_skills[0].Level} " +
                $"{_skills[1].Name} {_skills[1].Level}");

            foreach (INeed need in _needs)
            {
                need.Decay(Time.deltaTime);
            }

            if (!_isBusy)
            {
                DetermineAndUseStation();
            }
            else
            {
                if (_currentStation != null && _currentStation.Type == "Skill" && AnyCriticalNeed())
                {
                    _isBusy = false;
                }
            }
        }

        public IStation DetermineTargetStation(IEnumerable<IStation> stations)
        {
            INeed mostCriticalNeed = _needs.OrderBy(n => n.Level).FirstOrDefault();
            if (mostCriticalNeed != null && mostCriticalNeed.Level < 0.2f) // Arbitrary threshold for critical need
            {
                return stations.FirstOrDefault(s => s.Type == "Need" && s.Name == mostCriticalNeed.Name);
            }

            ISkill worstSkill = _skills.OrderBy(s => s.Level).FirstOrDefault();
            if (worstSkill != null)
            {
                return stations.FirstOrDefault(s => s.Type == "Skill" && s.Name == worstSkill.Name);
            }

            return null;
        }

        private void DetermineAndUseStation()
        {
            var targetStation = DetermineTargetStation(FindObjectsOfType<Station>());
            if (targetStation != null)
            {
                UseStation(targetStation);
            }
        }

        private bool AnyCriticalNeed()
        {
            return _needs.Any(n => n.Level < 0.2f);
        }

        private void UseStation(IStation station)
        {
            _isBusy = true;
            _currentStation = station;

            StartCoroutine(PerformStationUse(station));
        }

        IEnumerator PerformStationUse(IStation station)
        {
            yield return new WaitForSeconds(station.Duration);

            Log($"Using station: {station.Name} of Type {station.Type} for {station.Duration} seconds.");

            _isBusy = false;
            _currentStation = null;
        }
    }
}