using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib.searchers
{
    public class DFS<T> : Searcher<T>, ISearcher<T>
    {
        public override Solution<T> Search(ISearchable<T> searchable)
        {
            AddToOpenList(searchable.GetInitialState());
            HashSet < State<T> > discovered = new HashSet<State<T>>(); // labeled as discovered.
            
            while (OpenListSize > 0)
            {
                State<T> n = PopOpenList();

                if(n.Equals(searchable.GetGoalState())) // got to the goal state.
                {
                    return AllDiscovered(discovered, searchable);
                }

                if (!SetContains(discovered, n)) // not labeled as discovered yet.
                {
                    discovered.Add(n); // label it.
                    List<State<T>> neighbours = searchable.GetAllPossibleStates(n); // get neighbours.

                    foreach(State<T> s in neighbours)
                    {
                        AddToOpenList(s);
                    }
                }
            }

            return null;
        }

        private bool SetContains(HashSet<State<T>> set, State<T> s)
        {
            foreach (State<T> elem in set)
            {
                if (elem.Equals(s))
                {
                    return true;
                }
            }

            return false;
        }

        private Solution<T> AllDiscovered(HashSet<State<T>> set, ISearchable<T> searchable)
        {
            Solution<T> solution = new Solution<T>();

            foreach(State<T> s in set)
            {
                solution.Add(s);
            }

            solution.Add(searchable.GetGoalState());

            return solution;
        }
    }
}
