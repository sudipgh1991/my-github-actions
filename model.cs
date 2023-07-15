record GPT(string model, string prompt, int temperature, int max_tokens);

record Choice(string text, int index, string logprobs, string finish_reason);
record Usage(int prompt_tokens, int completion_tokens, int total_tokens);

record Output(
    string id,
    string @object,
    string created,
    string model,
    Choice[] choices,
    Usage usage
);