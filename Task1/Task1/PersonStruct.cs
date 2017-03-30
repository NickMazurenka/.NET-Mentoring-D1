namespace Task1
{
	public struct PersonStruct
	{
		public string FirstName;
		public string LastName;

		// Can't override Equals without boxing operation
		// http://stackoverflow.com/questions/10390782/why-cant-we-override-equals-in-a-value-type-without-boxing
		public override bool Equals(object obj)
		{
			if (obj is PersonStruct == false) return false;

			var p = (PersonStruct) obj;

			return Equals(p);
		}

		public bool Equals(PersonStruct p)
		{
			return FirstName == p.FirstName && LastName == p.LastName;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((FirstName?.GetHashCode() ?? 0) * 486187739) ^ (LastName?.GetHashCode() ?? 0);
			}
		}
	}
}
