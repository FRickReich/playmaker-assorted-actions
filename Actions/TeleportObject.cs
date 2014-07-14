// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Teleports triggering object to a set target and fires an event.")]
	public class TeleportObject : FsmStateAction
	{

		// Get Teleporter Target.
		[RequiredField]
		public FsmGameObject teleporterTarget;
		
		public FsmEvent finishEvent;

		private Space space;
		
		public override void Reset()
		{
			teleporterTarget = null;
			space = Space.World;
			finishEvent = null;
		}
		
		public override void Awake()
		{
			Fsm.HandleTriggerEnter = true;

		}

		public override void DoTriggerEnter(Collider other) {

			var newPosition = teleporterTarget.Value;

			var position = space == Space.World ? newPosition.transform.position : newPosition.transform.localPosition;

			other.transform.localPosition = position;

			Finish();
			if (finishEvent != null)
			{
				Fsm.Event(finishEvent);
			}
		}
	}
}