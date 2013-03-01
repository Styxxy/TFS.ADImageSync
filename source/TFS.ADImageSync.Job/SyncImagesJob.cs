﻿using System;
using Microsoft.TeamFoundation.Framework.Server;
using muhaha.TFS.Jobs.ImageSync;
using muhaha.Utils.DirectoryServices;

namespace muhaha.TFS.ADImageSync.Job
{
    public class SyncImagesJob : ITeamFoundationJobExtension
    {
        public static readonly Guid JobId = new Guid("66590D0D-3D89-4A04-878A-2204E9077E50");
        public const string JobName = "AD Image Sync Job";

        public TeamFoundationJobExecutionResult Run(TeamFoundationRequestContext requestContext, TeamFoundationJobDefinition jobDefinition, DateTime queueTime, out string resultMessage)
        {
            Func<TeamFoundationIdentity, byte[]> imageProviderFunc = i => ADHelper.GetImageFromAD(i.UniqueName); //todo => getimage from AD Func
            var run = TfsImageUploader.Run(requestContext, imageProviderFunc);
            resultMessage = run.Item2;
            return run.Item1;
        }
    }
}