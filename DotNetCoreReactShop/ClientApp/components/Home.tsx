import * as React from 'react';
import { RouteComponentProps, matchPath } from 'react-router';
import PropTypes from 'prop-types';
import 'isomorphic-fetch';
import PizzaService, { IPizza } from '../services/Pizzas'; 
import { Link, Redirect} from 'react-router-dom';
import { RoutePaths } from '../routes';
import RouterStore from '../stores/Router';

let pizzaService = new PizzaService();

interface FetchDataExampleState {
    forecasts: any[];
    loading: boolean;
}

export class Home extends React.Component<RouteComponentProps<{}>, FetchDataExampleState > {
    constructor() {
        super();
        this.state = { forecasts: [], loading: true };

        pizzaService.fetchAll().then((response) => {
            this.setState({ forecasts: response.content, loading: false });
        });

        //fetch('api/pizza/getPopular')
        //    .then(response => response.json() as Promise<any[]>)
        //    .then(data => {
        //        this.setState({ forecasts: data, loading: false });
        //    });
    }
    routerSet(forecast: any) {
        RouterStore.set("params",forecast.pizzaNo);

    }
    public render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderForecastsTable(this.state.forecasts,this);

        return <div>
             <span>
                {this.state.forecasts.map(function(object) {
        return (

            <li key={object.pizzaNo}>
                {object.pizzaName}
            </li>
                    );
                   
                })}
            </span>
            {contents}
        </div>;
    }
    private static renderForecastsTable(forecasts: any[],self:any) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Pizzalar</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(function (forecast) {
                    return (
                    <tr key={forecast.pizzaNo}>
                            <td>{forecast.pizzaName}  / 
                                <Link onClick={(e) => self.routerSet(forecast)} to={RoutePaths.Detail.replace(":id", forecast.pizzaNo)}>Detay</Link>
                               / <Link onClick={(e) => self.routerSet(forecast)} to={RoutePaths.Order.replace(":id", forecast.pizzaNo)}> hemen sepete ekle</Link>
                            </td>

                        </tr>
                        )
                })}
            </tbody>
        </table>;
    }
}
