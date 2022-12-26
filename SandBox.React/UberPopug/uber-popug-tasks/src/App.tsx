import './App.css';

import React, {useEffect, useRef, useState} from 'react';
import {Admin, AuthProvider, DataProvider, ListGuesser, Resource} from 'react-admin';
import dataProvider1 from './providers/dataProvider';
import Keycloak, {KeycloakConfig, KeycloakInitOptions, KeycloakTokenParsed} from 'keycloak-js';
import { keycloakAuthProvider, httpClient } from 'ra-keycloak';
import tags from "./tags";

const config: KeycloakConfig = {
    url: 'http://keycloak8080.localhost:8080',
    realm: 'uber-popug',
    clientId: 'uber-popug-tasks',
};

// here you can set options for the keycloak client
const initOptions: KeycloakInitOptions = {onLoad: 'login-required'};

// here you can implement the permission mapping logic for react-admin
const getPermissions = (decoded: KeycloakTokenParsed) => {
    const roles = decoded?.realm_access?.roles;
    if (!roles) {
        return false;
    }
    if (roles.includes('admin')) return 'admin';
    if (roles.includes('user')) return 'user';
    return false;
};

const raKeycloakOptions = {
    onPermissions: getPermissions,
};

const App = () => {
    const [keycloak, setKeycloak] = useState<Keycloak>();
    const authProvider = useRef<AuthProvider>();
    const dataProvider = useRef<DataProvider>();

    useEffect(() => {
        const initKeyCloakClient = async () => {
            // init the keycloak client
            const keycloakClient = new Keycloak(config);
            await keycloakClient.init(initOptions);
            // use keycloakAuthProvider to create an authProvider
            authProvider.current = keycloakAuthProvider(
                keycloakClient,
                raKeycloakOptions
            );
            // example dataProvider using the httpClient helper
            dataProvider.current = dataProvider1(
                'https://jsonplaceholder.typicode.com',
                httpClient(keycloakClient)
            );
            setKeycloak(keycloakClient);
        };
        if (!keycloak) {
            initKeyCloakClient();
        }
    }, [keycloak]);

    // hide the admin until the keycloak client is ready
    // if (!keycloak) return <p>Loading...</p>;

    return (
        <Admin
            dataProvider={dataProvider.current}
            authProvider={authProvider.current}
        >
            <Resource name="tags" {...tags}/>
        </Admin>
    );
}

export default App;
