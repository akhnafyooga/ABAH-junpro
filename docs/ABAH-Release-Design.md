# ABAH Release Design and Tryout Guide

This is the release design baseline for ABAH. The target client is WPF with the existing forest-green and mint branding. The shared backend is ASP.NET Core with PostgreSQL. The workflows below define implementation and acceptance criteria.

## Navigation and screens

| Screen | Purpose |
| --- | --- |
| Dashboard | Show upcoming pickups, items that need attention, and completed verified kilograms. Each item opens its detail page. |
| Listings | Producers create and manage listings. Collectors browse and filter by material and area. |
| Activity | Show offers, pickups, weight reviews and receipts in one list. Open each record for its timeline, current status and next action. |
| Account menu | Show the current role, allow switching among assigned roles and provide sign-out. |

Keep the existing ABAH wordmark and recycling identity, forest-green sidebar, mint selected states and Segoe UI. Use a labeled status and one primary action per detail view. Show who acts next when the current user has no action. Use inline validation, preserve drafts after connection errors and test keyboard focus and scrolling at 1280 × 720 with 125% scaling.

## Workflow

1. The producer publishes a listing with material, estimated weight, pickup location and Trade or Donation mode. Browsing shows the area. The API shares the precise address only with the producer and assigned collector after acceptance.
2. A collector proposes a future pickup time. For Trade, enter the rate in Rp/kg and a nonnegative pickup fee. For Donation, both values are zero. Show estimated net using the listed weight.
3. The producer accepts one pending offer. In one database transaction, reserve the listing, close competing offers and create the scheduled pickup. A concurrent or repeated request must never create another pickup.
4. The assigned collector marks the pickup Collected. On the way is optional. The collector submits positive actual kilograms and a scale photo. Only the producer can confirm the weight or request a correction with a reason. Retain earlier submissions in the timeline.
5. Donation completes when the producer confirms weight and creates a zero-value receipt. For Trade, calculate final net from verified kg × accepted rate − accepted fee and use decimal arithmetic. If the amount would be negative, keep the review open for correction or renegotiation. After confirmation, the collector records an external payment reference and the producer acknowledges receipt to complete the pickup.
6. Completion creates one receipt and adds the approved weight to the completed total once. Read the result from PostgreSQL after restart.

The API validates roles, ownership, current state and input independently of the UI. Store schedules in UTC and display them in WIB. Keep evidence behind participant authorization. Use WPF views and view models for UI, application services for workflow rules, and PostgreSQL constraints and transactions for consistency. Keep database credentials on the backend.

## Tryout setup

Run the API and WPF client against a seeded test database. Use separate sessions for one producer and one collector, and prepare a second collector account. Use a synthetic address and a test scale photo. For each test, save the record IDs and record the expected result, actual result and pass or fail. Use a fresh listing for each scenario.

### 1. Trade from listing to receipt

1. Producer: publish Cardboard at 12.500 kg in Trade mode. Verify Published.
2. Collector: find it and verify the public detail shows only the pickup area. Offer Rp 4,000/kg with a Rp 5,000 fee and a future pickup time. Verify Pending and Rp 45,000 estimated net.
3. Producer: accept the offer. Verify Reserved and Scheduled. Confirm both sessions show the same pickup ID and the assigned collector can now see the address.
4. Collector: mark Collected, enter 12.200 kg, attach the scale photo and submit. Verify the producer sees a weight review request.
5. Producer: verify Rp 48,800 gross and Rp 43,800 net. Confirm weight and verify Verified.
6. Collector: record external reference TEST-001. Producer: acknowledge receipt. Verify Completed, one receipt for Rp 43,800 and an increase of exactly 12.200 kg in completed weight.
7. Restart the client and reopen Activity. Verify receipt, photo and status persist. Compare the pickup, verification and settlement IDs in pgAdmin.

### 2. Donation

1. Producer: publish a 5.000 kg PET bottles Donation listing.
2. Collector: propose a pickup. Verify that both price and fee are zero.
3. Producer: accept. Collector: mark Collected and submit 4.800 kg and a photo.
4. Producer: confirm weight. Verify immediate completion, one zero-value receipt, no payment reference prompt and a 4.800 kg increase in completed weight.

### 3. Weight correction

1. Advance a fresh Trade pickup to weight review. Submit 10.000 kg.
2. Producer: request a correction with the reason “Scale display is unreadable.” Verify the collector sees the reason and totals stay unchanged.
3. Collector: submit a revised photo and 9.600 kg.
4. Producer: confirm. Verify the receipt calculation uses 9.600 kg, the earlier revision remains visible in history and impact updates only after completion.

### 4. Validation, permissions and recovery

| Check | Try it | Expected result |
| --- | --- | --- |
| Competing acceptance | Submit offers as two collectors. Try accepting both from separate producer sessions. | One accepted offer and one pickup. The second session refreshes with a reserved message. |
| Invalid input | Try a past date, negative fee, zero kg and unsupported image. | Field-level errors. Invalid records are never saved. |
| Unassigned collector | Open a test pickup or evidence record as the unassigned collector. | Access is denied and no private address or evidence is returned. |
| Duplicate submit | Repeat acceptance or payment recording after a simulated timeout. | The existing result is returned or displayed. One pickup and one receipt remain. |
| Connection loss | Stop the local API during a listing save, then restart and retry. | Inputs survive. The app checks whether the first save completed before retrying. Only one listing remains. |
| Keyboard and layout | Run at 1280 × 720 and 125% scaling. Use Tab and Enter through the publish and review flows. | Visible focus, usable scrolling and reachable primary actions. |

For the project demo, complete the Trade scenario first, then show a weight correction or competing acceptance. Capture the accepted offer, verified weight, receipt and matching pgAdmin rows.
