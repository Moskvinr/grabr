class Order {
    public id?: number;
    public name: string;
    public description: string;
    public orderByUserId?: string;
    public orderBy?: OrderByDto;
    public productPrice: number;
    public productLink: string;
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

class OrderByDto {
    public id?: string;
    public firstName?: string;
    public secondName?: string;
}
