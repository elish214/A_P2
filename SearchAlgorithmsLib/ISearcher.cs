using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Searcher interface.
    /// </summary>
    /// <typeparam name="T"> a generic type to search on. </typeparam>
    public interface ISearcher<T>
    {
        /// <summary>
        /// Searching method. uses on the searchable.
        /// </summary>
        /// <param name="searchable"> search at the searchable </param>
        /// <returns> Returns searchable's solution. </returns>
        Solution<T> Search(ISearchable<T> searchable);

        /// <summary>
        /// returns the number of nodes that been evaluated during the search.
        /// </summary>
        /// <returns> number of nodes that been evaluated during the search. </returns>
        int GetNumberOfNodesEvaluated();
    }
}
