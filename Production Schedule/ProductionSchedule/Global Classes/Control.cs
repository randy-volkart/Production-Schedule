using System;

namespace ProductionSchedule.Globals
{
    /*
     * A collection of properties used to control work flow.
     */
    /// <summary>
    /// A collection of properties used to control work flow.
    /// </summary>
    public static class Control
    {
        // The various states a Production Schedule form may be in.
        /// <value>The various states a Production Schedule form may be in.</value>
        public enum State { Initialize, New, Active, Changed, Open, Copy, Update, Delete, Completed, Error };

        // The different status values a Production Schedule object may have.
        /// <value>The different status values a Production Schedule object may have.</value>
        public enum Status { Okay, Issued, UnIssued, Cancelled, Completed };
    }
}
