import {useState, useEffect} from 'react';
import Keycloak from 'keycloak-js';
import UserInfo from "./UserInfo";
import Logout from "./Logout ";
import QueryAPI from "./QueryAPI";

export default function Resources() {
    const [keycloak, setKeycloak] = useState(null)
    const [authenticated, setAuthenticated] = useState(false)

    useEffect(() => {
        const keycloak = Keycloak('/keycloak.json');
        keycloak.init({onLoad: 'login-required'}).then(authenticated => {
            setKeycloak(keycloak)
            setAuthenticated(authenticated)
        })
    }, [])

    if (keycloak) {
        if (authenticated) return (
            <div className='my-12 grid place-items-center'>
                <p>This is a Keycloak-secured component of your application. You shouldn't be able
                    to see this unless you've authenticated with Keycloak.</p>
                <div>
                    <img src="https://random.imagecdn.app/500/250"/>
                </div>
                <UserInfo keycloak={keycloak}/>
                <QueryAPI keycloak={keycloak} />
                <Logout keycloak={keycloak} />
            </div>
        );
        else return (<div className='my-12'>Unable to authenticate!</div>)
    }

    return (
        <>
            <div className='my-12'>Initializing Keycloak...</div>
        </>
    )
}