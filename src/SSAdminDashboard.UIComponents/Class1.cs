namespace SSAdminDashboard.UIComponents;

using Microsoft.AspNetCore.Components;
using System;

public abstract class CancellableComponent : ComponentBase, IDisposable
{
    private readonly CancellationTokenSource cts = new();

    public CancellationToken Token => this.cts.Token;

    public void Cancel() => this.cts.Cancel();

    public void Dispose()
    {
        this.cts.Cancel();
        this.cts.Dispose();
    }
}
