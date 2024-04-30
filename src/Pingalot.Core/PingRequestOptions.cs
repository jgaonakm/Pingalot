using System;

namespace Pingalot;

public class PingRequestOptions
{
	public string Label { get; set; }
	public string Address { get; init; }
	public TimeSpan PingTimeout { get; init; }
	public int BufferSize { get; init; }
	public int TimeTolive { get; init; }
	public TimeSpan DelayBetweenPings { get; init; }
	public int NumberOfPings { get; init; }
}
