// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Wiggles an object around the Y axis using a time factor.")]
	public class SinusWiggle : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat multiplier;
		public FsmFloat timeFactor;
		public bool everyFrame;
		
		public override void Reset()
		{
			gameObject = null;
			multiplier = 5f;
			timeFactor = 0.5f;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoWiggle();
			
			if (!everyFrame)
			{
				Finish();
			}		
		}
		
		public override void OnUpdate()
		{
			DoWiggle();
		}

		void DoWiggle()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			if (gameObject!=null)
			{
				go.transform.eulerAngles = new Vector3(0f, Mathf.Sin(Time.time * timeFactor.Value) * multiplier.Value, 0f);	
			}
		}
	}
}
