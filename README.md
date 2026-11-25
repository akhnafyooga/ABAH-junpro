# ABAH — Aplikasi Penukar Limbah

ABAH helps waste producers offer recyclable material to local collectors and track each pickup through verified weight and a receipt. The Module 10 MVP is a Windows desktop application built with WPF, .NET 10, Npgsql and PostgreSQL. Its pickup area search uses Open-Meteo Geocoding.

- **Run the app** using the [Windows release ZIP](https://github.com/akhnafyooga/ABAH-junpro/releases/tag/module10-mvp-rc1).
- **Prepare the submission** using the [Module 10 deliverables record](docs/Module-10-MVP.md).
- **Test the release** using the [black-box test sheet](docs/Module-10-Black-Box.md).

## What you need

- Windows x64 and permission to run the extracted application.
- A running PostgreSQL server and a dedicated demo database. pgAdmin is the easiest way to create the database and apply the scripts. PostgreSQL runs separately from ABAH.
- Internet access for pickup area lookup and browser maps. Manual area entry works without internet.
- Use synthetic listings, public area names and sample scale images. The role selector supports a classroom demo on one machine.

## Install and configure

1. Download `ABAH-Module10-win-x64.zip` from the release page. Right-click and choose **Extract All**. Keep the `app`, `database`, `docs` and launcher files together. The packaged .NET runtime means you can run without Visual Studio or the SDK.
2. In pgAdmin, connect to your local PostgreSQL server. Under **Databases**, choose **Create → Database** and enter `abah`. Use a user that owns this dedicated database or has permission to create its tables. Confirm your host, port, username and password in the server connection settings.
3. Open **Query Tool** on `abah` and run these files one at a time, in this order. Check that each finishes successfully before opening the next file.

   | Script | Purpose |
   | --- | --- |
   | `database/001_offers.sql` | Creates listings, collectors and the original offer table. |
   | `database/002_demo_seed.sql` | Adds two demo listings and the Melati Waste Bank collector. |
   | `database/003_workflow.sql` | Adds the pickup workflow and preserves existing Module 8 offers separately. |

4. In the extracted folder, copy `database.example.json` to `database.local.json` if you need different connection settings. The launcher creates the default file on first run otherwise. The default host is `127.0.0.1`, port `5432`, database `abah`, and username `postgres`. The password is prompted separately and is never written to this file.
5. Open PowerShell in the extracted folder and run the launcher. Enter your **PostgreSQL user password** when prompted.

   ```powershell
   powershell -NoProfile -File .\Start-ABAH.ps1
   ```

6. Confirm **Dashboard** opens and **Waste Listings** shows the seeded listings. The top-right **Demo role** selector should offer **Producer** and **Melati Waste Bank**.

For the earlier ABAH demo server, use port `55438`, database `postgres` and user `abah_test` only if those values match your pgAdmin connection. If that database already has scripts 001 and 002, apply script 003 there. Keep one database selected consistently in pgAdmin and ABAH.

### Troubleshoot first launch

| Symptom | What to check |
| --- | --- |
| Launcher cannot find the EXE | Extract the ZIP completely. Look for `app/ABAH.Desktop.exe`. |
| Script execution is blocked | Ask your lab administrator whether PowerShell launchers are allowed. You can also provide `ABAH_POSTGRES_CONNECTION` through an approved local environment and launch the EXE from that session. |
| Connection times out | Confirm the PostgreSQL server is running and that the port in the JSON file matches pgAdmin. Use `Test-NetConnection 127.0.0.1 -Port 5432` with your actual port. |
| Password authentication failed | Use the password for the PostgreSQL database role. The pgAdmin master password unlocks saved credentials. |
| App asks for scripts 001, 002 and 003 | Run the scripts against the database named in `database.local.json`. Refresh the page afterward. |
| Only Producer appears | Apply the demo seed to the same database, then refresh or restart ABAH. |
| Location lookup fails | Check internet access or enter a public pickup area manually. |
| Impact is empty | Check Transactions. Trade counts after receipt acknowledgment. Donation counts after weight confirmation. |

## User guide

Pick a role in the top-right selector. Changing roles refreshes the page and its available actions. Select a record before using its action button. Refresh if another session just made a change.

| Step | Role and page | Action and expected result |
| --- | --- | --- |
| 1. Publish | Producer → Waste Listings | Enter `Test Cardboard`, `12.50` kg, a public pickup area and **Trade**. Publish and find the listing in the grid or card list. |
| 2. Propose | Melati Waste Bank → Waste Listings | Select the listing. Enter `4000` Rp/kg, `5000` fee and a future time in WIB using `yyyy-MM-dd HH:mm`. Submit. |
| 3. Accept | Producer → Offers | Select the pending offer. Check the estimated net of **Rp 45,000**, then accept. The pickup appears as **Scheduled**. |
| 4. Collect | Melati Waste Bank → Pickups | Select the scheduled pickup and choose **Mark collected**. |
| 5. Measure | Melati Waste Bank → Verification | Select the collected pickup. Enter `12.20` kg and choose a JPEG or PNG scale photo under 5 MB. Submit the weight. |
| 6. Review | Producer → Verification | Open the scale photo and check the measured net of **Rp 43,800**. Confirm weight or request a correction with a reason. A corrected measurement can be submitted by the collector. |
| 7. Record payment | Melati Waste Bank → Transactions | Select the verified record and record the external test payment reference `TEST-001`. ABAH stores the reference for payment made outside the app. |
| 8. Complete | Producer → Transactions | Select the **Recorded** transaction and acknowledge receipt. Check **Completed**, then open **Impact** to see the additional **12.20 kg**. |

For a **Donation**, select Donation when publishing and go through acceptance, collection and weight review. The offer price and fee are zero. Confirmation completes the donation and adds its verified weight to Impact without payment steps.

### Find a pickup area

As Producer, type a public place name such as `Bandung` in **Pickup area** and click **Find pickup area**. The top result fills the field. Open the dropdown to choose a different result, or preview the area in your browser. ABAH stores the area label with the listing. Enter the area manually if lookup is unavailable.

The desktop app calls the [Open-Meteo Geocoding API](https://open-meteo.com/en/docs/geocoding-api) using [GeoNames](https://www.geonames.org/) data. Browser map previews use [OpenStreetMap](https://www.openstreetmap.org/copyright). Results describe approximate public areas. This release consumes a third-party API. It does not include a separate ABAH-hosted server.

## Build from source

Install the .NET 10 SDK and use the WPF project as the Visual Studio startup project. From the root of a checkout of `main`:

```powershell
dotnet restore ABAH.sln --source https://api.nuget.org/v3/index.json
dotnet build ABAH.sln --no-restore
$env:ABAH_POSTGRES_CONNECTION = 'Host=127.0.0.1;Port=5432;Database=abah;Username=YOUR_USER;Password=YOUR_PASSWORD'
dotnet run --project src/ABAH.Desktop --no-restore
```

Use actual credentials only in your own PowerShell session. Keep connection strings, local configuration and screenshots containing credentials out of Git. To recreate the Windows release ZIP, run `./scripts/Publish-ABAH.ps1` with PowerShell from the source checkout. The ZIP is written under `artifacts`.

## Architecture and project references

WPF handles navigation and workflow input. Npgsql persists data to PostgreSQL, and the desktop calls the optional place lookup over HTTPS. The pickup states are Pending, Scheduled, Collected, Review, Correction, Verified, Recorded and Completed. Donation follows the same collection and review states and completes directly from Review. The demo uses shared test roles. Separate authentication, API authorization and private pickup address sharing remain future work.

- [Release design and scenario rationale](docs/ABAH-Release-Design.md)
- [Original project background and conceptual domain model](docs/ABAH-Project-Background.md)
- [Module 10 deliverables and submission evidence](docs/Module-10-MVP.md)
- [Black-box cases and result format](docs/Module-10-Black-Box.md)

## Team and contributions

Akhnaf Fawzan Yogatrisna works on architecture and data design. Rafi Busthami works on frontend and user flows. Akmal Rafli Fauzan works on backend and integration. For ongoing work, use branches such as `feature/pickup-status.rafi`, meaningful commit messages and a teammate-reviewed pull request.

### Add detailed pickup instructions

The map preview shows the approximate area returned by the lookup. When publishing,
use **Alamat detail / pickup instructions** for a public meeting point, for example
"Meet at the west gate of the recycling center." The instructions appear on
**Pickups** after acceptance for the Producer and selected demo collector. The
demo role switch is shared, so use public locations and synthetic data.
For an existing database, rerun the updated `database/003_workflow.sql` before
launching this version.

### Contact the demo collector on WhatsApp

Optionally set ABAH_DEMO_COLLECTOR_WHATSAPP in the launch environment to Melati
Waste Bank's approved business WhatsApp number, using international digits only.
For an Indonesian number, replace the leading 0 with 62 and remove spaces and
punctuation. As Producer, select a scheduled Melati pickup in Pickups and click
**Chat with Melati Waste Bank on WhatsApp**. The button opens a chat in the
browser. The user chooses whether to send a message.
