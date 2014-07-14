// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Converts a float value to Imperial units.")]
	public class ConvertUnitsToImperials : FsmStateAction
	{

		public enum Unit
		{
			Inch,
			Foot,
			Yard,
			Mile
		}
		
		[RequiredField]
		public FsmFloat UnitVariable;
		
		public Unit SelectedUnit;
		
		[RequiredField]
		public FsmFloat CalculatedValue;
		
		public bool everyFrame;
		
		public override void Reset()
		{
			UnitVariable = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			DoCalculate();
			
			if (!everyFrame)
				Finish();		
		}
		
		public override void OnUpdate()
		{
			DoCalculate();
		}

		void DoCalculate() {

			switch (SelectedUnit) 
			{
			case Unit.Inch:
				CalculatedValue.Value = UnitVariable.Value * 39.37f;
				break;
				
			case Unit.Foot:
				CalculatedValue.Value = UnitVariable.Value * 3.28f;
				break;
				
			case Unit.Yard:
				CalculatedValue.Value = UnitVariable.Value * 1.09f;
				break;
				
			case Unit.Mile:
				CalculatedValue.Value = UnitVariable.Value * 0.00062f;
				break;
			}

		}
	
	}
}
