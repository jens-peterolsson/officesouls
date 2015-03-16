using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simplenlg.framework;
using simplenlg.lexicon;
using simplenlg.realiser.english;

namespace Itbudet.Nlg
{
    public class NlgCreator : INlgCreator
    {
        private static NLGFactory _nlgFactory;
        private static Realiser _realiser;

        private NlgCreator()
        {
            var lexicon = Lexicon.getDefaultLexicon();
            _nlgFactory = new NLGFactory(lexicon);
            _realiser = new Realiser(lexicon);
        }

        private static INlgCreator _instance;
        public static INlgCreator Instance
        {
            get { return _instance ?? new NlgCreator(); }
            set { _instance = value; }
        }

        public string TransformBasicSentence(string sentence)
        {
            var nlgSentence = _nlgFactory.createSentence(sentence);
            var result = _realiser.realiseSentence(nlgSentence);
            return result;
        }

        public string BasicObjectSubject(SentenceContent sentenceContent)
        {
            var clause = _nlgFactory.createClause();
            var verb = _nlgFactory.createVerbPhrase(sentenceContent.Verb);
            var how = _nlgFactory.createAdjectivePhrase(sentenceContent.IndirectObject);
            var subject = _nlgFactory.createNounPhrase(sentenceContent.SentenceSubject);
            var subjectObject = _nlgFactory.createNounPhrase(sentenceContent.SentenceObject);

            clause.setSubject(subject);
            clause.setVerb(verb);
            clause.setObject(subjectObject);
            clause.setIndirectObject(how);
            clause.addComplement(sentenceContent.Complement);

            var result = _realiser.realiseSentence(clause);
            return result;
        }

    }
}
