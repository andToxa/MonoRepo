import {fetchUtils, Options} from 'react-admin';
import jsonServerProvider from 'ra-data-json-server';

const dataProvider = (url: string, httpClient: any) => jsonServerProvider(url, httpClient);

export default dataProvider;