import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import numeral from 'numeral';
import 'isomorphic-fetch';
import OrderStore from '../stores/Order';
import RouterStore from '../stores/Router';
import PizzaService, { IPizza } from '../services/Pizzas';
let pizzaService = new PizzaService();
import AuthService from '../services/Auth';
interface FetchDataExampleState {

    pizzaList: any[];
    loading: boolean;
}
class OrderItem {
    OrderItemId?: number;
    Pizza: any;
   Quantity ?: number
};
export class Order extends React.Component<RouteComponentProps<any>, FetchDataExampleState>{ //<RegisterCompleteProps, FetchDataExampleState>{

    constructor(props) {



        super(props);
        var pizzas = OrderStore.get();
        this.state = { pizzaList: pizzas, loading: true };

        let params = RouterStore.get("params");
        let quantity =Number(RouterStore.get("Quantity"));
        if (params)
            pizzaService.fetch(params).then((response) => {

                let index = pizzas.findIndex(f => f.Pizza.pizzaNo === response.content.pizzaNo);

                if (index > -1)
                    pizzas[index].Quantity += quantity;
                else {
                    let orderItem = new OrderItem();
                    orderItem.OrderItemId = pizzas.length;
                    orderItem.Pizza = response.content;
                    orderItem.Quantity = quantity;
                    pizzas.push(orderItem);
                }

                OrderStore.set(pizzas);
                RouterStore.remove("params");
                this.setState({ pizzaList: pizzas, loading: false });
            })
        else //TODO: refresh ,setstate 
            pizzaService.fetchAll().then((response) => {
                this.setState({ pizzaList: pizzas, loading: false });
            })



    }
    clearOrder = () => {
        setTimeout(() => { 
            this.setState({ pizzaList: [], loading: false });
        
        OrderStore.remove();
    })
    }

    public render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Order.renderForecastsTable(this.state.pizzaList);

        let total = 0;
        let offer = AuthService.isSignedInIn()? 5:0;

            for (var i = 0; i < this.state.pizzaList.length; i++) {
                total += this.state.pizzaList[i].Pizza.price * this.state.pizzaList[i].Quantity;
                } 
          

        let result = Order.renderPriceTable(total, offer);

        return <div>
            sepetim
            {contents}
            {result}
            <button className="pull-right btn btn-outline-primary"
                onClick={this.clearOrder}>
                sepeti temizle
                                    </button>
        </div>;
    }
    private static renderForecastsTable(forecasts: any[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>pizza</th>
                    <th>fiyat</th>
                    <th> miktar</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(function (forecast) {
                    return (
                        <tr key={forecast.OrderItemId}>
                            <td>{forecast.Pizza.pizzaName}</td>
                            <td>{forecast.Pizza.price}</td>
                            <td>{forecast.Quantity}</td>
                        </tr>
                    )
                })}
            </tbody>
        </table>
    }
    private static renderPriceTable(total: any, offer: any) {

        return <table className='table'>
            <thead>
                <tr>
                    <th>toplam fiyat</th>
                    <th>indirim </th>
                    <th>tutar</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{total}</td>
                    <td>%{offer}</td>
                    <td>{((100 - offer) * total) / 100}</td>
                </tr>
            </tbody>
        </table>
    }
}
