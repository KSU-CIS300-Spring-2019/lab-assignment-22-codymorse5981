/* TrieWithOneChild.cs
 * Author: Cody Morse
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Whether the trie contains the empty string
        /// </summary>
        private bool _isEmpty;

        /// <summary>
        /// If its the only child.
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// The childs label
        /// </summary>
        private char _label;

        public TrieWithOneChild (string s, bool isEmpty)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            { 
                throw new ArgumentException();
            }
            _isEmpty = isEmpty;
            _child = new TrieWithNoChildren().Add(s.Substring(1));
            _label = s[0]; 

        }

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
            else if (_isEmpty == false && s[0] == _label)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else if (_isEmpty == false && s[0] != _label)
            {
                return new TrieWithManyChildren(s, _isEmpty, _label, this);
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
            if (s == "")
            {
                return _isEmpty;
            }
            else if (s[0] == _label)
            {
                _child.Contains(s.Substring(1, 1));
                return true;
            }
            
            else
            {

                return false;
            }
        }
    }
}
