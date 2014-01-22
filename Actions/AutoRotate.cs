// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Custom")]
	[Tooltip("Constantly rotates a GameObject around an axis.")]
	public class AutoRotate : FsmStateAction
	{

		public FsmOwnerDefault gameObject;
		public FsmVector3 rotation;
		public bool everyFrame;
		
		public override void Reset()
		{
			gameObject = null;
			rotation = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			DoRotate();
			
			if (!everyFrame)
			{
				Finish();
			}		
		}

		public override void OnUpdate()
		{
			DoRotate();
		}

		void DoRotate()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			if (gameObject!=null)
			{
				go.transform.Rotate(rotation.Value * Time.deltaTime, Space.World);
			}
		}
	}
}