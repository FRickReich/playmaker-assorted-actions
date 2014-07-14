// Copyright (c) 2014 F. Rick Reich.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Advanced Actions")]
	[Tooltip("Generates a random name from lists of first and last names.")]
	public class RandomNameGenerator : FsmStateAction
	{

		[RequiredField]
		public TextAsset firstNameListObject;

		public TextAsset lastNameListObject;

		private string firstNameList;

		private string lastNameList;

		public FsmString fistName;

		public FsmString lastName;

		public FsmString fullName;

		public override void Reset()
		{
			firstNameList = null;
			lastNameList = null;
			fistName = null;
			lastName = null;
			fullName = null;
		}

		public override void OnEnter()
		{
			
			GenerateName();
			Finish();
			
		}

		void GenerateName() {

			var firstNameFromFileList = firstNameListObject.text;
			var lastNameFromFileList = lastNameListObject.text;

			string[] firstNameList = firstNameFromFileList.Split(new char[] {'\n'});
			string selectedFirstName = firstNameList[Random.Range(0, firstNameList.Length)];

			string[] lastNameList = lastNameFromFileList.Split(new char[] {'\n'});
			string selectedLastName = lastNameList[Random.Range(0, lastNameList.Length)];

			fistName.Value = selectedFirstName;
			lastName.Value = selectedLastName;
			fullName.Value = selectedFirstName + " " + selectedLastName;

		}

	}
}