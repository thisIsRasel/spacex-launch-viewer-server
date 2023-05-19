﻿using LanguageExt.Common;
using SpaceXLaunchViewer.Core.QueryModels;
using SpaceXLaunchViewer.Core.ResponseModels;

namespace SpaceXLaunchViewer.Core.Interfaces;
public interface ISpaceXApiClient
{
    Task<Result<IEnumerable<Launch>?>> GetPastLaunchesAsync(LaunchQuery query);
}