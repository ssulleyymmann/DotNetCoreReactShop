import * as React from 'react';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Detail } from './components/Detail';
import { Order } from './components/Order';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { SignIn, Register } from "./components/Auth";
import AuthService from './services/Auth';
import { Route, Redirect, Switch } from 'react-router-dom';

export class RoutePaths {
    public static Home: string = "/home";
    public static Detail: string = "/detail/:id";
    public static Order: string = "/order/:id";
    public static Contacts: string = "/contacts";
    public static ContactEdit: string = "/contacts/edit/:id";
    public static ContactNew: string = "/contacts/new";
    public static SignIn: string = "/";
    public static Register: string = "/register/";
}

export const routes = <Layout>
    <Route exact path={RoutePaths.SignIn} component={SignIn} />
    <Route path='/home' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchdata' component={FetchData} />
    <Route path={RoutePaths.Detail} component={Detail} />
    <Route path={RoutePaths.Order} component={Order} />
</Layout>;