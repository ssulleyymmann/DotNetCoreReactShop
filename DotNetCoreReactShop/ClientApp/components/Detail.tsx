import * as React from 'react';
import 'isomorphic-fetch';
import PizzaService, { IPizza } from '../services/Pizzas'; 
let pizzaService = new PizzaService();
import RouterStore from '../stores/Router';
import { Link, Redirect, RouteComponentProps } from 'react-router-dom';
import { RoutePaths } from '../routes';

interface FetchDataExampleState {
    forecasts: any;
    loading: boolean;
    quantityUpdated:number,
}


export class Detail extends React.Component<RouteComponentProps<any>, FetchDataExampleState > {
   
    constructor() {
        super();
        this.changeQuantity = this.changeQuantity.bind(this);
        this.state = {
            forecasts: {}, loading: true, quantityUpdated:1 };
        this.clickAddToCart = this.clickAddToCart.bind(this);
        /*
         * TODO:match undfined  this.props.match.params.id
         * router state kavramýna bakmam lazým.
         * */
        RouterStore.set("Quantity",1);
        let params = RouterStore.get("params");
        pizzaService.fetch(params).then((response) => {
            this.setState({ forecasts: response.content, loading: false });
        })

    }
    changeQuantity(event) {
        let quantity = event.target.value;
        this.setState({
            quantityUpdated: quantity // quantityUpdated will be updated after this function is finished 
        });
        RouterStore.set("Quantity", quantity);
    }

    routerSet(forecast: any) {
        RouterStore.set("params",forecast.pizzaNo);

    }
    public render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Detail.renderForecastsTable(this.state.forecasts,this);

        return <div>
            detay
            {contents}
        </div>;
    }
    private static renderForecastsTable(forecast:any,self) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Pizza</th>
                    <th>fiyat</th>
                    <th>resim</th>
                    <th>miktar</th>
                    <th>ekle</th>
                </tr>
            </thead>
            <tbody>
                    <tr key={forecast.pizzaNo}>
                    <td>{forecast.pizzaName}</td>
                    <td>{forecast.price} </td>
                    <td>{forecast.image} </td>
                    <td>
                    <input type="number" min="1" max="99"
                        className="form-control"
                        style={{ width: '5rem' }}
                        value={self.state.quantityUpdated}
                            onChange={self.changeQuantity} />
                    </td>
                    <td>
                        <Link onClick={(e) => self.routerSet(forecast)} to={RoutePaths.Order.replace(":id", forecast.pizzaNo)}>Sepete ekle</Link> </td>
                   </tr>
            </tbody>

        </table>;
    }

    clickAddToCart(e) {
        e.preventDefault();
        <Link to="/order">Register</Link>
    }

}
