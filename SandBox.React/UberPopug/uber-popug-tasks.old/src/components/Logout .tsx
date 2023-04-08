import React from 'react';

export default function Logout(props){
    const logout = () => {
        props.keycloak.logout();
    }

    return (
        <button onClick={ () => logout() }>
            Logout
        </button>
    );
};