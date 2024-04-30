﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pingalot;
internal class PingArguments
{
	[Usage(ApplicationAlias = "pingstats")]
	public static IEnumerable<Example> Examples => new[]
	{
			new Example("Ping an IP Address until cancelled", new PingArguments
			{
				TargetName = "1.1.1.1",
				PingUntilStopped = true
			}),
			new Example("Ping a hostname eight (8) times", new PingArguments
			{
				TargetName = "github.com",
				NumberOfPings = 8
			})
		};

	[Value(0, Required = true, HelpText = "IP address or hostname of the target", MetaName = "Target Name", MetaValue = "<IP or Hostname>")]
	public string TargetName { get; set; }

	[Option('t', HelpText = "Ping the specified host until stopped.\nTo stop - type Control-C.", Default = false)]
	public bool PingUntilStopped { get; set; }

	[Option('n', HelpText = "Number of echo requests to send.", MetaValue = "count", Default = 4)]
	public int NumberOfPings { get; set; }

	[Option('l', HelpText = "Send buffer size.", MetaValue = "size", Default = 32)]
	[Range(1, 65527)]
	public int BufferSize { get; set; }

	[Option('i', HelpText = "Time To Live.", MetaValue = "TTL", Default = 255)]
	public int TimeToLive { get; set; }

	[Option('w', HelpText = "Timeout to wait for each reply (in milliseconds).", MetaValue = "timeout", Default = 4000)]
	public int PingTimeoutInMilliseconds { get; set; }

	[Option('b', HelpText = "Timeout between each ping (in milliseconds)", MetaValue = "timeout", Default = 500)]
	public int BreakBetweenPingsInMilliseconds { get; set; }

	[Option("layout", HelpText = "The display layout.\n1. Traditional\n2. Modern", Default = 2)]
	public int Layout { get; set; }

	[Option("export", HelpText = "The file to export the results to. Data is saved as a CSV.")]
	public string ExportLocation { get; set; }

	[Option("label", HelpText = "The label to group the data when sumarizing multiple executions")]
	public string Label { get; set; }

	public TimeSpan PingTimeout => new TimeSpan(0, 0, 0, 0, PingTimeoutInMilliseconds);
	public TimeSpan BreakBetweenPings => new TimeSpan(0, 0, 0, 0, BreakBetweenPingsInMilliseconds);
}
