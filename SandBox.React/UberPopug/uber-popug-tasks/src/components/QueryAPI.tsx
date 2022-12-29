import React, {useState} from 'react';

const APIResponse = (props) => {
    if (!props.response)
        return (<div/>);
    else
        return (<pre>{props.response}</pre>);
}

export default function QueryAPI(props) {
    const [response, setResponse] = useState(null)

    const authorizationHeader = () => {
        if (!props.keycloak) return {};
        return {
            headers: {
                "Authorization": "Bearer " + props.keycloak.token
            }
        };
    }

    const handleClick = () => {
        fetch('https://localhost:7267/WeatherForecast', authorizationHeader())
            .then(response => {
                if (response.status === 200)
                    return response.json();
                else
                    return {status: response.status, message: response.statusText}
            })
            .then(json => setResponse({
                response: JSON.stringify(json, null, 2)
            }))
            .catch(err => {
                setResponse({response: err.toString()})
            })
    }

    return (
        <div className="QueryAPI">
            <button onClick={handleClick}>Send API request</button>
            <APIResponse response={response}/>
        </div>
    );
}