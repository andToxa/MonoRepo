import React, {useEffect, useState} from 'react';

export default function UserInfo(props) {
    const [userInfo, setUserInfo] = useState(null)

    useEffect(() => {
        if (userInfo == null) {
            props.keycloak.loadUserInfo().then(info => {
                setUserInfo({name: info?.name, email: info?.email, id: info?.sub})
            });
        }
    })

    return (
        <div className="UserInfo">
            <p>Name: {userInfo?.name}</p>
            <p>Email: {userInfo?.email}</p>
            <p>ID: {userInfo?.id}</p>
        </div>
    );
};