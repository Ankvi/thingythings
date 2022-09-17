<script lang="ts">
    import type { PageData } from './$types';

    export let data: PageData;
    $: recipes = data.recipes;
</script>

<svelte:head>
    <title>Recipes</title>
    <meta name="description" content="Recipes" />
</svelte:head>

{#each recipes as recipe (recipe.id)}
    <h3>{recipe.name}</h3>
    <p>{recipe.description}</p>
    <h4>Ingredients</h4>
    <ul>
        {#each recipe.ingredients as ingredient}
            <li>{ingredient.name}: {ingredient.amount}{ingredient.measurement}</li>
        {/each}
    </ul>
    {#each recipe.steps as step}
        <p>{step}</p>
    {/each}
{/each}