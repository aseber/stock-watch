using Newtonsoft.Json;
using System;

namespace stock_libs
{
    public class ChartResponse
    {
        /// <summary>
        ///     The time at which this quote was captured from the market.
        /// </summary>
        [JsonIgnore]
        public DateTime Timestamp => GetTimestamp(_dateComponent, _timeComponent);

        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
        private string _dateComponent { get; set; }

        [JsonProperty(PropertyName = "minute", NullValueHandling = NullValueHandling.Ignore)]
        private string _timeComponent { get; set; }

        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        private string label { get; set; }

        [JsonProperty(PropertyName = "high", NullValueHandling = NullValueHandling.Ignore)]
        public double High { get; set; }

        [JsonProperty(PropertyName = "low", NullValueHandling = NullValueHandling.Ignore)]
        public double Low { get; set; }

        [JsonProperty(PropertyName = "average", NullValueHandling = NullValueHandling.Ignore)]
        public double Average { get; set; }

        [JsonProperty(PropertyName = "volume", NullValueHandling = NullValueHandling.Ignore)]
        public int Volume { get; set; }

        [JsonProperty(PropertyName = "notional", NullValueHandling = NullValueHandling.Ignore)]
        public double Notional { get; set; }

        [JsonProperty(PropertyName = "numberOfTrades", NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfTrades { get; set; }

        [JsonProperty(PropertyName = "marketHigh", NullValueHandling = NullValueHandling.Ignore)]
        public double MarketHigh { get; set; }

        [JsonProperty(PropertyName = "marketLow", NullValueHandling = NullValueHandling.Ignore)]
        public double MarketLow { get; set; }

        [JsonProperty(PropertyName = "marketAverage", NullValueHandling = NullValueHandling.Ignore)]
        public double MarketAverage { get; set; }

        [JsonProperty(PropertyName = "marketVolume", NullValueHandling = NullValueHandling.Ignore)]
        public int MarketVolume { get; set; }

        [JsonProperty(PropertyName = "marketNotional", NullValueHandling = NullValueHandling.Ignore)]
        public double MarketNotional { get; set; }

        [JsonProperty(PropertyName = "marketNumberOfTrades", NullValueHandling = NullValueHandling.Ignore)]
        public int MarketNumberOfTrades { get; set; }

        [JsonProperty(PropertyName = "open", NullValueHandling = NullValueHandling.Ignore)]
        public double Open { get; set; }

        [JsonProperty(PropertyName = "close", NullValueHandling = NullValueHandling.Ignore)]
        public double Close { get; set; }

        [JsonProperty(PropertyName = "marketOpen", NullValueHandling = NullValueHandling.Ignore)]
        public double MarketOpen { get; set; }

        [JsonProperty(PropertyName = "marketClose", NullValueHandling = NullValueHandling.Ignore)]
        public double MarketClose { get; set; }

        [JsonProperty(PropertyName = "changeOverTime", NullValueHandling = NullValueHandling.Ignore)]
        public double? ChangeOverTime { get; set; }

        [JsonProperty(PropertyName = "marketChangeOverTime", NullValueHandling = NullValueHandling.Ignore)]
        public double MarketChangeOverTime { get; set; }

        private DateTime GetTimestamp(string date, string time)
        {
            var formattedDate = $"{date.Substring(0, 4)} {date.Substring(4, 2)} {date.Substring(6, 2)}";
            return DateTime.Parse($"{formattedDate} {time}");
        }
    }
}
