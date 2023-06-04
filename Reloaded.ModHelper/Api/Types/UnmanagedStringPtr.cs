using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper;

/// <summary>
/// A convenient way and safe way to 
/// </summary>
public unsafe class UnmanagedStringPtr : IDisposable
{
    /// <summary>
    /// An unmanaged pointer to this string in memory.
    /// </summary>
    public char* UnmanagedPointer { get; private set; }
    private bool isAllocated;

    public UnmanagedStringPtr()
    {
        
    }

    public UnmanagedStringPtr(string text)
    {
        AllocatedMemory(text);
    }

    /// <summary>
    /// Set the text for this pointer.
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        FreeMemory();
        AllocatedMemory(text);
    }

    private void AllocatedMemory(string text)
    {
        if (text == null)
        {
            ConsoleUtils.WriteError("Unable to allocate memory for \"text\" because it is null");
            return;
        }
        UnmanagedPointer = (char*)Marshal.StringToHGlobalAnsi(text);
        isAllocated = true;
    }

    private void FreeMemory()
    {
        if (!isAllocated)
            return;

        Marshal.FreeHGlobal((nint)UnmanagedPointer);
        isAllocated = false;
    }

    /// <summary>
    /// Frees memory assigned to this string pointer.
    /// </summary>
    public void Dispose()
    {
        FreeMemory();
    }

    public static implicit operator char*(UnmanagedStringPtr managedStringPtr)
    {
        return managedStringPtr.UnmanagedPointer;
    }

    public static implicit operator long(UnmanagedStringPtr managedStringPtr)
    {
        return (long)managedStringPtr.UnmanagedPointer;
    }
}
