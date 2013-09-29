namespace GitFlowVersion
{
    using System.Linq;

    public class MergeMessageParser
    {
        public static bool TryParse(string message, out string versionPart)
        {
            versionPart = null;
            string trimmed;
            if (message.StartsWith("Merge branch 'hotfix-"))
            {
                trimmed = message.Replace("Merge branch 'hotfix-", "");
            }
            else if (message.StartsWith("Merge branch 'release-"))
            {
                trimmed = message.Replace("Merge branch 'release-", "");
            }
            else if (message.StartsWith("Merge branch '"))
            {
                trimmed = message.Replace("Merge branch '", "");
                if (!char.IsNumber(trimmed.First()))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            trimmed = trimmed.TrimNewLines();
            if (!trimmed.EndsWith("'"))
            {
                return false;
            }
            versionPart = trimmed.TrimEnd('\'');
            return true;
        }

    }
}