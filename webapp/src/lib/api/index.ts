const baseUrl = 'https://localhost:56534';

export function api(method: 'POST' | 'GET' | 'DELETE', resource: string, data?: Record<string,unknown>) {
    return fetch(`${baseUrl}/${resource}`, {
        method,
        headers: {
            'Content-Type': 'application/json'
        },
        body: data && JSON.stringify(data)
    })
}