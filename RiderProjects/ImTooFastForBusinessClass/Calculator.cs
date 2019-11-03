// ReSharper disable once IdentifierTypo
namespace BusinessClassTypingTimerCalculato
{
    public class Calculator
    {
        public static double InputTimeMinutes;
        public static double InputTimeSeconds;
        public static double Words;
        private double _totalSeconds;
        private double _wordsPerSecond;
        // ReSharper disable once InconsistentNaming
        public static double WPM; 
        

        public void DoCalculate()
        {
            // Calculates the total seconds, then calculates words per second, then multiplies by 60 to get words per minute.
            _totalSeconds = InputTimeMinutes * 60;
            _totalSeconds += InputTimeSeconds;
            _wordsPerSecond = Words / _totalSeconds;

            WPM = _wordsPerSecond * 60;
        }
    }
}