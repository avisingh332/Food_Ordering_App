export interface MenuCreateaRequestType {
    dishName: string;
    price: number;
    imageUrl: string;
}

export interface RestaurantCreateRequestType {
    name: string;
    location: string;
    cuisine: string;
    imageUrl: string;
    menus: MenuCreateaRequestType[];
}
export interface CartItemCreateRequestType{
    cartId:string, 
    dishId:string, 
    quantity:number
}