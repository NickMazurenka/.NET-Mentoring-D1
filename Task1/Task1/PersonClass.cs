namespace Task1
{
	public class PersonClass
	{
		public string FirstName;
		public string LastName;

		public override bool Equals(object obj)
		{
			var person = obj as PersonClass;

			return person != null && Equals(person);
		}

		// GetHashCode implementation:
		//http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
		public override int GetHashCode()
		{
			unchecked
			{
				return ((FirstName?.GetHashCode() ?? 0) * 486187739) ^ (LastName?.GetHashCode() ?? 0);
			}
		}

		private bool Equals(PersonClass p)
		{
			return FirstName == p.FirstName && LastName == p.LastName;
		}
	}
}