// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace HutongGames.PlayMaker.Actions {
	[ActionCategory("Advanced Actions")]
	[Tooltip("Constantly orbits an object around another one, using a set direction and speed.")]

	public class VectorOrbit : FsmStateAction {

		public enum Direction
		{
			X,
			Y,
			Z
		}

		// Owner Object
		[RequiredField]
		public FsmOwnerDefault gameObject;

		// Target Object
		[RequiredField]		
		public FsmGameObject parentObject;

		[RequiredField]
		public Direction mapToDirection;

		// Speed Slider
		[HasFloatSlider(-10f, 10)]
		public FsmFloat adjustmentSpeed;

		public FsmVector3 SelfRotation;

		public FsmGameObject storeObject;

		// Debug
		public FsmBool debug;
		
		public override void Reset() {
			gameObject = null;
			parentObject = null;
			adjustmentSpeed = 5f;
			SelfRotation = null;
			debug = false;
			storeObject = null;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			var goTarget = parentObject.Value;

			var newParent = storeObject.Value;
			newParent = new GameObject( "OrbitPivot" );
			newParent.transform.position = goTarget.transform.position;

			newParent.transform.parent = goTarget == null ? null : goTarget.transform;

			go.transform.parent = newParent == null ? null : newParent.transform;
		}
		
		public override void OnUpdate()
		{

			DoOrbit();

		}

		void DoOrbit() {

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			var goTarget = parentObject.Value;
			var newParent = storeObject.Value;
			
			var rotateDirection = new Vector3();
			
			switch (mapToDirection) 
			{
			case Direction.X:
				go.transform.parent.Rotate(Vector3.right * adjustmentSpeed.Value * Time.deltaTime, Space.Self);
				break;
				
			case Direction.Y:
				go.transform.parent.Rotate(Vector3.up * adjustmentSpeed.Value * Time.deltaTime, Space.Self);
				break;
				
			case Direction.Z:
				go.transform.parent.Rotate(Vector3.forward * adjustmentSpeed.Value * Time.deltaTime, Space.Self);
				break;
			}

			go.transform.Rotate(SelfRotation.Value * Time.deltaTime, Space.World);

			// debug line to target
			if (debug.Value)
			{
				Debug.DrawLine(go.transform.position, goTarget.transform.position, Color.red);

				Debug.DrawLine (go.transform.position + -go.transform.up * 0.5f, go.transform.position + go.transform.up * 0.5f, Color.red);
				Debug.DrawLine (go.transform.position + -go.transform.right * 0.5f, go.transform.position + go.transform.right * 0.5f, Color.red);
				Debug.DrawLine (go.transform.position + -go.transform.forward * 0.5f, go.transform.position + go.transform.forward * 0.5f, Color.red);

				Debug.DrawLine (goTarget.transform.position + -goTarget.transform.up * 1.5f, goTarget.transform.position + goTarget.transform.up * 1.5f, Color.red);
				Debug.DrawLine (goTarget.transform.position + -goTarget.transform.right * 1.5f, goTarget.transform.position + goTarget.transform.right * 1.5f, Color.red);
				Debug.DrawLine (goTarget.transform.position + -goTarget.transform.forward * 1.5f, goTarget.transform.position + goTarget.transform.forward * 1.5f, Color.red);

			}

		}

	}
}