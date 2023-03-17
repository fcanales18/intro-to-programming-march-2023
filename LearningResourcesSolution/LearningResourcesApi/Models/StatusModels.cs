﻿namespace LearningResourcesApi.Models;

//Status is always "Normal", "Degraded", "OnFire"
public enum StatusLevel { Normal, Degraded, OnFire }
public record StatusResponse(StatusLevel status, DateTime lastOutage, List<DateTime> upcomingOutages, StatusHelpInfo ForHelp); 
public record StatusHelpInfo(string Contact, Dictionary<string, string> contactInfo);
