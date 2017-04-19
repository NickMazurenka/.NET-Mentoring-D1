using System;

namespace Task3
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class CustomDescriptionAttribute : Attribute
	{
		public string Description { get; }

		public CustomDescriptionAttribute(string description)
		{
			Description = description;
		}
	}
}
