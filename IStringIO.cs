namespace Labb_MongoDB;

internal interface IStringIO
{
    public string GetString();
    public int ParseInput(string input);
    public void PrintString(string output);
    public void PrintPrompt(string output);
    public void Exit();
}