using System;
using Priority_Queue;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    public abstract class PrioritySearcher<T, S> : Searcher<T>, ISearcher<T> where S : IComparable<S>
    {
        public delegate S Weight(State<T> s1, State<T> s2);
        public delegate S Addition(S cost1, S cost2);

        private SimplePriorityQueue<State<T>, S> openList;
        protected Dictionary<State<T>, S> Cost { get; }
        protected Weight W { get; }
        protected Addition Add { get; }

        public PrioritySearcher(Weight w, Addition add)
        {
            openList = new SimplePriorityQueue<State<T>, S>();
            Cost = new Dictionary<State<T>, S>();
            W = w;
            Add = add;
        }

        protected void AddToOpenList(State<T> s)
        {
            openList.Enqueue(s, Cost[s]);
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
            openList.UpdatePriority(s, Cost[s]);
        }

        protected void Update(State<T> s, State<T> n)
        {
            CameFrom[s] = n;
            Cost[s] = Add(Cost[n], W(n, s));
        }

        protected override void Clear()
        {
            openList.Clear();
            Cost.Clear();
            base.Clear();
        }

        public abstract override Solution<T> Search(ISearchable<T> searchable);

    }
}
