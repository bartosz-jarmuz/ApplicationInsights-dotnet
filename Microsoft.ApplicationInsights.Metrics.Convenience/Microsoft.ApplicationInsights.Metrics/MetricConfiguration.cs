﻿using System;
using Microsoft.ApplicationInsights.Metrics.Extensibility;
using System.Threading;

namespace Microsoft.ApplicationInsights.Metrics
{
    /// <summary>
    /// 
    /// </summary>
    public static class MetricConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public static class Defaults
        {
            private static int s_seriesCountLimit = 1000;
            private static int s_valuesPerDimensionLimit = 100;

            internal static readonly TimeSpan NewSeriesCreationTimeout = TimeSpan.FromMilliseconds(10);
            internal static readonly TimeSpan NewSeriesCreationRetryDelay = TimeSpan.FromMilliseconds(1);

            /// <summary>
            /// 
            /// </summary>
            public static int SeriesCountLimit
            {
                get
                {
                    return s_seriesCountLimit;
                }

                set
                {
                    if (value < 2)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(SeriesCountLimit)} may not be < 2.");
                    }

                    Interlocked.Exchange(ref s_seriesCountLimit, value);    // benign race;
                    MetricConfiguration.ReInitialize();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public static int ValuesPerDimensionLimit
            {
                get
                {
                    return s_valuesPerDimensionLimit;
                }

                set
                {
                    if (value < 2)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(SeriesCountLimit)} may not be < 2.");
                    }

                    Interlocked.Exchange(ref s_valuesPerDimensionLimit, value);    // benign race;
                    MetricConfiguration.ReInitialize();
                }
            }
        }   // public static class Defaults

        private static IMetricConfiguration s_simpleUIntMeasurement;
        private static IMetricConfiguration s_simpleDoubleMeasurement;
        private static IMetricConfiguration s_simpleUIntLifetimeCounter;

        static MetricConfiguration()
        {
            ReInitialize();
        }

        private static void ReInitialize()
        {
            s_simpleUIntMeasurement     = new SimpleMeasurementMetricConfiguration(Defaults.SeriesCountLimit,
                                                                                   Defaults.ValuesPerDimensionLimit,
                                                                                   Defaults.NewSeriesCreationTimeout,
                                                                                   Defaults.NewSeriesCreationRetryDelay,
                                                                                   new SimpleMeasurementMetricSeriesConfiguration(lifetimeCounter: false,
                                                                                                                                  supportDoubleValues: false));

            s_simpleDoubleMeasurement   = new SimpleMeasurementMetricConfiguration(Defaults.SeriesCountLimit,
                                                                                   Defaults.ValuesPerDimensionLimit,
                                                                                   Defaults.NewSeriesCreationTimeout,
                                                                                   Defaults.NewSeriesCreationRetryDelay,
                                                                                   new SimpleMeasurementMetricSeriesConfiguration(lifetimeCounter: false,
                                                                                                                                  supportDoubleValues: true));

            s_simpleUIntLifetimeCounter = new SimpleMeasurementMetricConfiguration(Defaults.SeriesCountLimit,
                                                                                   Defaults.ValuesPerDimensionLimit,
                                                                                   Defaults.NewSeriesCreationTimeout,
                                                                                   Defaults.NewSeriesCreationRetryDelay,
                                                                                   new SimpleMeasurementMetricSeriesConfiguration(lifetimeCounter: true,
                                                                                                                                  supportDoubleValues: false));
        }


        /// <summary>
        /// 
        /// </summary>
        public static IMetricConfiguration Default { get { return SimpleUIntMeasurement; } }

        /// <summary>
        /// 
        /// </summary>
        public static IMetricConfiguration SimpleUIntMeasurement { get { return s_simpleUIntMeasurement; } }

        /// <summary>
        /// 
        /// </summary>
        public static IMetricConfiguration SimpleDoubleMeasurement { get { return s_simpleUIntMeasurement; } }

        /// <summary>
        /// 
        /// </summary>
        public static IMetricConfiguration SimpleUIntLifetimeCounter { get { return s_simpleUIntMeasurement; } }
    }
}
