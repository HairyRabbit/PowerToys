﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Plugin.Folder.Sources;
using Microsoft.Plugin.Folder.Sources.Result;

namespace Microsoft.Plugin.Folder
{
    public class EnvironmentVariableProcessor : IFolderProcessor
    {
        private readonly IQueryEnvironmentVariable _queryEnvironmentVariable;

        public EnvironmentVariableProcessor(IQueryEnvironmentVariable queryEnvironmentVariable)
        {
            _queryEnvironmentVariable = queryEnvironmentVariable;
        }

        public IEnumerable<IItemResult> Results(string actionKeyword, string search)
        {
            if (search == null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            if (!search.StartsWith('%'))
            {
                return Enumerable.Empty<IItemResult>();
            }

            return _queryEnvironmentVariable.Query(search);
        }
    }
}
