// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using Monitor = System.Threading.Monitor;

namespace SubSystem.Threading
{
    // This class provides implementation of uninterruptible lock for internal
    // use by thread pool.
    internal class LowLevelLock : System.IDisposable
    {
        public void Dispose()
        {
        }

        public bool TryAcquire()
        {
            /*bool lockTaken = false;
            Monitor.try_enter_with_atomic_var(this, 0, false, ref lockTaken);*/
            return /*lockTaken*/Monitor.TryEnter(this, 0);
        }

        public void Acquire()
        {
            /*bool lockTaken = false;
            Monitor.try_enter_with_atomic_var(this, System.Threading.Timeout.Infinite, false, ref lockTaken);*/
            Monitor.Enter(this);
        }

        public void Release()
        {
            Monitor.Exit(this);
        }

        [Conditional("DEBUG")]
        public void VerifyIsLocked()
        {
            Debug.Assert(Monitor.IsEntered(this));
        }
    }
}
