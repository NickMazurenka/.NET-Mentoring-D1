using System;

namespace Task1
{
	public class PersonClass : IEquatable<PersonClass>
	{
		public string FirstName;
		public string LastName;

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;

			return Equals(obj as PersonClass);
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

		public bool Equals(PersonClass p)
		{
			if (ReferenceEquals(p, null)) return false;

			return string.Equals(FirstName, p.FirstName, StringComparison.InvariantCulture)
				&& string.Equals(LastName, p.LastName, StringComparison.InvariantCulture);
		}

		public static bool operator ==(PersonClass left, PersonClass right)
		{
			if (ReferenceEquals(left, null))
				if (ReferenceEquals(right, null))
					return true;
				else
					return false;

			return left.Equals(right);
		}

		public static bool operator !=(PersonClass left, PersonClass right)
		{
			return !(left == right);
		}
	}
}