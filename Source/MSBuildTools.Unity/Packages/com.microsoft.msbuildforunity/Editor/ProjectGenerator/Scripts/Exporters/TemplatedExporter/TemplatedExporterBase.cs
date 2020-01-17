﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using Microsoft.Build.Unity.ProjectGeneration.Templates;
using System.IO;

namespace Microsoft.Build.Unity.ProjectGeneration.Exporters.TemplatedExporter
{
    /// <summary>
    /// Base class for file based exporters.
    /// </summary>
    internal class TemplatedExporterBase : TemplatedExporterPart
    {
        private readonly FileTemplate templateFile;
        private readonly FileInfo exportPath;

        protected TemplatedExporterBase(FileTemplate templateFile, FileInfo exportPath)
            : base(templateFile.Root, templateFile.Root.CreateReplacementSet())
        {
            this.templateFile = templateFile;
            this.exportPath = exportPath;
        }

        /// <summary>
        /// Writes out the template data.
        /// </summary>
        public void Write()
        {
            // Ensure the parent directories are created
            Directory.CreateDirectory(exportPath.Directory.FullName);

            templateFile.Write(exportPath.FullName, replacementSet);
        }
    }
}
#endif