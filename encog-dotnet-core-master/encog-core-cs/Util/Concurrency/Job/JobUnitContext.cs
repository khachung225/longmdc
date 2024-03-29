//
// Encog(tm) Core v3.2 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2013 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
using System;

namespace Encog.Util.Concurrency.Job
{
    /// <summary>
    /// Holds basic configuration information for an Encog job.
    /// </summary>
    public class JobUnitContext
    {
        /// <summary>
        /// The JobUnit that this context will execute.
        /// </summary>
        public Object JobUnit { get; set; }

        /// <summary>
        /// The owner of this job.
        /// </summary>
        public ConcurrentJob Owner { get; set; }


        /// <summary>
        /// The task number.
        /// </summary>
        public int TaskNumber { get; set; }
    }
}
