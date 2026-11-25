# Module 10 Black Box Test Sheet

Test the extracted release without relying on source code or database edits for
the test actions. Use a fresh dedicated PostgreSQL database and synthetic data.
Record the release tag, Windows and PostgreSQL versions, tester and date. Use
the packaged start and setup instructions in the [README](../README.md).

| ID | Steps and inputs | Expected result | Actual result | Status | Evidence |
| --- | --- | --- | --- | --- | --- |
| BB01 | Extract the ZIP on Windows x64. Apply scripts 001–003 and run the launcher. | Dashboard opens, seeded items appear and both demo roles are available. | | Not run | |
| BB02 | Publish 12.50 kg Trade. Offer Rp 4,000/kg and Rp 5,000 fee. Accept, mark collected and submit 12.20 kg with a sample JPEG. Confirm, record TEST-001 and acknowledge receipt. | Estimated net Rp 45,000, final net Rp 43,800, one Completed pickup and +12.20 kg Impact. | | Not run | |
| BB03 | Publish Donation, accept a future pickup, collect and submit 4.80 kg with a photo. Confirm. | Rate and fee are zero. Confirmation completes the pickup and adds 4.80 kg without payment. | | Not run | |
| BB04 | Submit 10.00 kg. Request correction with a reason, then submit 9.60 kg and confirm. | Collector sees the reason, and the final amount uses the revised weight. | | Not run | |
| BB05 | Try zero weight, a negative fee, a past pickup time and an invalid image on the matching forms. | Each invalid action is rejected and does not advance the workflow. | | Not run | |
| BB06 | Submit two offers on one listing. Accept one. Refresh and try the competing offer from another open session if visible. | Only one pickup is scheduled. The second acceptance cannot reserve the listing. | | Not run | |
| BB07 | After BB02, close the app, relaunch with the same database and reopen Transactions and Impact. | Completed record, reference and weight totals persist. | | Not run | |
| BB08 | Enter Bandung and search. Check the selection, choose another result and open its map preview. | Top result is selected, alternate selection fills the area, and the preview opens the selected public area. | | Not run | |
| BB09 | Disable internet access while keeping local PostgreSQL reachable. Search a city, then publish with a manually entered area. | An understandable lookup error appears, and the manual listing can be published. | | Not run | |
| BB10 | At 1280 × 720 and 125% scaling, use Tab to navigate options, inputs and actions. | Required controls remain reachable by keyboard and scrolling. | | Not run | |
| BB11 | Start with an incorrect port, then close and relaunch with the correct port. | The failed connection has a readable message and the correct settings restore access. | | Not run | |

Set each case to Pass, Fail or Blocked after execution and describe what
actually happened. For failures, attach a screenshot or short clip, note the
test record ID and file a linked issue with steps to reproduce. Retest after
fixes and record the release or commit used. Keep passwords and personal
addresses out of attachments.
