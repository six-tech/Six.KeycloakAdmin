import {defineConfig} from 'astro/config';
import starlight from '@astrojs/starlight';
import starlightThemeSix from '@six-tech/starlight-theme-six'

export default defineConfig({
    base: '/Six.KeycloakAdmin/',
    site: 'https://six-tech.github.io',
    integrations: [
        starlight({
            title: 'Keycloak Admin',
            description: 'Modern .NET client for interacting with Keycloak servers',
            editLink: {
                baseUrl: 'https://github.com/six-tech/Six.KeycloakAdmin/edit/main/docs/src/content/docs/',
            },
            social: [
                {
                    icon: 'github',
                    label: 'GitHub',
                    href: 'https://github.com/six-tech/Six.KeycloakAdmin'
                },
            ],
            plugins: [
                starlightThemeSix({
                    navLinks: [
                        {
                            label: 'Docs',
                            link: '/getting-started/introduction',
                        },
                        {
                            label: 'Nuget.org',
                            link: 'https://six.technology',
                            attrs: {
                                target: '_blank',
                                rel: 'noopener',
                            },
                        },
                        {
                            label: 'Six',
                            link: 'https://six.technology',
                            attrs: {
                                target: '_blank',
                                rel: 'noopener',
                            },
                        },
                    ],
                }),
            ],
            sidebar: [
                {
                    label: 'Getting Started',
                    items: [
                        {label: 'Introduction', slug: 'getting-started/introduction'},
                        {label: 'Setup and Configuration', slug: 'getting-started/setup-and-configuration'},
                        {label: 'Aspire Integration', slug: 'getting-started/aspire-integration'},
                        {label: 'Running Tests', slug: 'maintenance/running-tests'},
                    ],
                },
                {
                    label: 'Examples',
                    items: [
                        {label: 'Authentication Methods', slug: 'examples/authentication-methods'},
                        {label: 'Client Management', slug: 'examples/client-management'},
                        {label: 'User Management', slug: 'examples/user-management'},
                        {label: 'Role Management', slug: 'examples/role-management'},
                        {label: 'Groups Management', slug: 'examples/groups-management'},
                        {label: 'Advanced Operations', slug: 'examples/advanced-operations'},
                    ],
                }
            ],
        }),
    ],
});
