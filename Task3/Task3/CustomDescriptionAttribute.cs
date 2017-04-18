using System;

namespace Task3
{
	public class CustomDescriptionAttribute : Attribute
	{
		public string Description { get; }

		public CustomDescriptionAttribute(string description)
		{
			Description = description;
		}
	}
}
