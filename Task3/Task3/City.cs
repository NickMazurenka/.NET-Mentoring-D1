using System.ComponentModel;

namespace Task3
{
	enum City
	{
		[Description("The one with Big Ben tower")]
		London,
		[Description("The one with big park")]
		NewYork,
		[Description("The one with National Library")]
		Minsk
	}

	enum CustomCity
	{
		[CustomDescription("The one with Big Ben tower")]
		London,
		[CustomDescription("The one with big park")]
		NewYork,
		[CustomDescription("Where I leave it up")]
		[CustomDescription("The one with National Library")]
        Minsk
	}
}
