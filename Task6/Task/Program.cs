// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

// See the ReadMe.html for additional information
namespace Task
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			var harnesses = new List<SampleHarness>();
			
			harnesses.Add(new LinqSamples());
            harnesses.Add(new TaskSamples());
						
			Application.EnableVisualStyles();
				
			using (SampleForm form = new SampleForm("HomeWork", harnesses))
			{
				form.ShowDialog();
			}
		}
	}
}