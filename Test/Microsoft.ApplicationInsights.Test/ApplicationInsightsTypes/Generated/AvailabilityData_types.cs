
//------------------------------------------------------------------------------
// This code was generated by a tool.
//
//   Tool : Bond Compiler 0.10.0.0
//   File : AvailabilityData_types.cs
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// <auto-generated />
//------------------------------------------------------------------------------


// suppress "Missing XML comment for publicly visible type or member"
#pragma warning disable 1591


#region ReSharper warnings
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
// ReSharper disable UnusedParameter.Local
// ReSharper disable RedundantUsingDirective
#endregion

namespace AI
{
    using System.Collections.Generic;

    [global::Bond.Attribute("Description", "Instances of AvailabilityData represent the result of executing an availability test.")]
    [global::Bond.Schema]
    [System.CodeDom.Compiler.GeneratedCode("gbc", "0.10.0.0")]
    public partial class AvailabilityData
        : Domain
    {
        [global::Bond.Attribute("Description", "Schema version")]
        [global::Bond.Id(10), global::Bond.Required]
        public int ver { get; set; }

        [global::Bond.Attribute("MaxStringLength", "64")]
        [global::Bond.Attribute("Description", "Identifier of a test run. Use it to correlate steps of test run and telemetry generated by the service.")]
        [global::Bond.Attribute("ActAsRequired", "Renaming testRunId to id.")]
        [global::Bond.Id(21), global::Bond.Required]
        public string id { get; set; }

        [global::Bond.Attribute("MaxStringLength", "1024")]
        [global::Bond.Attribute("Description", "Name of the test that these availability results represents.")]
        [global::Bond.Attribute("ActAsRequired", "Renaming testName to name.")]
        [global::Bond.Id(41), global::Bond.Required]
        public string name { get; set; }

        [global::Bond.Attribute("Description", "Duration in TimeSpan 'G' (general long) format: d:hh:mm:ss.fffffff")]
        [global::Bond.Attribute("CSType", "TimeSpan")]
        [global::Bond.Id(50), global::Bond.Required]
        public string duration { get; set; }

        [global::Bond.Attribute("ActAsRequired", "Renaming result to success.")]
        [global::Bond.Attribute("Description", "Success flag.")]
        [global::Bond.Id(61), global::Bond.Required]
        public bool success { get; set; }

        [global::Bond.Attribute("MaxStringLength", "1024")]
        [global::Bond.Attribute("Description", "Name of the location where the test was run from.")]
        [global::Bond.Id(70)]
        public string runLocation { get; set; }

        [global::Bond.Attribute("MaxStringLength", "8192")]
        [global::Bond.Attribute("Description", "Diagnostic message for the result.")]
        [global::Bond.Id(80)]
        public string message { get; set; }

        [global::Bond.Attribute("Description", "Collection of custom properties.")]
        [global::Bond.Attribute("MaxKeyLength", "150")]
        [global::Bond.Attribute("MaxValueLength", "8192")]
        [global::Bond.Id(100), global::Bond.Type(typeof(Dictionary<string, string>))]
        public IDictionary<string, string> properties { get; set; }

        [global::Bond.Attribute("Description", "Collection of custom measurements.")]
        [global::Bond.Attribute("MaxKeyLength", "150")]
        [global::Bond.Id(200), global::Bond.Type(typeof(Dictionary<string, double>))]
        public IDictionary<string, double> measurements { get; set; }

        public AvailabilityData()
            : this("AI.AvailabilityData", "AvailabilityData")
        {}

        protected AvailabilityData(string fullName, string name)
        {
            ver = 2;
            id = "";
            this.name = "";
            duration = "";
            runLocation = "";
            message = "";
            properties = new Dictionary<string, string>();
            measurements = new Dictionary<string, double>();
        }
    }
} // AI
