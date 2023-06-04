using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper;

public unsafe class UnmanagedStructPtr<T> : IDisposable where T : struct
{
    private bool disposedValue;

    public T* Instance { get; private set; }
    private readonly T obj;

    public UnmanagedStructPtr()
    {
        Instance = (T*)Marshal.AllocHGlobal(sizeof(T));
        obj = new T();
        Marshal.StructureToPtr(obj, (nint)Instance, false);
    }

    public UnmanagedStructPtr(T obj)
    {
        Instance = (T*)Marshal.AllocHGlobal(sizeof(T));
        this.obj = obj;
        Marshal.StructureToPtr(obj, (nint)Instance, false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            Marshal.FreeHGlobal((nint)Instance);

            if (obj is IDisposable disposable)
                disposable.Dispose();

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    ~UnmanagedStructPtr()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
