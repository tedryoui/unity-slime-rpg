using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeRPG
{
    [Serializable]
    public class Stager : MonoBehaviour
    {
        public List<StagePreset> stagePresetsOrder;
        public int crrPresetNumber;

        private void Start()
        {
            this.LoadFromDisk();
            
            Level.GetGui.taskbarViewModel.UpdateStage(stagePresetsOrder[crrPresetNumber].name);
            
            StartCoroutine(Transition());
        }

        public void NextStage()
        {
            crrPresetNumber++;
            
            if (crrPresetNumber >= stagePresetsOrder.Count)
                crrPresetNumber = stagePresetsOrder.Count - 1;
            
            Level.GetGui.taskbarViewModel.UpdateStage(stagePresetsOrder[crrPresetNumber].name);

            StartCoroutine(Transition());
        }

        public IEnumerator Transition()
        {
            Level.GetSlime.SetState(Level.GetSlime.MoveState);
            Level.GetSlime.Heal();
            
            yield return new WaitWhile(() => Level.GetSlime.CrrState == Level.GetSlime.MoveState);
            
            Level.GetSpawner.Spawn(stagePresetsOrder[crrPresetNumber].Enemies);
        }
    }
}