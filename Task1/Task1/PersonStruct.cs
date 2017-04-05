using System;

namespace Task1
{
	public struct PersonStruct : IEquatable<PersonStruct>
	{
		public string FirstName;
		public string LastName;

		public override bool Equals(object obj)
		{
			if (obj is PersonStruct == false) return false;

			var p = (PersonStruct) obj;

			return Equals(p);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((FirstName?.GetHashCode() ?? 0) * 486187739) ^ (LastName?.GetHashCode() ?? 0);
			}
		}

		public bool Equals(PersonStruct p)
		{
			return string.Equals(FirstName, p.FirstName, StringComparison.InvariantCulture)
				&& string.Equals(LastName, p.LastName, StringComparison.InvariantCulture);
		}

		public static bool operator ==(PersonStruct left, PersonStruct right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(PersonStruct left, PersonStruct right)
		{
			return !(left == right);
		}
	}
}
