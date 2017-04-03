using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private SimplePriorityQueue<State<T>> openList;
        private int evaluatedNodes;

        public Searcher()
        {
            openList = new SimplePriorityQueue<State<T>>();
            evaluatedNodes = 0;
        }

        protected void AddToOpenList(State<T> s)
        {
            openList.Enqueue(s, (float) s.Cost);
        }

        protected State<T> PopOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();
        }

        // a property of openList
        protected int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        protected bool OpenContains(State<T> s)
        {
            return openList.Contains(s);
        }

        protected State<T> GetOpenElem(State<T> s)
        {
            return openList.Where(elem => elem.Equals(s)).ToList().ElementAt(0);
        }

        protected void UpdatePriority(State<T> s)
        {
            openList.UpdatePriority(s, (float) s.Cost);
        }

        protected Solution<T> BackTrace(State<T> s)
        {
            Solution<T> solution = new Solution<T>();

            while(s != null)
            {
                solution.Add(s);
                s = s.CameFrom;
            }

            return solution;
        }

        // ISearcher’s methods:
        public virtual int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
