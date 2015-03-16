namespace Itbudet.Nlg
{
    public interface INlgCreator
    {
        string TransformBasicSentence(string sentence);
        string BasicObjectSubject(SentenceContent sentenceContent);
    }
}