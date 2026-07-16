using System.Text.RegularExpressions;

namespace InterManagement.Application.Features.Feedbacks
{

    public static class FeedbackMessageCleaner
    {
        private static readonly Regex LegacyTagPattern =
            new(@"^\[(STAGIAIRE|MENTOR):\d+\]\s*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static string Clean(string message)
        {
            if (string.IsNullOrEmpty(message))
                return message;

            return LegacyTagPattern.Replace(message, string.Empty);
        }
    }
}
