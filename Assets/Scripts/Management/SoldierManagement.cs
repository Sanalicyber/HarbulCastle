using System;
using System.Collections.Generic;
using SmugTowerDefense.Behaviours.Soldiers;
using SmugTowerDefense.Core;
using UnityEngine;

namespace SmugTowerDefense.Management
{
    public class SoldierManagement : Singleton<SoldierManagement>
    {
        public GameObject warriorPrefab;
        public GameObject magePrefab;
        public GameObject archerPrefab;
        private readonly List<Soldier> _soldiers = new List<Soldier>();

        public T CreateSoldier<T>(int connId) where T : Soldier
        {
            switch (typeof(T))
            {
                case not null when typeof(Warrior) == typeof(T):
                    return CreateSoldier<T>(connId, warriorPrefab);
                case not null when typeof(Mage) == typeof(T):
                    return CreateSoldier<T>(connId, magePrefab);
                case not null when typeof(Archer) == typeof(T):
                    return CreateSoldier<T>(connId, archerPrefab);
                default:
                    throw new ArgumentOutOfRangeException(nameof(T), typeof(T), null);
            }
        }

        private T CreateSoldier<T>(int connId, GameObject prefab) where T : Soldier
        {
            var soldier = Instantiate(prefab, transform).GetComponent<T>();
            soldier.teamId = connId;
            _soldiers.Add(soldier);
            return soldier;
        }
        
        public List<Soldier> GetSoldiers()
        {
            return _soldiers;
        }
    }
}