// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Sets an Array of bools to the opposite of the parent bool.")]
	public class BoolExchange : FsmStateAction
	{
		[RequiredField]
		public FsmBool parentBool;

		[ActionSection("Data")]

		[CompoundArray("Count", "boolVariable", "boolValue")]

		[UIHint(UIHint.Variable)]
		public FsmBool[] boolVariable;
		public FsmBool[] boolValue;

		public override void OnEnter()
		{

			DoBoolExchange();
			
			Finish();

		}

		void DoBoolExchange() {

			var currentBool = true;

			if(parentBool.Value == true) {
				currentBool = false;
			}
			if(parentBool.Value == false) {
				currentBool = true;
			}

			for(int i = 0;i<boolVariable.Length;i++) {
				
				boolValue[i].Value = currentBool;
				boolVariable[i].Value = boolValue[i].Value;
				
			}

		}
	}
}