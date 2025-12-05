-- Tworzenie tabel
CREATE TABLE "Transactions"
(
    "Id" SERIAL PRIMARY KEY,
    "Guid" UUID NOT NULL DEFAULT gen_random_uuid(),
    "FromAccount" TEXT NOT NULL,
    "ToAccount" TEXT NOT NULL,
    "Amount" NUMERIC(18,2) NOT NULL,
    "Currency" TEXT NOT NULL,
    "BookingDate" TIMESTAMP NOT NULL,
    "Title" TEXT NOT NULL,
    "Status" INT NOT NULL  -- Enum jako integer
);

CREATE TABLE "Confirmations"
(
    "Id" SERIAL PRIMARY KEY,
    "Guid" UUID NOT NULL DEFAULT gen_random_uuid(),
    "TransactionId" INT NOT NULL UNIQUE,
    "ConfirmationNumber" TEXT NOT NULL,
    "Status" INT NOT NULL, -- Enum jako integer
    "Amount" NUMERIC(18,2) NOT NULL,
    "Currency" INT NOT NULL, -- Enum jako integer
    "Sender" TEXT NOT NULL,
    "Receiver" TEXT NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL,
    CONSTRAINT fk_transaction
        FOREIGN KEY("TransactionId") 
        REFERENCES "Transactions"("Id")
        ON DELETE CASCADE
);

-- Seed dla Transaction (15 rekordów)
INSERT INTO "Transactions" ("Guid", "FromAccount", "ToAccount", "Amount", "Currency", "BookingDate", "Title", "Status")
VALUES
(gen_random_uuid(), 'ACC001', 'ACC101', 100.50, 'USD', NOW() - INTERVAL '10 days', 'Payment 1', 0),
(gen_random_uuid(), 'ACC002', 'ACC102', 200.00, 'USD', NOW() - INTERVAL '9 days', 'Payment 2', 1),
(gen_random_uuid(), 'ACC003', 'ACC103', 150.75, 'EUR', NOW() - INTERVAL '8 days', 'Payment 3', 0),
(gen_random_uuid(), 'ACC004', 'ACC104', 300.00, 'EUR', NOW() - INTERVAL '7 days', 'Payment 4', 1),
(gen_random_uuid(), 'ACC005', 'ACC105', 500.25, 'USD', NOW() - INTERVAL '6 days', 'Payment 5', 0),
(gen_random_uuid(), 'ACC006', 'ACC106', 250.00, 'USD', NOW() - INTERVAL '5 days', 'Payment 6', 0),
(gen_random_uuid(), 'ACC007', 'ACC107', 120.00, 'EUR', NOW() - INTERVAL '4 days', 'Payment 7', 1),
(gen_random_uuid(), 'ACC008', 'ACC108', 450.50, 'USD', NOW() - INTERVAL '3 days', 'Payment 8', 0),
(gen_random_uuid(), 'ACC009', 'ACC109', 600.00, 'EUR', NOW() - INTERVAL '2 days', 'Payment 9', 1),
(gen_random_uuid(), 'ACC010', 'ACC110', 700.75, 'USD', NOW() - INTERVAL '1 day', 'Payment 10', 0),
(gen_random_uuid(), 'ACC011', 'ACC111', 80.25, 'USD', NOW() - INTERVAL '12 days', 'Payment 11', 0),
(gen_random_uuid(), 'ACC012', 'ACC112', 90.00, 'EUR', NOW() - INTERVAL '11 days', 'Payment 12', 1),
(gen_random_uuid(), 'ACC013', 'ACC113', 110.50, 'USD', NOW() - INTERVAL '13 days', 'Payment 13', 0),
(gen_random_uuid(), 'ACC014', 'ACC114', 130.00, 'EUR', NOW() - INTERVAL '14 days', 'Payment 14', 1),
(gen_random_uuid(), 'ACC015', 'ACC115', 170.75, 'USD', NOW() - INTERVAL '15 days', 'Payment 15', 0);

-- Seed dla Confirmation (10 rekordów powi¹zanych z pierwszymi 10 transaction)
INSERT INTO "Confirmations" ("Guid", "TransactionId", "ConfirmationNumber", "Status", "Amount", "Currency", "Sender", "Receiver", "CreatedAt")
VALUES
(gen_random_uuid(), 1, 'CONF001', 0, 100.50, 0, 'ACC001', 'ACC101', NOW() - INTERVAL '9 days'),
(gen_random_uuid(), 2, 'CONF002', 1, 200.00, 0, 'ACC002', 'ACC102', NOW() - INTERVAL '8 days'),
(gen_random_uuid(), 3, 'CONF003', 0, 150.75, 1, 'ACC003', 'ACC103', NOW() - INTERVAL '7 days'),
(gen_random_uuid(), 4, 'CONF004', 1, 300.00, 1, 'ACC004', 'ACC104', NOW() - INTERVAL '6 days'),
(gen_random_uuid(), 5, 'CONF005', 0, 500.25, 0, 'ACC005', 'ACC105', NOW() - INTERVAL '5 days'),
(gen_random_uuid(), 6, 'CONF006', 0, 250.00, 0, 'ACC006', 'ACC106', NOW() - INTERVAL '4 days'),
(gen_random_uuid(), 7, 'CONF007', 1, 120.00, 1, 'ACC007', 'ACC107', NOW() - INTERVAL '3 days'),
(gen_random_uuid(), 8, 'CONF008', 0, 450.50, 0, 'ACC008', 'ACC108', NOW() - INTERVAL '2 days'),
(gen_random_uuid(), 9, 'CONF009', 1, 600.00, 1, 'ACC009', 'ACC109', NOW() - INTERVAL '1 day'),
(gen_random_uuid(), 10, 'CONF010', 0, 700.75, 0, 'ACC010', 'ACC110', NOW());