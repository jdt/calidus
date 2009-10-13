#region License
    // <copyright>
    //   Copyright 2009 Jesper De Temmerman 
    //   Licensed under the Apache License, Version 2.0 (the "License"); 
    //   you may not use this file except in compliance with the License. 
    //   You may obtain a copy of the License at
    //
    //   http://www.apache.org/licenses/LICENSE-2.0 
    //
    //   Unless required by applicable law or agreed to in writing, software 
    //   distributed under the License is distributed on an "AS IS" BASIS, 
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    //   See the License for the specific language governing permissions and 
    //   limitations under the License. 
    // </copyright>
#endregion
    
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDT.Calidus.Common.Rules;
using JDT.Calidus.UI.Events;

namespace JDT.Calidus.UI.Model
{
    /// <summary>
    /// This class is an observable rule violation list
    /// </summary>
    public class RuleViolationList : IList<RuleViolation>
    {
        private IList<RuleViolation> _list;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        public RuleViolationList()
        {
            _list = new List<RuleViolation>();
        }

        /// <summary>
        /// Notifies that a violation was added to the list
        /// </summary>
        public event EventHandler<RuleViolationEventArgs> ViolationAdded;
        private void OnViolationAdded(RuleViolation violation)
        {
            if (ViolationAdded != null)
                ViolationAdded(this, new RuleViolationEventArgs(violation));
        }

        /// <summary>
        /// Notifies that a violation was removed from the list
        /// </summary>
        public event EventHandler<RuleViolationEventArgs> ViolationRemoved;
        private void OnViolationRemoved(RuleViolation violation)
        {
            if (ViolationRemoved != null)
                ViolationRemoved(this, new RuleViolationEventArgs(violation));
        }

        #region List members

            public int IndexOf(RuleViolation item)
            {
                return _list.IndexOf(item);
            }

            public void Insert(int index, RuleViolation item)
            {
                _list.Insert(index, item);
                OnViolationAdded(item);
            }

            public void RemoveAt(int index)
            {
                _list.RemoveAt(index);
                OnViolationRemoved(_list[index]);
            }

            public RuleViolation this[int index]
            {
                get
                {
                    return _list[index];
                }
                set
                {
                    _list[index] = value;
                }
            }

            public void Add(RuleViolation item)
            {
                _list.Add(item);
                OnViolationAdded(item);
            }

            public void Clear()
            {
                //do not use the IList clear: every time an object
                //is removed the call to the event might cause a call
                //to count and this result needs to be accurate
                foreach (RuleViolation aViolation in new List<RuleViolation>(_list))
                {
                    _list.Remove(aViolation);
                    OnViolationRemoved(aViolation);
                }
            }

            public bool Contains(RuleViolation item)
            {
                return _list.Contains(item);
            }

            public void CopyTo(RuleViolation[] array, int arrayIndex)
            {
                _list.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return _list.Count; }
            }

            public bool IsReadOnly
            {
                get { return _list.IsReadOnly; }
            }

            public bool Remove(RuleViolation item)
            {
                bool res = _list.Remove(item);
                if (res)
                    OnViolationRemoved(item);

                return res;
            }

            public IEnumerator<RuleViolation> GetEnumerator()
            {
                return _list.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _list.GetEnumerator();
            }

        #endregion
    }
}
