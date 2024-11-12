export interface MenuCreateaRequestType {
    id:string|null,
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
    restaurantId:string, 
    dishId:string, 
    quantity:number
}