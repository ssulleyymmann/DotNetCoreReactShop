import RestUtilities from './RestUtilities';

export interface IPizza {
    pizzaId?: number,
    pizzaNo: string;
    pizzaName: string;
    price: number;
    image: string;
}

export default class Pizzas {
    fetchAll() {
        return RestUtilities.get<Array<IPizza>>('/api/pizza/getPopular');
    }

    fetch(pizzaNo: string) {
        return RestUtilities.get<IPizza>(`/api/pizza/getPizzaDetail/${pizzaNo}`);
    }
}

