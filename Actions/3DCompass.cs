// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	[ActionCategory("Advanced Actions")]
	[Tooltip("Builds a compass to show the direction to a set target.")]
	public class Compass3D : FsmStateAction {
		
		[RequiredField]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		public FsmGameObject targetObject;

		[HasFloatSlider(0f,5)]
		public FsmFloat adjustmentSpeed;

		public FsmBool debug;

		private Quaternion lastRotation;
		private Quaternion desiredRotation;

		public override void Reset() {
			gameObject = null;
			targetObject = null;
			adjustmentSpeed = 2.5f;
		}

		public override void OnLateUpdate() {
			DoOrientate3D();
		}

		void DoOrientate3D() {

			var upVector = new FsmVector3 { UseVariable = true};
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			var goTarget = targetObject.Value;

			Vector3 lookAtPos = goTarget.transform.position;
			lookAtPos.y = go.transform.position.y;

			var diff = lookAtPos - go.transform.position;
			if (diff != Vector3.zero && diff.sqrMagnitude > 0)
			{
				desiredRotation = Quaternion.LookRotation(diff, upVector.IsNone ? Vector3.up : upVector.Value);
			}
			
			lastRotation = Quaternion.Slerp(lastRotation, desiredRotation, adjustmentSpeed.Value * Time.deltaTime);
			go.transform.rotation = lastRotation;

			if (debug.Value)
			{
				Debug.DrawLine(go.transform.position, lookAtPos, Color.red);
			}
		}

	}
}