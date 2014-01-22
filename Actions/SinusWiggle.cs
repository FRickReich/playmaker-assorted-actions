// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Custom")]
	[Tooltip("Wiggles around on a sinus axis.")]
	public class SinusWiggle : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool animate;
		public FsmFloat multiplier;
		public FsmFloat timeFactor;
		public bool everyFrame;
		
		public override void Reset()
		{
			gameObject = null;
			animate = false;
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
				// content.Value = textAsset.text;
				//	UnityEngine.Debug.Log(content.Value);
				
				go.transform.eulerAngles = new Vector3(0f, Mathf.Sin(Time.time * timeFactor.Value) * multiplier.Value, 0f);	
			}
		}
	}
}
