using System;

namespace provider.Domain.Models;

public class LinkOrigin
{
	public string Origin { get; set; }
	public List<LinkLocation> Locations { get; set; }
}
