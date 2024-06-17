using System;
using System.Collections.Generic;
using com.Halkyon.AI.Character.StaffJobs;
using UnityEngine;

namespace com.Halkyon.AI.Interaction.Stations
{
    public abstract class StaffWorkstation : InteractableMonoBehaviour
    {
        protected virtual Dictionary<Type, int> requiredStaff { get; } = new();
        protected virtual Dictionary<Type, List<Staff>> assignedStaff { get; } = new();

        public Dictionary<Type, int> RequiredStaff => new(requiredStaff);
        public Dictionary<Type, List<Staff>> AssignedStaff => new(assignedStaff);

        public abstract override void Interact(Character.Character character);

        public void AddRequiredStaffType<T>(int spots) where T : Staff
        {
            requiredStaff[typeof(T)] = spots;
        }
        
        public void AssignStaff<T>(T staff) where T : Staff
        {
            if (requiredStaff.TryGetValue(typeof(T), out int spots))
            {
                assignedStaff.TryGetValue(typeof(T), out List<Staff> staffList);
                
                List<Staff> staffAssigned = staffList;
                if (staffAssigned == null)
                {
                    staffAssigned = new List<Staff>();
                    assignedStaff[typeof(T)] = staffAssigned;
                }
                
                if (staffAssigned.Count < spots)
                {
                    staffAssigned.Add(staff);
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
            if (assignedStaff.TryGetValue(typeof(T), out List<Staff> staffList))
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
            if (assignedStaff.TryGetValue(typeof(T), out List<Staff> staffList))
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