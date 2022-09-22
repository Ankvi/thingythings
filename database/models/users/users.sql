CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE TABLE IF NOT EXISTS users (
    id              UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    firstName       TEXT,
    lastName        TEXT,
    email           TEXT NOT NULL,
    password        TEXT NOT NULL
);
