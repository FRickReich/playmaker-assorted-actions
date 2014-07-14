// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Pauses/Unpauses the current scene using a bool value.")]
	public class PauseScene : FsmStateAction
	{
		private FsmFloat timeScale;
		public FsmBool pause;
		
		public override void Reset()
		{
			pause = false;
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

			if (pause.Value) {
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