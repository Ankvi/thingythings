CREATE SCHEMA IF NOT EXISTS recipe;

CREATE TYPE recipe.measurement AS ENUM (
    'kg',
    'hg',
    'g',
    'l',
    'dl',
    'cl',
    'ml'
);

CREATE TABLE IF NOT EXISTS recipe.categories(
    id      UUID PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
    name    TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS recipe.recipes (
    id              UUID PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
    name            TEXT NOT NULL,
    description     TEXT NOT NULL,
    steps           TEXT[]
);

CREATE TABLE IF NOT EXISTS recipe.ingredients(
    recipeId      UUID NOT NULL,
    ingredientId  UUID NOT NULL,
    amount        NUMERIC (8,1) NOT NULL DEFAULT 0,
    measurement   recipe.MEASUREMENT NOT NULL,

	FOREIGN KEY(recipeId) REFERENCES recipe.recipes(id),
 	FOREIGN KEY(ingredientId) REFERENCES ingredient.ingredients(id)
);

