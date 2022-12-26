import Vue from 'vue'
import Keycloak from 'keycloak-js'

const initOptions = {
    url: 'http://keycloak8080.localhost:8080', // process.env.VUE_APP_KEYCLOAK_URL,
    realm: 'uber-popug',
    clientId: 'uber-popug-tasks'
}

const keycloak = Keycloak(initOptions)

const KeycloakPlugin = {
    install: Vue => {
        Vue.$keycloak = keycloak
    }
}

Vue.use(KeycloakPlugin)

export default KeycloakPlugin