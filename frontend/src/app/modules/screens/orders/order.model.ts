class Order {
    public id?: number;
    public name: string;
    public description: string;
    public orderByUserId?: string;
    public orderBy?: OrderUser;
    public deliveryManUserId?: string;
    public deliveryMan?: OrderUser;
    public productPrice: number;
    public productLink: string;
    public productImage?: string;
    public finalPrice?: number;
    public reward: number;
    public count: number;

    public deliveryStatus?: DeliveryStatus;
}

enum DeliveryStatus {
    Open,
    Cancelled,
    CustomerConfirmed,
    DeliverymanConfirmed,
    Closed
}

class OrderUser {
    public id?: string;
    public firstName?: string;
    public secondName?: string;
}
