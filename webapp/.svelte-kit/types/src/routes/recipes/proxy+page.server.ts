// @ts-nocheck
import { api } from '$lib/api';
import { error } from '@sveltejs/kit';
import type { PageServerLoad, Actions } from './$types';

enum Measurement {
    KG,
    HG,
    G,
    L,
    DL,
    CL,
    ML,
    CUP,
    TBSP,
    TSP
}

interface Ingredient {
    name: string;
    amount: number;
    measurement: Measurement;
}

interface Recipe {
    id: string;
    name: string;
    description: string;
    ingredients: Ingredient[];
    steps: string[];
}

export const load = async () => {
    const response = await api('GET', 'recipes');

    if (response.status === 404) {
        return {
            recipes: [] as Recipe[]
        }
    }

    if (response.status === 200) {
		return {
			recipes: (await response.json()) as Recipe[]
		};
	}

	throw error(response.status);
}

export const actions = {

};null as any as PageServerLoad;;null as any as Actions;