using System;
using Priority_Queue;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    /// <summary>
    /// Priority Searcher abstract class.
    /// </summary>
    /// <typeparam name="T"> a generic type to search on. </typeparam>
    /// <typeparam name="S"> a generic type to compare with. </typeparam>
    public abstract class PrioritySearcher<T, S> : Searcher<T>, ISearcher<T> where S : IComparable<S>
    {
        /// <summary>
        /// Returns the weight between two states.
        /// </summary>
        /// <param name="s1"> a state. </param>
        /// <param name="s2"> another state. </param>
        /// <returns> weight between two states. </returns>
        public delegate S Weight(State<T> s1, State<T> s2);

        /// <summary>
        /// Returns the result of an addition between two costs.
        /// </summary>
        /// <param name="cost1"> a cost. </param>
        /// <param name="cost2"> another cost. </param>
        /// <returns> result of an addition between two costs. </returns>
        public delegate S Addition(S cost1, S cost2);

        /// <summary>
        /// Holds a priority queue to use it in search.
        /// </summary>
        private SimplePriorityQueue<State<T>, S> openList;
        
        /// <summary>
        /// Holds a dictionary of states to their current costs.
        /// </summary>
        protected Dictionary<State<T>, S> Cost { get; }

        /// <summary>
        /// A weight function.
        /// </summary>
        protected Weight W { get; }

        /// <summary>
        /// An addition function.
        /// </summary>
        protected Addition Add { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="w"> A weight function. </param>
        /// <param name="add">  An addition function. </param>
        public PrioritySearcher(Weight w, Addition add)
        {
            openList = new SimplePriorityQueue<State<T>, S>();
            Cost = new Dictionary<State<T>, S>();
            W = w;
            Add = add;
        }

        /// <summary>
        /// Add a state to the priority queue.
        /// </summary>
        /// <param name="s"> a state to add. </param>
        protected void AddToOpenList(State<T> s)
        {
            openList.Enqueue(s, Cost[s]);
        }

        /// <summary>
        /// Pop out a state from priority queue.
        /// </summary>
        /// <returns> the top state in the queue. </returns>
        protected State<T> PopOpenList()
        {
            Increase();
            return openList.Dequeue();
        }

        /// <summary>
        /// A property of openList
        /// </summary>
        protected int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        /// <summary>
        /// Checks whether the queue contains a state or not.
        /// </summary>
        /// <param name="s"> a specific state. </param>
        /// <returns>  whether the queue contains the state or not. </returns>
        protected bool OpenContains(State<T> s)
        {
            return openList.Contains(s);
        }

        /// <summary>
        /// Returns a specific state's element in the queue.
        /// </summary>
        /// <param name="s"> a specific state. </param>
        /// <returns> the state's element in the queue. </returns>
        protected State<T> GetOpenElem(State<T> s)
        {
            return openList.Where(elem => elem.Equals(s)).ToList().ElementAt(0);
        }

        /// <summary>
        /// Updates state's priority in th queue.
        /// </summary>
        /// <param name="s"> a specific state. </param>
        protected void UpdatePriority(State<T> s)
        {
            openList.UpdatePriority(s, Cost[s]);
        }

        /// <summary>
        /// Update state's details.
        /// </summary>
        /// <param name="s"> a state. </param>
        /// <param name="n"> another state. </param>
        protected void Update(State<T> s, State<T> n)
        {
            CameFrom[s] = n;
            Cost[s] = Add(Cost[n], W(n, s));
        }

        /// <summary>
        /// Clears both priority queue and dictionary. also calls base's clear.
        /// </summary>
        protected override void Clear()
        {
            openList.Clear();
            Cost.Clear();
            base.Clear();
        }

        /// <summary>
        /// Searching method. uses on the searchable.
        /// </summary>
        /// <param name="searchable"> search at the searchable </param>
        /// <returns> Returns searchable's solution. </returns>
        public abstract override Solution<T> Search(ISearchable<T> searchable);

    }
}
