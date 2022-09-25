CREATE SCHEMA IF NOT EXISTS categories;

CREATE TYPE categories.type AS ENUM(
    'recipe'
);

CREATE TABLE IF NOT EXISTS categories.category(
    id      SERIAL NOT NULL PRIMARY KEY,
    type    categories.type NOT NULL,
    name    TEXT NOT NULL,
    createdBy INT NOT NULL,
    createdAt TIMESTAMPTZ NOT NULL DEFAULT now(),
    updatedAt TIMESTAMPTZ NOT NULL DEFAULT now(),

    UNIQUE(type, name),

    CONSTRAINT fk_createdBy FOREIGN KEY(createdBy) REFERENCES users(id)
);

CREATE TRIGGER set_timestamp
    BEFORE UPDATE ON categories.category
    FOR EACH ROW
EXECUTE PROCEDURE trigger_set_updated_at();
