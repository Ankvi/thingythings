CREATE SCHEMA IF NOT EXISTS category;

CREATE TYPE category.type AS ENUM(
    'recipe'
);

CREATE TABLE IF NOT EXISTS category.categories(
    id      UUID PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
    category category.type NOT NULL,
    name    TEXT NOT NULL,
    UNIQUE(category, name)
)
