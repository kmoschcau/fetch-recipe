using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FetchRecipe.Data
{
    public sealed partial class Iso8601DurationJsonConverter : JsonConverter<TimeSpan?>
    {
        public static readonly Regex YearMonthDurationRegex = CreateYearMonthDurationRegex();
        public static readonly Regex WeeksDurationRegex = CreateWeeksDurationRegex();
        public static readonly Regex ExtractionRegex = CreateExtractionRegex();

        private const string DaysName = "days";
        private const string HoursName = "hours";
        private const string MinutesName = "minutes";
        private const string SecondsName = "seconds";

        [GeneratedRegex(@"P.*?\d+[YM].*?T")]
        private static partial Regex CreateYearMonthDurationRegex();

        [GeneratedRegex(@"P\d+W")]
        private static partial Regex CreateWeeksDurationRegex();

        [GeneratedRegex(
            $@"P(?:(?<{DaysName}>\d+)D)?T(?:(?<{HoursName}>\d+)H)?(?:(?<{MinutesName}>\d+)M)?(?:(?<{SecondsName}>\d+)S)?"
        )]
        private static partial Regex CreateExtractionRegex();

        public static TimeSpan? Parse(string? text)
        {
            if (text is null)
            {
                return null;
            }

            Match match = ExtractionRegex.Match(text);

            return match.Success
                ? new TimeSpan(
                    int.TryParse(
                        match.Groups[DaysName].Value,
                        CultureInfo.InvariantCulture,
                        out int days
                    )
                        ? days
                        : 0,
                    int.TryParse(
                        match.Groups[HoursName].Value,
                        CultureInfo.InvariantCulture,
                        out int hours
                    )
                        ? hours
                        : 0,
                    int.TryParse(
                        match.Groups[MinutesName].Value,
                        CultureInfo.InvariantCulture,
                        out int minutes
                    )
                        ? minutes
                        : 0,
                    int.TryParse(
                        match.Groups[SecondsName].Value,
                        CultureInfo.InvariantCulture,
                        out int seconds
                    )
                        ? seconds
                        : 0
                )
                : null;
        }

        public static string? Format(TimeSpan? nullableTimeSpan)
        {
            if (nullableTimeSpan is TimeSpan timeSpan)
            {
                StringBuilder builder = new StringBuilder("P");

                if (timeSpan.Days > 0)
                {
                    builder.Append(timeSpan.Days).Append("D");
                }

                builder.Append("T");

                if (timeSpan.Hours > 0)
                {
                    builder.Append(timeSpan.Hours).Append("H");
                }

                if (timeSpan.Minutes > 0)
                {
                    builder.Append(timeSpan.Minutes).Append("M");
                }

                if (timeSpan.Seconds > 0)
                {
                    builder.Append(timeSpan.Seconds).Append("S");
                }
                return builder.ToString();
            }

            return null;
        }

        public override TimeSpan? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            string? text = reader.GetString();

            if (text is null)
            {
                return null;
            }

            if (YearMonthDurationRegex.IsMatch(text))
            {
                throw new NotSupportedException("Year or month durations are not supported.");
            }

            if (WeeksDurationRegex.IsMatch(text))
            {
                throw new NotSupportedException("Week durations are not supported.");
            }

            return Parse(reader.GetString());
        }

        public override void Write(
            Utf8JsonWriter writer,
            TimeSpan? value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(Format(value));
        }
    }
}
