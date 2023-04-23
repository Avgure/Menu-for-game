namespace Menu
{
    public interface IScreenSettingsCarrier
    {
        public int ChosenScreenModeIndex
        { get; }
        public int ChosenResolutionSimpleIndex
        { get; }
        public int ChosenRefreshRateIndex
        { get; }
    }
}