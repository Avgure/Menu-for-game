namespace Menu
{
    public interface IGraphicsSettingsCarrier
    {
        public int ChosenVsyncToggleValue
        { get; }
        public int ChosenMaxFPSValue
        { get; }
        public int ChosenQualityLevelValue
        { get; }
    }
}