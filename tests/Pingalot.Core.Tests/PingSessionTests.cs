using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using System.Net;
using System.Collections.Generic;

namespace Pingalot.Core.Tests
{
	[TestClass]
	public class PingSessionTests
	{
		[TestMethod]
		public void TestPingStatisticsDivideByZero()
		{
			// https://github.com/TurnerSoftware/Pingalot/issues/10

			var pingRequests = new List<PingRequest>();

			var startTime = new DateTime(2022, 5, 19, 14, 30, 0);
			var duration = TimeSpan.FromSeconds(30);
			var endTime = startTime.Add(duration);


			var pingRequest = new PingRequest
			{
				Address = IPAddress.Loopback,
				Status = IPStatus.TimedOut,
				RoundtripTime = 0,
				TimeToLive = 0,
				BufferLength = 0,
				HasMatchingBuffer = false,
				RequestTime = DateTime.Now
			};

			pingRequests.Add(pingRequest);

			var testPingSession = new PingSession(startTime, endTime, duration, pingRequests);

			Assert.AreEqual(testPingSession.AverageRoundtrip, 0, "If PacketsReceived is 0, when we attempt to calculate AverageRoundTrip we may trigger a divide by zero exception.");
		}
	}
}