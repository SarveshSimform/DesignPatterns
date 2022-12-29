using System;
using System.Threading.Tasks;

using Sleeksoft.CB.Exceptions;
using Sleeksoft.CB.Commands;

namespace Sleeksoft.CB.States
{
    #pragma warning disable CS1998     
    internal class StateOpen : ICircuitState, IDisposable
    {
        private const string TYPE_NAME = "StateOpen";

        private readonly ICircuit m_Circuit;
        private readonly ICommand m_Command;
        private readonly TimeSpan m_CircuitResetInterval;

        public StateOpen(ICircuit circuit, TimeSpan circuitResetInterval)
        {
            m_Circuit = circuit;
            m_CircuitResetInterval = circuitResetInterval;
            m_Command = new Command(TimeSpan.MaxValue);
        }

        internal bool Disposed { get; private set; }

        public void Enter()
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            m_Command.ExecuteScheduled( () => m_Circuit.AttemptToClose(), m_CircuitResetInterval);
        }

        public bool IsOpen
        {
            get { return true; }
        }

        public bool IsHalfOpen
        {
            get { return false; }
        }

        public bool IsClosed
        {
            get { return false; }
        }

        private void CommandFailed()
        {
        }

        private void CommandSucceeded()
        {
        }

        public void ExecuteSync(Action command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            throw new CircuitBreakerOpenException();
        }

        public T ExecuteSync<T>(Func<T> command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            throw new CircuitBreakerOpenException();
        }

        public T ExecuteSync<T>(Func<T> command, Func<T> fallbackCommand)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            throw new CircuitBreakerOpenException();
        }

        public async Task ExecuteAsync(Func<Task> command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            throw new CircuitBreakerOpenException();
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            throw new CircuitBreakerOpenException();
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> command, Func<Task<T>> fallbackCommand)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            throw new CircuitBreakerOpenException();
        }

        public void Dispose()
        {
            if (!this.Disposed)
            {
                this.Disposed = true;

                if (m_Command != null)
                {
                    m_Command.Dispose();
                }
            }
        }
    }
}