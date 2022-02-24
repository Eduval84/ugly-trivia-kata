using System.Collections.Generic;

namespace Trivia
{
    public class Questions
    {
        public Questions()
        {
        }
        public LinkedList<string> PopQuestions { get; } = new LinkedList<string>();
        public LinkedList<string> ScienceQuestions { get; } = new LinkedList<string>();
        public LinkedList<string> SportsQuestions { get; } = new LinkedList<string>();
        public LinkedList<string> RockQuestions { get; } = new LinkedList<string>();
    }
}