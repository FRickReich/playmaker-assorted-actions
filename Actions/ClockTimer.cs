// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Create an analog clock using system date time.")]
	public class ClockTimer : FsmStateAction
	{

		public FsmInt hours;

		public FsmInt minutes;

		public FsmInt seconds;

		public FsmInt milliseconds;

		public FsmGameObject hoursGameObject;

		public FsmGameObject minutesGameObject;

		public FsmGameObject secondsGameObject;

		public FsmGameObject millisecondsGameObject;

		public bool everyFrame;

		public bool debug;

		public override void OnEnter()
		{
			DoTimer();
			
			if (!everyFrame)
				Finish();		
		}
		
		public override void OnUpdate()
		{
			DoTimer();
		}

		void DoTimer() {

			TimeSpan timespan = DateTime.Now.TimeOfDay;
			
			DateTime time = DateTime.Now;

			var hoursToDegrees = 360f / 12f;
			var minutesToDegrees = 360f / 60f;
			var secondsToDegrees = 360f / 60f;

			var hoursObject = hoursGameObject.Value;
			var minutesObject = minutesGameObject.Value;
			var secondsObject = secondsGameObject.Value;
			var millsecondsObject = millisecondsGameObject.Value;

			milliseconds.Value = int.Parse(DateTime.Now.ToString("fff"));
			seconds.Value = int.Parse(DateTime.Now.ToString("ss"));
			minutes.Value = int.Parse(DateTime.Now.ToString("mm"));
			hours.Value = int.Parse(DateTime.Now.ToString("hh"));


			hoursObject.transform.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
			minutesObject.transform.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -minutesToDegrees);
			secondsObject.transform.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
			millsecondsObject.transform.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -secondsToDegrees);

			if (debug)
			{
				Debug.DrawLine(hoursObject.transform.position, hoursObject.transform.position + hoursObject.transform.up * 1.5f, Color.yellow);
				Debug.DrawLine(minutesObject.transform.position, minutesObject.transform.position + minutesObject.transform.up * 1.5f, Color.yellow);
				Debug.DrawLine(secondsObject.transform.position, secondsObject.transform.position + secondsObject.transform.up * 1.5f, Color.yellow);
				Debug.DrawLine(millsecondsObject.transform.position, millsecondsObject.transform.position + millsecondsObject.transform.up * 1.5f, Color.red);
			}

		}
	}
}
