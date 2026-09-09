namespace ABAH.Desktop.Models;

/// <summary>
/// Status penjemputan sesuai alur di README (fitur #5 Pickup Scheduling &amp; Tracking).
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
