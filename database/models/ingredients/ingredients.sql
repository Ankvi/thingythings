CREATE SCHEMA IF NOT EXISTS ingredient;

CREATE TABLE IF NOT EXISTS ingredient.ingredients (
    id      UUID NOT NULL PRIMARY KEY DEFAULT gen_random_uuid(),
    name    TEXT NOT NULL
);