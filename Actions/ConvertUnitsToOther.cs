// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Converts a float value to Other units.")]
	public class ConvertUnitsOther : FsmStateAction
	{
		

		public enum Unit
		{
			Point,
//			Pixel,
			Span,
			Pace,
			NauticalMile,
			RomanLeague
//			Lightyear,
//			Parsec
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
			case Unit.Point:
				CalculatedValue.Value = UnitVariable.Value * 39.37f * 72;
				break;

//			case Unit.Pixel:
//				CalculatedValue.Value = UnitVariable.Value * 3779.52f;
//				break;
				
			case Unit.Span:
				CalculatedValue.Value = UnitVariable.Value * 0.23f;
				break;

			case Unit.Pace:
				CalculatedValue.Value = UnitVariable.Value * 0.71f;
				break;

			case Unit.NauticalMile:
				CalculatedValue.Value = UnitVariable.Value / 1852;
				break;

			case Unit.RomanLeague:
				CalculatedValue.Value = UnitVariable.Value / 2222;
				break;

//			case Unit.Lightyear:
//				CalculatedValue.Value = UnitVariable.Value / 9460528000000000;
//				break;
				
//			case Unit.Parsec:
//				CalculatedValue.Value = UnitVariable.Value / 30856776000000000;
//				break;
			}

		}
	
	}
}
