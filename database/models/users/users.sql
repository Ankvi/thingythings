CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE TABLE IF NOT EXISTS users (
    id              SERIAL NOT NULL PRIMARY KEY,
    firstName       TEXT,
    lastName        TEXT,
    email           TEXT NOT NULL,
    password        TEXT NOT NULL,
    createdAt       TIMESTAMPTZ NOT NULL DEFAULT now(),
    updatedAt       TIMESTAMPTZ NOT NULL DEFAULT now()
);

CREATE TRIGGER set_timestamp
    BEFORE UPDATE ON users
    FOR EACH ROW
    EXECUTE PROCEDURE trigger_set_updated_at();
