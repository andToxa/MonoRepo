import Keycloak from "keycloak-js";
const keycloak = new Keycloak({
    url: "http://keycloak8080.localhost:8080",
    realm: "uber-popug",
    clientId: "uber-popug-tasks",
});

export default keycloak;