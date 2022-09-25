<script lang="ts">
    import DataTable, { Body, Cell, Head, Row } from '@smui/data-table';
    import type { PageData } from './$types';

    export let data: PageData;
    $: recipes = data.recipes;
</script>

<svelte:head>
    <title>Recipes</title>
    <meta name="description" content="Recipes" />
</svelte:head>
<DataTable>
    <Head>
        <Row>
            <Cell numeric>ID</Cell>
            <Cell>Name</Cell>
            <Cell style="width: 100%;">Description</Cell>
        </Row>
    </Head>
    <Body>
        {#each recipes as recipe (recipe.id)}
            <Row>
                <Cell numeric>{recipe.id}</Cell>
                <Cell>{recipe.name}</Cell>
                <Cell>{recipe.description}</Cell>
            </Row>
        {/each}
    </Body>
</DataTable>

<!-- {#each recipe.ingredients as ingredient}
                    <li>{ingredient.name}: {ingredient.amount}{ingredient.measurement}</li>
                {/each} -->

                <!-- {#each recipe.steps as step}
                <p>{step}</p>
            {/each} -->
