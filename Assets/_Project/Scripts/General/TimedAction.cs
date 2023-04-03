using System;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class TimedAction : MonoBehaviour
    {
        [HideInInspector]
        public bool timerActive;
        
        private Action timerFinishedAction;
        private Action tickAction;

        private float timeSinceStart;
        private float finishTime;

        private bool destroyOnFinish = true;

        public void StartTimedAction(Action timerFinishAction, float timerDuration)
        {
            timerFinishedAction = timerFinishAction;

            timeSinceStart = Time.time;
            finishTime = timerDuration + timeSinceStart;

            timerActive = true;
        }

        private float remainingTime;

        public void PauseTimer()
        {
            if (!timerActive) return;

            timerActive = false;
            remainingTime = finishTime - timeSinceStart;
        }

        public void UnpauseTimer()
        {
            if (timerActive) return;

            timeSinceStart = Time.deltaTime;
            finishTime = remainingTime + timeSinceStart;
            timerActive = true;
        }

        public void CancelTimer() => timerActive = false;

        private void Update()
        {
            if (timerActive)
            {
                UpdateTimer();
            }
        }

        private void UpdateTimer()
        {
            timeSinceStart += Time.deltaTime;
            if (TimerFinished())
            {
                timerActive = false;
                timerFinishedAction?.Invoke();
                if (destroyOnFinish) Destroy(this);
            }
            else
            {
                tickAction?.Invoke();
            }
        }

        public void AddTickAction(Action toAdd) => tickAction = toAdd;

        public TimedAction DestroyOnFinish(bool value)
        {
            destroyOnFinish = value;
            return this;
        }

        private bool TimerFinished() => timeSinceStart >= finishTime;
    }
}