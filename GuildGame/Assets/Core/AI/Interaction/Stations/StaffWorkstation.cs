using System;
using System.Collections.Generic;
using com.Halkyon.AI.Character.StaffJobs;
using UnityEngine;

namespace com.Halkyon.AI.Interaction.Stations
{
    public abstract class StaffWorkstation : InteractableMonoBehaviour
    {
        private readonly Dictionary<Type, int> _requiredStaff = new();
        private readonly Dictionary<Type, List<Staff>> _assignedStaff = new();

        public Dictionary<Type, int> RequiredStaff => new(_requiredStaff);
        public Dictionary<Type, List<Staff>> AssignedStaff => new(_assignedStaff);

        public abstract override void Interact(Character.Character character);

        public void AddRequiredStaffType<T>(int spots) where T : Staff
        {
            _requiredStaff[typeof(T)] = spots;
        }
        
        public void AssignStaff<T>(T staff) where T : Staff
        {
            if (_requiredStaff.TryGetValue(typeof(T), out int spots) &&
                _assignedStaff.TryGetValue(typeof(T), out List<Staff> staffList))
            {
                if (staffList.Count < spots)
                {
                    staffList.Add(staff);
                }
                else {
                    Log($"StaffWorkstation: {name} is full for {typeof(T).Name}", LogType.Warning);
                }
            }
            else
            {
                Log($"StaffWorkstation: {name} does not require {typeof(T).Name}", LogType.Warning);
            }
        }
        
        public void UnassignStaff<T>(T staff) where T : Staff
        {
            if (_assignedStaff.TryGetValue(typeof(T), out List<Staff> staffList))
            {
                staffList.Remove(staff);
            }
            else
            {
                Log($"StaffWorkstation: {name} does not have any {typeof(T).Name} assigned", LogType.Warning);
            }
        }
        
        public T GetFreeStaffMemberOfType<T>() where T : Staff
        {
            if (_assignedStaff.TryGetValue(typeof(T), out List<Staff> staffList))
            {
                foreach (Staff staff in staffList)
                {
                    if (!staff.IsPerformingTask)
                    {
                        return (T) staff;
                    }
                }
            }
            return default;
        }
    }
}