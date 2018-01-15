export default class Router {

    static get(key: string) {
        return window.localStorage.getItem(key)
    }

    static set(key:string,path: any) {
        window.localStorage.setItem(key, path);
    }
    static remove(key: string): void {
        window.localStorage.removeItem(key);
    }
}
