// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Custom")]
	[Tooltip("Stops the gametime and pauses the current scene.")]
	public class PauseScene : FsmStateAction
	{
		private FsmFloat timeScale;
		public FsmBool pauseGame;
		
		public override void Reset()
		{
			pauseGame = false;
		}
		
		public override void OnEnter()
		{
			DoTimeScale();
		}
		public override void OnUpdate()
		{
			DoTimeScale();
		}
		
		void DoTimeScale()
		{

			if (pauseGame.Value) {
				timeScale = 0.0f;
			} else {
				timeScale = 1.0f;
			}

			Time.timeScale = timeScale.Value;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;

			Finish();
		}
	}
}