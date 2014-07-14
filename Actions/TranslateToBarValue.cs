// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Translates a float to the width of a Progressbar (Usable for eg. Healthbars in NGUI).")]
	public class TranslateToBarValue : FsmStateAction
	{

		[RequiredField]
		public FsmFloat CurrentValue;

		[RequiredField]
		public FsmFloat MaxValue;

		[RequiredField]
		public FsmFloat MaxBarWidth;

		public FsmFloat Result;

		public bool everyFrame;
		
		public override void Reset()
		{
			CurrentValue = null;
			MaxValue = null;
			MaxBarWidth = 1.0f;
			Result = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{

			Result.Value = CurrentValue.Value / MaxValue.Value * MaxBarWidth.Value;
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			Result.Value = CurrentValue.Value / MaxValue.Value * MaxBarWidth.Value;
		}
	}
}