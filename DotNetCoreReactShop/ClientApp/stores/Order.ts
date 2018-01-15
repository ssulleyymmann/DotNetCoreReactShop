export default class Order {
    static STORAGE_KEY: string = "order";

    static get() {
        let items = window.localStorage.getItem(Order.STORAGE_KEY);
        return items ? JSON.parse(items) : [];
    }

    static set(pizza: any) {
        window.localStorage.setItem(Order.STORAGE_KEY, JSON.stringify(pizza));
    }
    static remove(): void {
        window.localStorage.removeItem(Order.STORAGE_KEY);
    }
}
