using Penalty.Debugging;

namespace Penalty
{
    public class PenaltyConsts
    {
        public const string LocalizationSourceName = "Penalty";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "30a71a255f6541879aad24befd89b680";
    }
}
