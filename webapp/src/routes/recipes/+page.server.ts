import { api } from '$lib/api';
import { error } from '@sveltejs/kit';
import type { PageServerLoad, Actions } from './$types';

enum Measurement {
    KG = 'kg',
    HG = 'hg',
    G = 'g',
    L = 'l',
    DL = 'dl',
    CL = 'cl',
    ML = 'ml',
    CUP = 'cup',
    TBSP = 'tbsp',
    TSP = 'tsp'
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

export const load: PageServerLoad = async () => {
    return {
        recipes: [{
            id: 'ayy',
            name: 'Lasagna',
            description: 'Top tier italian cuisine',
            ingredients: [{
                name: 'Ground beef',
                amount: 400,
                measurement: Measurement.G
            }],
            steps: [
                'Fry shit'
            ]
        }, {
            id: 'lmao',
            name: 'Pho',
            description: 'Philippino beef broth stew with so many great things',
            ingredients: [{
                name: 'Cow bones',
                amount: 2,
                measurement: Measurement.KG
            }],
            steps: [
                'Boil the bones',
                'Rinse off any gunk that\'s stuck to the bones',
                'Boil the bones again with all the spices in a tea bag or something similar'
            ]
        }] as Recipe[]
    }
    // const response = await api('GET', 'recipes');

    // if (response.status === 404) {
    //     return {
    //         recipes: [] as Recipe[]
    //     }
    // }

    // if (response.status === 200) {
	// 	return {
	// 		recipes: (await response.json()) as Recipe[]
	// 	};
	// }

	// throw error(response.status);
}

export const actions: Actions = {

}