BEGIN;
ALTER TABLE waste_listings ADD COLUMN IF NOT EXISTS mode text NOT NULL DEFAULT 'Trade';
ALTER TABLE waste_listings ADD COLUMN IF NOT EXISTS pickup_area text NOT NULL DEFAULT '';
ALTER TABLE waste_listings ADD COLUMN IF NOT EXISTS reserved boolean NOT NULL DEFAULT false;

-- Separate from the legacy demo so old offers keep their original price semantics.
CREATE TABLE IF NOT EXISTS workflow_offers (
    id integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    listing_id integer NOT NULL REFERENCES waste_listings(listing_id),
    collector_id integer NOT NULL REFERENCES collectors(collector_id),
    rate numeric(14,2) NOT NULL CHECK (rate >= 0),
    fee numeric(14,2) NOT NULL CHECK (fee >= 0),
    scheduled_at timestamptz NOT NULL,
    status text NOT NULL DEFAULT 'Pending' CHECK (status IN
        ('Pending','Scheduled','Collected','Review','Correction','Verified','Recorded','Completed')),
    actual_kg numeric(10,2) CHECK (actual_kg > 0),
    evidence bytea,
    correction text,
    payment_reference text,
    completed_at timestamptz
);
CREATE UNIQUE INDEX IF NOT EXISTS workflow_one_pickup
    ON workflow_offers(listing_id) WHERE status <> 'Pending';
COMMIT;
