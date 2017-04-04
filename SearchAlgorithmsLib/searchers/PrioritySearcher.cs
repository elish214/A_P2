using System;
using Priority_Queue;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    public abstract class PrioritySearcher<T> : Searcher<T>, ISearcher<T>
    {
        private SimplePriorityQueue<State<T>> openList;

        public PrioritySearcher()
        {
            openList = new SimplePriorityQueue<State<T>>();
        }

        protected void AddToOpenList(State<T> s)
        {
            openList.Enqueue(s, (float)s.Cost);
        }

        protected State<T> PopOpenList()
        {
            Increase();
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
            openList.UpdatePriority(s, (float)s.Cost);
        }

        public abstract override Solution<T> Search(ISearchable<T> searchable);

    }
}
