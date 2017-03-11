namespace T4.Console
{
    public interface ISpeech
    {
        string ToText();
        void FromText(string message);
    }
}
