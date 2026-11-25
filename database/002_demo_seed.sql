BEGIN;

INSERT INTO waste_listings (demo_key, material_type, estimated_weight_kg)
VALUES ('pet', 'PET bottles', 15.50), ('cardboard', 'Cardboard', 30.00)
ON CONFLICT (demo_key) DO NOTHING;

INSERT INTO collectors (demo_key, name)
VALUES ('melati', 'Melati Waste Bank')
ON CONFLICT (demo_key) DO NOTHING;

COMMIT;
