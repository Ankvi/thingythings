import api from '$lib/api';
import { invalid, redirect } from '@sveltejs/kit';
import type { AxiosError } from 'axios';
import type { Actions } from './$types';

interface RegisterUserRequest {
    email: string;
    password: string;
    confirmPassword: string;
}

interface UserRegisteredResponse {
    success: boolean;
}

interface ValidationFieldErrorResponse {
    propertyName: string;
    message: string;
}

interface ValidationErrorResponse {
    errors: ValidationFieldErrorResponse[];
    success: boolean;
}

type RegisterActionResponse = {
    email: string;

}

export const actions: Actions = {
    signIn: async ({ request }) => {
        const formData = await request.formData();

        const email = formData.get('email');
        const password = formData.get('password');

        try {
            const response = await api.post('/users/login', {
                email,
                password
            });

            if (response.status == 200) {
                throw redirect(303, '/');
            }
        } catch (e) {
            return invalid(400, { email, incorrect: true });
        }
    },
    register: async({ request }) => {
        const formData = await request.formData();

        const body: RegisterUserRequest = {
            email: formData.get('email') as string,
            password: formData.get('password') as string,
            confirmPassword: formData.get('confirmPassword') as string
        }

        if (!body.email) {
            return invalid(400, { email: body.email, missing: true });
        }

        try {
            const response = await api.post<UserRegisteredResponse>('/users/register', body)
            console.log(response);
            throw redirect(303, '/');
        } catch (e) {
            const error = e as AxiosError;
            switch (error.response?.status) {
                case 400: {
                    const data = error.response.data as ValidationErrorResponse;
                    console.error(data);
                }

            }
        }
    }
}
