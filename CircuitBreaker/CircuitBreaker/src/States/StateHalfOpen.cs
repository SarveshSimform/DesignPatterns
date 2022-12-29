using System;
using System.Threading;
using System.Threading.Tasks;

using Sleeksoft.CB.Exceptions;
using Sleeksoft.CB.Commands;

namespace Sleeksoft.CB.States
{

    internal class StateHalfOpen : ICircuitState, IDisposable
    {
        private const string TYPE_NAME = "StateHalfOpen";

        private const int CALL_RUNNING = 1;
        private const int CALL_NOT_RUNNING = 0;

        private readonly ICircuit m_Circuit;
        private readonly ICommand m_Command;

        private int m_IsCallRunning;

        public StateHalfOpen(ICircuit circuit, TimeSpan commandTimeout)
        {
            m_Circuit = circuit;
            m_Command = new Command(commandTimeout);
        }

        internal bool Disposed { get; private set; }

        public void Enter()
        {
            m_IsCallRunning = CALL_NOT_RUNNING;
        }

        public bool IsOpen
        {
            get { return false; }
        }

        public bool IsHalfOpen
        {
            get { return true; }
        }

        public bool IsClosed
        {
            get { return false; }
        }

        public void CommandFailed()
        {
            m_Circuit.Open();
        }

        public void CommandSucceeded()
        {
            m_Circuit.Close();
        }

        public void ExecuteSync(Action command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            if ( Interlocked.CompareExchange(ref m_IsCallRunning, CALL_RUNNING, CALL_NOT_RUNNING) == CALL_NOT_RUNNING )
            {
                bool exceptionHappened = true;

                try
                {
                    m_Command.ExecuteSync(command);
                    exceptionHappened = false;
                }
                finally
                {
                    if ( exceptionHappened )
                    {
                        this.CommandFailed();
                    }
                    else
                    {
                        this.CommandSucceeded();
                    }
                }
            }
            else
            {
                throw new CircuitBreakerOpenException();
            }
        }

        public T ExecuteSync<T>(Func<T> command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            if ( Interlocked.CompareExchange(ref m_IsCallRunning, CALL_RUNNING, CALL_NOT_RUNNING) == CALL_NOT_RUNNING )
            {
                T result = default(T);
                bool exceptionHappened = true;

                try
                {
                    result = m_Command.ExecuteSync(command);
                    exceptionHappened = false;
                }
                finally
                {
                    if ( exceptionHappened )
                    {
                        this.CommandFailed();
                    }
                    else
                    {
                        this.CommandSucceeded();
                    }
                }

                return result;
            }
            else
            {
                throw new CircuitBreakerOpenException();
            }
        }

        public T ExecuteSync<T>(Func<T> command, Func<T> fallbackCommand)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            if ( Interlocked.CompareExchange(ref m_IsCallRunning, CALL_RUNNING, CALL_NOT_RUNNING) == CALL_NOT_RUNNING )
            {
                T result = default(T);

                try
                {
                    result = m_Command.ExecuteSync(command);
                    this.CommandSucceeded();
                }
                catch ( Exception )
                {
                    this.CommandFailed();
                    result = m_Command.ExecuteSync(fallbackCommand);
                }

                return result;
            }
            else
            {
                throw new CircuitBreakerOpenException();
            }
        }

        public async Task ExecuteAsync(Func<Task> command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            if ( Interlocked.CompareExchange(ref m_IsCallRunning, CALL_RUNNING, CALL_NOT_RUNNING) == CALL_NOT_RUNNING )
            {
                bool exceptionHappened = true;

                try
                {
                    await m_Command.ExecuteAsync(command);
                    exceptionHappened = false;
                }
                finally
                {
                    if ( exceptionHappened )
                    {
                        this.CommandFailed();
                    }
                    else
                    {
                        this.CommandSucceeded();
                    }
                }
            }
            else
            {
                throw new CircuitBreakerOpenException();
            }
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> command)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            if ( Interlocked.CompareExchange(ref m_IsCallRunning, CALL_RUNNING, CALL_NOT_RUNNING) == CALL_NOT_RUNNING )
            {
                Task<T> task = default(Task<T>);
                bool exceptionHappened = true;

                try
                {
                    task = m_Command.ExecuteAsync(command);
                    await task;
                    exceptionHappened = false;
                }
                finally
                {
                    if ( exceptionHappened )
                    {
                        this.CommandFailed();
                    }
                    else
                    {
                        this.CommandSucceeded();
                    }
                }

                return await task;
            }
            else
            {
                throw new CircuitBreakerOpenException();
            }
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> command, Func<Task<T>> fallbackCommand)
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(TYPE_NAME);
            }

            if ( Interlocked.CompareExchange(ref m_IsCallRunning, CALL_RUNNING, CALL_NOT_RUNNING) == CALL_NOT_RUNNING )
            {
                Task<T> task = default(Task<T>);

                try
                {
                    task = m_Command.ExecuteAsync(command);
                    await task;
                    this.CommandSucceeded();
                }
                catch ( Exception )
                {
                    this.CommandFailed();
                    task = m_Command.ExecuteAsync(fallbackCommand);
                    await task;
                }

                return await task;
            }
            else
            {
                throw new CircuitBreakerOpenException();
            }
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