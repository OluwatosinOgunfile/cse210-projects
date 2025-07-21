public class PromptGenerator
{
    public static string[] _questions = {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "How did you see the hand of the Lord in your life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do over today, what would it be?",
        "What new goals are you planning on setting as a result of today's activities?",
        "What insights did you gain from studying the Gospel today?",
        "What impressions came into your mind as you prayed?",
        "What good counsel did you give someone today?",
        "Who do you feel the need to help today, tomorrow, or soon?"
    };
    public List<string> _prompts = new List<string>(_questions);

    public PromptGenerator()
    {

    }
    public string GetRandomPrompt()
    {
        var random = new Random();
        int index = random.Next(_prompts.Count);
        string jrnlPrompt = _prompts[index];
        return jrnlPrompt;
    }
}