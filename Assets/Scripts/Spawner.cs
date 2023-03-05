using System;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeRPG
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _xOffset;

        [HideInInspector] public List<Enemy> enemies = new List<Enemy>();
        
        private void Update()
        {
            CorrectPosition();
        }

        public void Spawn(List<Enemy> enemiesPreset)
        {
            enemies.Clear();
            var id = 0;
            
            foreach (var enemy in enemiesPreset)
            {
                var rangeZ = UnityEngine.Random.Range(-4.0f, 4.0f);
                var rangeVector = new Vector3(++id * 1.5f, 0.0f, rangeZ);
                
                var obj = Instantiate(enemy, transform.position + rangeVector, Quaternion.identity, transform);
                obj.Target = Level.GetSlime;
                obj.Despawn += DespawnEnemy;
                enemies.Add(obj);
            }
        }

        private void CorrectPosition()
        {
            var screenPointToRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height / 2.0f));
            if (Physics.Raycast(screenPointToRay, out var hit, 1000))
            {
                var transformPosition = transform.position;
                transformPosition.x = hit.point.x + _xOffset;
                transform.position = transformPosition;
            }
        }

        private void DespawnEnemy(Entity enemy)
        {
            enemies.Remove(enemy as Enemy);
            Destroy(enemy.gameObject);
            
            if(enemies.Count == 0) 
                Level.GetStager.NextStage();
        }
    }
}