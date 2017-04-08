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
        protected HashSet<State<T>> Closed { get; }
        protected Dictionary<State<T>, State<T>> CameFrom { get; }

        public Searcher()
        {
            evaluatedNodes = 0;
            Closed = new HashSet<State<T>>();
            CameFrom = new Dictionary<State<T>, State<T>>();
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

            while (CameFrom.Keys.Contains(s))
            {
                solution.Add(s);
                s = CameFrom[s];
            }

            return solution;
        }

        protected virtual void Clear()
        {
            CameFrom.Clear();
            Closed.Clear();
        }

        public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
