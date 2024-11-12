export interface User{
    userId:string,
    email: string;
    roles: string[];
    name: string;
    token:string;
}
export enum OrderStatus {
    Placed = 0,
    Preparing = 1,
    Ready = 2,
    Delivered = 3
  }