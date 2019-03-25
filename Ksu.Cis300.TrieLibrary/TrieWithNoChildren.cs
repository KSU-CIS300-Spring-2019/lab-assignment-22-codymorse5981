/* TrieWithNoChildren.cs
 * Author: Cody Morse
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Whether the empty string is stored in the trie rooted at this node
        /// </summary>
        private bool _isEmpty = false;

        /// <summary>
        /// If its the only child.
        /// </summary>

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isEmpty = true;
            }
            else
            {
                return new TrieWithOneChild(s, _isEmpty);
            }
            return this;
        }

        /// <summary>
        /// Determines whether this trie contains the given string.
        /// </summary>
        /// <param name="s">string to see if trie contains it.</param>
        /// <returns>Whether trie contains label</returns>
        public bool Contains(string s)
        {
            if (s != "")
            {
                return _isEmpty;
            }
            return false;
        }
    }
}
