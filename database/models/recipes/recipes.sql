CREATE SCHEMA IF NOT EXISTS recipes;

CREATE TYPE recipes.measurement AS ENUM (
    'kg',
    'hg',
    'g',
    'l',
    'dl',
    'cl',
    'ml',
    'cup',
    'tsp',
    'tbsp'
);

CREATE TABLE IF NOT EXISTS recipes.recipe(
    id              SERIAL NOT NULL PRIMARY KEY,
    name            TEXT NOT NULL,
    description     TEXT NOT NULL,
    steps           TEXT[],
    createdBy       INT NOT NULL,
    createdAt       TIMESTAMPTZ NOT NULL DEFAULT now(),

    FOREIGN KEY(createdBy) REFERENCES users(id)
);

CREATE TRIGGER set_timestamp
    BEFORE UPDATE ON recipes.recipe
    FOR EACH ROW
EXECUTE PROCEDURE trigger_set_updated_at();

CREATE TABLE IF NOT EXISTS recipes.recipe_categories(
    recipeId      INT NOT NULL,
    categoryId    INT NOT NULL,

	CONSTRAINT fk_recipes FOREIGN KEY(recipeId) REFERENCES recipes.recipe(id),
 	CONSTRAINT fk_categories FOREIGN KEY(categoryId) REFERENCES categories.category(id)
);

CREATE TABLE IF NOT EXISTS recipes.ingredient(
    id          SERIAL NOT NULL PRIMARY KEY,
    name        TEXT NOT NULL,
    createdBy   INT NOT NULL,
    createdAt   TIMESTAMPTZ NOT NULL DEFAULT now(),
    updatedAt   TIMESTAMPTZ NOT NULL DEFAULT now(),

    FOREIGN KEY(createdBy) REFERENCES users(id)
);

CREATE TRIGGER set_timestamp
    BEFORE UPDATE ON recipes.ingredient
    FOR EACH ROW
EXECUTE PROCEDURE trigger_set_updated_at();

CREATE TABLE IF NOT EXISTS recipes.recipe_ingredient(
     recipeId      SERIAL NOT NULL,
     ingredientId  SERIAL NOT NULL,
     amount        NUMERIC (8,1) NOT NULL DEFAULT 0,
     measurement   recipes.MEASUREMENT NOT NULL,

     CONSTRAINT fk_recipe FOREIGN KEY(recipeId) REFERENCES recipes.recipe(id),
     CONSTRAINT fk_ingredient FOREIGN KEY(ingredientId) REFERENCES recipes.ingredient(id)
);
