//
// User.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using System.Collections.Generic;

namespace ProjectX
{
	public class UserModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public UserModel(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
		static public List<UserModel> Samples()
		{
			var list = new List<UserModel> {
				new UserModel("Don", "Joe"),
				new UserModel("Don", "Jane"),
				new UserModel("Doe", "Jane"),
				new UserModel("Doe", "John"),
				new UserModel("Sample", "John"),
			};
			return list;

		}


	}
}

