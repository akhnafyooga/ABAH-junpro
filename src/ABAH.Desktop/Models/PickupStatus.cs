namespace ABAH.Desktop.Models;

/// <summary>
/// Pickup statuses following the flow in the README (feature #5 Pickup Scheduling &amp; Tracking).
/// </summary>
public enum PickupStatus
{
    Requested,
    Accepted,
    OnTheWay,
    Collected,
    Verified,
    Completed
}
