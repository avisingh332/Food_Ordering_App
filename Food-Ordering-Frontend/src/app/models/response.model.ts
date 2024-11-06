import { User } from "./generic.model"

export interface ApiResponse{
    isSuccess: boolean, 
    message:string, 
    result: object
}
export interface LoginResponse{
    userId:string, 
    name:string, 
    email:string, 
    jwtToken:string, 
    expiresIn:Date, 
    roles:string[],
}
export interface UserResponse {
    id:string, 
    name:string, 
    email:string,
}
export interface RestaurantResponse{
    id:string, 
    name:string, 
    ownerId:string, 
    owner:UserResponse, 
    location:string, 
    registeredAt:string, 
    cuisine:string, 
    imageUrl:string, 

}
export interface MenuResponse{
    id:string, 
    restaurantId:string, 

}
export interface MenuItemResponse{

}
export interface OrderResponse{

}
export interface OrderItemResponse{
    
}
export interface ReviewResponse{

}
export interface CartItemResponse{

}
export interface CartResponse{

}