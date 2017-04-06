using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private int evaluatedNodes;

        public Searcher()
        {
            evaluatedNodes = 0;
        }

        public void Increase()
        {
            evaluatedNodes++;
        }

        // ISearcher’s methods:
        public int GetNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        protected Solution<T> BackTrace(State<T> s)
        {
            Solution<T> solution = new Solution<T>();           

            while (s != null)
            {
                solution.Add(s);
                s = s.CameFrom;
            }

            return solution;
        }

        public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
