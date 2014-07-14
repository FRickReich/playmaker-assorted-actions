// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Converts a float value to Metrical units.")]
	public class ConvertUnitsToMetrics : FsmStateAction
	{

		public enum Unit
		{
			Millimeter,
			Centimeter,
			Meter,
			Kilometer
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
			case Unit.Millimeter:
				CalculatedValue.Value = UnitVariable.Value * 1000;
				break;
				
			case Unit.Centimeter:
				CalculatedValue.Value = UnitVariable.Value * 100;
				break;

			case Unit.Meter:
				CalculatedValue.Value = UnitVariable.Value * 1;
				break;
				
			case Unit.Kilometer:
				CalculatedValue.Value = UnitVariable.Value / 1000;
				break;
			}

		}
	
	}
}
