﻿using System;
using System.Windows.Forms;
using EVEMon.Common.Helpers;

namespace EVEMon.Common.Threading
{
    /// <summary>
    /// A timer based on a window forms timer.
    /// </summary>
    public sealed class UIActorTimer : IActorTimer
    {
        private readonly Timer m_timer;
        private readonly Action m_callback;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="period">The period.</param>
        /// <param name="start">if set to <c>true</c> [start].</param>
        internal UIActorTimer(Action callback, int period, bool start)
        {
            m_callback = callback;

            m_timer = new Timer();
            m_timer.Tick += m_timer_Tick;
            m_timer.Interval = period;
            if (start)
                m_timer.Start();
        }

        /// <summary>
        /// On every tick, invokes the callback.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                m_callback();
            }
            catch (ObjectDisposedException exc)
            {
                ExceptionHandler.LogException(exc, true);
            }
            catch (AccessViolationException exc)
            {
                ExceptionHandler.LogException(exc, true);
            }
        }

        /// <summary>
        /// Gets or sets the timer's period, in milliseconds.
        /// </summary>
        public int Period
        {
            get { return m_timer.Interval; }
            set { m_timer.Interval = value; }
        }

        /// <summary>
        /// Starts or resumes the timer.
        /// </summary>
        public void Start()
        {
            m_timer.Start();
        }

        /// <summary>
        /// Pauses the timer, it will be resumable with <see cref="Start"/>.
        /// </summary>
        public void Stop()
        {
            m_timer.Stop();
        }

        /// <summary>
        /// Dispose the timer
        /// </summary>
        public void Dispose()
        {
            m_timer.Dispose();
        }
    }
}